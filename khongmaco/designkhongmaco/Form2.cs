using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace designkhongmaco
{
    public partial class Form2 : Form
    {
        private Random random = new Random();
        private List<SanPham> sanPhamList;
        private List<TextBox> displayedProducts = new List<TextBox>(); // List to store displayed products
        private List<int> selectedPrices = new List<int>(); // List to store prices of selected products


        public Form2()
        {
            InitializeComponent();
            // Load product list from JSON file
            string filePathSanPham = "SanPham.json";
            string json = File.ReadAllText(filePathSanPham);
            sanPhamList = JsonSerializer.Deserialize<List<SanPham>>(json); // Deserialize to List<SanPham>
            DisplayProductList();

            // Disable direct editing of giarandom textBox
            giarandom.ReadOnly = true;
            // Redirect focus to a different control when giarandom textBox is entered
            giarandom.Enter += (sender, e) => { this.ActiveControl = doan; };
        }


        // Thay vì truy cập đến textBox8, bạn có thể kiểm tra nếu TextBox được tìm thấy trong mảng Controls trước khi truy cập vào nó.

        private void DisplayProductList()
        {
            // Display product information on TextBoxes
            for (int i = 0; i < Math.Min(6, sanPhamList.Count); i++) // Sửa thành Math.Min(6, sanPhamList.Count)
            {
                string textBoxName = "textBox" + (i + 2);
                TextBox textBox = FindTextBox(textBoxName); // Find TextBox control by name
                if (textBox != null)
                {
                    textBox.Text = $"{sanPhamList[i].TenSP} - Price: {sanPhamList[i].GiaSP} - {sanPhamList[i].Mota}";
                    displayedProducts.Add(textBox);
                    // Attach click event handler to select product
                    textBox.Click += TextBox_Click;
                }
            }

            // Randomize and display the price in textBox1
            int randomPrice = random.Next(60, 100) * 100; // Random price between 1 and 1000
            giarandom.Text = randomPrice.ToString();
        }

        // Helper method to find TextBox control by name
        private TextBox FindTextBox(string name)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Name == name)
                {
                    return textBox;
                }
            }
            return null;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox clickedTextBox = (TextBox)sender;

            // Đặt lại màu nền và kiểu viền cho tất cả các sản phẩm
            foreach (var textBox in displayedProducts)
            {
                if (textBox == clickedTextBox)
                {
                    textBox.BackColor = Color.LightBlue; // Đặt màu nền light blue
                    textBox.BorderStyle = BorderStyle.FixedSingle; // Đặt kiểu viền FixedSingle
                }
                else
                {
                    textBox.BackColor = Color.White; // Đặt màu nền trắng
                    textBox.BorderStyle = BorderStyle.None; // Đặt kiểu viền None
                }
            }

            // Thêm hoặc loại bỏ sản phẩm khỏi danh sách đã chọn
            if (!displayedProducts.Contains(clickedTextBox))
            {
                displayedProducts.Add(clickedTextBox);

                // Trích xuất giá từ thông tin sản phẩm
                int productPrice = ExtractPrice(clickedTextBox.Text);

                // Lưu giá sản phẩm vào danh sách để so sánh sau này
                selectedPrices.Add(productPrice);
            }
            else
            {
                displayedProducts.Remove(clickedTextBox);

                // Loại bỏ giá của sản phẩm không được chọn khỏi danh sách
                int productPrice = ExtractPrice(clickedTextBox.Text);
                selectedPrices.Remove(productPrice);
            }

            // Kiểm tra nếu số lượng sản phẩm đã chọn là 5 và textbox được chọn là textbox thứ 5, loại bỏ màu nền và kiểu viền
            if (displayedProducts.Count == 5 && clickedTextBox == textBox6)
            {
                clickedTextBox.BackColor = Color.White;
                clickedTextBox.BorderStyle = BorderStyle.None;
            }
        }






        // Helper method to extract price from product information
        private int ExtractPrice(string productInfo)
        {
            int startIndex = productInfo.IndexOf("Price:") + 7; // Find the start index of the product price
            int endIndex = productInfo.IndexOf("-", startIndex); // Find the end index of the product price
            string priceString = productInfo.Substring(startIndex, endIndex - startIndex).Trim(); // Extract the price string
            return int.Parse(priceString);
        }

        private void doan_Click(object sender, EventArgs e)
        {
            // Check if random price is a valid integer
            if (!int.TryParse(giarandom.Text, out int randomPrice))
            {
                MessageBox.Show("Invalid input price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int countCorrectGuess = 0; // Number of correct guesses
            int totalPrize = 0; // Total prize

            // Check if each product's price is lower than the random price and calculate total prize
            if (textBox2.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox2.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox2.Text); // Add product price to total prize
            }
            if (textBox3.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox3.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox3.Text); // Add product price to total prize
            }
            if (textBox4.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox4.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox4.Text); // Add product price to total prize
            }
            if (textBox5.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox5.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox5.Text); // Add product price to total prize
            }
            if (textBox6.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox6.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox6.Text); // Add product price to total prize
            }
            if (textBox7.BorderStyle == BorderStyle.FixedSingle && ExtractPrice(textBox7.Text) < randomPrice)
            {
                countCorrectGuess++; // Increment the number of correct guesses by 1
                totalPrize += ExtractPrice(textBox7.Text); // Add product price to total prize
            }

            // Limit the number of correct guesses to 4
            countCorrectGuess = Math.Min(countCorrectGuess, 4);

            if (countCorrectGuess >2)
            {
                // Create a new instance of chucmung form
                chucmung chucmungForm = new chucmung();
                // Set the correct guess count and total prize to the chucmung form
                chucmungForm.SetCorrectGuessCount(countCorrectGuess);
                chucmungForm.SetTienThuong(totalPrize);
                // Show the chucmung form
                chucmungForm.Show();
            }
            else
            {
                thua thuaForm = new thua();
                thuaForm.SetCorrectGuessCount(countCorrectGuess); // Thiết lập số lượng sản phẩm đoán trúng
                thuaForm.Show();
            }

            // Close Form2
            this.Close();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // Display product list when the form loads
            DisplayProductList();
        }
    }
}
