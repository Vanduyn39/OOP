using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using OOP_CLASS_1;

namespace designkhongmaco
{
    public partial class MainKMC : Form
    {
        public Random random = new Random();
        public SanPhamList sanPhamList;
        public SanPham sanpham;
        public List<TextBox> displayedProducts = new List<TextBox>();
        public List<int> selectedPrices = new List<int>();
        public int TienThuong { get; private set; }

        public MainKMC(SanPhamList sanPhamList, SanPham sanPham)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            this.sanpham = sanPham;
            HienThiDanhSachSanPham();
            giarandom.ReadOnly = true;
            giarandom.TabStop = false;
            giarandom.Enter += Giarandom_Enter;
        }

        private void HienThiDanhSachSanPham()
        {
            for (int i = 0; i < Math.Min(6, sanPhamList.SanPhams.Count); i++)
            {
                string tenTextBox = "textBox" + (i + 2);
                TextBox textBox = TimTextBox(tenTextBox);
                if (textBox != null)
                {
                    textBox.Text = $"{sanPhamList.SanPhams[i].TenSP} - {sanPhamList.SanPhams[i].Mota} - Giá: {sanPhamList.SanPhams[i].GiaSP} -";
                    textBox.ReadOnly = true;
                    displayedProducts.Add(textBox);
                    textBox.Click += TextBox_Click;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy TextBox với tên {tenTextBox}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            int giaNgauNhien = random.Next(60, 100) * 100;
            giarandom.Text = giaNgauNhien.ToString();
        }

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

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox clickedTextBox = (TextBox)sender;
            foreach (TextBox textBox in displayedProducts)
            {
                if (textBox == clickedTextBox)
                {
                    textBox.BackColor = Color.LightBlue;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    textBox.BackColor = Color.White;
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            if (!displayedProducts.Contains(clickedTextBox))
            {
                displayedProducts.Add(clickedTextBox);
                selectedPrices.Add(TrichXuatGia(clickedTextBox.Text));
            }
            else
            {
                displayedProducts.Remove(clickedTextBox);
                selectedPrices.Remove(TrichXuatGia(clickedTextBox.Text));
            }
        }

        private int TrichXuatGia(string thongTinSanPham)
        {
            int viTriBatDau = thongTinSanPham.IndexOf("Giá:") + 5;
            int viTriKetThuc = thongTinSanPham.IndexOf("-", viTriBatDau);
            string chuoiGia = thongTinSanPham.Substring(viTriBatDau, viTriKetThuc - viTriBatDau).Trim();
            return int.Parse(chuoiGia);
        }

        private void doan_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(giarandom.Text, out int giaNgauNhien))
            {
                MessageBox.Show("Giá nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuongDoanDung = 0;
            int tongGiaiThuong = 0;
            if (textBox2.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox2.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox2.Text);
            }
            if (textBox3.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox3.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox3.Text);
            }
            if (textBox4.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox4.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox4.Text);
            }
            if (textBox5.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox5.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox5.Text);
            }
            if (textBox6.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox6.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox6.Text);
            }
            if (textBox7.BorderStyle == BorderStyle.FixedSingle && TrichXuatGia(textBox7.Text) < giaNgauNhien)
            {
                soLuongDoanDung++;
                tongGiaiThuong += TrichXuatGia(textBox7.Text);
            }
            soLuongDoanDung = Math.Min(soLuongDoanDung, 4);
            if (soLuongDoanDung >= 2)
            {
                // Hiển thị MessageBox thông báo số sản phẩm đoán đúng và tiền thưởng
                MessageBox.Show($"Bạn đã đoán đúng {soLuongDoanDung} sản phẩm.\nTiền thưởng của bạn: {tongGiaiThuong} ", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show($"Bạn chỉ đoán đúng được {soLuongDoanDung} sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tongGiaiThuong = 0;
            }
            TienThuong = (int)tongGiaiThuong;
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
        }
        private void Giarandom_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = doan;
        }
    }
}
