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

        private void form1_batdau_Click(object sender, EventArgs e)
        {
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

            // Lấy tên người chơi từ textBox1
            string Ten = textBox1.Text;

            // Thêm người chơi vào danh sách người chơi
            Player Player = new Player(Ten, vongChoi, 0);
            playerList.Add(Player);

            BatDau(playerList, Player);

            // Lưu danh sách người chơi vào tệp JSON sau khi cập nhật dữ liệu của người chơi
            DieuKhien.WriteFile(filePathPlayer, playerList);
        }

        private void BatDau(PlayerList playerList, Player player)
        {
            SanPhamList sanPhamList = new SanPhamList();
            SanPham sanPham = new SanPham();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            KetThucGame.ENDGAME ENDGAME = new KetThucGame.ENDGAME(player);

            // Vòng 1: BÀN TAY VÀNG
            Vòng_2.GuessThePrice guessThePriceForm = new Vòng_2.GuessThePrice(sanPhamList);
            guessThePriceForm.ShowDialog();
            player.TienThuong += guessThePriceForm.TienThuong;

            if (player.TienThuong == 0)
            {
                MessageBox.Show("Bạn đã thua ở vòng 1. Kết thúc chương trình!");
                //player.Vongchoidachoi = "Bàn tay vàng";
                playerList.Add(player);
                ENDGAME.Show();
                return; // Dừng chương trình nếu người chơi thua ở vòng 1
            }

            // Vòng 2: ĐẾM NGƯỢC 
            DEM_NGUOC.Main_DN main_DN = new DEM_NGUOC.Main_DN(sanPhamList, sanPham);
            main_DN.ShowDialog();
            player.TienThuong += (int)main_DN.demNguoc.TienThuong;

            if (main_DN.demNguoc.TienThuong == 0)
            {
                // Hiển thị thông báo thua
                MessageBox.Show("Bạn đã thua ở vòng 2. Kết thúc chương trình!");
                playerList.Add(player);
                ENDGAME.Show();
                return; // Dừng chương trình nếu người chơi thua ở vòng 2.
            }

            // Vòng 3: KHÔNG MÀ CÓ
            designkhongmaco.MainKMC form = new designkhongmaco.MainKMC(sanPhamList, sanPham);
            form.ShowDialog();

            player.TienThuong += (int)form.TienThuong;

            if (form.TienThuong == 0)
            {
                // Hiển thị thông báo thua
                MessageBox.Show("Bạn đã thua ở vòng 3. Kết thúc chương trình!");
                playerList.Add(player);
                ENDGAME.Show();
                return; // Dừng chương trình nếu người chơi thua ở vòng 3.
            }

            // Vòng 4: LỰA CHỌN THÔNG MINH
            Vòng_4.MainVong4 MainVong4 = new Vòng_4.MainVong4(sanPhamList);
            MainVong4.ShowDialog();
            player.TienThuong += (int)MainVong4.LuaChonThongMinh.TienThuong;

            if (MainVong4.LuaChonThongMinh.TienThuong == 0)
            {
                // Hiển thị thông báo thua
                MessageBox.Show("Bạn đã thua ở vòng 4. Kết thúc chương trình!");
                playerList.Add(player);
                ENDGAME.Show();
                return; // Dừng chương trình nếu người chơi thua ở vòng 4.
            }

            // Hiển thị thông báo hoàn thành tất cả các vòng chơi
            MessageBox.Show("Chúc mừng! Bạn đã hoàn thành tất cả các vòng chơi.");
            ENDGAME.Show();
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
