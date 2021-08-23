using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh
{
    [Serializable]
    public class KhachHangLogin
    {
        public int MaKH { get; set; }
        public string TaiKhoan { get; set; }
    }
}