using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public interface IVongChoi
    {
        string TenVongChoi { get; }
        int TienThuong { get; }
        void Play();

    }
}
