using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using DEM_NGUOC;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Vòng_2
{
    public partial class PunchABunch : Form
    {
        public Random random = new Random();
        private int correctGuesses;
        private  Vong_BanTayVang vongBanTayVang;

        public PunchABunch(int correctGuesses, string username)
        {
            SanPhamList sanPhamList = new SanPhamList();
            this.correctGuesses = correctGuesses;
            InitializeComponent();
            label1.Text = username;
            label1.BringToFront();
            vongBanTayVang = new Vong_BanTayVang(sanPhamList);

        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            decimal totalPrize = vongBanTayVang.totalPrizeMoney;
            MessageBox.Show($"Bạn đã hết lượt đấm! \nTổng giải thưởng:{totalPrize}");
            this.Hide();
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            // Get the player name from the textbox
            //string playerName = textBox1.Text;
            // Add the player to the player list
            //Player newPlayer = new Player(playerName, null, 0);
            //playerList.Add(newPlayer);
            dieuKhien.AddPlayer(playerList);
            SanPham_DN SanPham_DN = new DEM_NGUOC.SanPham_DN(sanPhamList);
            SanPham_DN.ShowDialog();
        }

        private void pnl_PAB_MouseClick(object sender, MouseEventArgs e)
        {
            List<int> prizeValues = vongBanTayVang.prizeValues;
            if (correctGuesses > 0)
            {
                int randomIndex = random.Next(prizeValues.Count);
                int prizeValue = prizeValues[randomIndex];
                System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}


