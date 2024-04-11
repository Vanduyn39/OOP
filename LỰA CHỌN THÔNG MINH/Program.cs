using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vòng_4
{
    internal static class Program
    {
        // Khai báo biến toàn cục
        public static SanPhamList sanPhamList;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Khởi tạo danh sách sản phẩm
            sanPhamList = new SanPhamList();

            // Thêm sản phẩm vào danh sách ở đây...

            // Khởi tạo và hiển thị Form1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(sanPhamList));
        }
    }
}
