using CuaHangBanMoHinh.Models.EL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class KhachHangDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public KhachHangDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public IEnumerable<KHACHHANG> ListAllPaging(string timKiem, int page, int pageSize)
        {
            IOrderedQueryable<KHACHHANG> model = db.KHACHHANGs.OrderByDescending(x => x.MaKH);
            if (!string.IsNullOrEmpty(timKiem))
            {
                model = model.Where(x => x.HoTen.Contains(timKiem)).OrderByDescending(x => x.MaKH);
            }
            return model.ToPagedList(page, pageSize);
        }
        public KHACHHANG XemChiTiet(int id)
        {
            return db.KHACHHANGs.Find(id);
        }
        public bool Update(KHACHHANG entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return false;
            }
            var KHACHHANG = db.KHACHHANGs.Find(entity.MaKH);
            KHACHHANG.HoTen = entity.HoTen;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var KHACHHANG = db.KHACHHANGs.Find(id);
                db.KHACHHANGs.Remove(KHACHHANG);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //ng dung
        public long Insert(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MaKH;
        }
        public bool KiemTraTaiKhoan(string taiKhoan)
        {
            return db.KHACHHANGs.Count(x => x.TaiKhoan == taiKhoan) > 0;

        }
        public KHACHHANG LayID(string taiKhoan)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.TaiKhoan == taiKhoan);
        }
        public bool Login(string taiKhoan, string matKhau)
        {
            var ketqua = db.KHACHHANGs.Count(x => x.TaiKhoan == taiKhoan && x.MatKhau == matKhau);
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