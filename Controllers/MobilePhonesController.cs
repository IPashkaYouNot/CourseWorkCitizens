using kr.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace kr.Controllers
{
    public class MobilePhonesController : Controller
    {
        private KrModel db = new KrModel();

        // GET: MobilePhones/Create/5
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(new cMobilePhone { Citizen = id});
        }

        // POST: MobilePhones/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Citizen")] cMobilePhone cMobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.cMobilePhone.Add(cMobilePhone);
                db.SaveChanges();
                return RedirectToAction("Edit", "Citizens", new { id = cMobilePhone.Citizen });
            }

            ViewBag.Citizen = new SelectList(db.vCitizen, "Id", "IPNCode", cMobilePhone.Citizen);
            return View(cMobilePhone);
        }

        // GET: MobilePhones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cMobilePhone cMobilePhone = db.cMobilePhone.Find(id);
            if (cMobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(cMobilePhone);
        }

        // POST: MobilePhones/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Citizen")] cMobilePhone cMobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMobilePhone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Citizens", new { id = cMobilePhone.Citizen });
            }
            return View(cMobilePhone);
        }

        // GET: MobilePhones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cMobilePhone cMobilePhone = db.cMobilePhone.Find(id);
            if (cMobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(cMobilePhone);
        }

        // POST: MobilePhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cMobilePhone cMobilePhone = db.cMobilePhone.Find(id);
            var citId = cMobilePhone.Citizen;
            db.cMobilePhone.Remove(cMobilePhone);
            db.SaveChanges();
            return RedirectToAction("Edit", "Citizens", new { id = citId });
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
