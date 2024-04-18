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
            // Sắp xếp các sản phẩm theo giá
            List<SanPham> sortedSanPhams = new List<SanPham>(SanPhamList.SanPhams); // Sao chép danh sách sản phẩm
            sortedSanPhams.Sort(SoSanhSPByGia);

            // Lấy ra tất cả các bộ 3 sản phẩm có giá cách nhau nhiều nhất là 1.000.000
            List<List<SanPham>> TatCaBoBa = LocSanPham(sortedSanPhams);
            // Lấy ngẫu nhiên một bộ 3 sản phẩm từ tất cả các bộ 3 đã tìm được
            List<SanPham> randomTriplet = null;
            if (TatCaBoBa.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, TatCaBoBa.Count);
                randomTriplet = TatCaBoBa[randomIndex];
            }

            // Đảo ngược thứ tự của các sản phẩm trong bộ 3
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
            // Lưu danh sách sản phẩm đã lọc
            SanPhamList.SanPhams = randomTriplet;

            // Tính giá trị thưởng tối đa (tổng giá 3 sản phẩm)
            this.TongTienThuong = randomTriplet[0].GiaSP + randomTriplet[1].GiaSP + randomTriplet[2].GiaSP;
        }

        // Hàm swap để hoán đổi vị trí giữa hai phần tử trong một List
        public void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
        // Phương thức so sánh dựa trên thuộc tính GiaSP
        public int SoSanhSPByGia(SanPham sp1, SanPham sp2)
        {
            return sp1.GiaSP.CompareTo(sp2.GiaSP);
        }

        // Phương pháp được sửa đổi để tìm tất cả các bộ ba hợp lệ có chênh lệch giá từ 1 đến 50
        public List<List<SanPham>> LocSanPham(List<SanPham> sortedSanPhams)
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
            // In ra danh sách sản phẩm
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

            // Kiểm tra lựa chọn của người chơi
            if (sanPhamChon.GiaSP == maxPrice)
            {
                Console.WriteLine("Chúc mừng! Bạn đã chọn đúng sản phẩm có giá cao nhất: " + sanPhamChon.TenSP);
                Console.WriteLine("Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + TongTienThuong);
                this.TienThuong += (int)TongTienThuong;
                Console.WriteLine("Tiền thưởng: " + this.TienThuong);
            }
            else
            {
                // In ra thông báo nếu lựa chọn không chính xác
                SanPham maxPriceSanPham = null;
                foreach (SanPham sp in SanPhamList.SanPhams)
                {
                    if (sp.GiaSP == maxPrice)
                    {
                        maxPriceSanPham = sp;
                        break;
                    }
                }
                Console.WriteLine("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + maxPriceSanPham.TenSP);
            }
        }
        public decimal GetMaxPrice()
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
