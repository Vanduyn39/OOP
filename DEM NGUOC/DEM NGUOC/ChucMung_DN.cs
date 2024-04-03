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
    public partial class ChucMung_DN : Form
    {
        public ChucMung_DN()
        {
            InitializeComponent();
            pnl_thongbao.Visible = false;
        }

        private void btn_tt_cm_Click(object sender, EventArgs e)
        {
            pnl_thongbao.Visible=true;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
