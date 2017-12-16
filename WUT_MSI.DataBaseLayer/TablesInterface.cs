using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.DataBaseLayer
{
    public class TablesInterface
    {
        private DbLayer db;

        public TablesInterface()
        {
            this.db = new DbLayer();
        }

        public void Apply()
        {
            db.SaveChanges();
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
