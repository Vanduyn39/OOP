using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using OOP_CLASS_1;

namespace designkhongmaco
{
    public partial class Form2 : Form
    {
        public Random random = new Random();
        public SanPhamList sanPhamList;
        public SanPham sanpham;
        public List<TextBox> displayedProducts = new List<TextBox>();
        public List<int> selectedPrices = new List<int>();

        public Form2(SanPhamList sanPhamList, SanPham sanPham)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            this.sanpham = sanPham;
            HienThiDanhSachSanPham();

            // Vô hiệu hóa chỉnh sửa trực tiếp của TextBox giarandom
            giarandom.ReadOnly = true;
            giarandom.TabStop = false; // Không cho phép tab đến TextBox giarandom
            // Chuyển focus sang control khác khi nhập vào TextBox giarandom
            giarandom.Enter += (sender, e) => { this.ActiveControl = doan; };
        }

        // Hiển thị danh sách sản phẩm
        // Hiển thị danh sách sản phẩm
        private void HienThiDanhSachSanPham()
        {
            for (int i = 0; i < Math.Min(6, sanPhamList.SanPhams.Count); i++)
            {
                string tenTextBox = "textBox" + (i + 2);
                TextBox textBox = TimTextBox(tenTextBox); // Tìm control TextBox bằng tên
                if (textBox != null)
                {
                    textBox.Text = $"{sanPhamList.SanPhams[i].TenSP} - Giá: {sanPhamList.SanPhams[i].GiaSP} - {sanPhamList.SanPhams[i].Mota}";
                    textBox.ReadOnly = true; // Chuyển TextBox thành không thể sửa
                    displayedProducts.Add(textBox);
                    // Gắn sự kiện click để chọn sản phẩm
                    textBox.Click += TextBox_Click;
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy textBox
                    MessageBox.Show($"Không tìm thấy TextBox với tên {tenTextBox}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Ngẫu nhiên và hiển thị giá trong TextBox giarandom
            int giaNgauNhien = random.Next(60, 100) * 100; // Giá ngẫu nhiên từ 6000 đến 10000
            giarandom.Text = giaNgauNhien.ToString();
        }


        // Hàm tìm TextBox theo tên
        private TextBox TimTextBox(string ten)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.Name == ten)
                {
                    return (TextBox)control;
                }
            }
            return null;
        }

        // Sự kiện click chọn sản phẩm
        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox clickedTextBox = (TextBox)sender;

            // Đặt lại màu nền và kiểu viền cho tất cả sản phẩm
            foreach (TextBox textBox in displayedProducts)
            {
                if (textBox == clickedTextBox)
                {
                    textBox.BackColor = Color.LightBlue; // Đặt màu nền là light blue
                    textBox.BorderStyle = BorderStyle.FixedSingle; // Đặt kiểu viền là FixedSingle
                }
                else
                {
                    textBox.BackColor = Color.White; // Đặt màu nền là trắng
                    textBox.BorderStyle = BorderStyle.None; // Đặt kiểu viền là None
                }
            }

            // Thêm hoặc loại bỏ sản phẩm khỏi danh sách đã chọn
            if (!displayedProducts.Contains(clickedTextBox))
            {
                displayedProducts.Add(clickedTextBox);
                selectedPrices.Add(TrichXuatGia(clickedTextBox.Text)); // Thêm giá sản phẩm vào danh sách đã chọn
            }
            else
            {
                displayedProducts.Remove(clickedTextBox);
                selectedPrices.Remove(TrichXuatGia(clickedTextBox.Text)); // Loại bỏ giá sản phẩm khỏi danh sách đã chọn
            }


        }

        // Phương thức trợ giúp để trích xuất giá từ thông tin sản phẩm
        private int TrichXuatGia(string thongTinSanPham)
        {
            int viTriBatDau = thongTinSanPham.IndexOf("Giá:") + 5; // Tìm vị trí bắt đầu của giá sản phẩm
            int viTriKetThuc = thongTinSanPham.IndexOf("-", viTriBatDau); // Tìm vị trí kết thúc của giá sản phẩm
            string chuoiGia = thongTinSanPham.Substring(viTriBatDau, viTriKetThuc - viTriBatDau).Trim(); // Trích xuất chuỗi giá
            return int.Parse(chuoiGia);
        }

        // Sự kiện click cho nút đoán
        private void doan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem giá ngẫu nhiên có phải là một số nguyên hợp lệ không
            if (!int.TryParse(giarandom.Text, out int giaNgauNhien))
            {
                MessageBox.Show("Giá nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuongDoanDung = 0; // Số lượng đoán đúng
            int tongGiaiThuong = 0; // Tổng giải thưởng

            // Kiểm tra xem giá của từng sản phẩm có thấp hơn giá ngẫu nhiên không và tính tổng giải thưởng
            if (textBox2.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox2.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox2.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }
            if (textBox3.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox3.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox3.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }
            if (textBox4.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox4.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox4.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }
            if (textBox5.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox5.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox5.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }
            if (textBox6.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox6.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox6.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }
            if (textBox7.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox7.Text) < giaNgauNhien)
            {
                soLuongDoanDung++; // Tăng số lượng đoán đúng lên 1
                tongGiaiThuong += TrichXuatGia(textBox7.Text); // Thêm giá sản phẩm vào tổng giải thưởng
            }

            // Giới hạn số lượng đoán đúng là tối đa 4
            soLuongDoanDung = Math.Min(soLuongDoanDung, 4);

            if (soLuongDoanDung > 2)
            {
                // Tạo một thể hiện mới của form chucmung
                chucmung chucmungForm = new chucmung();
                // Thiết lập số lượng đoán đúng và tổng giải thưởng cho form chucmung
                chucmungForm.SetCorrectGuessCount(soLuongDoanDung);
                chucmungForm.SetTienThuong(tongGiaiThuong);
                // Hiển thị form chucmung
                chucmungForm.Show();
            }
            else
            {
                thua thuaForm = new thua(sanPhamList);
                thuaForm.SetCorrectGuessCount(soLuongDoanDung); // Thiết lập số lượng sản phẩm đoán trúng
                thuaForm.Show();
            }

            // Đóng Form2
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            HienThiDanhSachSanPham();
        }
    }
}