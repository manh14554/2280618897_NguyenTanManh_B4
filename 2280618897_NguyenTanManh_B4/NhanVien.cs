using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2280618897_NguyenTanManh_B4
{
    public class NhanVien
    {
        public int MSNV { get; set; }
        public string TenNV { get; set; }
        public double LuongCB { get; set; }
        public NhanVien() { }

        public NhanVien(int id, string ten, double luong)
        {
            MSNV = id;
            TenNV = ten;
            LuongCB = luong;
        }
    }
}
