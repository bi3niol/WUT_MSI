using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.WebApp.Models
{
    public class FindCountryQuestionVM
    {
        public string Question { get; set; }
        [Required]
        [DisplayName("Wybierz Odpowiedź")]
        public int AnswerId { get; set; }
        public IEnumerable<SelectListItem> Answers { get; set; }
        public FindCountryQuestionVM()
        {

        }
        public FindCountryQuestionVM(DbAttribute attribute)
        {
            Question = attribute.Name;
            Answers = new SelectList(attribute.AttributeValues, "Id", "Value");
        }
    }
}