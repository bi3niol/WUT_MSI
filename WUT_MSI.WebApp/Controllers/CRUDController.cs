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
            SetViewBag();
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

        private void SetViewBag(DbCountry country=null,
            DbAttributeValue Distance = null, DbAttributeValue Climate = null, DbAttributeValue Area = null, DbAttributeValue Development = null,
            DbAttributeValue Rain = null, DbAttributeValue Safety = null, DbAttributeValue Medicine = null, DbAttributeValue Population = null,
            DbAttributeValue Density = null, DbAttributeValue Jet = null, DbAttributeValue Sea = null, DbAttributeValue Mountain = null)
        {
            ViewBag.Countries = new SelectList(db.Countries,"Id", "Name", country==null?db.Countries.FirstOrDefault():country);

            var attributes = db.Attributes.Find(AttributeType.Distance).AttributeValues;
            ViewBag.DistanceAttributes = new SelectList(attributes, "Id", "Value", Distance==null?attributes.FirstOrDefault():Distance);

            attributes = db.Attributes.Find(AttributeType.Climate).AttributeValues;
            ViewBag.ClimateAttributes = new SelectList(attributes, "Id", "Value", Climate == null ? attributes.FirstOrDefault() : Climate);

            attributes = db.Attributes.Find(AttributeType.Area).AttributeValues;
            ViewBag.AreaAttributeValues = new SelectList(attributes, "Id", "Value", Area == null ? attributes.FirstOrDefault() : Area);

            attributes = db.Attributes.Find(AttributeType.Development).AttributeValues;
            ViewBag.DevelopmentAttributeValues = new SelectList(attributes, "Id", "Value", Development == null ? attributes.FirstOrDefault() : Development);

            attributes = db.Attributes.Find(AttributeType.Rains).AttributeValues;
            ViewBag.RainsAttributeValues = new SelectList(attributes, "Id", "Value", Rain == null ? attributes.FirstOrDefault() : Rain);

            attributes = db.Attributes.Find(AttributeType.Safety).AttributeValues;
            ViewBag.SafetyAttributeValues = new SelectList(attributes, "Id", "Value", Safety == null ? attributes.FirstOrDefault() : Safety);

            attributes = db.Attributes.Find(AttributeType.Medicine).AttributeValues;
            ViewBag.MedicineAttributeValues = new SelectList(attributes, "Id", "Value", Medicine == null ? attributes.FirstOrDefault() : Medicine);

            attributes = db.Attributes.Find(AttributeType.Population).AttributeValues;
            ViewBag.PopulationAttributeValues = new SelectList(attributes, "Id", "Value", Population == null ? attributes.FirstOrDefault() : Population);

            attributes = db.Attributes.Find(AttributeType.Density).AttributeValues;
            ViewBag.DensityAttributeValues = new SelectList(attributes, "Id", "Value", Density == null ? attributes.FirstOrDefault() : Density);

            attributes = db.Attributes.Find(AttributeType.Jet).AttributeValues;
            ViewBag.JetAttributeValues = new SelectList(attributes, "Id", "Value", Jet == null ? attributes.FirstOrDefault() : Jet);

            attributes = db.Attributes.Find(AttributeType.Sea).AttributeValues;
            ViewBag.SeaAttributeValues = new SelectList(attributes, "Id", "Value", Sea == null ? attributes.FirstOrDefault() : Sea);

            attributes = db.Attributes.Find(AttributeType.Mountain).AttributeValues;
            ViewBag.MountainAttributeValues = new SelectList(attributes, "Id", "Value", Mountain == null ? attributes.FirstOrDefault() : Mountain);
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
