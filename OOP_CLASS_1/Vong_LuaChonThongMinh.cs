using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class Vong_LuaChonThongMinh : VongChoi
    {
        public SanPhamList SanPhamList;
        public decimal bonusReward;
        //private List<SanPham> lichSuSanPham; // Lịch sử sản phẩm đã chọn
        // Tạo phương thức GetSanPhamList để trả về giá trị của thuộc tính SanPhamList

        public Vong_LuaChonThongMinh(SanPhamList sanPhamList, Player currentPlayer) : base("LuaChonThongMinh")
        {
            //// Khởi tạo lịch sử sản phẩm
            //lichSuSanPham = new List<SanPham>();
            SanPhamList = sanPhamList;
            // Sắp xếp các sản phẩm theo giá
            List<SanPham> sortedSanPhams = new List<SanPham>(SanPhamList.SanPhams); // Sao chép danh sách sản phẩm
            sortedSanPhams.Sort(CompareSanPhamByGiaSP);

            // Lấy ra tất cả các bộ 3 sản phẩm có giá cách nhau ít nhất 50
            List<List<SanPham>> allValidTriplets = GetFilteredSanPhams(sortedSanPhams);
            // Lấy ngẫu nhiên một bộ 3 sản phẩm từ tất cả các bộ 3 đã tìm được
            List<SanPham> randomTriplet = null;
            if (allValidTriplets.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, allValidTriplets.Count);
                randomTriplet = allValidTriplets[randomIndex];
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

            //// In ra danh sách sản phẩm đã lọc
            //for (int i = 0; i < SanPhamList.SanPhams.Count; i++)
            //{
            //    SanPham sp = GetSanPham(i);
            //    Console.WriteLine(sp.ToString());
            //}

            // Tính giá trị thưởng tối đa (tổng giá 3 sản phẩm)
            this.bonusReward = randomTriplet[0].GiaSP + randomTriplet[1].GiaSP + randomTriplet[2].GiaSP;
        }

        // Hàm swap để hoán đổi vị trí giữa hai phần tử trong một List
        public void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
        //// Phương thức hoán đổi hai phần tử trong danh sách
        //private void Swap(List<SanPham> list, int index1, int index2)
        //{
        //    SanPham temp = list[index1];
        //    list[index1] = list[index2];
        //    list[index2] = temp;
        //}
        // Phương thức so sánh dựa trên thuộc tính GiaSP
        public int CompareSanPhamByGiaSP(SanPham sp1, SanPham sp2)
        {
            return sp1.GiaSP.CompareTo(sp2.GiaSP);
        }

        // Phương pháp được sửa đổi để tìm tất cả các bộ ba hợp lệ có chênh lệch giá từ 1 đến 50
        public List<List<SanPham>> GetFilteredSanPhams(List<SanPham> sortedSanPhams)
        {
            List<List<SanPham>> allValidTriplets = new List<List<SanPham>>();

            for (int i = 0; i < sortedSanPhams.Count - 2; i++)
            {
                SanPham sanPham1 = sortedSanPhams[i];
                SanPham sanPham2 = sortedSanPhams[i + 1];
                SanPham sanPham3 = sortedSanPhams[i + 2];

                if (Math.Abs(sanPham1.GiaSP - sanPham2.GiaSP) <= 50 && Math.Abs(sanPham2.GiaSP - sanPham3.GiaSP) <= 50)
                {
                    List<SanPham> triplet = new List<SanPham>();
                    triplet.Add(sanPham1);
                    triplet.Add(sanPham2);
                    triplet.Add(sanPham3);
                    allValidTriplets.Add(triplet);
                }
            }

            return allValidTriplets;
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
            //// Lựa chọn sản phẩm
            //SanPham sanPhamChon;
            //do
            //{
            //    Console.WriteLine("Lựa chọn sản phẩm có giá cao nhất:");
            //    int sanPhamChonNumber = int.Parse(Console.ReadLine());
            //    sanPhamChon = SanPhamList.SanPhams[sanPhamChonNumber - 1];
            //} while (LichSuSanPham(sanPhamChon)); // Kiểm tra xem sản phẩm đã chọn có trong lịch sử không

            //// Thêm sản phẩm mới vào lịch sử
            //lichSuSanPham.Add(sanPhamChon);
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
                Console.WriteLine("Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + bonusReward);
                this.TienThuong += (int)bonusReward;
                Console.WriteLine("Tiền thưởng: " + this.TienThuong);
            }
            else
            {
                // In ra thông báo nếu lựa chọn không chính xác
                SanPham maxPriceSanPham = SanPhamList.SanPhams.Find(delegate (SanPham sp) { return sp.GiaSP == maxPrice; });
                Console.WriteLine("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + maxPriceSanPham.TenSP);
            }
        }
        // Phương thức kiểm tra xem một sản phẩm có trong lịch sử hay không
        //private bool LichSuSanPham(SanPham sanPham)
        //{
        //    return lichSuSanPham.Any(sp => sp.Equals(sanPham));
        //}
        // Phương thức giả lập lấy giá sản phẩm cao nhất
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
        //public SanPham GetSanPham(int index)
        //{
        //    // Kiểm tra xem chỉ mục có nằm trong phạm vi hợp lệ không
        //    if (index >= 0 && index < SanPhamList.SanPhams.Count)
        //    {
        //        // Nhận sản phẩm tại chỉ mục được chỉ định
        //        SanPham product = SanPhamList.SanPhams[index];

        //        // Trả lại sản phẩm
        //        return product;
        //    }
        //    else
        //    {
        //        // Nếu chỉ mục không hợp lệ, hãy ném ArgumentOutOfRangeException
        //        throw new ArgumentOutOfRangeException("index", "Invalid index provided.");
        //    }
        //}

    }
}
