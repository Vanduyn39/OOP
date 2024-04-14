using System.Windows.Forms;
using System;

namespace designkhongmaco
{
    partial class Form1 : Form
    {
        private Button button1; // Thêm phần khai báo của button1

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng mới của Form2 và hiển thị nó
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); // Ẩn Form1 khi hiển thị Form2
        }
    }
}
