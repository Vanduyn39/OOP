using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Vòng_2
{
    public partial class GuessThePrice : Form
    {
        private Vong_BanTayVang vongBanTayVang;
        private int displayedProducts;
        public int numberOfProducts;
        public SanPham nextProducts;
        private int correctGuesses;
        public int TienThuong { get; private set; }
        public int totalPrize { get; set; }

        public GuessThePrice(SanPhamList sanPhamList)
        {
            InitializeComponent();
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);
            pnl_PAB.MouseClick += pnl_PAB_MouseClick;

        }

        // Trong phương thức Guess:
        private void Guess(string guess)
        {
            // Lấy giá trị hiddenPrice và correctPrice từ class
            decimal hiddenPrice = vongBanTayVang.GetHiddenPrice();
            decimal correctPrice = vongBanTayVang.GetCorrectPrice(nextProducts, numberOfProducts);
            correctGuesses = vongBanTayVang.correctGuesses;

            // Hiển thị kết quả đoán giá thông qua Label
            if ((guess == "l" && correctPrice < hiddenPrice) || (guess == "h" && correctPrice > hiddenPrice))
            {
                pnl_Result.BringToFront();
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán đúng! \nGiá đúng là: {correctPrice} VND. ";
                correctGuesses++;
            }
            else
            {
                pnl_Result.BringToFront();
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán sai!  \nGiá đúng là: {correctPrice} VND.";
            }

            // Gọi phương thức Guess từ class để cập nhật trạng thái
            vongBanTayVang.Guess(guess, hiddenPrice, correctPrice);
            // Hiển thị sản phẩm tiếp theo
            DisplayProduct();
        }

        // Trong phương thức DisplayProduct:
        private void DisplayProduct()
        {
            if (displayedProducts < 4)
            {
                decimal hiddenPrice = vongBanTayVang.GetHiddenPrice();
                numberOfProducts = vongBanTayVang.GetNumberOfProducts();
                nextProducts = vongBanTayVang.GetNextProduct();
                if (nextProducts != null)
                {
                    label1.Text = $"Trưng bày {numberOfProducts} sản phẩm: {nextProducts.TenSP}\nMô tả: {nextProducts.Mota} \nGiá đưa ra: {hiddenPrice} VND.";
                    displayedProducts++;
                }
            }
            else if (displayedProducts == 4)
            {
                int correctGuess = vongBanTayVang.correctGuesses;
                if (correctGuess > 0)
                {
                    MessageBox.Show($"Bạn đã đoán đúng {correctGuess} trên tổng số {displayedProducts} câu.");
                    correctGuess = vongBanTayVang.correctGuesses;
                    pnl_PAB.Visible = true;
                    pnl_PAB.Enabled = true;
                    pnl_Game.Visible = false;
                    pnl_Game.Enabled = false;
                    pnl_Result.Visible = false;
                    pnl_Result.Enabled = false;
                    pnl_PAB.BringToFront();
                }
                else
                {
                    MessageBox.Show("Bạn đã thua cuộc!");
                    this.Close();
                }
            }
        }
        private void btn_NH_Click(object sender, EventArgs e)
        {
            Guess("l");
        }

        private void btn_LH_Click(object sender, EventArgs e)
        {
            Guess("h");


        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            pnl_Start.Visible = false;
            pnl_Game.Visible = true;
            displayedProducts = 0;
            vongBanTayVang.Play();
            DisplayProduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_Result.Visible = false;
            if (displayedProducts == 4)
            {
                button1.Visible = false;
            }
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            decimal totalPrize = vongBanTayVang.totalPrizeMoney;
            MessageBox.Show($"Bạn đã hết lượt đấm! \nTổng giải thưởng: {totalPrize} VND.");
            totalPrize += vongBanTayVang.TienThuong;
            TienThuong = (int)totalPrize;
            this.Hide();
        }


        private void pnl_PAB_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            List<int> prizeValues = vongBanTayVang.prizeValues;
            
                if (correctGuesses > 0)
                {
                    if (clickedButton.Tag != null && clickedButton.Tag.ToString() == "box")
                    {
                        Random random = new Random();
                        int randomIndex = random.Next(prizeValues.Count);
                        int prizeValue = prizeValues[randomIndex];
                        correctGuesses--;
                        MessageBox.Show($"Giải thưởng của ô là: {prizeValue} VND.\nBạn còn {correctGuesses} cơ hội!");
                        clickedButton.Visible = false;
                        vongBanTayVang.AddPrize(prizeValue); // Add the prize value to the Vong_BanTayVang object
                    }
                }

                else
                {
                    btn_Result.Visible = true;
                }
            
        }
    }
}