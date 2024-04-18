using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_CLASS_1
{
    public class Vong_KhongMaCo : VongChoi
    {
        private SanPhamList DanhSachSanPham;
        private List<int> CacChiSoSanPhamDaChon = new List<int>();
        private List<SanPham> SanPhamDaHienThiTruoc = new List<SanPham>();

        public Vong_KhongMaCo(SanPhamList danhSachSanPham) : base("Khong Ma Co")
        {
            DanhSachSanPham = danhSachSanPham;
        }

        public override void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int gia = TaoGiaNgauNhien();

            List<SanPham> sanPham = ChonSanPham();

            HienThiSanPham(sanPham);

            int[] cacSanPhamDaChon = ChonSanPhamCuaNguoiDung(sanPham);

            CapNhatCacSanPhamDaChon(cacSanPhamDaChon);

            HienThiSanPhamDaChonVaDung(cacSanPhamDaChon, sanPham, gia);
        }

        private int TaoGiaNgauNhien()
        {
            Random random = new Random();
            return random.Next(55, 76) * 100;
        }

        private List<SanPham> ChonSanPham()
        {
            List<SanPham> sanPham = new List<SanPham>();
            foreach (SanPham sp in DanhSachSanPham.SanPhams)
            {
                bool daChon = false;
                for (int i = 0; i < CacChiSoSanPhamDaChon.Count; i++)
                {
                    if (CacChiSoSanPhamDaChon[i] == sanPham.Count)
                    {
                        daChon = true;
                        break;
                    }
                }
                if (!daChon)
                    sanPham.Add(sp);

                if (sanPham.Count >= 6)
                    break;
            }
            return sanPham;
        }

        private void HienThiSanPham(List<SanPham> sanPham)
        {
            Console.WriteLine("Xin chào! Hãy chọn 4 sản phẩm:");
            Console.WriteLine();

            List<SanPham> sanPhamHienThi = (SanPhamDaHienThiTruoc.Count > 0) ? SanPhamDaHienThiTruoc : sanPham;

            for (int i = 0; i < sanPhamHienThi.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, sanPhamHienThi[i].TenSP);
            }
        }

        private int[] ChonSanPhamCuaNguoiDung(List<SanPham> sanPham)
        {
            int dem = 0;
            int[] cacSanPhamDaChon = new int[4];
            while (dem < 4)
            {
                Console.Write("Chọn sản phẩm thứ {0}: ", dem + 1);
                int luaChon;
                if (int.TryParse(Console.ReadLine(), out luaChon) && luaChon >= 1 && luaChon <= sanPham.Count)
                {
                    bool daChonTruoc = false;
                    for (int i = 0; i < dem; i++)
                    {
                        if (cacSanPhamDaChon[i] == luaChon)
                        {
                            daChonTruoc = true;
                            break;
                        }
                    }

                    if (!daChonTruoc)
                    {
                        cacSanPhamDaChon[dem] = luaChon;
                        dem++;
                    }
                    else
                    {
                        Console.WriteLine("Sản phẩm này đã được chọn trước đó. Hãy chọn sản phẩm khác!");
                    }
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Hãy chọn lại!");
                }
            }
            return cacSanPhamDaChon;
        }

        private void CapNhatCacSanPhamDaChon(int[] cacSanPhamDaChon)
        {
            CacChiSoSanPhamDaChon.AddRange(cacSanPhamDaChon);
        }

        private void HienThiSanPhamDaChonVaDung(int[] cacSanPhamDaChon, List<SanPham> sanPham, int gia)
        {
            Console.WriteLine();
            Console.WriteLine("Các sản phẩm bạn đã chọn và đoán đúng:");
            decimal tongThuong = 0;
            int soLuongDung = 0;
            foreach (int luaChon in cacSanPhamDaChon)
            {
                int chiSo = luaChon;
                if (chiSo > 0 && chiSo <= sanPham.Count && sanPham[chiSo - 1].GiaSP < gia)
                {
                    Console.WriteLine("{0} - Giá: {1}", sanPham[chiSo - 1].TenSP, sanPham[chiSo - 1].GiaSP);
                    tongThuong += sanPham[chiSo - 1].GiaSP;
                    soLuongDung++;
                }
            }

            if (soLuongDung <= 2)
            {
                Console.WriteLine("Bạn đã đoán đúng dưới 2 sản phẩm, xin mời đoán lại!");
                Console.ReadKey();
                SanPhamDaHienThiTruoc = sanPham;
                Play();
                return;
            }

            Console.WriteLine("Tiền thưởng của vòng hiện tại: {0}", tongThuong);
            Console.ReadKey();
        }
    }
}
