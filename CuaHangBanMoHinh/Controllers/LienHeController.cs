using CuaHangBanMoHinh.Common;
using CuaHangBanMoHinh.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangBanMoHinh.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            // handle in here
            if (LienHe.SendMail(contact))
            {
                RedirectToAction("Index","MoHinh");
            }
            return View(contact);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
    }
}