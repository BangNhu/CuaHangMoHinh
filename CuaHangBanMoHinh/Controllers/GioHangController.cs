
using CuaHangBanMoHinh.Models;
using CuaHangBanMoHinh.Models.DAO;
using CuaHangBanMoHinh.Models.EL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangBanMoHinh.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int mamh, string url)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Find(n => n.iMaMH == mamh);
            if (sp == null)
            {
                sp = new GioHang(mamh);
                lstGioHang.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }
            return Redirect(url);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GioHang()
        {
            List<Models.GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "MoHinh");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongSoLuong = TongTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult XoaSPKhoiGioHang(int iMaMH)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.iMaMH == iMaMH);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.iMaMH == iMaMH);
                if (lstGioHang.Count == 0)
                {
                    return RedirectToAction("Index", "MoHinh");
                }
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapNhatGioHang(int iMaMH, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.iMaMH == iMaMH);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("Index", "MoHinh");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
           /* if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return Redirect("~/User/DangNhap?id=2");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "User");
            }*/
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        [HttpPost]
        public ActionResult DatHang(string hoTen, string diaChi, string dienThoai, string email)
        {
            double total = 0;
            var dondathang = new DONDATHANG();
            dondathang.NgayDat = DateTime.Now;
            dondathang.TinhTrangGiaoHang = 1;
            dondathang.DaThanhToan = false;
            var id = new DonDatHangDao().Insert(dondathang);
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            foreach(var item in lstGioHang)
            {
                
                var chiTietDonHang = new CHITIETDATHANG();
                var chiTietDao = new ChiTietDonHangDao();
                chiTietDonHang.MaDonHang = chiTietDonHang.MaDonHang;
                chiTietDonHang.MaMH = item.iMaMH;
                chiTietDonHang.SoLuong = item.iSoLuong;
                chiTietDonHang.DonGia = (decimal)item.dDonGia;
                chiTietDao.Insert(chiTietDonHang);
                total += item.dThanhTien;
            }
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));

            content = content.Replace("{{CustomerName}}", hoTen);
            content = content.Replace("{{Phone}}", dienThoai);
            content = content.Replace("{{Email}}", email);
            content = content.Replace("{{Address}}", diaChi);
            content = content.Replace("{{Total}}", total.ToString("N0"));
            new MailHelper().SendMail(email, "Đơn hàng mới từ Taki Shop", content);

            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}