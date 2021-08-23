using CuaHangBanMoHinh.Models.EL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class LoaiPhimDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public LoaiPhimDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public int Insert(LOAIPHIM entity)
        {
            db.LOAIPHIMs.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiPhim;
        }
        public IEnumerable<LOAIPHIM> ListAllPaging(string timKiem, int page, int pageSize)
        {
            IOrderedQueryable<LOAIPHIM> model = db.LOAIPHIMs.OrderByDescending(x => x.MaLoaiPhim);
            if (!string.IsNullOrEmpty(timKiem))
            {
                model = model.Where(x => x.TenPhim.Contains(timKiem)).OrderByDescending(x => x.MaLoaiPhim);
            }
            return model.ToPagedList(page, pageSize);
        }
        public LOAIPHIM XemChiTiet(int id)
        {
            return db.LOAIPHIMs.Find(id);
        }
        public bool Update(LOAIPHIM entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return false;
            }
            var LOAIPHIM = db.LOAIPHIMs.Find(entity.MaLoaiPhim);
            LOAIPHIM.TenPhim = entity.TenPhim;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var LOAIPHIM = db.LOAIPHIMs.Find(id);
                db.LOAIPHIMs.Remove(LOAIPHIM);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //nguoi dung
        public List<LOAIPHIM> ListAll()
        {
            return db.LOAIPHIMs.OrderByDescending(x => x.MaLoaiPhim).ToList();
        }
    }
}