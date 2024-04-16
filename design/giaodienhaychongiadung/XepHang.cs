using System;
using System.Windows.Forms;
using OOP_CLASS_1; // Assuming the Player class is defined here

namespace TrangChu
{
    public partial class XepHang : Form
    {
        public XepHang()
        {
            InitializeComponent();
        }

        //private void XepHang_Load(object sender, EventArgs e)
        //{
        //    // Call a method to populate the DataGridView with player data
        //    PopulateDataGridView();
        //}

        //private void PopulateDataGridView()
        //{
        //    // Create some sample players (replace this with your actual player data)
        //    Player[] players = new Player[]
        //    {
        //        new Player("Player 1", VongChoi.Vong1, 100),
        //        new Player("Player 2", VongChoi.Vong2, 200),
        //        new Player("Player 3", VongChoi.Vong3, 150)
        //    };

        //    // Call the sorting method to sort players by prize money
        //    Player.Sort(players, Player.CompareByTienThuong);

        //    // Clear existing rows in the DataGridView
        //    dataGridView1.Rows.Clear();

        //    // Add sorted players to the DataGridView
        //    foreach (Player player in players)
        //    {
        //        dataGridView1.Rows.Add(player.GetTen(), player.GetVongChoi(), player.GetTienThuong());
        //    }
        //}

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the main form when this form is closed
            this.Hide();
            TrangChu f1 = new TrangChu();
            f1.ShowDialog();
        }
    }
}
