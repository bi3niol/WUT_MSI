using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.MinimalRules;
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
            MinimalRuleManager minimalRuleManager = new MinimalRuleManager();
            List<MinimalRule> minimalRules = minimalRuleManager.GenerateRules();
            QuestionHelper.Initialize(minimalRules);
            return GetQuestion(QuestionHelper.StartGenerate());
        }
        public ActionResult GetQuestion(AttributeType questionId = AttributeType.Area)
        {
            var question = new FindCountryQuestionVM(tablesInterface.GetAttribute(questionId));
            return View(question);
        }
        [HttpPost]
        public ActionResult GetQuestion([Bind(Include = "AnswerId")]FindCountryQuestionVM model)
        {
            //TODO: Set Question
            var res = QuestionHelper.GetNextQuestion(model.AnswerId);
            switch (res.Result)
            {
                case QuestionResult.Question:
                    return GetQuestion(res.Question);
                case QuestionResult.NoAnswear:
                case QuestionResult.Answear:
                    return ShowFoundCountries(res.Countries);
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        private ActionResult ShowFoundCountries(string[] countries)
        {
            return View(countries);
        }
    }
}