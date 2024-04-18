using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEM_NGUOC
{
     public partial class Main_DN : Form
    {
        private SanPhamList SanPhamList;
        public Vong_DemNguoc demNguoc;
        public SanPham sanpham;
        private Player player; 
        public int[] giasai = new int[4];
        public int[] giatri = new int[4];
        public Main_DN(SanPhamList sanPhamList, SanPham sanPham)
        {
            InitializeComponent();
            this.SanPhamList = sanPhamList;
            this.sanpham = sanPham;
        }

        private void btn_chơi_Click(object sender, EventArgs e)
        {
            demNguoc.HienGiaSai(giasai);
            lbl_nghin1.Text = giasai[0].ToString();
            lbl_tram.Text = giasai[1].ToString();
            lbl_chuc.Text = giasai[2].ToString();
            lbl_dvi.Text = giasai[3].ToString();
            timerCount.Start();
            btn_chơi.Enabled = false;
        }
        int count = 60;
        private void timerCount_Tick(object sender, EventArgs e)
        {
            count--;
            if (count == 0)
            {
                timerCount.Stop();
                demNguoc.TienThuong += 0;
                SanPhamList sanPhamList = new SanPhamList();
                PlayerList playerList = new PlayerList();
                DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
                dieuKhien.AddSanPham(sanPhamList);
                dieuKhien.AddPlayer1(playerList);
                dieuKhien.AddPlayer2(playerList);

                MessageBox.Show("Bạn đã thua vòng Đếm Ngược");
                this.Close();
            }
            lbl_timer.Text = count.ToString();
        }

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            int i = 0;
            AmThanh amThanh = new AmThanh();
            demNguoc.DonViSP(sanpham, giatri);
            if ((giatri[0] >= giasai[0] && rdb_lonhon_nghin.Checked) || (giatri[0] < giasai[0] && rdb_nhohon_nghin.Checked))
                i += 0;
            else
                i += 1;
            if ((giatri[1] >= giasai[1] && rdb_lonhon_tram.Checked) || (giatri[1] < giasai[1] && rdb_nhohon_tram.Checked))
                i += 0;
            else
                i += 1;
            if ((giatri[2] >= giasai[2] && rdb_lonhon_chuc.Checked) || (giatri[2] < giasai[2] && rdb_nhohon_chuc.Checked))
                i += 0;
            else
                i += 1;
            if ((giatri[3] >= giasai[3] && rdb_lonhon_dvi.Checked) || (giatri[3] < giasai[3] && rdb_nhohon_dvi.Checked))
                i += 0;
            else
                i += 1;
            if (i == 0)
            {
                SanPhamList sanPhamList = new SanPhamList();
                PlayerList playerList = new PlayerList();
                DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
                dieuKhien.AddSanPham(sanPhamList);
                dieuKhien.AddPlayer1(playerList);
                dieuKhien.AddPlayer2(playerList);
                timerCount.Stop();
                demNguoc.TienThuong = (int)sanpham.GiaSP;
                MessageBox.Show($"Chúc mừng bạn vượt qua vòng Đếm Ngược!!!\nTiền thưởng: {demNguoc.TienThuong}");
                amThanh.PlayCorrectSound();
                this.Close();
            }
            else
            {
                amThanh.PlayIncorrectSound();
            }

        }
        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            demNguoc = new Vong_DemNguoc(SanPhamList);
            sanpham = demNguoc.RandomSanPham();
            MessageBox.Show($"San pham doan gia: \n{sanpham.TenSP}");
            pnl_huongdan.Visible = false;
        }

        private void Main_DN_Load(object sender, EventArgs e)
        {

        }
    }
}
