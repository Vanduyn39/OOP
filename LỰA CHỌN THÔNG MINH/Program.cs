using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vòng_4
{
    internal static class Program
    {
        // Khai báo biến toàn cục
        //public static SanPhamList sanPhamList;
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
            Player currentPlayer = playerList.Players[0];
            Application.Run(new MainVong4(sanPhamList, currentPlayer));
        }
    }
}
