using CuaHangBanMoHinh.Common;
using CuaHangBanMoHinh.Models.DAO;
using CuaHangBanMoHinh.Models.EL;
using CuaHangBanMoHinh.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangBanMoHinh.Controllers
{
    public class MoHinhController : Controller
    {
        CuaHangBanMoHinhDbContext db = new CuaHangBanMoHinhDbContext();
        // GET: MoHinh
        public ActionResult Index()
        {
            var moHinhDao = new MoHinhDao();
            ViewBag.SanPhamMoi = moHinhDao.SanPhanMoi(8);
            ViewBag.SanPhamBanChay = moHinhDao.SanPhamBanChay(8);
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult LoaiMoHinhPartial()
        {
            var model = new LoaiMoHinhDao().ListAll();
            return PartialView(model);
        }
        public PartialViewResult LoaiPhimPartial()
        {
            var model = new LoaiPhimDao().ListAll();
            return PartialView(model);
        }
        public PartialViewResult _NavbarPartial()
        {
            var model = new LoaiMoHinhDao().ListAll();
            return PartialView(model);
        }
        public ActionResult SanPhamLienQuanPartial(int id)
        {
            var mohinh = new MoHinhDao().ChiTietMoHinh(id);
            ViewBag.SanPhamLienQuan = new MoHinhDao().SanPhamLienQuan(id); 
            return PartialView(mohinh);

        }
        public ActionResult SanPhamTheoDanhMuc(int idLoaiMH, int? page)
        {
            ViewBag.MaCD = idLoaiMH;
            int iSize = 8;
            int iPageNum = (page ?? 1);
            var mohinh = new MoHinhDao().SanPhamTheoDanhMuc(idLoaiMH);
            return View(mohinh.ToPagedList(iPageNum, iSize));
        }
        public ActionResult SanPhamTheoPhim(int idLoaiMH, int? page)
        {
            ViewBag.MaCD = idLoaiMH;
            int iSize = 8;
            int iPageNum = (page ?? 1);
            var mohinh = new MoHinhDao().SanPhamTheoPhim(idLoaiMH);
            return View(mohinh.ToPagedList(iPageNum, iSize));
        }
        public JsonResult ListName(string q)
        {
            var db = new MoHinhDao().ListName(q);
            return Json(new
            {
                db = db,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult TimKiemSanPham(string strSearch, int? page)
        {
            int iSize = 8;
            int iPageNum = (page ?? 1);
            ViewBag.Search = strSearch;
            if (!string.IsNullOrEmpty(strSearch))
            {
                var listMH = from sp in db.MOHINHs where sp.TenMH.Contains(strSearch) select sp;
                var kq = listMH.OrderByDescending(x => x.MaMH);
                return View(kq.ToPagedList(iPageNum, iSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChiTietMoHinh(int id)
        {
            var sp = from s in db.MOHINHs where s.MaMH == id select s;
            var avg = (from x in db.BINHLUANs where x.MaMH == id select x.DanhGia).Average();
            ViewBag.TongCmt = db.BINHLUANs.Where(x => x.MaMH == id).Count();
            //float avg = Convert.ToSingle((from x in db.BINHLUANs where x.MaMH == id select x.Rating).Average());
            ViewBag.AvgRating = avg;

            return View(sp.Single());
        }

        [HttpPost]
        public ActionResult ChiTietMoHinh(FormCollection collection, BINHLUAN cmt, MOHINH sp)
        {
            //Thêm đơn hàng
            var session = (KhachHangLogin)Session[CuaHangBanMoHinh.Common.CommonConstants.KHACHHANG_SESSION];


            var iMaMH = int.Parse(collection["MaMH"]);
            var sBinhLuan = collection["BinhLuan"];
            var iRate = int.Parse(collection["Rate"]);
            if (String.IsNullOrEmpty(sBinhLuan))
            {
                ViewData["err1"] = "Vui lòng nhập bình luận";
            }
            else
            {
                var dao = new BinhLuanDao();
                cmt.MaKH = session.MaKH;
                cmt.ThoiGianDang = DateTime.Now;
                cmt.DanhGia = iRate;
                cmt.NoiDung = sBinhLuan;
                cmt.MaMH = iMaMH;
                dao.Insert(cmt);

            }
            //return View();
            return RedirectToAction("ChiTietMoHinh", "MoHinh", new { MaMH = iMaMH });
        }

        public ActionResult NhanXetPartial(int id)
        {
            var dao = new BinhLuanDao().dsBinhLuan(id);
            return PartialView(dao);
        }
        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }

    }
}