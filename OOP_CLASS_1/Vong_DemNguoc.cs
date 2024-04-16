using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class Vong_DemNguoc : VongChoi
    {
        private SanPhamList SanPhamList;
        private SanPham sanpham;
        private Random random = new Random();
        private int[] giasai = new int[4];
        public TextBox textBox1;
        private int j;
        public Vong_DemNguoc(SanPhamList sanPhamList) : base("Đếm Ngược")
        {
            SanPhamList = sanPhamList;
        }
        public void HienGiaSai(int[] giasai)
        {
            for (int i = 0; i < 4; i++)
            {
                giasai[i] = random.Next(1, 9);
            }
            Console.WriteLine($"Giá sai của sản phẩm: {giasai[0]} - {giasai[1]} - {giasai[2]} - {giasai[3]}");
        }
        private void DemNguocTime()
        {
            int i;
            for (i = 60; i >= 0; i--)
            {
                Thread.Sleep(1000);
                if (i == 0)
                {
                    Console.Write("\nĐã hết thời gian.Vui lòng nhấn Enter 4 lần để kết thúc vòng chơi. \nChúc bạn may mắn làn sau !!!");
                    TienThuong = 0;
                    return;
                }
            }
        }
        private bool Kiemtra(int[] giasai, int[] giatri)
        {
            AmThanh amThanh= new AmThanh();
            Thread demnguoc = new Thread(DemNguocTime);
            demnguoc.Start();
            while (!demnguoc.Join(0))
            {
                string[] doangia = new string[4];
                Console.Write("Hàng triệu: ");
                doangia[0] = Console.ReadLine();
                Console.Write("Hàng trăm nghìn: ");
                doangia[1] = Console.ReadLine();
                Console.Write("Hàng chục nghìn: ");
                doangia[2] = Console.ReadLine();
                Console.Write("Hàng nghìn: ");
                doangia[3] = Console.ReadLine();
                j = 0;
                for (int i = 0; i < 4; i++)
                {
                    if ((giatri[i] >= giasai[i] && doangia[i].Equals(">", StringComparison.OrdinalIgnoreCase)) || (giatri[i] < giasai[i] && doangia[i].Equals("<", StringComparison.OrdinalIgnoreCase)))
                    { j += 0; }
                    else
                    { j += 1; }
                }
                if (j != 0)
                {
                    Console.WriteLine(" Sai rồi, mời bạn chọn lại!!!");
                    this.TienThuong = 0;
                    amThanh.PlayIncorrectSound();
                }
                else
                {
                    Console.WriteLine(" Chúc mừng bạn đã vượt qua vòng Đếm Ngược!!!");
                    amThanh.PlayCorrectSound();
                    return true;
                    break;
                }
            }
            return false;
        }
        public override void Play(TextBox textBox1)
        {
            textBox1=textBox1;
            Console.OutputEncoding = Encoding.UTF8;
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (SanPham sanPham in SanPhamList.SanPhams)
            {
                if (sanPham.GiaSP >= 1000 && sanPham.GiaSP <= 9999)
                {
                    sanPhams.Add(sanPham);
                }
            }
            if (sanPhams.Count > 0)
            {
                Console.WriteLine("Bạn hãy đoán giá của sản phẩm bằng cách lựa chọn lớn hơn hoặc nhỏ hơn (>/<)\n để so sánh từng đơn vị trong giá của sản phẩm lớn hơn hay nhỏ hơn giá sai mà chương trình đưa ra");
                // Chọn một sản phẩm ngẫu nhiên từ danh sách sản phẩm thỏa mãn điều kiện
                int index = random.Next(0, sanPhams.Count);
                 sanPhamNgauNhien = sanPhams[index];
                textBox1.Text=sanPhamNgauNhien.TenSP.ToString();
                Console.WriteLine($"Sản phẩm bạn cần đoán giá là: \nTên sản phẩm: {sanPhamNgauNhien.TenSP}\nMô tả sản phẩm: {sanPhamNgauNhien.Mota}");
                int a = (int)sanPhamNgauNhien.GiaSP / 1000;
                int b = ((int)sanPhamNgauNhien.GiaSP - a * 1000) / 100;
                int c = ((int)sanPhamNgauNhien.GiaSP - a * 1000 - b * 100) / 10;
                int d = (int)sanPhamNgauNhien.GiaSP - a * 1000 - b * 100 - c * 10;
                int[] giatri = { a, b, c, d };
                HienGiaSai(giasai);
                if (Kiemtra(giasai, giatri))
                {
                    this.TienThuong = (int)sanPhamNgauNhien.GiaSP;
                }
                else { this.TienThuong = 0; }
            }
        }
    }
}
