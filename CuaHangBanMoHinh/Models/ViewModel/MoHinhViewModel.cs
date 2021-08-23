using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.ViewModel
{
    public class MoHinhViewModel
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public string MoTa { get; set; }
        public string HinhLon { get; set; }
        public int SoLuongBan { get; set; }
        public double GiaBan { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}