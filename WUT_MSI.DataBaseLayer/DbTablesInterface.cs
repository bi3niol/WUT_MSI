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

        public void ClearDb()
        {
            foreach (var element in GetCountryAttributes(item => true))
                RemoveCountryAttributes(element);

            foreach (var element in GetAttributeValues(item => true))
                RemoveAttributeValue(element);

            foreach (var element in GetAttributes(item => true))
                RemoveAttribute(element);

            foreach (var element in GetCountries(item => true))
                RemoveCountry(element);

            Apply();
        }

        public DbCountry AddCountry(DbCountry country)
        {
            var result = db.Countries.Add(country);
            Apply();
            return result;
        }

        public DbCountry[] GetCountries(Func<DbCountry,bool> predicate)
        {
            return db.Countries.Where(predicate).ToArray();
        }

        public DbCountry GetCountry(int id)
        {
            return db.Countries.FirstOrDefault(item => item.Id == id);
        }

        public bool RemoveCountry(DbCountry country)
        {
            var result = db.Countries.Remove(country);
            Apply();
            return result != null; 
        }

        public DbAttribute AddAttribute(DbAttribute attribute)
        {
            var result = db.Attributes.Add(attribute);
            Apply();
            return result;
        }

        public DbAttribute[] GetAttributes(Func<DbAttribute, bool> predicate)
        {
            return db.Attributes.Where(predicate).ToArray();
        }

        public DbAttribute GetAttribute(AttributeType id)
        {
            return db.Attributes.FirstOrDefault(item => item.Id == id);
        }

        public bool RemoveAttribute(DbAttribute attribute)
        {
            var result = db.Attributes.Remove(attribute);
            Apply();
            return result != null;
        }

        public void AddAttributeValueToAttribute(DbAttribute attribute, DbAttributeValue value)
        {
            attribute.AttributeValues.Add(value);
            Apply();
        }

        public DbAttributeValue AddAttributeValue(DbAttributeValue value)
        {
            var result = db.AttributeValues.Add(value);
            Apply();
            return result;
        }

        public DbAttributeValue[] GetAttributeValues(Func<DbAttributeValue, bool> predicate)
        {
            return db.AttributeValues.Where(predicate).ToArray();
        }

        public DbAttributeValue GetAttributeValue(int id)
        {
            return db.AttributeValues.FirstOrDefault(item => item.Id == id);
        }

        public bool RemoveAttributeValue(DbAttributeValue value)
        {
            var result = db.AttributeValues.Remove(value);
            Apply();
            return result != null;
        }

        public DbCountryAttributes AddCountryAttributes(DbCountryAttributes element)
        {
            var result = db.CountryAttributes.Add(element);
            Apply();
            return result;
        }

        public DbCountryAttributes[] GetCountryAttributes(Func<DbCountryAttributes, bool> predicate)
        {
            return db.CountryAttributes.Where(predicate).OrderBy(c=>c.Country.Id).ToArray();
        }

        public DbCountryAttributes GetCountryAttributes(long id)
        {
            return db.CountryAttributes.FirstOrDefault(item => item.Id == id);
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
