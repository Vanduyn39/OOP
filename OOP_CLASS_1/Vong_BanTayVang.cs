using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class Vong_BanTayVang : VongChoi
    {
        public SanPhamList SanPhamList;
        public Random random = new Random();
        public int displayedProducts = 0;
        public int correctGuesses = 0; // Số lượng sản phẩm được đoán đúng
        public decimal correctPrice;       
        public decimal hiddenPrice;
        public SanPham SanPham;
        public int totalPrizeMoney = 0;
        public Vong_BanTayVang(SanPhamList sanPhamList) : base("Ban Tay Vang")
        {
            SanPhamList = sanPhamList;
            
        }

        public override void Play()
        {
            Console.WriteLine($"Chào mừng bạn đến vòng chơi '{TenVongChoi}'!");

            int randomIndex = random.Next(SanPhamList.SanPhams.Count);

            foreach (SanPham sanPham in SanPhamList.SanPhams)
            {
                if (displayedProducts >= 4) // Kiểm tra số lượng sản phẩm đã hiển thị
                    break;
                for (int i = 0; i < 4; i++)
                {
                    
                    int numberOfProducts = random.Next(1, 10); // Số lượng sản phẩm từ 1 đến 10
                    SanPham = SanPhamList.SanPhams[randomIndex];
                    correctPrice = sanPham.GiaSP * numberOfProducts;
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine($"Có {numberOfProducts} sản phẩm được trưng bày cho bạn.");

                    if (hiddenPrice != correctPrice)
                    {
                        
                        hiddenPrice = Math.Round(random.Next(100, 9000) * 1m / 100) * 100;
                        Console.WriteLine($"Sản phẩm: {sanPham.TenSP}");
                        Console.WriteLine($"Mô tả: {sanPham.Mota}");
                        Console.WriteLine($"Giá đưa ra: {hiddenPrice}");
                        Console.Write("Đoán giá cao hơn (h) hay thấp hơn (l) giá đưa ra: ");
                        string guess = Console.ReadLine();
                        Guess(guess, sanPham);
                        displayedProducts++; // Tăng số lượng sản phẩm đã hiển thị
                    }
                }
            }


            // Đấm ô và nhận thưởng
            Console.WriteLine("---------------_-_-----------------");
            Console.WriteLine("Bắt đầu đấm ô...");
            Console.WriteLine($"Bạn có {correctGuesses} lượt đấm.");
            int punchCount = correctGuesses; // Số lượt đấm
            List<int> prizeValues = new List<int> { 15000, 15000, 5000, 5000, 5000, 1000, 1000, 1000, 1000, 1000, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            List<int> chosenPrizes = new List<int>(); // Lưu giữ giải thưởng đã chọn
            List<int> bonusPunches = new List<int>(); // Lưu giữ ô có thêm lượt đấm

            // Random 2 ô có thêm lượt đấm
            while (bonusPunches.Count < 2)
            {
                int randomBox = random.Next(1, 51); // Random số ô từ 1 đến 50
                if (!bonusPunches.Contains(randomBox))
                {
                    bonusPunches.Add(randomBox); // Thêm ô vào danh sách ô có thêm lượt đấm
                }
            }

            for (int i = 0; i < correctGuesses; i++)
            {
                Console.Write($"Nhập số ô bạn muốn đấm (1-50): ");
                if (int.TryParse(Console.ReadLine(), out int chosenBox) && chosenBox >= 1 && chosenBox <= 50)
                {
                    if (!chosenPrizes.Contains(chosenBox)) // Kiểm tra ô đã được chọn trước đó chưa
                    {
                        chosenPrizes.Add(chosenBox); // Thêm ô vào danh sách ô đã chọn
                        punchCount--; // Giảm số lượt đấm
                        Console.WriteLine($"Ô {chosenBox}: {prizeValues[chosenBox - 1]} VND"); // In giải thưởng của ô đã chọn

                        if (bonusPunches.Contains(chosenBox)) // Kiểm tra ô đã chọn có thêm lượt đấm không
                        {
                            correctGuesses++; // Nếu có, tăng số lượt đấm
                            Console.WriteLine("Bạn đã nhận được thêm 1 lượt đấm.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ô này đã được chọn trước đó. Vui lòng chọn ô khác.");
                        i--; // Đếm lại nếu ô đã được chọn trước đó
                    }
                }
                else
                {
                    Console.WriteLine("Số ô không hợp lệ. Vui lòng nhập lại.");
                    i--; // Đếm lại nếu nhập số ô không hợp lệ hoặc hết lượt đấm
                }
            }

            // Tính tổng giải thưởng
            
            foreach (int chosenBox in chosenPrizes)
            {
                totalPrizeMoney += prizeValues[chosenBox - 1];
            }

            Console.WriteLine("---------------_-_-----------------");
            Console.WriteLine($"Tổng giải thưởng bạn đạt được trong vòng này: {totalPrizeMoney} VND");
            Console.WriteLine("Kết thúc vòng chơi.");
            this.TienThuong = totalPrizeMoney;
            Console.ReadLine();
        }
        public void Guess(string guess, SanPham sanPham)
        {
            // Kiểm tra xem sanPham có giá trị hay không trước khi sử dụng
            if (sanPham != null)
            {
                // Kiểm tra đoán đúng hay sai
                if ((guess == "l" && correctPrice < hiddenPrice) || (guess == "h" && correctPrice > hiddenPrice))
                {
                    Console.WriteLine("Bạn đã đoán đúng!");
                    Console.WriteLine($"Giá đúng là: {correctPrice}");
                    correctGuesses++;
                    displayedProducts++; 
                }
                else
                {
                    Console.WriteLine("Bạn đã đoán sai.");
                    Console.WriteLine($"Giá đúng là: {correctPrice}");
                    displayedProducts++;
                }
            }
            else
            {
                Console.WriteLine("Không có sản phẩm để đoán.");
            }
        }

    }
}