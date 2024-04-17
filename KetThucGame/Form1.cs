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

namespace KetThucGame
{
    public partial class Form1 : Form
    {
        public Player Player;
        public Form1(Player player)
        {
            InitializeComponent();
            Player = player;
            panel_choilai.Visible = false;
        }

        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            panel_choilai.Visible = true;
        }

        private void btn_choilai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TenNguoichoi.Text=Player.Ten.ToString();
            lbl_tienthuong.Text = Player.TienThuong.ToString();
        }
    }
}
