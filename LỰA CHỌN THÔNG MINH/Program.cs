using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vòng_4
{
    internal static class Program
    {
        // Khai báo biến toàn cục
        public static SanPhamList sanPhamList;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Khởi tạo danh sách sản phẩm
            //sanPhamList = new SanPhamList();

            // Thêm sản phẩm vào danh sách ở đây...
            //Console.OutputEncoding = Encoding.UTF8;
            //Danh sách sản phẩm 
            string filePathSanPham = "SanPham.json";
            SanPhamList sanPhamList = new SanPhamList();

            sanPhamList.Add(new SanPham { TenSP = "Máy lọc không khí Samsung AX32BG3100GBSV 41W ", GiaSP = 4695, Mota = "Phạm vi lọc hiệu quả: Phòng 41m²\nLượng gió thổi ra: 320 m³/h\nCông suất: 41W\nĐộ ồn cao nhất: 51 dB\nBộ lọc bụi cho máy: Màng lọc thô-Màng lọc than hoạt tính-Màng lọc bụi siêu mịn" });
            sanPhamList.Add(new SanPham { TenSP = "Máy giặt Panasonic 8.2 kg NA-F82Y01DRV", GiaSP = 5990, Mota = "Loại máy: Cửa trênLồng đứng\nKhối lượng giặt: 8.2 Kg\nChất liệu lồng giặt: Thép không gỉ\nKích thước - Khối lượng: Cao 95.2 cm - Ngang 55.4 cm - Sâu 58.2 cm - Nặng 34 kg" });
            sanPhamList.Add(new SanPham { TenSP = "AirPods Pro", GiaSP = 6199, Mota = "AirPods Pro (thế hệ thứ 2) với Hộp Sạc MagSafe (USB-C)" });
            sanPhamList.Add(new SanPham { TenSP = "Máy Lọc Nước Aqua", GiaSP = 5800, Mota = "Công nghệ lọc RO loạt bộ 99,9% tạp chất Tiết kiệm diện tích với thiết kế nhỏ gọn" });
            sanPhamList.Add(new SanPham { TenSP = "Smart Tivi LG 4K 65 inch 65UQ8000PSC", GiaSP = 6500, Mota = "Tivi có kích thước màn hình 65 inch dùng đẹp cho phòng khách lớn, phòng họp, sảnh chờ vừa và nhỏ Chân đế tivi chất liệu nhựa lõi kim loại chắc chắn và bền tốt, nâng đỡ an toàn cho màn hình " });
            sanPhamList.Add(new SanPham { TenSP = "MacBook Air 13 inch M2 2022 8CPU 8GPU 8GB/256GB", GiaSP = 7900, Mota = "MacBook Air M2 2022 còn chứa đựng nguồn sức mạnh lớn lao với chip M2 siêu mạnh, thời lượng pin chạm  ngưỡng 18 giờ, màn hình Liquid Retina tuyệt đẹp và hệ thống camera kết hợp cùng âm thanh tân tiến." });
            sanPhamList.Add(new SanPham { TenSP = "Tủ lạnh Samsung side by side Inverter 616 lít RS64T5F01B4/SV", GiaSP = 9999, Mota = "Dung tích sử dụng 616 lít phù hợp với gia đình có 5 - 7 thành viên.\r\n\r\nỨng dụng công nghệ SpaceMax giúp mở rộng không gian lưu trữ.\r\n\r\nCó thể kết nối với Bluetooth, điều khiển bằng giọng nói." });
            sanPhamList.Add(new SanPham { TenSP = "Điện thoại Apple iPhone 15 Pro Max 512GB VN/A", GiaSP = 8500, Mota = "Thiết kế sang trọng với 4 màu sắc,Cổng sạc USB-C 3 10Gbps, Hiển thị sắc nét, sống động,Bộ vi xử lý A17 Pro mạnh mẽ,Hệ thống camera sắc nét" });
            sanPhamList.Add(new SanPham { TenSP = "Laptop ASUS ROG Strix G16 G614JU-N3135W", GiaSP = 7500, Mota = "Laptop Asus ROG Strix G16 mang đến một thiết kế cực kỳ ấn tượng, đậm chất Gaming cho các game thủ chính hiệu. Với hiệu năng cực đỉnh cùng cấu hình máy mạnh mẽ, giúp bạn có thể trải nghiệm chơi game ấn tượng. Màn hình laptop Asus Gaming này sắc nét cho từng chi tiết." });
            sanPhamList.Add(new SanPham { TenSP = "Tivi Samsung 43 inch", GiaSP = 1000, Mota = "Trải nghiệm hình ảnh sống động: Tận hưởng hình ảnh sắc nét, sống động với độ phân giải cao và công nghệ HDR tiên tiến.\r\nÂm thanh mạnh mẽ: Mang đến âm thanh vòm ấn tượng, cho bạn đắm chìm trong thế giới giải trí.\r\nThiết kế hiện đại: Màn hình tràn viền, mang đến trải nghiệm xem rộng rãi và sang trọng.\r\nHệ điều hành thông minh: Tích hợp nhiều ứng dụng giải trí phổ biến, dễ dàng truy cập và sử dụng.\r\nKết nối đa dạng: Hỗ trợ nhiều cổng kết nối, cho phép bạn kết nối với nhiều thiết bị khác nhau." });
            sanPhamList.Add(new SanPham { TenSP = "Điện thoại iPhone 14 Pro Max", GiaSP = 1010, Mota = "Hiệu năng mạnh mẽ: Chip xử lý A16 Bionic mạnh mẽ, cho phép bạn xử lý mọi tác vụ một cách mượt mà.\r\nHệ thống camera ấn tượng: Chụp ảnh và quay phim sắc nét với camera sau 48MP và camera trước 12MP.\r\nMàn hình Super Retina XDR: Màn hình OLED sắc nét, sống động với độ sáng cao và màu sắc rực rỡ.\r\nThiết kế sang trọng: Khung thép không gỉ cao cấp, mặt kính cường lực Ceramic Shield bền bỉ.\r\nThời lượng pin dài: Sử dụng cả ngày dài mà không lo hết pin." });
            sanPhamList.Add(new SanPham { TenSP = "Laptop Dell XPS 13", GiaSP = 1012, Mota = "Thiết kế mỏng nhẹ: Dễ dàng mang theo bên mình mọi lúc mọi nơi.\r\nHiệu năng cao: Mạnh mẽ với chip xử lý Intel Core thế hệ mới nhất.\r\nMàn hình InfinityEdge: Viền màn hình siêu mỏng, cho bạn trải nghiệm hình ảnh rộng rãi.\r\nBàn phím và touchpad cao cấp: Mang đến trải nghiệm gõ phím và sử dụng chuột thoải mái.\r\nThời lượng pin dài: Sử dụng cả ngày dài mà không lo hết pin." });
            sanPhamList.Add(new SanPham { TenSP = "Máy giặt Samsung 8kg", GiaSP = 1032, Mota = "Giặt sạch hiệu quả: Công nghệ giặt EcoBubble đánh tan vết bẩn hiệu quả, bảo vệ quần áo.\r\nTiết kiệm điện và nước: Chế độ giặt tiết kiệm giúp bạn tiết kiệm điện và nước.\r\nGiặt êm ái: Giảm tiếng ồn tối đa, mang đến sự yên tĩnh cho ngôi nhà bạn.\r\nNhiều chương trình giặt: Đáp ứng đa dạng nhu cầu giặt giũ của bạn.\r\nThiết kế hiện đại: Sang trọng và tiện nghi." });
            sanPhamList.Add(new SanPham { TenSP = "Tủ lạnh Panasonic 2 cánh", GiaSP = 3000, Mota = "Dung tích lớn: Đáp ứng nhu cầu lưu trữ thực phẩm cho gia đình bạn.\r\nCông nghệ bảo quản thực phẩm tiên tiến: Giữ thực phẩm tươi ngon lâu hơn.\r\nTiết kiệm điện: Chế độ tiết kiệm điện giúp bạn tiết kiệm chi phí tiền điện.\r\nThiết kế hiện đại: Sang trọng và tiện nghi.\r\nĐộ ồn thấp: Hoạt động êm ái, không gây tiếng ồn." });
            sanPhamList.Add(new SanPham { TenSP = "Máy lọc nước Kangaroo", GiaSP = 3030, Mota = "Loại bỏ tạp chất: Loại bỏ các tạp chất, vi khuẩn, kim loại nặng trong nước.\r\nCung cấp nước sạch: Mang đến cho bạn nguồn nước sạch để uống và sinh hoạt.\r\nThiết kế nhỏ gọn: Dễ dàng lắp đặt và sử dụng.\r\nTiết kiệm chi phí: Tiết kiệm chi phí mua nước đóng chai.\r\nAn toàn cho sức khỏe: Đảm bảo sức khỏe cho gia đình bạn." });
            sanPhamList.Add(new SanPham { TenSP = "Máy sấy tóc Philips", GiaSP = 4000, Mota = "Sấy tóc nhanh khô: Công suất lớn giúp bạn sấy tóc nhanh khô.\r\nChăm sóc tóc chuyên nghiệp: Chế độ sấy mát, sấy ion giúp bảo vệ tóc khỏi hư tổn.\r\nThiết kế tiện dụng: Dễ dàng sử dụng và cất giữ.\r\nAn toàn khi sử dụng: Tự động ngắt khi quá nhiệt.\r\nKiểu dáng hiện đại: Sang trọng và thời trang." });
            sanPhamList.Add(new SanPham { TenSP = "Bàn ủi hơi nước Tefal", GiaSP = 4060, Mota = "Ủi nhanh phẳng phiu: Hơi nước mạnh mẽ giúp ủi nhanh phẳng phiu mọi loại quần áo.\r\nChăm sóc quần áo chuyên nghiệp: Chế độ ủi hơi, ủi khô, ủi đứng đáp ứng đa dạng nhu cầu ủi đồ.\r\nTiết kiệm thời gian: Ủi nhanh hơn so với bàn ủi thông thường.\r\nAn toàn khi sử dụng: Tự động ngắt khi không sử dụng.\r\nThiết kế hiện đại: Sang trọng và tiện nghi." });
            sanPhamList.Add(new SanPham { TenSP = "Nồi cơm điện Sharp", GiaSP = 5000, Mota = "Nấu cơm ngon: Nấu cơm chín đều, dẻo thơm với công nghệ nấu hiện đại.\r\nGiữ ấm lâu: Giữ cơm ấm nóng trong nhiều giờ.\r\nDễ sử dụng: Bảng điều khiển đơn giản, dễ dàng sử dụng.\r\nThiết kế hiện đại: Sang trọng và tiện nghi.\r\nAn toàn khi sử dụng: Vỏ nồi được làm bằng chất liệu an toàn cho sức khỏe." });
            sanPhamList.Add(new SanPham { TenSP = "Máy xay sinh tố BlueStone", GiaSP = 5070, Mota = "Xay nhuyễn nhanh chóng: Xay nhuyễn mọi loại thực phẩm một cách nhanh chóng và hiệu quả.\r\nĐa chức năng: Xay sinh tố, xay smoothie, xay cháo, xay đồ khô,...\r\nDễ sử dụng: Cốc xay và lưỡi dao dễ dàng tháo lắp và vệ sinh.\r\nThiết kế hiện đại: Sang trọng và tiện nghi.\r\nAn toàn khi sử dụng: Cốc xay được làm bằng chất liệu chịu lực cao, lưỡi dao được làm bằng thép không gỉ." });
            sanPhamList.Add(new SanPham { TenSP = "Bộ chén dĩa Bát Tràng", GiaSP = 400, Mota = "Truyền thống và hiện đại: Nổi tiếng với nét đẹp truyền thống kết hợp với thiết kế hiện đại, sang trọng.\r\nChất liệu cao cấp: Làm từ đất sét cao cấp, nung trong lò nung củi truyền thống, đảm bảo an toàn cho sức khỏe.\r\nBền đẹp: Chịu được nhiệt độ cao, không bị nứt vỡ, sứt mẻ trong quá trình sử dụng.\r\nĐa dạng mẫu mã: Phù hợp với mọi nhu cầu sử dụng, từ ăn uống hàng ngày đến đãi khách.\r\nMang đến sự tinh tế cho không gian bếp: Góp phần tạo nên sự sang trọng và ấm cúng cho ngôi nhà bạn." });
            sanPhamList.Add(new SanPham { TenSP = "Bộ nồi inox Sunhouse", GiaSP = 600, Mota = "Chất liệu cao cấp: Làm từ inox 304 cao cấp, bền bỉ, sáng bóng, an toàn cho sức khỏe.\r\nDẫn nhiệt tốt: Nấu nướng nhanh chín, tiết kiệm thời gian và năng lượng.\r\nDễ dàng vệ sinh: Vết bẩn bám dính dễ dàng được lau chùi, không bị ám màu theo thời gian.\r\nThiết kế hiện đại: Sang trọng và tiện nghi, phù hợp với mọi không gian bếp.\r\nĐa dạng mẫu mã: Phù hợp với nhu cầu nấu nướng của mọi gia đình." });
            sanPhamList.Add(new SanPham { TenSP = "Chảo chống dính Tefal", GiaSP = 450, Mota = "Công nghệ chống dính tiên tiến: Chống dính hoàn hảo, thức ăn không bám dính, dễ dàng vệ sinh.\r\nBền bỉ: Chịu được nhiệt độ cao, không bị trầy xước trong quá trình sử dụng.\r\nAn toàn cho sức khỏe: Không chứa PFOA, PTFE, chì, an toàn cho sức khỏe.\r\nDẫn nhiệt tốt: Nấu nướng nhanh chín, tiết kiệm thời gian và năng lượng.\r\nĐa dạng mẫu mã: Phù hợp với mọi nhu cầu nấu nướng." });
            sanPhamList.Add(new SanPham { TenSP = "Bình thủy tinh Lock&Lock", GiaSP = 500, Mota = "Chất liệu cao cấp: Làm từ thủy tinh borosilicate cao cấp, chịu nhiệt tốt, an toàn cho sức khỏe.\r\nGiữ nhiệt lâu: Giữ nước nóng hoặc lạnh trong nhiều giờ.\r\nThiết kế tiện dụng: Nắp bình có quai cầm, dễ dàng rót nước.\r\nDễ dàng vệ sinh: Có thể tháo rời các bộ phận để vệ sinh sau khi sử dụng.\r\nAn toàn cho máy rửa chén: Tiết kiệm thời gian và công sức vệ sinh." });
            sanPhamList.Add(new SanPham { TenSP = "Bình giữ nhiệt Thermos", GiaSP = 550, Mota = "Giữ nhiệt và giữ lạnh hiệu quả: Giữ nước nóng hoặc lạnh trong nhiều giờ.\r\nThiết kế tiện dụng: Kích thước nhỏ gọn, dễ dàng mang theo bên mình.\r\nAn toàn khi sử dụng: Vỏ bình được làm bằng thép không gỉ, ruột bình được làm bằng nhựa cao cấp, an toàn cho sức khỏe.\r\nMẫu mã đa dạng: Phù hợp với mọi nhu cầu sử dụng.\r\nTiện lợi: Dùng để đựng nước nóng, cà phê, trà, nước ép trái cây,..." });
            sanPhamList.Add(new SanPham { TenSP = "Bộ dao thớt Zwilling", GiaSP = 650, Mota = "Chất liệu cao cấp: Dao được làm từ thép không gỉ cao cấp, thớt được làm từ gỗ tự nhiên, bền bỉ và an toàn cho sức khỏe.\r\nĐộ sắc bén cao: Dao sắc bén, dễ dàng cắt thái thực phẩm.\r\nThiết kế tiện dụng: Dao có tay cầm chống trượt, thớt có rãnh chống tràn.\r\nDễ dàng vệ sinh: Dao và thớt có thể được rửa sạch bằng tay hoặc máy rửa chén.\r\nĐa dạng mẫu mã: Phù hợp với mọi nhu cầu sử dụng." });

            string json = JsonSerializer.Serialize(sanPhamList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePathSanPham, json);
            string jsonFromFile = File.ReadAllText(filePathSanPham);
            SanPhamList deserializedSanPhamList = JsonSerializer.Deserialize<SanPhamList>(json);
            // Khởi tạo và hiển thị Form1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(sanPhamList));
        }
    }
}
