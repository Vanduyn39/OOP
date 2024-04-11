using System;
using System.Windows.Forms;
using OOP_CLASS_1;

namespace Vòng_4
{
    public partial class Form1 : Form
    {
        private Vong_LuaChonThongMinh vongChoi;
        private SanPhamList sanPhamList;

        public Form1(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            vongChoi = new Vong_LuaChonThongMinh(sanPhamList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // In ra danh sách sản phẩm đã lọc
            for (int i = 0; i < sanPhamList.SanPhams.Count; i++)
            {
                SanPham sp = vongChoi.GetSanPham(i);
                Console.WriteLine(sp.ToString());
                if (i == 0)
                    label1.Text = sp.TenSP;
                else if (i == 1)
                    label2.Text = sp.TenSP;
                else if (i == 2)
                    label3.Text = sp.TenSP;
                if (i >= 2) break; 
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null && clickedLabel.Text != null)
            {
                string productName = clickedLabel.Text;
                SanPham selectedProduct = null;
                foreach (SanPham sp in sanPhamList.SanPhams)
                {
                    if (sp.TenSP == productName)
                    {
                        selectedProduct = sp;
                        break;
                    }
                }
                if (selectedProduct != null)
                {
                    MessageBox.Show(selectedProduct.Mota, "Mô tả sản phẩm");
                }
            }
        }

        private void btn_S1_Click(object sender, EventArgs e)
        {
            HandleButtonClick(label1);
        }

        private void btn_S2_Click(object sender, EventArgs e)
        {
            HandleButtonClick(label2);
        }

        private void btn_S3_Click(object sender, EventArgs e)
        {
            HandleButtonClick(label3);
        }

        private void HandleButtonClick(Label label)
        {
            SanPham selectedProduct = null;
            foreach (SanPham sp in sanPhamList.SanPhams)
            {
                if (sp.TenSP == label.Text)
                {
                    selectedProduct = sp;
                    break;
                }
            }

            if (selectedProduct != null && selectedProduct.GiaSP == vongChoi.GetMaxPrice())
            {
                MessageBox.Show("Chúc mừng! Bạn đã chọn đúng sản phẩm có giá cao nhất: " + selectedProduct.TenSP);
                MessageBox.Show("Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + vongChoi.bonusReward);
            }
            else
            {
                SanPham maxPriceSanPham = null;
                foreach (SanPham sp in sanPhamList.SanPhams)
                {
                    if (sp.GiaSP == vongChoi.GetMaxPrice())
                    {
                        maxPriceSanPham = sp;
                        break;
                    }
                }
                MessageBox.Show("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + maxPriceSanPham.TenSP);
            }
        }
    }
}