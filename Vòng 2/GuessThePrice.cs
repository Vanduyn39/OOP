using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_CLASS_1;

namespace Vòng_2
{
    public partial class GuessThePrice : Form
    {
        private Vong_BanTayVang vongBanTayVang;
        private SanPhamList sanPhamList;
        private int displayedProducts;
        private SanPham sanPham;
        Random random = new Random();
        private int correctGuesses;
        private int totalGuesses;
        private int numberOfProducts;
        private decimal correctPrice;
        public GuessThePrice(SanPhamList sanPhamList)
        {
            InitializeComponent();
            // Khởi tạo danh sách sản phẩm
            this.sanPhamList = sanPhamList;
            // Khởi tạo vòng chơi với danh sách sản phẩm
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);
            sanPham = new SanPham();
            

        }
        private void DisplayProduct()
        {
            // Kiểm tra xem chỉ số có nằm trong phạm vi của danh sách không
            if (displayedProducts < 4)
            {
                int randomIndex = random.Next(vongBanTayVang.SanPhamList.SanPhams.Count);
                numberOfProducts = random.Next(2, 9);
                vongBanTayVang.hiddenPrice = Math.Round(random.Next(400, 90000) * 1m / 100) * 100;
                // Hiển thị thông tin sản phẩm tiếp theo
                SanPham sanPham = vongBanTayVang.SanPhamList.SanPhams[randomIndex];
                label1.Text = $"Trưng bày {numberOfProducts} sản phẩm: {sanPham.TenSP}\nMô tả: {sanPham.Mota} \nGiá đưa ra: {vongBanTayVang.hiddenPrice}";
                correctPrice = numberOfProducts * sanPham.GiaSP;
                displayedProducts++;
            }
            else if (displayedProducts == 4)
            {
                MessageBox.Show($"Bạn đã đoán đúng {correctGuesses} trên tổng số {displayedProducts} câu.");
                // Hiển thị form mới
                //this.Hide();
                //PunchABunch newForm = new PunchABunch(correctGuesses);
                //newForm.ShowDialog(); // Hiển thị form mới dưới dạng dialog
            }
        }

        private void Guess(string guess)
        {

            // Kiểm tra đoán đúng hay sai
            if ((guess == "l" && correctPrice < vongBanTayVang.hiddenPrice) || (guess == "h" && correctPrice > vongBanTayVang.hiddenPrice))
            {
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán đúng! \nGiá đúng là: {correctPrice} ";
                correctGuesses++;
            }
            else
            {
                pnl_Result.Visible = true;
                lbl_Result.Text = $"Bạn đã đoán sai!  \nGiá đúng là: {correctPrice}";

            }

            // Gọi phương thức Guess của vòng chơi và hiển thị kết quả
            vongBanTayVang.Guess(guess, sanPham);
            // Hiển thị sản phẩm tiếp theo hoặc form kết quả nếu đã đoán đủ 4 sản phẩm
            DisplayProduct();
        }


        private void btn_NH_Click_1(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút "Nhỏ hơn"
            Guess("l");
        }

        private void btn_LH_Click_1(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút "Lớn hơn"
            Guess("h");
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            pnl_Start.Visible=false;
            pnl_Game.Visible = true;
            // Bắt đầu vòng chơi khi người dùng nhấn nút "Bắt đầu vòng chơi"
            displayedProducts = 0;
            vongBanTayVang.Play();
            DisplayProduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_Result.Visible = false;
            if (displayedProducts == 4)
            {
                button1.Visible=false;
            }
            
        }
    }
}
