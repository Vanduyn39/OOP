using System.Windows.Forms;
using System;
using OOP_CLASS_1;

namespace designkhongmaco
{
    partial class Form1 : Form
    {
        private Button button1;
        private SanPhamList sanPhamList;

        public Form1(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList; // Gán giá trị của tham số vào biến thành viên
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng mới của Form2 và hiển thị nó
            SanPham sanPham = new SanPham(); // Tạo một đối tượng SanPham mới
            Form2 form2 = new Form2(sanPhamList, sanPham); // Truyền cả hai tham số
            form2.Show();
            this.Hide(); // Ẩn Form1 khi hiển thị Form2
        }
    }
}
