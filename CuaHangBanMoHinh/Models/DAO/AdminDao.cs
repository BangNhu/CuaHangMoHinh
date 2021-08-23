using CuaHangBanMoHinh.Models.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class AdminDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public AdminDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public long Insert(ADMIN entity)
        {
            db.ADMINs.Add(entity);
            db.SaveChanges();
            return entity.MaAd;
        }
        public ADMIN LayID(string tenDN)
        {
            return db.ADMINs.SingleOrDefault(x => x.TenDN == tenDN);
        }
        public bool Login(string tenDN, string matKhau)
        {
            var ketqua = db.ADMINs.Count(x => x.TenDN == tenDN && x.MatKhau == matKhau);
            if (ketqua > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}