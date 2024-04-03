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
        private Random random;
        public Main_DN()
        {
            InitializeComponent();
            random =new Random();
        }

        private void btn_chơi_Click(object sender, EventArgs e)
        {
            lbl_nghin1.Text = "";
            int rd1 = random.Next(1, 9);
            lbl_nghin1.Text = rd1.ToString();
            lbl_tram.Text = "";
            int rd2 = random.Next(1, 9);
            lbl_tram.Text = rd2.ToString();
            lbl_chuc.Text = "";
            int rd3 = random.Next(1, 9);
            lbl_chuc.Text = rd3.ToString();
            lbl_dvi.Text = "";
            int rd4 = random.Next(1, 9);
            lbl_dvi.Text = rd4.ToString();
            timerCount.Start();
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
        int gia = 1234;

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            int i = 0;
            int nghin = gia / 1000;
            int tram = (gia - nghin * 1000) / 100;
            int chuc = (gia - nghin * 1000 - tram * 100) / 10;
            int dvi = gia - nghin * 1000 - tram * 100 - chuc * 10;
            int rd1=int.Parse(lbl_nghin1.Text);
            int rd2=int.Parse(lbl_tram.Text);
            int rd3=int.Parse(lbl_chuc.Text);
            int rd4=int.Parse(lbl_dvi.Text);
            if ((rd1<nghin&&rdb_lonhon_nghin.Checked)||(rd1>nghin&&rdb_nhohon_nghin.Checked))
                i += 0;
            else
                i += 1; 
            if ((rd2 < tram && rdb_lonhon_tram.Checked)||(rd2>tram&&rdb_nhohon_tram.Checked))
                i += 0;
            else
                i += 1;
            if ((rd3 < chuc && rdb_lonhon_chuc.Checked)||(rd3>chuc&&rdb_nhohon_chuc.Checked))
                i += 0;
            else
                i += 1;
            if ((rd4 < dvi && rdb_lonhon_dvi.Checked)||(rd4>dvi&&rdb_nhohon_dvi.Checked))
                i += 0;
            else
                i += 1;
            if(i==0)
            {
                ChucMung_DN chucMung_DN = new ChucMung_DN();
                this.Hide();
                chucMung_DN.Show();
            }
        }
        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            pnl_huongdan.Visible = false;
        }
    }
}
