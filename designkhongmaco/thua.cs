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

namespace designkhongmaco
{
    public partial class thua : Form
    {
        private SanPhamList sanPhamList;

        public thua(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList; // Gán giá trị của tham số vào biến thành viên

            // Không cho phép chỉnh sửa TextBox hiển thị số lượng sản phẩm đoán sai
            soluongthua.ReadOnly = true;
        }

        public void SetCorrectGuessCount(int count)
        {
            soluongthua.Text = count.ToString();
        }

        private void doanlai_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Close();
            // Tạo một đối tượng SanPham mới
            SanPham sanPham = new SanPham();
            // Tạo một thể hiện mới của Form2 và truyền cả hai tham số
            Form2 form2 = new Form2(sanPhamList, sanPham);
            // Hiển thị Form2
            form2.Show();
        }
    }
}
