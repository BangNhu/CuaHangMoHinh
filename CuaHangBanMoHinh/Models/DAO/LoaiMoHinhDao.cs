using CuaHangBanMoHinh.Models.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
namespace CuaHangBanMoHinh.Models.DAO
{
    public class LoaiMoHinhDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public LoaiMoHinhDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public int Insert(LOAIMOHINH entity)
        {
            db.LOAIMOHINHs.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiMH;
        }
        public IEnumerable<LOAIMOHINH> ListAllPaging(string timKiem, int page, int pageSize)
        {
            IOrderedQueryable<LOAIMOHINH> model = db.LOAIMOHINHs.OrderByDescending(x => x.MaLoaiMH);
            if (!string.IsNullOrEmpty(timKiem))
            {
                model = model.Where(x => x.TenMH.Contains(timKiem)).OrderByDescending(x=>x.MaLoaiMH);
            }
            return model.ToPagedList(page,pageSize);
        }
        public LOAIMOHINH XemChiTiet(int id)
        {
            return db.LOAIMOHINHs.Find(id);
        }
        public bool Update(LOAIMOHINH entity)
        {
            try
            {

            }catch(Exception ex)
            {
                return false;
            }
            var loaimohinh = db.LOAIMOHINHs.Find(entity.MaLoaiMH);
            loaimohinh.TenMH = entity.TenMH;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var loaimohinh = db.LOAIMOHINHs.Find(id);
                db.LOAIMOHINHs.Remove(loaimohinh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //nguoi dung
        public List<LOAIMOHINH> ListAll()
        {
            return db.LOAIMOHINHs.OrderByDescending(x => x.MaLoaiMH).ToList();
        }
        
    }
}