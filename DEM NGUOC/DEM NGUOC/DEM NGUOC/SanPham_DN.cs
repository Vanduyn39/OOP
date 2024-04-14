using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_CLASS_1;

namespace DEM_NGUOC
{
    public partial class SanPham_DN : Form
    {
        private Vong_DemNguoc demNguoc;
        private SanPhamList sanPhamList;
        private Random random;
        private SanPham sanpham;
        public SanPham_DN(SanPhamList SanPhamList)
        {
            InitializeComponent();
            sanPhamList=SanPhamList;
        }

            private void bt_batdau_Click(object sender, EventArgs e)
            {
                panel_cm.Visible=false;
                cua_1.Visible=false;
                cua_2.Visible=false;
            }
        private void btn_tieptuc_Click_1(object sender, EventArgs e)
        {
            Main_DN form = new Main_DN(sanPhamList,sanpham);
            this.Hide();
            form.TopMost = true;
            form.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SanPham_DN_Load(object sender, EventArgs e)
        {
            demNguoc = new Vong_DemNguoc(sanPhamList);

            random = new Random();
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (SanPham sanPham in sanPhamList.SanPhams)
            {
                if (sanPham.GiaSP >= 1000 && sanPham.GiaSP <= 9999)
                {
                    sanPhams.Add(sanPham);
                }
            }
            if (sanPhams.Count > 0)
            {
                int index = random.Next(0, sanPhams.Count);
                sanpham = sanPhams[index];
                textBox1.Text = sanpham.TenSP.ToString();

            }

        }
    }
}
