using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace designkhongmaco
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Khởi tạo và điền dữ liệu vào file JSON trước khi chạy ứng dụng
            CreateAndPopulateJsonFile();

            // Chạy Form1 trước
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void CreateAndPopulateJsonFile()
        {
            string filePathSanPham = "SanPham.json";
            List<SanPham> sanPhamList = new List<SanPham>();
            sanPhamList.Add(new SanPham { TenSP = "Máy lọc không khí Samsung AX32BG3100GBSV 41W ", GiaSP = 4695, Mota = "Phạm vi lọc hiệu quả: Phòng 41m²\nLượng gió thổi ra: 320 m³/h\nCông suất: 41W\nĐộ ồn cao nhất: 51 dB\nBộ lọc bụi cho máy: Màng lọc thô-Màng lọc than hoạt tính-Màng lọc bụi siêu mịn" });
            sanPhamList.Add(new SanPham { TenSP = "Máy giặt Panasonic 8.2 kg NA-F82Y01DRV", GiaSP = 5990, Mota = "Loại máy: Cửa trênLồng đứng\nKhối lượng giặt: 8.2 Kg\nChất liệu lồng giặt: Thép không gỉ\nKích thước - Khối lượng: Cao 95.2 cm - Ngang 55.4 cm - Sâu 58.2 cm - Nặng 34 kg" });
            sanPhamList.Add(new SanPham { TenSP = "AirPods Pro", GiaSP = 6199, Mota = "AirPods Pro (thế hệ thứ 2) với Hộp Sạc MagSafe (USB-C)" });
            sanPhamList.Add(new SanPham { TenSP = "Máy Lọc Nước Aqua", GiaSP = 5800, Mota = "Công nghệ lọc RO loạt bộ 99,9% tạp chất Tiết kiệm diện tích với thiết kế nhỏ gọn" });
            sanPhamList.Add(new SanPham { TenSP = "Smart Tivi LG 4K 65 inch 65UQ8000PSC", GiaSP = 6500, Mota = "Tivi có kích thước màn hình 65 inch dùng đẹp cho phòng khách lớn, phòng họp, sảnh chờ vừa và nhỏ Chân đế tivi chất liệu nhựa lõi kim loại chắc chắn và bền tốt, nâng đỡ an toàn cho màn hình " });
            sanPhamList.Add(new SanPham { TenSP = "MacBook Air 13 inch M2 2022 8CPU 8GPU 8GB/256GB", GiaSP = 7900, Mota = "MacBook Air M2 2022 còn chứa đựng nguồn sức mạnh lớn lao với chip M2 siêu mạnh, thời lượng pin chạm  ngưỡng 18 giờ, màn hình Liquid Retina tuyệt đẹp và hệ thống camera kết hợp cùng âm thanh tân tiến." });
            sanPhamList.Add(new SanPham { TenSP = "Tủ lạnh Samsung side by side Inverter 616 lít RS64T5F01B4/SV", GiaSP = 9999, Mota = "Dung tích sử dụng 616 lít phù hợp với gia đình có 5 - 7 thành viên.\r\n\r\nỨng dụng công nghệ SpaceMax giúp mở rộng không gian lưu trữ.\r\n\r\nCó thể kết nối với Bluetooth, điều khiển bằng giọng nói.\r\n\r\nỨng dụng Recipes tích hợp sẵn hàng trăm công thức nấu nướng.\r\n\r\nỨng dụng công nghệ Digital Inverter." });
            sanPhamList.Add(new SanPham { TenSP = "Điện thoại Apple iPhone 15 Pro Max 512GB VN/A", GiaSP = 8500, Mota = "Thiết kế sang trọng với 4 màu sắc,Cổng sạc USB-C 3 10Gbps, Hiển thị sắc nét, sống động,Bộ vi xử lý A17 Pro mạnh mẽ,Hệ thống camera sắc nét" });
            sanPhamList.Add(new SanPham { TenSP = "Laptop ASUS ROG Strix G16 G614JU-N3135W", GiaSP = 7500, Mota = "Laptop Asus ROG Strix G16 mang đến một thiết kế cực kỳ ấn tượng, đậm chất Gaming cho các game thủ chính hiệu. Với hiệu năng cực đỉnh cùng cấu hình máy mạnh mẽ, giúp bạn có thể trải nghiệm chơi game ấn tượng. Màn hình laptop Asus Gaming này sắc nét cho từng chi tiết được hiển thị một cách chân thật và sống động" });


            string json = JsonSerializer.Serialize(sanPhamList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePathSanPham, json);
        }
    }

    public class SanPham
    {
        public string TenSP { get; set; }
        public int GiaSP { get; set; }
        public string Mota { get; set; }
    }
}
