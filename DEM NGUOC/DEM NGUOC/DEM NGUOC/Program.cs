using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace DEM_NGUOC
{
    public  class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SanPhamList sanPhamList = new SanPhamList();
            SanPham sanPham = new SanPham();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien=new DieuKhien(playerList,sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_DN(sanPhamList,sanPham));
        }
    }
}
