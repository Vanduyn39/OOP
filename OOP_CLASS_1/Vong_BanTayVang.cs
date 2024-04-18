using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace OOP_CLASS_1
{
    public class Vong_BanTayVang : VongChoi
    {
        public Random random;
        public List<SanPham> displayedProducts;
        public int correctGuesses;
        public decimal totalPrizeMoney;
        public List<int> chosenBoxes;
        public List<int> bonusPunches;
        public const int maxDisplayedProducts = 4;
        public List<int> prizeValues;
        public SanPhamList sanPhamList;
        public List<SanPham> displayedProductsHistory;
        public Vong_BanTayVang(SanPhamList sanPhamList) : base("Ban Tay Vang")
        {
            random = new Random();
            correctGuesses = 0;
            totalPrizeMoney = 0;
            chosenBoxes = new List<int>();
            bonusPunches = new List<int>();
            prizeValues = new List<int>();
            this.sanPhamList = sanPhamList;
            displayedProducts = new List<SanPham>(); 
            InitializePrizeValues();

            for (int i = 0; i < maxDisplayedProducts; i++)
            {
                SanPham nextProduct = GetNextProduct();
                if (nextProduct != null)
                {
                    displayedProducts.Add(nextProduct);
                }
            }
        }

        public void InitializePrizeValues()
        {
            int[] values = { 15000, 15000, 5000, 5000, 5000,
                             1000, 1000, 1000, 1000, 1000,
                             500, 500, 500, 500, 500,
                             500, 500, 500, 500, 500,
                             500, 250, 250, 250, 250,
                             250, 250, 250, 250, 250,
                             250, 100, 100, 100, 100,
                             100, 100, 100, 100, 100,
                             100, 50, 50, 50, 50, 50,
                             50, 50, 50, 50, 50,
                             50, 50, 50, 50, 50 };

            prizeValues.AddRange(values);
        }

        public SanPham GetNextProduct()
        {
            if (sanPhamList.SanPhams.Count == 0)
            {
                return null;
            }

            int index = random.Next(0, sanPhamList.SanPhams.Count);
            SanPham nextProduct = sanPhamList.SanPhams[index];
            sanPhamList.SanPhams.RemoveAt(index);

            return nextProduct;
        }

        public int GetNumberOfProducts()
        {
            return random.Next(1, 11);
        }

        public decimal GetHiddenPrice()
        {
            return Math.Round(random.Next(400, 30000) * 1m / 1000) * 1000;
        }

        public decimal GetCorrectPrice(SanPham sanPham, int num)
        {
            return sanPham.GiaSP * num;
        }

        public void Guess(string guess, decimal hiddenPrice, decimal correctPrice)
        {
            AmThanh amThanh = new AmThanh();
            if ((guess == "h" && correctPrice > hiddenPrice) || (guess == "l" && correctPrice < hiddenPrice))
            {
                amThanh.PlayCorrectSound();
                Console.WriteLine("Bạn đã đoán đúng!");
                Console.WriteLine($"Giá đúng là: {correctPrice}");
                correctGuesses++;
            }
            else
            {
                amThanh.PlayIncorrectSound();
                Console.WriteLine("Bạn đã đoán sai.");
                Console.WriteLine($"Giá đúng là: {correctPrice}");
            }
        }

        public decimal CalculateTotalPrizeMoney()
        {
            decimal total = 0;
            foreach (int chosenBox in chosenBoxes)
            {
                total += GetPrizeValue(chosenBox);
            }
            return total;
        }
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
        public override void Play()
        {
            Console.WriteLine($"Chào mừng bạn đến vòng chơi '{TenVongChoi}'!");
            int displayedCount = 0; 
            foreach (SanPham product in displayedProducts)
            {
                displayedCount++;
                decimal hiddenPrice = GetHiddenPrice();
                int numberOfProducts = GetNumberOfProducts();
                decimal correctPrice = GetCorrectPrice(product, numberOfProducts);
                if (hiddenPrice != correctPrice)
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine($"Trưng bày {numberOfProducts} sản phẩm được trưng bày cho bạn.");
                    Console.WriteLine($"Sản phẩm: {product.TenSP}");
                    Console.WriteLine($"Mô tả: {product.Mota}");
                    Console.WriteLine($"Giá đưa ra: {hiddenPrice}");
                    Console.WriteLine($"Bạn đoán giá đúng của {numberOfProducts} sản phẩm {product.TenSP} cao hơn hay thấp hơn giá đưa ra?");
                    string guess;

                    Console.WriteLine("Nhập cao hơn 'h' hoặc thấp hơn 'l' để đoán giá:");
                    guess = Console.ReadLine();
                    if (guess != "h" && guess != "l")
                    {
                        Console.WriteLine("Câu trả lời không hợp lệ! Vui lòng nhập lại.");
                    }
                    Guess(guess, hiddenPrice, correctPrice);
                }
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
                        if (GetPrizeValue(chosenBox) > 0) 
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
            TienThuong = (int)totalPrizeMoney;

        }


    }
}
