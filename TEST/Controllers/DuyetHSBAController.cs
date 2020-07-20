using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST.Models;

namespace TEST.Controllers
{
    public class DuyetHSBAController : Controller
    {
        QLBNKMEntities db = new QLBNKMEntities();
        // GET: DuyetHSBA
        public ActionResult Index(int id = 0)
        {   
            if (id!=0)
            {
                var hs = db.HSBAs.Find(id);
                if (hs.DUYET)
                    hs.DUYET = false;
                else
                    hs.DUYET = true;
                db.Entry(hs).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            var lisths = db.HSBAs.Where(m => m.DUYET == true);
            return View(lisths.ToList());
        }
        public ActionResult hienthihsba()
        {
            var hSBAs = db.HSBAs.Where(m => m.DUYET == false);
            return View(hSBAs.ToList());
        }

    }
}