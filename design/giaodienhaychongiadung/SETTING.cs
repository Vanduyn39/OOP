using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodienhaychongiadung
{
    public partial class SETTING : Form
    {
        public SETTING()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void SETTING_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SETTING_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}

