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

        public void AddCountryAttributes(DbCountryAttributes[] attribute)
        {
            foreach(var element in attribute)
                db.CountryAttributes.Add(element);
            Apply();
        }

        public DbCountryAttributes[] GetCountryAttributes(DbCountry country)
        {
            return db.CountryAttributes.Where(item => item.Country.Id == country.Id).ToArray();
        }

        public bool RemoveCountryAttributes(DbCountry country)
        {
            var attributes = GetCountryAttributes(country);
            db.CountryAttributes.RemoveRange(attributes);
            Apply();
            return attributes != null;
        }
    }
}
