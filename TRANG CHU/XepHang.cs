using System;
using System.Windows.Forms;
using OOP_CLASS_1;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Drawing;

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
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    MessageBox.Show("File rỗng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

                DataGridViewCellStyle headerCellStyle = new DataGridViewCellStyle();
                headerCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                headerCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

                DataGridViewColumn rankColumn = new DataGridViewColumn();
                rankColumn.HeaderText = "Hạng";
                rankColumn.Name = "Hạng";
                rankColumn.CellTemplate = new DataGridViewTextBoxCell();
                rankColumn.HeaderCell.Style = headerCellStyle;
                rankColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Add(rankColumn);

                DataGridViewColumn playerNameColumn = new DataGridViewColumn();
                playerNameColumn.HeaderText = "Tên";
                playerNameColumn.Name = "Tên";
                playerNameColumn.CellTemplate = new DataGridViewTextBoxCell();
                playerNameColumn.HeaderCell.Style = headerCellStyle;
                playerNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Add(playerNameColumn);

                DataGridViewColumn prizeMoneyColumn = new DataGridViewColumn();
                prizeMoneyColumn.HeaderText = "Tiền Thưởng";
                prizeMoneyColumn.Name = "Tiền Thưởng";
                prizeMoneyColumn.CellTemplate = new DataGridViewTextBoxCell();
                prizeMoneyColumn.HeaderCell.Style = headerCellStyle;
                prizeMoneyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                MessageBox.Show("Lỗi đọc file.");
            }
        }
    }
}
