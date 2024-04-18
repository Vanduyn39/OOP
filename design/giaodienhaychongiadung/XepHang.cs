using System;
using System.Windows.Forms;
using OOP_CLASS_1;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web.UI;

namespace TrangChu
{
    public partial class XepHang : Form
    {
        private List<Player> players;

        public XepHang()
        {
            InitializeComponent();
        }

        private void XepHang_Load(object sender, EventArgs e)
        {

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

        private List<Player> XepHangNguoiChoi(string filePathPlayer)
        {
            try
            {
                if (File.Exists(filePathPlayer))
                {
                    string fileContent = File.ReadAllText(filePathPlayer);
                    PlayerList playerList = JsonSerializer.Deserialize<PlayerList>(fileContent);
                    if (playerList != null && playerList.Players != null)
                    {
                        players = playerList.Players;
                        players.Sort(SoSanhPlayerByTien);
                        return players;
                    }
                }
                else
                {
                    MessageBox.Show("Player data file does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return null;
        }


        public int SoSanhPlayerByTien(Player p1, Player p2)
        {
            return -p1.TienThuong.CompareTo(p2.TienThuong);
        }

        private void XepHang_Load_1(object sender, EventArgs e)
        {
            string filePathPlayer = "Player.json";
            List<Player> rankedPlayers = XepHangNguoiChoi(filePathPlayer);
            if (rankedPlayers != null)
            {
                dataGridView1.Columns.Clear();
                DataGridViewColumn rankColumn = new DataGridViewColumn();
                rankColumn.HeaderText = "Hạng";
                rankColumn.Name = "Hạng";
                rankColumn.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView1.Columns.Add(rankColumn);

                DataGridViewColumn playerNameColumn = new DataGridViewColumn();
                playerNameColumn.HeaderText = "Tên";
                playerNameColumn.Name = "Tên";
                playerNameColumn.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView1.Columns.Add(playerNameColumn);

                DataGridViewColumn prizeMoneyColumn = new DataGridViewColumn();
                prizeMoneyColumn.HeaderText = "Tiền Thưởng";
                prizeMoneyColumn.Name = "Tiền Thưởng";
                prizeMoneyColumn.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView1.Columns.Add(prizeMoneyColumn);

                dataGridView1.Rows.Clear();
                for (int i = 0; i < rankedPlayers.Count; i++)
                {
                    Player player = rankedPlayers[i];
                    if (player.TienThuong > 0)
                    {
                        dataGridView1.Rows.Add(i + 1, player.Ten, player.TienThuong);
                    }
                }
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
            }
            else
            {
                MessageBox.Show("Error occurred while reading the file.");
            }
        }
    }
}