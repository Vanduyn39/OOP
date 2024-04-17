using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vòng_2;
using Vòng_4;
using DEM_NGUOC;
using designkhongmaco;
using System.Numerics;
using KetThucGame;

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
        private SanPhamList sanPhamList;
        private SanPham sanPham;
        private Player player;

        //private void guna2Button1_Click(object sender, EventArgs e)
        //{ 
        //    panel_btn.Visible = false;
        //    //this.Hide();
        //    //Vòng_2.GuessThePrice newf1 = new Vòng_2.Form1();
        //    //newf1.Show();
        //}


        private void form1_batdau_Click(object sender, EventArgs e)
        {
            //this.Hide();
            panel_btn.Visible = true;
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
            Player Player = new Player(Ten, vongChoi, 0);
            playerList.Add(Player);

            // Ghi danh sách người chơi vào tệp
            //DieuKhien.WriteFile(filePathPlayer, playerList);

            // Create instances of other classes and pass the player list
            //DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            // Add the player to the game
            //dieuKhien.AddPlayer1(playerList);
            //dieuKhien.AddPlayer2(playerList);
            //dieuKhien.AddSanPham(sanPhamList);
            //DieuKhien.WriteFile(filePathPlayer, playerList);
            // Start the game for the current player
            BatDau(playerList, Player);

            //while (true)
            //{
            //    string answer = MessageBox.Show("Bạn có muốn tham gia chơi không?", "Chào mừng bạn đến với trò chơi!", MessageBoxButtons.YesNo).ToString();
            //    if (answer == "Yes")
            //    {
            //        Player player = new Player(); // Tạo một người chơi mới
            //        Console.Write("=========================================\nNhập tên bạn: ");
            //        player.Ten = Console.ReadLine();
            //        string playAgain = MessageBox.Show("Bạn có muốn chơi lại không?", "Chào mừng bạn đến với trò chơi!", MessageBoxButtons.YesNo).ToString();
            //        if (playAgain == "No")
            //            break;
            //    }
            //    else
            //        break;
            //}
            //}

            // Set the _username variable in the GuessThePrice form
            //Vòng_2.GuessThePrice GuessThePrice = new Vòng_2.GuessThePrice(sanPhamList, currentPlayer.Ten); // Use currentPlayer.Ten instead of newPlayer.Ten
            //GuessThePrice.ShowDialog();
            //Vòng_4.MainVong4 Form1 = new Vòng_4.MainVong4(sanPhamList, currentPlayer);
            //Form1.ShowDialog();

            //// Update the player's bonus reward after round 4
            //currentPlayer.TienThuong += (int)Form1.LuaChonThongMinh.bonusReward;
            //// Cộng thêm tiền thưởng của vòng 4
            //KetThucGame.Form1 form1 = new KetThucGame.Form1(player);
            //form1.Show();
            // Save the player list to a JSON file after updating the player's data
            DieuKhien.WriteFile(filePathPlayer, playerList);
            KetThucGame.Form1 form1 = new KetThucGame.Form1(player);
            form1.Show();

        }

        public void BatDau(PlayerList playerList, Player player)
        {
            SanPhamList sanPhamList = new SanPhamList();
            SanPham sanPham = new SanPham();
            //PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            //// Vòng 1: Vòng_2.GuessThePrice(sanPhamList)
            //Vòng_2.GuessThePrice guessThePriceForm = new Vòng_2.GuessThePrice(sanPhamList);
            //guessThePriceForm.ShowDialog();
            //player.TienThuong += (int)Vòng_2.PunchABunch.btn_Result_Click.totalPrize;
            //if (player.TienThuong == 0)
            //{
            //    MessageBox.Show("Bạn đã thua ở vòng 1. Kết thúc chương trình!");
            //    playerList.Add(player);
            //    return; // Dừng chương trình nếu người chơi thua ở vòng 1
            //}

            // Vòng 2: DEM_NGUOC.SanPham_DN(sanPhamList)
            DEM_NGUOC.Main_DN main_DN = new DEM_NGUOC.Main_DN(sanPhamList, sanPham);
            main_DN.ShowDialog();
            player.TienThuong += (int)main_DN.demNguoc.TienThuong;
            // Hiển thị thông tin về vòng 2
            //MessageBox.Show($"Thông tin về vòng 2: Tiền thưởng: {player.TienThuong}");

            if (player.TienThuong == 0)
            {
                // Hiển thị thông báo thua
                MessageBox.Show("Bạn đã thua ở vòng 2. Kết thúc chương trình!");
                playerList.Add(player);
                return; // Dừng chương trình nếu người chơi thua ở vòng 2.
            }

            //// Vòng 3: designkhongmaco.Form1(sanPhamList)
            //designkhongmaco.Form2 Form = new designkhongmaco.Form2(sanPhamList, sanPham);
            //Form.ShowDialog();
            //player.TienThuong += (int)Form.designkhongmaco.tongGiaiThuong;
            //// Hiển thị thông tin về vòng 2
            ////MessageBox.Show($"Thông tin về vòng 2: Tiền thưởng: {player.TienThuong}");

            //if (player.TienThuong == 0)
            //{
            //    // Hiển thị thông báo thua
            //    MessageBox.Show("Bạn đã thua ở vòng 3. Kết thúc chương trình!");
            //    playerList.Add(player);
            //    return; // Dừng chương trình nếu người chơi thua ở vòng 3.
            //}

            // Vòng 4: Vòng_4.MainVong4(sanPhamList, currentPlayer)
            Vòng_4.MainVong4 mainVong4Form = new Vòng_4.MainVong4(sanPhamList);
            mainVong4Form.ShowDialog();
            //player.TienThuong += mainVong4Form.Player.TienThuong;
            player.TienThuong += (int)mainVong4Form.LuaChonThongMinh.TienThuong;

            // Hiển thị thông tin về vòng 3
            //MessageBox.Show($"Thông tin về vòng 4: Tiền thưởng: {mainVong4Form.LuaChonThongMinh.TienThuong}");

            if (player.TienThuong == 0)
            {
                // Hiển thị thông báo thua
                MessageBox.Show("Bạn đã thua ở vòng 4. Kết thúc chương trình!");
                playerList.Add(player);
                return; // Dừng chương trình nếu người chơi thua ở vòng 4.
            }

            //playerList.Add(player);

            // Hiển thị thông báo hoàn thành tất cả các vòng chơi
            MessageBox.Show("Chúc mừng! Bạn đã hoàn thành tất cả các vòng chơi.");
            //string filePathPlayer = "Player.json";
            ////// Update the player's bonus reward after round 4
            ////player.TienThuong += (int)mainVong4Form.LuaChonThongMinh.bonusReward;
            //// Cộng thêm tiền thưởng của vòng 4

            //// Save the player list to a JSON file after updating the player's data
            //DieuKhien.WriteFile(filePathPlayer, playerList);
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
