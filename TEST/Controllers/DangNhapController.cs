using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TEST.Models;

namespace TEST.Controllers
{
    public class DangNhapController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();
        public int CheckUser(String TENDN, String MATKHAU)
        {
            var test = db.TAIKHOANs.Where(x => x.TENDN == TENDN && x.MATKHAU == MATKHAU).ToList();
            var kq = test.Where(x => x.ADMIN == true).ToList();
            if (kq.Count() > 0)
            {
                Session["TENDN"] = kq.First().TENDN;
                return 2;
                
            }
            else if(test.Count()>0)
            {
                Session["TENDN"] = test.First().TENDN;
                return 1;
            }
            else
            {
                Session["TENDN"] = null;
                return 0;
            }
        }
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(TAIKHOAN tk)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(tk.TENDN, tk.MATKHAU)==2)
                {
                    FormsAuthentication.SetAuthCookie(tk.TENDN, true);
                    return RedirectToAction("GioiThieu");
                }
                else if(CheckUser(tk.TENDN, tk.MATKHAU)==1)
                {
                    FormsAuthentication.SetAuthCookie(tk.TENDN, true);
                    return RedirectToAction("GioiThieuBS");
                }    
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng.");
            }
            return View(tk);
        }
        public ActionResult GioiThieu()
        {   
            if(Session["TENDN"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View();
        }
        public ActionResult GioiThieuBS()
        {
            if (Session["TENDN"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View();
        }
    }
}