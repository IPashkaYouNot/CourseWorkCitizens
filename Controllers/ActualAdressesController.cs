using kr.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace kr.Controllers
{
    public class ActualAdressesController : Controller
    {
        private KrModel db = new KrModel();

        // GET: ActualAdresses
        public ActionResult Index()
        {
            var cActualAdress = db.cActualAdress.Include(c => c.cPostCode);
            cActualAdress.Select(c => c.cPostCode).Include(pc => pc.cSettlement);
            return View(cActualAdress.ToList());
        }

        // GET: ActualAdresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cActualAdress cActualAdress = db.cActualAdress.Find(id);
            if (cActualAdress == null)
            {
                return HttpNotFound();
            }
            return View(cActualAdress);
        }

        // GET: ActualAdresses/Create
        public ActionResult Create()
        {
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name");
            return View();
        }

        // POST: ActualAdresses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullAdress,PostCodeId")] cActualAdress cActualAdress)
        {
            if (ModelState.IsValid)
            {
                db.cActualAdress.Add(cActualAdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cActualAdress.PostCodeId);
            return View(cActualAdress);
        }

        // GET: ActualAdresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cActualAdress cActualAdress = db.cActualAdress.Find(id);
            if (cActualAdress == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cActualAdress.PostCodeId);
            return View(cActualAdress);
        }

        // POST: ActualAdresses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullAdress,PostCodeId")] cActualAdress cActualAdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cActualAdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostCodeId = new SelectList(db.cPostCode, "Id", "Name", cActualAdress.PostCodeId);
            return View(cActualAdress);
        }

        // GET: ActualAdresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cActualAdress cActualAdress = db.cActualAdress.Find(id);
            if (cActualAdress == null)
            {
                return HttpNotFound();
            }
            return View(cActualAdress);
        }

        // POST: ActualAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cActualAdress cActualAdress = db.cActualAdress.Find(id);
            db.cActualAdress.Remove(cActualAdress);
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
