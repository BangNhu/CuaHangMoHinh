using CuaHangBanMoHinh.Models.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models
{
    public class GioHang
    {
        CuaHangBanMoHinhDbContext db = new CuaHangBanMoHinhDbContext();
        public int iMaMH { get; set; }
        public string sTenMH { get; set; }
        public string sAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get
            {
                return iSoLuong * dDonGia;
            }
        }
        public GioHang(int ms)
        {
            iMaMH = ms;
            MOHINH s = db.MOHINHs.Single(n => n.MaMH == iMaMH);
            sTenMH = s.TenMH;
            sAnh = s.HinhLon;
            dDonGia = double.Parse(s.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}