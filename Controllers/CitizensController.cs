using kr.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace kr.Controllers
{
    public class CitizensController : Controller
    {
        private KrModel db = new KrModel();

        // GET: Citizens
        public ActionResult Index()
        {
            var vCitizen = db.vCitizen.Include(v => v.cActualAdress).Include(v => v.cRegistrationAdress);
            return View(vCitizen.ToList());
        }

        // GET: Citizens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vCitizen vCitizen = db.vCitizen.Find(id);
            if (vCitizen == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentId = new SelectList(vCitizen.vDocument, "DocumentId", "DocumentId");

            return View(vCitizen);
        }

        // GET: Citizens/Create
        public ActionResult Create()
        {
            ViewBag.ActualAdress = new SelectList(db.cActualAdress, "Id", "FullAdress");
            ViewBag.RegistrationAdress = new SelectList(db.cRegistrationAdress, "Id", "FullAdress");
            return View();
        }

        // POST: Citizens/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IPNCode,Name,Surname,Patronymic,HomeNumber,BirthDate,RegistrationAdress,ActualAdress")] vCitizen vCitizen)
        {
            if (ModelState.IsValid)
            {
                db.vCitizen.Add(vCitizen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActualAdress = new SelectList(db.cActualAdress, "Id", "FullAdress", vCitizen.ActualAdress);
            ViewBag.RegistrationAdress = new SelectList(db.cRegistrationAdress, "Id", "FullAdress", vCitizen.RegistrationAdress);
            return View(vCitizen);
        }

        // GET: Citizens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vCitizen vCitizen = db.vCitizen.Find(id);
            if (vCitizen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActualAdress = new SelectList(db.cActualAdress, "Id", "FullAdress", vCitizen.ActualAdress);
            ViewBag.RegistrationAdress = new SelectList(db.cRegistrationAdress, "Id", "FullAdress", vCitizen.RegistrationAdress);
            return View(vCitizen);
        }

        // POST: Citizens/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IPNCode,Name,Surname,Patronymic,HomeNumber,BirthDate,RegistrationAdress,ActualAdress")] vCitizen vCitizen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vCitizen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActualAdress = new SelectList(db.cActualAdress, "Id", "FullAdress", vCitizen.ActualAdress);
            ViewBag.RegistrationAdress = new SelectList(db.cRegistrationAdress, "Id", "FullAdress", vCitizen.RegistrationAdress);
            return View(vCitizen);
        }

        // GET: Citizens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vCitizen vCitizen = db.vCitizen.Find(id);
            if (vCitizen == null)
            {
                return HttpNotFound();
            }
            return View(vCitizen);
        }

        // POST: Citizens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vCitizen vCitizen = db.vCitizen.Find(id);
            db.vCitizen.Remove(vCitizen);
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
