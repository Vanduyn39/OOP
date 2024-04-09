using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class Vong_DemNguoc : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_DemNguoc(SanPhamList sanPhamList ) : base("Đếm Ngược")
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random random = new Random();
            int hangtrieu = random.Next(1, 9);
            int hangtramnghin = random.Next(1, 9);
            int hangchucnghin = random.Next(1, 9);
            int hangnghin = random.Next(1, 9);
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (var sanPham in SanPhamList.SanPhams)
            {
                if (sanPham.GiaSP >= 1000 && sanPham.GiaSP <= 9999)
                {
                    sanPhams.Add(sanPham);
                }
            }
            if (sanPhams.Count > 0)
            {
                // Chọn một sản phẩm ngẫu nhiên từ danh sách sản phẩm thỏa mãn điều kiện
                int index = random.Next(0, sanPhams.Count);
                SanPham sanPhamNgauNhien = sanPhams[index];
                Console.WriteLine($"Sản phẩm bạn cần đoán giá là: \nTên sản phẩm: {sanPhamNgauNhien.TenSP}\nMô tả sản phẩm: {sanPhamNgauNhien.Mota}");
                int a = (int)sanPhamNgauNhien.GiaSP / 1000;
                int b = ((int)sanPhamNgauNhien.GiaSP - a * 1000) / 100;
                int c = ((int)sanPhamNgauNhien.GiaSP - a * 1000 - b * 100) / 10;
                int d = (int)sanPhamNgauNhien.GiaSP - a * 1000 - b * 100 - c * 10;
                Console.WriteLine($"Giá sai của sản phẩm: {hangtrieu} - {hangtramnghin} - {hangchucnghin} - {hangnghin}");
                Console.WriteLine("Bạn hãy đoán giá của sản phẩm bằng cách lựa chọn lớn hơn hoặc nhỏ hơn (>/<)\n để so sánh từng đơn vị trong giá của sản phẩm lớn hơn hay nhỏ hơn giá sai mà chương trình đưa ra");
                int i = 0;
                while (true)
                {
                    Console.Write("Hàng triệu: ");
                    string ht = Console.ReadLine();
                    Console.Write("Hàng trăm nghìn: ");
                    string htn = Console.ReadLine();
                    Console.Write("Hàng chục nghìn: ");
                    string hcn = Console.ReadLine();
                    Console.Write("Hàng nghìn: ");
                    string hn = Console.ReadLine();
                    if ((a > hangtrieu && ht.Equals(">", StringComparison.OrdinalIgnoreCase)) || (a < hangtrieu && ht.Equals("<", StringComparison.OrdinalIgnoreCase)))
                    { i += 0; }
                    else
                    { i += 1; }
                    if ((b > hangtramnghin && htn.Equals(">", StringComparison.OrdinalIgnoreCase)) || (b < hangtramnghin && htn.Equals("<", StringComparison.OrdinalIgnoreCase)))
                    { i += 0; }
                    else
                    { i += 1; }
                    if ((c > hangchucnghin && hcn.Equals(">", StringComparison.OrdinalIgnoreCase)) || (c <hangchucnghin && hcn.Equals("<", StringComparison.OrdinalIgnoreCase)))
                    { i += 0; }
                    else
                    { i += 1; }
                    if ((d > hangnghin && hn.Equals(">", StringComparison.OrdinalIgnoreCase)) || (d <hangnghin && hn.Equals("<", StringComparison.OrdinalIgnoreCase)))
                    { i += 0; }
                    else
                    { i += 1; }
                    if (i == 0)
                    {
                        Console.WriteLine("Chúc mừng bạn đã vượt qua vòng Đếm Ngược!!!");
                       this.TienThuong=(int)sanPhamNgauNhien.GiaSP;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" Sai rồi, mời bạn chọn lại!!!");
                        this.TienThuong = 0;
                    }
                }
            }
        }
    }
}
