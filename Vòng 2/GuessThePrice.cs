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
        public string Ten;
        public GuessThePrice(SanPhamList sanPhamList, string Ten)
        {
            InitializeComponent();
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);
            this.Ten = Ten;
            label2.Text = $"Player: {this.Ten}";
            label2.BringToFront();
        }

        private void DisplayProduct()
        {
            if (displayedProducts < 4)
            {
                decimal hiddenPrice = vongBanTayVang.GetHiddenPrice();
                numberOfProducts = vongBanTayVang.GetNumberOfProducts();
                SanPham nextProducts = vongBanTayVang.GetNextProduct();

                if (nextProducts != null)
                {
                    label1.Text = $"Trưng bày {numberOfProducts} sản phẩm: {nextProducts.TenSP}\nMô tả: {nextProducts.Mota} \nGiá đưa ra: {hiddenPrice}";
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
                    PunchABunch newForm = new PunchABunch(correctGuess, this.Ten);
                    newForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn đã thua cuộc!");
                    this.Close();
                }
            }
        }

        private void Guess(string guess,decimal hiddenPrice, decimal correctPrice)
        {
            SanPham nextProducts = vongBanTayVang.GetNextProduct();
            correctPrice = nextProducts.GiaSP * this.numberOfProducts;
            int correctGuess = vongBanTayVang.correctGuesses;

            if ((guess == "l" && correctPrice < hiddenPrice) || (guess == "h" && correctPrice > hiddenPrice))
            {
                pnl_Result.BringToFront();
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán đúng! \nGiá đúng là: {correctPrice} ";
                correctGuess++;
            }
            else
            {
                pnl_Result.BringToFront();
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán sai!  \nGiá đúng là: {correctPrice}";
            }

            vongBanTayVang.Guess(guess, hiddenPrice, correctPrice);
            DisplayProduct();
        }

        private void btn_NH_Click_1(object sender, EventArgs e)
        {
            Guess("l", vongBanTayVang.GetHiddenPrice(), vongBanTayVang.correctPrice);
        }

        private void btn_LH_Click_1(object sender, EventArgs e)
        {
            Guess("h", vongBanTayVang.GetHiddenPrice(), vongBanTayVang.correctPrice);


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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
