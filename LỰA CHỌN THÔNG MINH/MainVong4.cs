using System;
using System.Media;
using System.Windows.Forms;
using OOP_CLASS_1;
using KetThucGame;

namespace Vòng_4
{
    public partial class MainVong4 : Form
    {
        public Vong_LuaChonThongMinh LuaChonThongMinh { get; private set; }
        private SanPhamList sanPhamList;
        private bool DaChon;
        private bool[] btnClicked = new bool[3]; // Theo dõi số lần nhấp vào nút

        public MainVong4(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            this.LuaChonThongMinh = new Vong_LuaChonThongMinh(sanPhamList); 
            this.DaChon = false;
            HienTenSP();
            // Vô hiệu hóa các nút lựa chọn ban đầu
            btn_S1.Enabled = false;
            btn_S2.Enabled = false;
            btn_S3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Hiển thị mô tả sản phẩm khi nhấp vào nút
        private void HienMoTaSP(int index)
        {
            if (index >= 0 && index < sanPhamList.SanPhams.Count)
            {
                SanPham sanPhamChon = sanPhamList.SanPhams[index];
                MessageBox.Show(sanPhamChon.Mota, "Mô tả sản phẩm");
            }
        }

        // Hiển thị tên sản phẩm
        private void HienTenSP()
        {
            label1.Text = LuaChonThongMinh.SanPhamList.SanPhams[0].TenSP;
            label2.Text = LuaChonThongMinh.SanPhamList.SanPhams[1].TenSP;
            label3.Text = LuaChonThongMinh.SanPhamList.SanPhams[2].TenSP;
        }

        // Trình xử lý sự kiện cho nút 1 lần nhấp
        private void btn_1_Click(object sender, EventArgs e)
        {
            HienMoTaSP(0);
            btnClicked[0] = true;
            KiemTraMoTa();
        }

        // Trình xử lý sự kiện cho nút bấm 2 lần
        private void btn_2_Click(object sender, EventArgs e)
        {
            HienMoTaSP(1);
            btnClicked[1] = true;
            KiemTraMoTa();
        }

        // Trình xử lý sự kiện cho nút bấm 3
        private void btn_3_Click(object sender, EventArgs e)
        {
            HienMoTaSP(2);
            btnClicked[2] = true;
            KiemTraMoTa();
        }

        // Bật các nút chọn khi nhấp vào tất cả các nút sản phẩm
        private void KiemTraMoTa()
        {
            if (btnClicked[0] && btnClicked[1] && btnClicked[2])
            {
                btn_S1.Enabled = true;
                btn_S2.Enabled = true;
                btn_S3.Enabled = true;
            }
        }

        // Ẩn bảng hướng dẫn khi nhấp vào nút tiếp tục
        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            pnl_huongdan.Visible = false;
        }

        private void ChonSPGiaCao(int index)
        {
            AmThanh amThanh = new AmThanh();
            if (index >= 0 && index < sanPhamList.SanPhams.Count)
            {
                SanPham sanPhamChon = sanPhamList.SanPhams[index];

                decimal maxPrice = decimal.MinValue;
                SanPham GiaSPCaoNhat = null;

                foreach (SanPham sp in sanPhamList.SanPhams)
                {
                    if (sp.GiaSP > maxPrice)
                    {
                        maxPrice = sp.GiaSP;
                        GiaSPCaoNhat = sp;
                    }
                }

                if (sanPhamChon.GiaSP == maxPrice)
                {
                    amThanh.PlayCorrectSound();
                    MessageBox.Show("Chúc mừng! Bạn đã chọn đúng sản phẩm có giá cao nhất: " + sanPhamChon.TenSP + " Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + LuaChonThongMinh.TongTienThuong);
                    LuaChonThongMinh.TienThuong += (int)LuaChonThongMinh.TongTienThuong;
                    MessageBox.Show("Tiền thưởng: " + LuaChonThongMinh.TienThuong);
                    this.Hide();
                }
                else
                {
                    amThanh.PlayIncorrectSound();
                    MessageBox.Show("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + GiaSPCaoNhat.TenSP);
                    DaChon = true;
                    if (DaChon)
                    {
                        MessageBox.Show("Bạn đã chọn sai, chương trình kết thúc!");
                        this.Hide();
                    }
                }

                HienTenSP();
            }
        }
        // Xử lý sự kiện Chọn
        private void btn_S1_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(0);
        }

        private void btn_S2_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(1);
        }

        private void btn_S3_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(2);
        }
    }
}
