using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public abstract class VongChoi : IVongChoi
    {
        public string TenVongChoi { get;  set; }
        public int TienThuong { get;  set; }
        public abstract void Play();
        public VongChoi(string tenVongChoi)
        {
            this.TenVongChoi = tenVongChoi;
        }

    }
}
