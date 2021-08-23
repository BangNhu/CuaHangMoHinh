using CuaHangBanMoHinh.Models.EL;
using CuaHangBanMoHinh.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.DAO
{
    public class BinhLuanDao
    {
        CuaHangBanMoHinhDbContext db = null;
        public BinhLuanDao()
        {
            db = new CuaHangBanMoHinhDbContext();
        }
        public long Insert(BINHLUAN entity)
        {
            db.BINHLUANs.Add(entity);
            db.SaveChanges();
            return entity.MaBL;
        }
        public List<BinhLuanViewModel> dsBinhLuan(int id)
        {
            var model = from a in db.BINHLUANs
                        join b in db.KHACHHANGs on a.MaKH equals b.MaKH
                        where a.MaMH == id
                        select new BinhLuanViewModel()
                        {
                            MaKH = (int)a.MaKH,
                            MaBL = a.MaBL,
                            MaMH = (int)a.MaMH,
                            ThoiGianDang = (DateTime)a.ThoiGianDang,
                            DanhGia = (int)a.DanhGia,
                            TenKH = b.TaiKhoan
                        };
            model.Where(x => x.MaMH == id).OrderByDescending(cmt => cmt.ThoiGianDang).Take(6);
            return model.ToList();
            
        }
    }
}