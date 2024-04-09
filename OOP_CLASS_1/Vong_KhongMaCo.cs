using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_CLASS_1
{
    public class Vong_KhongMaCo : VongChoi
    {
        private SanPhamList SanPhamList;
        private List<int> ChosenProductIndexes = new List<int>();
        private List<SanPham> LastDisplayedProducts = new List<SanPham>();

        public Vong_KhongMaCo(SanPhamList sanPhamList) : base("Khong Ma Co")
        {
            SanPhamList = sanPhamList;
        }

        public override void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Random random = new Random();
            int price = random.Next(55, 76) * 100;

            List<SanPham> products = new List<SanPham>();
            foreach (SanPham product in SanPhamList.SanPhams)
            {
                bool chosen = false;
                for (int i = 0; i < ChosenProductIndexes.Count; i++)
                {
                    if (ChosenProductIndexes[i] == products.Count)
                    {
                        chosen = true;
                        break;
                    }
                }
                if (!chosen)
                    products.Add(product);

                if (products.Count >= 6)
                    break;
            }

            Console.WriteLine("Xin chào! Hãy chọn 4 sản phẩm có giá thấp hơn {0}:", price);
            Console.WriteLine();

            // Sử dụng lại danh sách sản phẩm đã được in ra trước đó khi đoán lại
            List<SanPham> displayProducts = (LastDisplayedProducts.Count > 0) ? LastDisplayedProducts : products;

            for (int i = 0; i < displayProducts.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, displayProducts[i].TenSP);
            }

            int count = 0;
            int[] chosenProducts = new int[4];
            while (count < 4)
            {
                Console.Write("Chọn sản phẩm thứ {0}: ", count + 1);
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= displayProducts.Count)
                {
                    bool alreadyChosen = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (chosenProducts[i] == choice)
                        {
                            alreadyChosen = true;
                            break;
                        }
                    }

                    if (!alreadyChosen)
                    {
                        chosenProducts[count] = choice;
                        count++;
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

            ChosenProductIndexes.AddRange(chosenProducts);

            Console.WriteLine();
            Console.WriteLine("Các sản phẩm bạn đã chọn và đoán đúng:");
            decimal totalPrize = 0;
            int correctCount = 0;
            foreach (int choice in chosenProducts)
            {
                int index = choice;
                if (index > 0 && index <= displayProducts.Count && displayProducts[index - 1].GiaSP < price)
                {
                    Console.WriteLine("{0} - Giá: {1}", displayProducts[index - 1].TenSP, displayProducts[index - 1].GiaSP);
                    totalPrize += displayProducts[index - 1].GiaSP;
                    correctCount++;
                }
            }

            if (correctCount <= 2) // Nếu số sản phẩm đoán đúng ít hơn hoặc bằng 2 thì thua và đoán lại
            {
                Console.WriteLine("Bạn đã đoán đúng dưới 2 sản phẩm, xin mời đoán lại!");
                Console.ReadKey();
                LastDisplayedProducts = products; // Lưu lại danh sách sản phẩm đã được in ra
                Play(); // Gọi lại phương thức Play để người chơi đoán lại
                return;
            }

            Console.WriteLine("Tiền thưởng của vòng hiện tại: {0}", totalPrize);
            Console.ReadKey();
        }
    }
}

