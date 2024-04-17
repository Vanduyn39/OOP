using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vòng_2
{
    //TienThuong luu o btn_Result_Click
    public partial class PunchABunch : Form
    {
        public Random random = new Random();
        private int correctGuesses;
        private Vong_BanTayVang vongBanTayVang;

        public PunchABunch(int correctGuesses)
        {
            SanPhamList sanPhamList = new SanPhamList();
            this.correctGuesses = correctGuesses;
            InitializeComponent();
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);


        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            decimal totalPrize = vongBanTayVang.totalPrizeMoney;
            MessageBox.Show($"Bạn đã hết lượt đấm! \nTổng giải thưởng: {totalPrize} VND.");
            totalPrize += vongBanTayVang.TienThuong;
            this.Close();
        }

        private void pnl_PAB_MouseClick(object sender, MouseEventArgs e)
        {
            List<int> prizeValues = vongBanTayVang.prizeValues;
            if (correctGuesses > 0)
            {
                int randomIndex = random.Next(prizeValues.Count);
                int prizeValue = prizeValues[randomIndex];
                Button clickedButton = (Button)sender;
                correctGuesses--;
                MessageBox.Show($"Giải thưởng của ô là: {prizeValue} VND.\nBạn còn {correctGuesses} cơ hội!");
                clickedButton.Visible = false;
                vongBanTayVang.AddPrize(prizeValue); // Add the prize value to the Vong_BanTayVang object
            }
            else if (correctGuesses > 0)
            {
                correctGuesses++; // Thêm một lượt đấm
                MessageBox.Show("Bạn đã nhận được thêm một lượt đấm!");
            }
            else
            {
                btn_Result.Visible = true;
            }
        }
    }

}


