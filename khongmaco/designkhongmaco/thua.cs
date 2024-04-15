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
        public thua()
        {
            InitializeComponent();
        }

        public void SetCorrectGuessCount(int count)
        {
            soluongthua.Text = count.ToString();
        }

        private void doanlai_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Close();
            // Tạo một thể hiện mới của Form2
            Form2 form2 = new Form2();
            // Hiển thị Form2
            form2.Show();
        }


    }
}
