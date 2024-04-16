using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vòng_2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Assume that the first player in the playerList is the currently logged-in player
            Player currentPlayer = playerList.Players[0];
            Application.Run(new GuessThePrice(sanPhamList, currentPlayer.Ten));
        }
    }
}