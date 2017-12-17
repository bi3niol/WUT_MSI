using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.DataBaseLayer
{
    public class DbTablesInterface
    {
        private DbLayer db;

        public DbTablesInterface()
        {
            this.db = new DbLayer();
        }

        public void Apply()
        {
            db.SaveChanges();
        }

        public void AddCountry(DbCountry country)
        {
            db.Countries.Add(country);
            Apply();
        }

        public DbCountry[] GetCountries(Func<DbCountry,bool> predicate)
        {
            return db.Countries.Where(predicate).ToArray();
        }

        public bool RemoveCountry(DbCountry country)
        {
            var result = db.Countries.Remove(country);
            Apply();
            return result != null; 
        }

        public void AddAttribute(DbAttribute attribute)
        {
            db.Attributes.Add(attribute);
            Apply();
        }

        public DbAttribute[] GetAttributes(Func<DbAttribute, bool> predicate)
        {
            return db.Attributes.Where(predicate).ToArray();
        }

        public bool RemoveAttribute(DbAttribute attribute)
        {
            var result = db.Attributes.Remove(attribute);
            Apply();
            return result != null;
        }

        public void AddAttributeValue(DbAttributeValue value)
        {
            db.AttributeValues.Add(value);
            Apply();
        }

        public DbAttributeValue[] GetAttributeValues(Func<DbAttributeValue, bool> predicate)
        {
            return db.AttributeValues.Where(predicate).ToArray();
        }

        public bool RemoveAttributeValue(DbAttributeValue value)
        {
            var result = db.AttributeValues.Remove(value);
            Apply();
            return result != null;
        }

        public void AddCountryAttributes(DbCountryAttributes element)
        {
            db.CountryAttributes.Add(element);
            Apply();
        }

        public DbCountryAttributes[] GetCountryAttributes(Func<DbCountryAttributes, bool> predicate)
        {
            return db.CountryAttributes.Where(predicate).ToArray();
        }

        public DbAttributeValue[] GetAttributeValue(AttributeType type)
        {
            return GetAttributes(item => item.Id == type).FirstOrDefault()?.AttributeValues.ToArray();
        }

        public bool RemoveCountryAttributes(DbCountryAttributes element)
        {
            var result = db.CountryAttributes.Remove(element);
            Apply();
            return result != null;
        }
    }
}
