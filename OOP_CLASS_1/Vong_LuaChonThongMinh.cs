using System;
using System.Collections.Generic;

namespace OOP_CLASS_1
{
    public class Vong_LuaChonThongMinh : VongChoi
    {
        public SanPhamList SanPhamList;
        public decimal TongTienThuong;

        public Vong_LuaChonThongMinh(SanPhamList sanPhamList) : base("LuaChonThongMinh")
        {
            SanPhamList = sanPhamList;
            // Sắp xếp danh sách sản phẩm theo giá tăng dần
            List<SanPham> sortedSanPhams = new List<SanPham>(SanPhamList.SanPhams);
            sortedSanPhams.Sort(SoSanhSPByGia);

            // Lọc các bộ ba sản phẩm có giá cận kề nhau
            List<List<SanPham>> TatCaBoBa = LocSanPham(sortedSanPhams);

            // Chọn ngẫu nhiên một bộ ba sản phẩm từ danh sách các bộ ba
            List<SanPham> randomTriplet = null;
            if (TatCaBoBa.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, TatCaBoBa.Count);
                randomTriplet = TatCaBoBa[randomIndex];
            }

            // Hoán đổi vị trí các sản phẩm trong bộ ba ngẫu nhiên
            if (randomTriplet != null)
            {
                Random random = new Random();
                int n = randomTriplet.Count;
                for (int i = 0; i < n; i++)
                {
                    int j = random.Next(i, n);
                    Swap<SanPham>(randomTriplet, i, j);
                }
            }

            // Cập nhật danh sách sản phẩm với bộ ba đã được chọn và xáo trộn
            SanPhamList.SanPhams = randomTriplet;
            // Tính tổng tiền thưởng dựa trên giá của các sản phẩm trong bộ ba
            this.TongTienThuong = randomTriplet[0].GiaSP + randomTriplet[1].GiaSP + randomTriplet[2].GiaSP;
        }

        // Hoán đổi vị trí hai phần tử trong danh sách
        private void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        // So sánh hai sản phẩm theo giá
        private int SoSanhSPByGia(SanPham sp1, SanPham sp2)
        {
            return sp1.GiaSP.CompareTo(sp2.GiaSP);
        }

        // Lọc các bộ ba sản phẩm có giá cận kề nhau
        private List<List<SanPham>> LocSanPham(List<SanPham> sortedSanPhams)
        {
            List<List<SanPham>> TatCaBoBa = new List<List<SanPham>>();
            for (int i = 0; i < sortedSanPhams.Count - 2; i++)
            {
                SanPham sanPham1 = sortedSanPhams[i];
                SanPham sanPham2 = sortedSanPhams[i + 1];
                SanPham sanPham3 = sortedSanPhams[i + 2];
                if (Math.Abs(sanPham1.GiaSP - sanPham2.GiaSP) <= 1000 && Math.Abs(sanPham2.GiaSP - sanPham3.GiaSP) <= 1000)
                {
                    List<SanPham> triplet = new List<SanPham>();
                    triplet.Add(sanPham1);
                    triplet.Add(sanPham2);
                    triplet.Add(sanPham3);
                    TatCaBoBa.Add(triplet);
                }
            }
            return TatCaBoBa;
        }

        public override void Play()
        {
            Console.WriteLine("Lựa chọn thông minh:");
            Console.WriteLine("Danh sách sản phẩm:");
            int i = 1;
            foreach (SanPham sp in SanPhamList.SanPhams)
            {
                Console.WriteLine(i + ". " + sp.TenSP + " - " + sp.Mota);
                i++;
            }
            Console.WriteLine("Lựa chọn sản phẩm có giá cao nhất:");
            int sanPhamChonNumber = int.Parse(Console.ReadLine());
            while (sanPhamChonNumber < 1 || sanPhamChonNumber > 3)
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại số từ 1 đến 3:");
                sanPhamChonNumber = int.Parse(Console.ReadLine());
            }
            SanPham sanPhamChon = SanPhamList.SanPhams[sanPhamChonNumber - 1];
            decimal maxPrice = GetMaxPrice();
            AmThanh amThanh = new AmThanh();
            if (sanPhamChon.GiaSP == maxPrice)
            {
                amThanh.PlayCorrectSound();
                Console.WriteLine("Chúc mừng! Bạn đã chọn đúng sản phẩm có giá cao nhất: " + sanPhamChon.TenSP);
                Console.WriteLine("Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + TongTienThuong);
                this.TienThuong += (int)TongTienThuong;
                Console.WriteLine("Tiền thưởng: " + this.TienThuong);
            }
            else
            {
                amThanh.PlayIncorrectSound();
                SanPham SPGiaCao = null;
                foreach (SanPham sp in SanPhamList.SanPhams)
                {
                    if (sp.GiaSP == maxPrice)
                    {
                        SPGiaCao = sp;
                        break;
                    }
                }
                Console.WriteLine("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + SPGiaCao.TenSP);
            }
        }

        private decimal GetMaxPrice()
        {
            decimal maxPrice = 0;
            foreach (SanPham sp in SanPhamList.SanPhams)
            {
                if (sp.GiaSP > maxPrice)
                {
                    maxPrice = sp.GiaSP;
                }
            }
            return maxPrice;
        }
    }
}
