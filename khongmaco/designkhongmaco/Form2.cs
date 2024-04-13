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
        }

        // Thay vì truy cập đến textBox8, bạn có thể kiểm tra nếu TextBox được tìm thấy trong mảng Controls trước khi truy cập vào nó.

        private void DisplayProductList()
        {
            // Display product information on TextBoxes
            for (int i = 0; i < Math.Min(7, sanPhamList.Count); i++)
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
            int randomPrice = random.Next(55, 100) * 100; // Random price between 1 and 1000
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

            // Check if maximum number of selected products has been reached
            if (displayedProducts.Count >= 4 && !displayedProducts.Contains(clickedTextBox))
            {
                MessageBox.Show("You can only select up to 4 products.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var textBox in displayedProducts)
            {
                if (textBox == clickedTextBox)
                {
                    textBox.BackColor = Color.LightBlue; // Set background color to light blue for the selected textbox
                    textBox.BorderStyle = BorderStyle.FixedSingle; // Highlight by setting border style to FixedSingle
                }
                else
                {
                    textBox.BackColor = Color.White; // Reset background color to white for other textboxes
                    textBox.BorderStyle = BorderStyle.None; // Set border style to None for other textboxes
                }
            }

            if (!displayedProducts.Contains(clickedTextBox))
            {
                displayedProducts.Add(clickedTextBox);

                // Extract price from product information
                int productPrice = ExtractPrice(clickedTextBox.Text);

                // Save product price to a list for later comparison
                selectedPrices.Add(productPrice);
            }
            else
            {
                displayedProducts.Remove(clickedTextBox);

                // Remove price of the deselected product from the list
                int productPrice = ExtractPrice(clickedTextBox.Text);
                selectedPrices.Remove(productPrice);
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

            if (countCorrectGuess >= 2)
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

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Display product list when the form loads
            DisplayProductList();
        }
    }
}
