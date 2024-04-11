using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trang_Chủ;
using OOP_CLASS_1;

namespace Vòng_2
{
    public partial class Form1 : Form
    {
        private Panel pnl_Current;
        private List<Button> boxes = new List<Button>();
        private Vong_BanTayVang vongBanTayVang;
        public Form1()
        {
            InitializeComponent();
            SanPhamList sanPhamList = new SanPhamList();
            pnl_Current = pnl_Game; // Bắt đầu với pnl_Game được hiển thị
            vongBanTayVang = new Vong_BanTayVang(sanPhamList); // Load default products or replace with your own method
        }
        
        private void DelayedAction()
        {
            // Ngủ trong 2 giây
            Thread.Sleep(2000);

            // Sử dụng phương thức Invoke để đảm bảo rằng UI được cập nhật từ luồng UI
            this.Invoke(new Action(() =>
            {
                // Ẩn PictureBox
                pictureBox1.Visible = false;
                // Hiển thị Panel
                pnl_Game.Visible = true;
                
                label1.Text = "";
            }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        

        private void btn_NH_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_LH_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(DelayedAction));
            thread.Start();
        }
    }
}
