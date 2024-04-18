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

namespace TrangChu
{
    public partial class SETTING : Form
    {
        private AmThanh amThanh=new AmThanh();
        public SETTING()
        {
            InitializeComponent();
        }

        private void SETTING_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void rdb_bat_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb_bat.Checked)
            {
                amThanh.PlayMoGameSound();
            }
        }

        private void rdb_tat_CheckedChanged(object sender, EventArgs e)
        {
            amThanh.StopMoGameSound();
        }
    }
}

