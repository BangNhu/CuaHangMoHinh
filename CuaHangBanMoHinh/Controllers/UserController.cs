using CuaHangBanMoHinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangBanMoHinh.Models.DAO;
using CuaHangBanMoHinh.Models.EL;
using CuaHangBanMoHinh.Common;

namespace CuaHangBanMoHinh.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                var ketqua = dao.Login(model.TaiKhoan, MaHoa.GetMD5(model.MatKhau));
                if (ketqua)
                {
                    var khachhang = dao.LayID(model.TaiKhoan);
                    var khachhangSession = new KhachHangLogin();
                    khachhangSession.TaiKhoan = khachhang.TaiKhoan;
                    khachhangSession.MaKH = khachhang.MaKH;
                    Session.Add(CommonConstants.KHACHHANG_SESSION, khachhangSession);
                    return RedirectToAction("Index", "MoHinh");
                }

                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            
            return View(model);
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKyModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                if (dao.KiemTraTaiKhoan(model.TaiKhoan))
                {
                    ModelState.AddModelError("","Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var khachhang = new KHACHHANG();
                    khachhang.HoTen = model.HoTen;
                    khachhang.TaiKhoan = model.TaiKhoan;
                    khachhang.MatKhau = MaHoa.GetMD5(model.MatKhau);
                    khachhang.Email = model.Email;
                    khachhang.DiaChi = model.DiaChi;
                    khachhang.DienThoai = model.DienThoai;
                    var ketqua = dao.Insert(khachhang);
                    if(ketqua > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new DangKyModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            
            return View(model);
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstants.KHACHHANG_SESSION] = null;
            return RedirectToAction("DangNhap");
        }

        
    }
}