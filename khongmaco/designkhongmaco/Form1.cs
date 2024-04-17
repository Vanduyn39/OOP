using System.Windows.Forms;
using System;
using OOP_CLASS_1;

namespace designkhongmaco
{
    partial class Form1 : Form
    {
        private Button button1; // Thêm phần khai báo của button1
        private SanPhamList sanPhamList;
        private SanPham sanPham;

        public Form1(SanPhamList SanPhamList)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng mới của Form2 và hiển thị nó
            Form2 form2 = new Form2(sanPhamList, sanPham);
            form2.Show();
            this.Hide(); // Ẩn Form1 khi hiển thị Form2
        }
    }
}
