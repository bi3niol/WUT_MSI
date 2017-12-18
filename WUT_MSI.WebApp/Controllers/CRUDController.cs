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
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.WebApp.Controllers
{
    public class CRUDController : Controller
    {
        private DbTablesInterface tablesInterface = new DbTablesInterface();
        // GET: CRUD
        public ActionResult Index()
        {
            return View(tablesInterface.GetCountryAttributes(a=>true));
        }

        //// GET: CRUD/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DbCountryAttributes dbCountryAttributes = tablesInterface.GetCountryAttributes(id.Value);
        //    if (dbCountryAttributes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dbCountryAttributes);
        //}

        // GET: CRUD/Create
        public ActionResult Create()
        {
            var model = new CRUDModel();
            SetListsToModel(model);
            return View(model);
        }

        // POST: CRUD/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Country_Id,DistanceAttribute_Id,ClimateAttribute_Id,AreaAttribute_Id,DevelopmentAttribute_Id,RainsAttribute_Id,SafetyAttribute_Id,MedicineAttribute_Id,PopulationAttribute_Id,DensityAttribute_Id,JetAttribute_Id,SeaAttribute_Id,MountainAttribute_Id")] CRUDModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateOrCreateCountryAttributes(tablesInterface, true);
                return RedirectToAction("Index");
            }
            SetListsToModel(model);
            return View(model);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbCountryAttributes dbCountryAttributes = tablesInterface.GetCountryAttributes(id.Value);
            if (dbCountryAttributes == null)
            {
                return HttpNotFound();
            }
            return View(CRUDModel.GedModel(dbCountryAttributes));
        }

        // POST: CRUD/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Country_Id,DistanceAttribute_Id,ClimateAttribute_Id,AreaAttribute_Id,DevelopmentAttribute_Id,RainsAttribute_Id,SafetyAttribute_Id,MedicineAttribute_Id,PopulationAttribute_Id,DensityAttribute_Id,JetAttribute_Id,SeaAttribute_Id,MountainAttribute_Id")] CRUDModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateOrCreateCountryAttributes(tablesInterface);
                return RedirectToAction("Index");
            }
            SetListsToModel(model);
            return View(model);
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbCountryAttributes dbCountryAttributes = tablesInterface.GetCountryAttributes(id.Value);
            if (dbCountryAttributes == null)
            {
                return HttpNotFound();
            }
            tablesInterface.RemoveCountryAttributes(dbCountryAttributes);
            return RedirectToAction("Index");
        }

        //// POST: CRUD/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    DbCountryAttributes dbCountryAttributes = db.CountryAttributes.Find(id);
        //    db.CountryAttributes.Remove(dbCountryAttributes);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        private void SetListsToModel(CRUDModel model)
        {
            var countries = tablesInterface.GetCountries(c => true);
            model.CountryId = new SelectList(countries, "Id", "Name", model.Country_Id == 0 ? countries.FirstOrDefault()?.Id : model.Country_Id);

            var attributes = tablesInterface.GetAttributeValue(AttributeType.Distance);
            model.DistanceAttributeId = new SelectList(attributes, "Id", "Value", model.DistanceAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.DistanceAttribute_Id);
            attributes = tablesInterface.GetAttributeValue(AttributeType.Climate);
            model.ClimateAttributeId = new SelectList(attributes, "Id", "Value", model.ClimateAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.ClimateAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Area);
            model.AreaAttributeId = new SelectList(attributes, "Id", "Value", model.AreaAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.AreaAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Development);
            model.DevelopmentAttributeId = new SelectList(attributes, "Id", "Value", model.DevelopmentAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.DevelopmentAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Rains);
            model.RainsAttributeId = new SelectList(attributes, "Id", "Value", model.RainsAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.RainsAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Safety);
            model.SafetyAttributeId = new SelectList(attributes, "Id", "Value", model.SafetyAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.SafetyAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Medicine);
            model.MedicineAttributeId = new SelectList(attributes, "Id", "Value", model.MedicineAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.MedicineAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Population);
            model.PopulationAttributeId = new SelectList(attributes, "Id", "Value", model.PopulationAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.PopulationAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Density);
            model.DensityAttributeId = new SelectList(attributes, "Id", "Value", model.DensityAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.DensityAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Jet);
            model.JetAttributeId = new SelectList(attributes, "Id", "Value", model.JetAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.JetAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Sea);
            model.SeaAttributeId = new SelectList(attributes, "Id", "Value", model.SeaAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.SeaAttribute_Id);

            attributes = tablesInterface.GetAttributeValue(AttributeType.Mountain);
            model.MountainAttributeId = new SelectList(attributes, "Id", "Value", model.MountainAttribute_Id == 0 ? attributes.FirstOrDefault()?.Id : model.MountainAttribute_Id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //
            }
            base.Dispose(disposing);
        }
    }
}
