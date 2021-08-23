using CuaHangBanMoHinh.Models.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class ChiTietDonHangDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public ChiTietDonHangDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public bool Insert(CHITIETDATHANG chitiet)
        {
            try
            {
                db.CHITIETDATHANGs.Add(chitiet);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
