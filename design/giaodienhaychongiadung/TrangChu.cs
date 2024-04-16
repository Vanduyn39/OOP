using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vòng_2;
using Vòng_4;

namespace TrangChu
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        private Player currentPlayer;
        private VongChoi vongChoi;
        //private void guna2Button1_Click(object sender, EventArgs e)
        //{ 
        //    panel_btn.Visible = false;
        //    //this.Hide();
        //    //Vòng_2.GuessThePrice newf1 = new Vòng_2.Form1();
        //    //newf1.Show();
        //}

        private void form1_batdau_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList;

            string filePathPlayer = "Player.json";

            // Kiểm tra xem tệp JSON có tồn tại hay không
            if (File.Exists(filePathPlayer))
            {
                // Đọc danh sách người chơi từ tệp
                playerList = DieuKhien.ReadFile(filePathPlayer);
            }
            else
            {
                // Tạo một danh sách người chơi mới
                playerList = new PlayerList();
            }

            // Get the player name from the textbox
            string Ten = textBox1.Text;

            // Add the player to the player list
            Player currentPlayer = new Player(Ten, vongChoi, 0);
            playerList.Add(currentPlayer);

            // Ghi danh sách người chơi vào tệp
            DieuKhien.WriteFile(filePathPlayer, playerList);

            // Create instances of other classes and pass the player list
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);

            // Add the player to the game
            dieuKhien.AddPlayer(playerList);
            dieuKhien.AddSanPham(sanPhamList);

            // Set the _username variable in the GuessThePrice form
            //Vòng_2.GuessThePrice GuessThePrice = new Vòng_2.GuessThePrice(sanPhamList, currentPlayer.Ten); // Use currentPlayer.Ten instead of newPlayer.Ten
            //GuessThePrice.ShowDialog();
            Vòng_4.MainVong4 Form1 = new Vòng_4.MainVong4(sanPhamList, currentPlayer);
            Form1.ShowDialog();

            // Update the player's bonus reward after round 4
            currentPlayer.TienThuong += (int)Form1.LuaChonThongMinh.bonusReward;

            // Save the player list to a JSON file after updating the player's data
            DieuKhien.WriteFile(filePathPlayer, playerList);
        }

        private void form_thoat_Click(object sender, EventArgs e)
        {
            panel_btn.Visible   =true ;
        }

        private void btn_choi_Click(object sender, EventArgs e)
        {
            panel_btn.Visible = false;
        }

        private void btn_thoatform_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            SETTING setting = new SETTING();
            setting.ShowDialog();
        }

        private void btn_xephang_Click(object sender, EventArgs e)
        {
            this.Hide();
            XepHang mn = new XepHang();
            mn.ShowDialog();
        }
    }
}
