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
        private bool daChon;
        //private Player player;
        private bool[] btnClicked = new bool[3]; // Theo dõi số lần nhấp vào nút
        /*public Player Player;*/ // Add this line at the class level

        public MainVong4(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            this.LuaChonThongMinh = new Vong_LuaChonThongMinh(sanPhamList); // Pass sanPhamList only
            this.daChon = false;
            /*this.player = player;*/ // Assign the player parameter to the player field
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

        // Chọn sản phẩm có giá cao nhất
        //private Player currentPlayer; // Add this line at the class level

        private void ChonSPGiaCao(int index)
        {
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
                    MessageBox.Show("Chúc mừng! Bạn đã chọn đúng sản phẩm có giá cao nhất: " + sanPhamChon.TenSP + " Bạn đã nhận được tất cả 3 sản phẩm với giá trị " + LuaChonThongMinh.bonusReward);
                    LuaChonThongMinh.TienThuong += (int)LuaChonThongMinh.bonusReward;
                    MessageBox.Show("Tiền thưởng: " + LuaChonThongMinh.TienThuong);
                    this.Hide();
                }
                else
                {
                    // Play the error sound
                    PlayErrorSound();

                    MessageBox.Show("Xin lỗi! Bạn đã chọn sai, sản phẩm có giá cao nhất là: " + GiaSPCaoNhat.TenSP);
                    daChon = true;
                    if (daChon)
                    {
                        MessageBox.Show("Bạn đã chọn sai, chương trình kết thúc!");
                        this.Hide();
                    }
                }

                HienTenSP();
            }
        }

        private void PlayErrorSound()
        {
            try
            {
                // Load the sound file from the Vòng_4 project
                SoundPlayer player = new SoundPlayer(@"Resources\trlsai.wav.wav");

                // Play the sound asynchronously
                player.Play();
            }
            catch (Exception ex)
            {
                // Handle any errors while playing the sound
                Console.WriteLine("Error playing sound: " + ex.Message);
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

        // Trình xử lý sự kiện cho nút chọn 1 cú nhấp chuột
        private void btn_S1_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(0);
        }

        // Trình xử lý sự kiện cho nút chọn 2 lần nhấp
        private void btn_S2_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(1);
        }

        // Trình xử lý sự kiện cho nút chọn 3 lần nhấp
        private void btn_S3_Click_1(object sender, EventArgs e)
        {
            ChonSPGiaCao(2);
        }
    }
}
