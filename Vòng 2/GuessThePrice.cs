using OOP_CLASS_1;
using System;
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
        public GuessThePrice(SanPhamList sanPhamList)
        {
            InitializeComponent();
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);
        }

        // Trong phương thức Guess:
        private void Guess(string guess)
        {
            // Lấy giá trị hiddenPrice và correctPrice từ class
            decimal hiddenPrice = vongBanTayVang.GetHiddenPrice();
            decimal correctPrice = vongBanTayVang.GetCorrectPrice(nextProducts, numberOfProducts);
            int correctGuess = vongBanTayVang.correctGuesses;

            // Hiển thị kết quả đoán giá thông qua Label
            if ((guess == "l" && correctPrice < hiddenPrice) || (guess == "h" && correctPrice > hiddenPrice))
            {
                pnl_Result.BringToFront();
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán đúng! \nGiá đúng là: {correctPrice} VND. ";
                correctGuess++;
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
                    this.Hide();
                    PunchABunch newForm = new PunchABunch(correctGuess);
                    newForm.ShowDialog();
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
    }
}