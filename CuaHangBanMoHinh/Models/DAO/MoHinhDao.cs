using CuaHangBanMoHinh.Models.EL;
using CuaHangBanMoHinh.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class MoHinhDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public MoHinhDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public int Insert(MOHINH entity)
        {
            db.MOHINHs.Add(entity);
            db.SaveChanges();
            return entity.MaMH;
        }
        public IEnumerable<MOHINH> ListAllPaging(string timKiem, int page, int pageSize)
        {
            IOrderedQueryable<MOHINH> model = db.MOHINHs.OrderByDescending(x => x.MaMH);
            if (!string.IsNullOrEmpty(timKiem))
            {
                model = model.Where(x => x.TenMH.Contains(timKiem)).OrderByDescending(x => x.MaMH);
            }
            return model.ToPagedList(page, pageSize);
        }
        public MOHINH XemChiTiet(int id)
        {
            return db.MOHINHs.Find(id);
        }
        public bool Update(MOHINH entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return false;
            }
            var MOHINH = db.MOHINHs.Find(entity.MaMH);
            MOHINH.TenMH = entity.TenMH;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var MOHINH = db.MOHINHs.Find(id);
                db.MOHINHs.Remove(MOHINH);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //nguoi dung
        public List<MOHINH> SanPhanMoi(int top)
        {
            return db.MOHINHs.OrderByDescending(x => x.NgayCapNhat).Take(top).ToList();
        }
        public List<MOHINH> SanPhamBanChay(int top)
        {
            return db.MOHINHs.OrderByDescending(x => x.SoLuongBan).Take(top).ToList();
        }
        public MOHINH ChiTietMoHinh(int id)
        {
            return db.MOHINHs.Find(id);
        }
        public List<MOHINH> SanPhamLienQuan(int idmohinh)
        {
            var mohinh = db.MOHINHs.Find(idmohinh);
            return db.MOHINHs.Where(x => x.MaMH != idmohinh && x.MaLoaiMH == mohinh.MaLoaiMH).Take(8).ToList();
        }
        public List<MOHINH> SanPhamTheoDanhMuc(int id)
        {
            return db.MOHINHs.Where(x=>x.MaLoaiMH == id).ToList();
        }
        public List<MOHINH> SanPhamTheoPhim(int id)
        {
            return db.MOHINHs.Where(x => x.MaMH == id).ToList();
        }

        public List<string> ListName(string keyword)
        {
            return db.MOHINHs.Where(x => x.TenMH.Contains(keyword)).Select(x => x.TenMH).ToList();
        }
        
    }
}