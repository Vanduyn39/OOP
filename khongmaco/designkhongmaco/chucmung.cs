using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace designkhongmaco
{
    public partial class chucmung : Form
    {
        public chucmung()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void SetCorrectGuessCount(int count)
        {
            soluongthang.Text = count.ToString();
        }

        public void SetTienThuong(int prize)
        {
            tienthuong.Text = prize.ToString(); // Hiển thị giá trị tiền thưởng trong textbox txtTienThuong
        }

    }
}
