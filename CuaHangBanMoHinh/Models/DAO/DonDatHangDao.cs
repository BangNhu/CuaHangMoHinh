using CuaHangBanMoHinh.Models.EL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class DonDatHangDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public DonDatHangDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public int Insert(DONDATHANG dondathang)
        {
            db.DONDATHANGs.Add(dondathang);
            db.SaveChanges();
            return dondathang.MaDonHang;
        }
        public IEnumerable<DONDATHANG> ListAllPaging( int page, int pageSize)
        {
            IOrderedQueryable<DONDATHANG> model = db.DONDATHANGs.OrderByDescending(x => x.MaDonHang);
            
            return model.ToPagedList(page, pageSize);
        }
        public DONDATHANG XemChiTiet(int id)
        {
            return db.DONDATHANGs.Find(id);
        }
        
        public bool Delete(int id)
        {
            try
            {
                var DONDATHANG = db.DONDATHANGs.Find(id);
                db.DONDATHANGs.Remove(DONDATHANG);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}