using OOP_CLASS_1;
using System;
using System.Windows.Forms;

namespace TrangChu
{
    public partial class SETTING : Form
    {
        private AmThanh amThanh = new AmThanh();

        public SETTING()
        {
            InitializeComponent();
        }

        private void SETTING_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void SETTING_Load(object sender, EventArgs e)
        {
            rdb_t.Checked = false; // Không ch?n rdb_bat khi form ???c m?
            amThanh.StopMoGameSound(); // ??m b?o âm thanh ???c t?t khi form ???c m?
        }

        private void rdb_t_CheckedChanged(object sender, EventArgs e)
        {
            amThanh.StopMoGameSound();
        }

        private void rdb_b_CheckedChanged(object sender, EventArgs e)
        {
            amThanh.PlayMoGameSound();
        }
    }
}
