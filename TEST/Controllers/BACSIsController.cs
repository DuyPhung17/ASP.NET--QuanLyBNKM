using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEST.Models;

namespace TEST.Controllers
{
    public class BACSIsController : Controller
    {
        private QLBNKMEntities db = new QLBNKMEntities();

        // GET: BACSIs
        public ActionResult Index()
        {
            return View(db.BACSIs.ToList());
        }
        [HttpPost]
        public ActionResult Index(String tenBS)
        {
            var bacSis = db.BACSIs.Where(abc => abc.TENBS.Contains(tenBS));
            return View(bacSis.ToList());
        }


        // GET: BACSIs/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACSI bACSI = db.BACSIs.Find(id);
            if (bACSI == null)
            {
                return HttpNotFound();
            }
            return View(bACSI);
        }

        // GET: BACSIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BACSIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABS,TENBS,NGAYSINHBS,SDTBS,DIACHIBS,CHUYENMON,TRINHDO")] BACSI bACSI)
        {
            var anhBS = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(anhBS.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            anhBS.SaveAs(path);

            if (ModelState.IsValid)
            {
                bACSI.ANHBS = postedFileName;
                db.BACSIs.Add(bACSI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bACSI);
        }

        // GET: BACSIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACSI bACSI = db.BACSIs.Find(id);
            if (bACSI == null)
            {
                return HttpNotFound();
            }
            return View(bACSI);
        }

        // POST: BACSIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABS,TENBS,NGAYSINHBS,SDTBS,DIACHIBS,CHUYENMON,TRINHDO")] BACSI bACSI)
        {
            var anhBS = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(anhBS.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                anhBS.SaveAs(path);
            }
            catch
            { }

            if (ModelState.IsValid)
            {
                db.Entry(bACSI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bACSI);
        }

        // GET: BACSIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACSI bACSI = db.BACSIs.Find(id);
            if (bACSI == null)
            {
                return HttpNotFound();
            }
            return View(bACSI);
        }

        // POST: BACSIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BACSI bACSI = db.BACSIs.Find(id);
            db.BACSIs.Remove(bACSI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
