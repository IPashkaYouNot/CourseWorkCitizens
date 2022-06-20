using kr.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace kr.Controllers
{
    public class cRegistrationAdressesController : Controller
    {
        private KrModel db = new KrModel();

        // GET: cRegistrationAdresses
        public ActionResult Index()
        {
            var cRegistrationAdress = db.cRegistrationAdress.Include(c => c.cPostCode);
            cRegistrationAdress.Select(c => c.cPostCode).Include(pc => pc.cSettlement);
            return View(cRegistrationAdress.ToList());
        }

        // GET: cRegistrationAdresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cRegistrationAdress cRegistrationAdress = db.cRegistrationAdress.Find(id);
            if (cRegistrationAdress == null)
            {
                return HttpNotFound();
            }
            return View(cRegistrationAdress);
        }

        // GET: cRegistrationAdresses/Create
        public ActionResult Create()
        {
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name");
            return View();
        }

        // POST: cRegistrationAdresses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullAdress,PostCodeId")] cRegistrationAdress cRegistrationAdress)
        {
            if (ModelState.IsValid)
            {
                db.cRegistrationAdress.Add(cRegistrationAdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cRegistrationAdress.PostCodeId);
            return View(cRegistrationAdress);
        }

        // GET: cRegistrationAdresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cRegistrationAdress cRegistrationAdress = db.cRegistrationAdress.Find(id);
            if (cRegistrationAdress == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cRegistrationAdress.PostCodeId);
            return View(cRegistrationAdress);
        }

        // POST: cRegistrationAdresses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullAdress,PostCodeId")] cRegistrationAdress cRegistrationAdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRegistrationAdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cRegistrationAdress.PostCodeId);
            return View(cRegistrationAdress);
        }

        // GET: cRegistrationAdresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cRegistrationAdress cRegistrationAdress = db.cRegistrationAdress.Find(id);
            if (cRegistrationAdress == null)
            {
                return HttpNotFound();
            }
            return View(cRegistrationAdress);
        }

        // POST: cRegistrationAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cRegistrationAdress cRegistrationAdress = db.cRegistrationAdress.Find(id);
            db.cRegistrationAdress.Remove(cRegistrationAdress);
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
