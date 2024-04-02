using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Class
{
    public abstract class VongChoi : IVongChoi
    {
        public string TenVongChoi { get; protected set; }
        public int TienThuong { get; protected set; }
        public abstract void Play();
        public VongChoi(string tenVongChoi,int tienthuong)
        {
            this.TenVongChoi= tenVongChoi;
            this.TienThuong = tienthuong;
        }

    }
}
