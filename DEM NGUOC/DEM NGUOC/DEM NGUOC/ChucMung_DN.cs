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

namespace DEM_NGUOC
{
    public partial class ChucMung_DN : Form
    {
        public SanPhamList SanPhamList;
        public Vong_DemNguoc demNguoc;
        public SanPham sanpham;

        public ChucMung_DN(SanPhamList sanPhamList, SanPham sanPham)
        {
            InitializeComponent();
            pnl_thongbao.Visible = false;
            this.SanPhamList = sanPhamList;
            this.sanpham = sanPham;
        }

        private void btn_tt_cm_Click(object sender, EventArgs e)
        {
            pnl_thongbao.Visible=true;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChucMung_DN_Load(object sender, EventArgs e)
        {
            demNguoc=new Vong_DemNguoc(SanPhamList);
            demNguoc.TienThuong= sanpham.GiaSP;
            Giaithuong.Text = $"Ten Giai Thuong: {sanpham.TenSP}\nGia Giai Thuong: {sanpham.GiaSP}";
        }
    }
}
