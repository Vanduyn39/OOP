using System;
using System.Text;

namespace EndGame_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            lbl_Result.Text = "Chúc mừng người chơi {} đã hoàn thành tất cả các vòng chơi.\n Số tiền thưởng của bạn là {} VND.";
        }
    }
}
