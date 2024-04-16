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
        public Random random;
        public SanPhamList SanPhamList;
        public Vong_DemNguoc demNguoc;
        public SanPham sanpham;
        public int[] giasai = new int[4];
        public Main_DN(SanPhamList sanPhamList, SanPham sanPham)
        {
            InitializeComponent();
            random = new Random();
            this.SanPhamList = sanPhamList;
            this.sanpham = sanPham;
        }

        private void btn_chơi_Click(object sender, EventArgs e)
        {
            demNguoc=new Vong_DemNguoc(SanPhamList);
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
            if(count== 0)
            {
                timerCount.Stop();
                Thua thua = new Thua();
                this.Hide();
                thua.Show();
            }
            lbl_timer.Text = count.ToString();
        }

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            int i = 0;
            //AmThanh amThanh = new AmThanh();
            int a = (int)sanpham.GiaSP / 1000;
            int b = ((int)sanpham.GiaSP - a * 1000) / 100;
            int c = ((int)sanpham.GiaSP - a * 1000 - b * 100) / 10;
            int d = (int)sanpham.GiaSP - a * 1000 - b * 100 - c * 10;
            int[] giatri = { a, b, c, d };
            if ((a >= giasai[0] && rdb_lonhon_nghin.Checked) || (a < giasai[0] && rdb_nhohon_nghin.Checked))
                i += 0;
            else
                i += 1;
            if ((b >= giasai[1] && rdb_lonhon_tram.Checked) || (b < giasai[1] && rdb_nhohon_tram.Checked))
                i += 0;
            else
                i += 1;
            if ((c >= giasai[2] && rdb_lonhon_chuc.Checked) || (c < giasai[2] && rdb_nhohon_chuc.Checked))
                i += 0;
            else
                i += 1;
            if ((d >= giasai[3] && rdb_lonhon_dvi.Checked) || (d < giasai[3] && rdb_nhohon_dvi.Checked))
                i += 0;
            else
                i += 1;
            if (i == 0)
            {
                ChucMung_DN chucMung_DN = new ChucMung_DN(SanPhamList, sanpham);
                timerCount.Stop();
                //amThanh.PlayCorrectSound();
                this.Hide();
                chucMung_DN.Show();
            }
            else
            {
                //amThanh.PlayIncorrectSound();
            }

        }
        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            pnl_huongdan.Visible = false;
        }

        private void Main_DN_Load(object sender, EventArgs e)
        {

        }
    }
}
