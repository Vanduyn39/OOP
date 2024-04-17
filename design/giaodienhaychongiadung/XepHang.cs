using System;
using System.Windows.Forms;
using OOP_CLASS_1; // Assuming the Player and PlayerList classes are defined here
using System.IO;

namespace TrangChu
{
    public partial class XepHang : Form
    {
        public XepHang()
        {
            InitializeComponent();
        }

        private void XepHang_Load(object sender, EventArgs e)
        {
            string filePathPlayer = "Player.json";

            // Read the file and populate the dataGridView1 control
            PlayerList playerList = DieuKhien.ReadFile(filePathPlayer);
            dataGridView1.DataSource = playerList;

            // Customize the appearance and behavior of the dataGridView1 control
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the main form when this form is closed
            this.Hide();
            TrangChu f1 = new TrangChu();
            f1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }
    }
}