using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.WebApp.Controllers
{
    public class CountryFinderController : Controller
    {
        private DbTablesInterface tablesInterface = new DbTablesInterface();
        // GET: CountryFinder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StartFind()
        {
            //TODO: Resetowanie pytan

            return RedirectToAction("GetQuestion");
        }
        public ActionResult GetQuestion()
        {
            AttributeType questionId=AttributeType.Area;
            //sprawdzenie czy jest jeszcze jakies pytanie, jesli nie to znaczy ze znaleziono panstwo
            bool hasQuestion = false;//TODO:
            if (hasQuestion)
                questionId = AttributeType.Area;//TODO: get questionId
            else
                return ShowFoundCountries();
            //Pobieranie pytania (IdPytania)
            var question = new FindCountryQuestionVM(tablesInterface.GetAttribute(questionId));
            return View(question);
        }
        [HttpPost]
        public ActionResult GetQuestion([Bind(Include = "AnswerId")]FindCountryQuestionVM model)
        {
            //TODO: Set Question

            return RedirectToAction("GetQuestion");
        }

        private ActionResult ShowFoundCountries()
        {
            var country = new List<string>() { "Poland" };//TODO;
            return View(country);
        }
    }
}