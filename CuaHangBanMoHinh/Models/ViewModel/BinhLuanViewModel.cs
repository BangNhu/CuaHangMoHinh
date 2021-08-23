using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.ViewModel
{
    public class BinhLuanViewModel
    {
        public int MaBL { get; set; }
        public int MaKH { get; set; }
        public int MaMH { get; set; }
        public string NoiDung { get; set; }
        public int DanhGia { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public string TenKH { set; get; }
        
    }
}