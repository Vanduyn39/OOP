using System;
using System.Collections.Generic;

namespace OOP_CLASS_1
{
    public class Vong_BanTayVang : VongChoi
    {
        public Random random = new Random();
        public List<SanPham> displayedProducts = new List<SanPham>();
        public int correctGuesses = 0;
        public decimal totalPrizeMoney = 0;
        public List<int> chosenBoxes = new List<int>();
        public List<int> bonusPunches = new List<int>();
        public const int maxDisplayedProducts = 4;
        public List<int> prizeValues = new List<int>();
        public Vong_BanTayVang(SanPhamList sanPhamList) : base("Ban Tay Vang")
        {
            SanPhamList = sanPhamList;
            prizeValues.AddRange(new int[] {
                15000, 15000, 5000, 5000, 5000,
                1000, 1000, 1000, 1000, 1000,
                500, 500, 500, 500,
                500, 500, 500, 500, 500,
                500, 250, 250, 250, 250,
                250, 250, 250, 250, 250,
                250, 100, 100, 100, 100,
                100, 100, 100, 100, 100,
                100, 50, 50, 50, 50, 50,
                50, 50, 50, 50, 50,
                50, 50, 50, 50, 50,
                50, 50, 50, 50, 50 });
        }

        public SanPhamList SanPhamList { get; set; }
        public decimal correctPrice { get; private set; }

        // Lấy sản phẩm tiếp theo từ danh sách sản phẩm
        public SanPham GetNextProduct()
        {
            int index = random.Next(SanPhamList.SanPhams.Count);
            return SanPhamList.SanPhams[index];
        }

        // Lấy số lượng sản phẩm từ 1 đến 10
        public int GetNumberOfProducts()
        {
            return random.Next(1, 11);
        }

        // Lấy giá ẩn của sản phẩm
        public decimal GetHiddenPrice()
        {
            return Math.Round(random.Next(1000, 9000) * 1m / 1000) * 1000;
        }

        public override void Play()
        {
            Console.WriteLine($"Chào mừng bạn đến vòng chơi '{TenVongChoi}'!");

            while (displayedProducts.Count < maxDisplayedProducts)
            {
                SanPham nextProduct = GetNextProduct();
                decimal hiddenPrice = GetHiddenPrice();
                int numberOfProducts = GetNumberOfProducts();
                this.correctPrice = nextProduct.GiaSP * numberOfProducts;

                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Có {numberOfProducts} sản phẩm được trưng bày cho bạn.");

                if (hiddenPrice != correctPrice)
                {
                    Console.WriteLine($"Sản phẩm: {nextProduct.TenSP}");
                    Console.WriteLine($"Mô tả: {nextProduct.Mota}");
                    Console.WriteLine($"Giá đưa ra: {hiddenPrice}");
                    Console.Write("Đoán giá cao hơn (h) hay thấp hơn (l) giá đưa ra: ");
                    string guess = Console.ReadLine();
                    Guess(guess, hiddenPrice, correctPrice);
                }

                displayedProducts.Add(nextProduct);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Bắt đầu đấm ô...");
            Console.WriteLine($"Bạn có {correctGuesses} lượt đấm.");
            int punchCount = correctGuesses;

            while (bonusPunches.Count < 2)
            {
                int randomBox = random.Next(1, 51);
                if (!bonusPunches.Contains(randomBox))
                {
                    bonusPunches.Add(randomBox);
                }
            }

            for (int i = 0; i < correctGuesses; i++)
            {
                Console.Write($"Nhập số ô bạn muốn đấm (1-50): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int chosenBox) && chosenBox >= 1 && chosenBox <= 50)
                {
                    if (!chosenBoxes.Contains(chosenBox))
                    {
                        chosenBoxes.Add(chosenBox);
                        punchCount--;
                        Console.WriteLine($"Ô {chosenBox}: {GetPrizeValue(chosenBox)} VND");

                        if (bonusPunches.Contains(chosenBox))
                        {
                            correctGuesses++;
                            Console.WriteLine("Bạn đã nhận được thêm 1 lượt đấm.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ô này đã được chọn trước đó. Vui lòng chọn ô khác.");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Số ô không hợp lệ. Vui lòng nhập lại.");
                    i--;
                }
            }

            totalPrizeMoney = CalculateTotalPrizeMoney();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Tổng giải thưởng bạn đạt được trong vòng này: {totalPrizeMoney} VND");
            Console.WriteLine("Kết thúc vòng chơi.");
            this.TienThuong = decimal.ToInt32(totalPrizeMoney);
        }

        // Tính tổng giải thưởng
        public decimal CalculateTotalPrizeMoney()
        {
            decimal total = 0;
            foreach (int chosenBox in chosenBoxes)
            {
                total += GetPrizeValue(chosenBox);
            }
            return total;
        }

        // Lấy giá trị giải thưởng tại ô đấm
        public int GetPrizeValue(int chosenBox)
        {
            if (chosenBox > prizeValues.Count)
            {
                return 0;
            }
            return prizeValues[chosenBox - 1];
        }
        public void AddPrize(int prizeValue)
        {
            prizeValues.Add(prizeValue);
            totalPrizeMoney += prizeValue;
        }
        // Đoán giá của sản phẩm
        public void Guess(string guess, decimal hiddenPrice, decimal correctPrice)
        {

            if (guess == "h" && correctPrice > hiddenPrice || guess == "l" && correctPrice < hiddenPrice)
            {
                Console.WriteLine("Bạn đã đoán đúng!");
                Console.WriteLine($"Giá đúng là: {correctPrice}");
                correctGuesses++;
            }
            else
            {
                Console.WriteLine("Bạn đã đoán sai.");
                Console.WriteLine($"Giá đúng là: {correctPrice}");
            }
        }
    }
}