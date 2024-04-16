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
        private Random random = new Random();
        private SanPhamList sanPhamList;
        private List<TextBox> displayedProducts = new List<TextBox>();
        private List<int> selectedPrices = new List<int>();

        public Form2(SanPhamList sanPhamList)
        {
            InitializeComponent();
            this.sanPhamList = sanPhamList;
            DisplayProductList();

            // Disable direct editing of giarandom textBox
            giarandom.ReadOnly = true;
            // Redirect focus to a different control when giarandom textBox is entered
            giarandom.Enter += (sender, e) => { this.ActiveControl = doan; };
        }

        // Display product list
        private void DisplayProductList()
        {
            for (int i = 0; i < Math.Min(6, sanPhamList.SanPhams.Count); i++) // Use Math.Min to avoid index out of range
            {
                string textBoxName = "textBox" + (i + 2);
                TextBox textBox = FindTextBox(textBoxName); // Find TextBox control by name
                if (textBox != null)
                {
                    textBox.Text = $"{sanPhamList.SanPhams[i].TenSP} - Price: {sanPhamList.SanPhams[i].GiaSP} - {sanPhamList.SanPhams[i].Mota}";
                    displayedProducts.Add(textBox);
                    // Attach click event handler to select product
                    textBox.Click += TextBox_Click;
                }
            }

            // Randomize and display the price in textBox1
            int randomPrice = random.Next(60, 100) * 100; // Random price between 6000 and 10000
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

        // Event handler for selecting products
        private void TextBox_Click(object sender, EventArgs e)
        {
            TextBox clickedTextBox = (TextBox)sender;

            // Reset background color and border style for all products
            foreach (var textBox in displayedProducts)
            {
                if (textBox == clickedTextBox)
                {
                    textBox.BackColor = Color.LightBlue; // Set background color to light blue
                    textBox.BorderStyle = BorderStyle.FixedSingle; // Set border style to FixedSingle
                }
                else
                {
                    textBox.BackColor = Color.White; // Set background color to white
                    textBox.BorderStyle = BorderStyle.None; // Set border style to None
                }
            }

            // Add or remove product from selected list
            if (!displayedProducts.Contains(clickedTextBox))
            {
                displayedProducts.Add(clickedTextBox);
                selectedPrices.Add(ExtractPrice(clickedTextBox.Text)); // Add product price to selected list
            }
            else
            {
                displayedProducts.Remove(clickedTextBox);
                selectedPrices.Remove(ExtractPrice(clickedTextBox.Text)); // Remove product price from selected list
            }

            // If 5 products are selected and the clicked textbox is the 6th one, reset its background color and border style
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

        // Event handler for guess button click
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
            foreach (var textBox in displayedProducts)
            {
                int productPrice = ExtractPrice(textBox.Text);
                if (textBox.BorderStyle == BorderStyle.FixedSingle && productPrice < randomPrice)
                {
                    countCorrectGuess++; // Increment the number of correct guesses by 1
                    totalPrize += productPrice; // Add product price to total prize
                }
            }

            // Limit the number of correct guesses to 4
            countCorrectGuess = Math.Min(countCorrectGuess, 4);

            // Show appropriate message box based on correct guesses
            if (countCorrectGuess > 2)
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
                thuaForm.SetCorrectGuessCount(countCorrectGuess); // Set the correct guess count
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