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
        public Main_DN()
        {
            InitializeComponent();
        }

        private void Panel_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_nghin1_Click(object sender, EventArgs e)
        {
            lbl_nghin1.Text = "";
            Random random = new Random();
            int rd = random.Next(1, 9);
            lbl_nghin1.Text = rd.ToString();
        }
    }
}
