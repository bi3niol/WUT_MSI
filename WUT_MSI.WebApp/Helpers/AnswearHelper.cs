﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Helpers
{
    public static class AnswearHelper
    {
        private static Dictionary<int, AttributeType> mapping;
        private static DbTablesInterface db;

        static AnswearHelper()
        {
            mapping = new Dictionary<int, AttributeType>();

            db = new DbTablesInterface();

            foreach (var element in db.GetAttributes(item => true))
                foreach (var value in element.AttributeValues)
                    mapping.Add(value.Id, element.Id);
        }

        public static AttributeType Convert(int valueId)
        {
            AttributeType type;
            if (mapping.TryGetValue(valueId, out type))
                return type;
            throw new ArgumentException("Nie ma wartości o podanym id");
        }

        public static string GetCountryName(string ruleId)
        {
            int id = int.Parse(ruleId);

            return db.GetCountryAttributes(id)?.Country.Name;
        }
    }
}