using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Security;
using TEST.Models;

namespace TEST.Controllers
{
    public class DangNhapController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(TAIKHOAN tk)
        {
            TAIKHOAN tk1 = db.TAIKHOANs.SingleOrDefault(x => x.TENDN == tk.TENDN && x.MATKHAU == tk.MATKHAU && x.ADMIN == true);
            TAIKHOAN tk2 = db.TAIKHOANs.SingleOrDefault(x => x.TENDN == tk.TENDN && x.MATKHAU == tk.MATKHAU && x.ADMIN == false);

            Session["TaiKhoanNotAdmin"] = null;
            Session["TaiKhoanAdmin"] = null;

            if (tk1 != null)
            {
                Session["TaiKhoanAdmin"] = tk1;
            }

            if (tk2 != null)
            {
                Session["TaiKhoanNotAdmin"] = tk2;
            }

            if(Session["TaiKhoanAdmin"] != null)
            {
                Session["TENDN"] = tk1.TENDN;
                return RedirectToAction("GioiThieu");

            }

            if (Session["TaiKhoanNotAdmin"] != null)
            {
                Session["TENDN"] = tk2.TENDN;
                return RedirectToAction("GioiThieuBS", new { id = tk.MABS });
            }
            return RedirectToAction("DangNhap", "DangNhap");
        }
        public ActionResult GioiThieu()
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("DangNhap", "DangNhap");

            return View();
        }
        public ActionResult GioiThieuBS()
        {
            if (Session["TaiKhoanNotAdmin"] == null)
                return RedirectToAction("DangNhap", "DangNhap");
          
            return View();
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoanNotAdmin"] = null;
            Session["TaiKhoanAdmin"] = null;
            return RedirectToAction("DangNhap","DangNhap");
        }
    }
}