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
    public partial class SanPham_DN : Form
    {
        public SanPham_DN()
        {
            InitializeComponent();
        }

        private void bt_batdau_Click(object sender, EventArgs e)
        {
            panel_cm.Visible=false;
            cua_1.Visible=false;
            cua_2.Visible=false;
        }
        private void btn_tieptuc_Click_1(object sender, EventArgs e)
        {
            Main_DN form = new Main_DN();
            this.Hide();
            form.TopMost = true;
            form.ShowDialog();

        }
    }
}
