using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Class_OOP;
using OOP_Class;

namespace Class_OOP
{

    class Program
    {
        //Phương thức ghi  file Player
        public static void WriteFile(string filePathPlayer, PlayerList list)
        {
            try
            {
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePathPlayer, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //Phương thức đọc  file Player

        public static PlayerList ReadFile(string filePathPlayer)
        {
            try
            {
                if (File.Exists(filePathPlayer))
                {
                    string FileRead = File.ReadAllText(filePathPlayer);
                    PlayerList list = JsonSerializer.Deserialize<PlayerList>(FileRead);
                    return list;
                }
                else
                {
                    return new PlayerList(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
        //static string[] ReadDataFromFile(string filePath)
        //{
        //    // Bước 1: Mở tệp để đọc dữ liệu
        //    string[] lines = File.ReadAllLines(filePath);

        //    // Bước 2: Khai báo một mảng
        //    string[] array = new string[lines.Length];

        //    // Bước 3: Thêm dữ liệu vào mảng
        //    Array.Copy(lines, array, lines.Length);

        //    // Trả về mảng chứa dữ liệu
        //    return array;
        //}
        //public static void WriteDataToFile(string filePath, string[] data)
        //{
        //    using (StreamWriter writer = new StreamWriter(filePath))
        //    {
        //        foreach (string line in data)
        //        {
        //            writer.WriteLine(line);
        //        }
        //    }
        //}
        static void Main(string[] args)
        {
            //Player.CompareTienThuong compareTienThuong = new Player.CompareTienThuong(Player.CompareByTienThuong);
            Console.OutputEncoding = Encoding.UTF8;
            //Danh sách sản phẩm 
            string filePathSanPham = "SanPham.json";
            SanPhamList sanPhamList = new SanPhamList();
            sanPhamList.Add(new SanPham { TenSP = "Máy lọc không khí Samsung AX32BG3100GBSV 41W ", GiaSP = 4695, Mota = "Phạm vi lọc hiệu quả: Phòng 41m²\nLượng gió thổi ra: 320 m³/h\nCông suất: 41W\nĐộ ồn cao nhất: 51 dB\nBộ lọc bụi cho máy: Màng lọc thô-Màng lọc than hoạt tính-Màng lọc bụi siêu mịn" });
            sanPhamList.Add(new SanPham { TenSP = "Máy giặt Panasonic 8.2 kg NA-F82Y01DRV", GiaSP = 5990, Mota = "Loại máy: Cửa trênLồng đứng\nKhối lượng giặt: 8.2 Kg\nChất liệu lồng giặt: Thép không gỉ\nKích thước - Khối lượng: Cao 95.2 cm - Ngang 55.4 cm - Sâu 58.2 cm - Nặng 34 kg" });
            sanPhamList.Add(new SanPham { TenSP = "AirPods Pro", GiaSP = 6199, Mota = "AirPods Pro (thế hệ thứ 2) với Hộp Sạc MagSafe (USB-C)" });
            string json = JsonSerializer.Serialize(sanPhamList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePathSanPham, json);
            string jsonFromFile = File.ReadAllText(filePathSanPham);
            SanPhamList deserializedSanPhamList = JsonSerializer.Deserialize<SanPhamList>(json);
            //Thêm dữ liệu từ file vào mãng 
            //PlayerList playerList = ReadFile("Player.txt");
            //Player[] array = new Player[];
            //string[] array = ReadDataFromFile("Player.txt");
            //Tạo 1 file mới 
            string filePathPlayer = "Player.json";
            PlayerList playerList = new PlayerList();
            WriteFile(filePathPlayer, playerList);

            //Thêm dữ liệu từ mãng vào file
            //WriteDataToFile(filePathPlayer, array);
            DieuKhien dieuKhien = new DieuKhien(filePathPlayer);
            dieuKhien.AddVongChoi(new Vong_DemNguoc(200,sanPhamList));
            dieuKhien.AddVongChoi(new Vong_KhongMaCo(300, sanPhamList));
            dieuKhien.AddVongChoi(new Vong_BanTayVang(400, sanPhamList));
            dieuKhien.AddVongChoi(new Vong_LuaChonThongMinh(500, sanPhamList));
            //Tạo danh sách Player
            //Player.Sort(array, compareTienThuong);
            //WriteFile(filePathPlayer, playerList);
            PlayerList FileRead = ReadFile(filePathPlayer);
            Console.WriteLine("Bạn có muốn tham gia chơi không? (y/n)");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    dieuKhien.StartGame(playerList);
                    Console.WriteLine("Bạn có muốn chơi lại không? (y/n)");
                    string playAgain = Console.ReadLine();
                    if (!playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                        break;
                }
                else
                    break;
            }
            WriteFile(filePathPlayer, playerList);//Thêm người chơi mới
            PlayerList newData = ReadFile(filePathPlayer);

            Console.ReadLine();

        }
    }
}
