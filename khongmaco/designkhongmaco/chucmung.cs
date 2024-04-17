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
        private int tongGiaiThuong; // Khai báo biến tongGiaiThuong

        public chucmung()
        {
            InitializeComponent();

            // Không cho phép chỉnh sửa các TextBox hiển thị số sản phẩm đoán đúng và tiền thưởng
            soluongthang.ReadOnly = true;
            tienthuong.ReadOnly = true;
        }

        public void SetCorrectGuessCount(int count)
        {
            soluongthang.Text = count.ToString();
        }

        public void SetTienThuong(int tongGiaiThuong)
        {
            this.tongGiaiThuong = tongGiaiThuong;
            tienthuong.Text = tongGiaiThuong.ToString(); // Hiển thị tổng giải thưởng trong TextBox
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            // Đóng form chucmung khi nút thoát được nhấn
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label2 nếu cần
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click trên label3 nếu cần
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }


}
