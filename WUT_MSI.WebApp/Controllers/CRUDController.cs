using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.WebApp.Controllers
{
    public class CRUDController : Controller
    {
        private DbLayer db = new DbLayer();

        // GET: CRUD
        public ActionResult Index()
        {
            return View(db.CountryAttributes.ToList());
        }

        // GET: CRUD/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbCountryAttributes dbCountryAttributes = db.CountryAttributes.Find(id);
            if (dbCountryAttributes == null)
            {
                return HttpNotFound();
            }
            return View(dbCountryAttributes);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Country_Id,DistanceAttribute_Id,ClimateAttribute_Id,AreaAttribute_Id,DevelopmentAttribute_Id,RainsAttribute_Id,SafetyAttribute_Id,MedicineAttribute_Id,PopulationAttribute_Id,DensityAttribute_Id,JetAttribute_Id,SeaAttribute_Id,MountainAttribute_Id")] DbCountryAttributes dbCountryAttributes)
        {
            if (ModelState.IsValid)
            {
                db.CountryAttributes.Add(dbCountryAttributes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbCountryAttributes);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbCountryAttributes dbCountryAttributes = db.CountryAttributes.Find(id);
            if (dbCountryAttributes == null)
            {
                return HttpNotFound();
            }
            return View(dbCountryAttributes);
        }

        // POST: CRUD/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Country_Id,DistanceAttribute_Id,ClimateAttribute_Id,AreaAttribute_Id,DevelopmentAttribute_Id,RainsAttribute_Id,SafetyAttribute_Id,MedicineAttribute_Id,PopulationAttribute_Id,DensityAttribute_Id,JetAttribute_Id,SeaAttribute_Id,MountainAttribute_Id")] DbCountryAttributes dbCountryAttributes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbCountryAttributes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbCountryAttributes);
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbCountryAttributes dbCountryAttributes = db.CountryAttributes.Find(id);
            if (dbCountryAttributes == null)
            {
                return HttpNotFound();
            }
            return View(dbCountryAttributes);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DbCountryAttributes dbCountryAttributes = db.CountryAttributes.Find(id);
            db.CountryAttributes.Remove(dbCountryAttributes);
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
