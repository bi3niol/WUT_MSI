using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.DataBaseGenerator
{
    class Program
    {
        private static DbTablesInterface db;
        static void Main(string[] args)
        {
            db = new DbTablesInterface();
            db.ClearDb();
            InitializeAttributes();
            InitializeCountries();
        }

        public static void InitializeAttributes()
        {
           
            var values2 = new Dictionary<int, DbAttributeValue>
            {
                {0, new DbAttributeValue { Value = "Blisko" } },
                {1, new DbAttributeValue { Value = "Średnio" } },
                {2, new DbAttributeValue { Value = "Daleko" } },
                {3, new DbAttributeValue { Value = "Bardzo daleko" } },
                {4, new DbAttributeValue { Value = "Wysoka" } },
                {5, new DbAttributeValue { Value = "Średnia" } },
                {6, new DbAttributeValue { Value = "Umiarkowana" } },
                {7, new DbAttributeValue { Value = "Niska" } },
                {8, new DbAttributeValue { Value = "Bardzo duży" } },
                {9, new DbAttributeValue { Value = "Duży" } },
                {10, new DbAttributeValue { Value = "Średni" } },
                {11, new DbAttributeValue { Value = "Mały" } },
                {12, new DbAttributeValue { Value = "Bardzo" } },
                {13, new DbAttributeValue { Value = "Słabo" } },
                {14, new DbAttributeValue { Value = "Dużo" } },
                {15, new DbAttributeValue { Value = "Umarkowanie" } },
                {16, new DbAttributeValue { Value = "Mało" } },
                {17, new DbAttributeValue { Value = "Wysoki" } },
                {18, new DbAttributeValue { Value = "Niski" } },
                {19, new DbAttributeValue { Value = "Bardzo duża" } },
                {20, new DbAttributeValue { Value = "Duża" } },
                {21, new DbAttributeValue { Value = "Średnia" } },
                {22, new DbAttributeValue { Value = "Mała" } },
                {23, new DbAttributeValue { Value = "Tak" } },
                {24, new DbAttributeValue { Value = "Nie" } },
            };
            var values = new Dictionary<int, DbAttributeValue>();

            foreach (var element in values2)
               values[element.Key] = db.AddAttributeValue(element.Value);

            DbAttribute attribute;
            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Distance,
                Name = "Jak daleko znajduje się państwo?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[0]);
            db.AddAttributeValueToAttribute(attribute, values[1]);
            db.AddAttributeValueToAttribute(attribute, values[2]);
            db.AddAttributeValueToAttribute(attribute, values[3]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Climate,
                Name = "Jak panuje temperatura?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[4]);
            db.AddAttributeValueToAttribute(attribute, values[5]);
            db.AddAttributeValueToAttribute(attribute, values[6]);
            db.AddAttributeValueToAttribute(attribute, values[7]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Area,
                Name = "Jak duży jest kraj?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[8]);
            db.AddAttributeValueToAttribute(attribute, values[9]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[11]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Development,
                Name = "W jakim stopniu kraj jest rozwinięty?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[12]);
            db.AddAttributeValueToAttribute(attribute, values[1]);
            db.AddAttributeValueToAttribute(attribute, values[13]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Rains,
                Name = "Jak dużo opadów występuje?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[14]);
            db.AddAttributeValueToAttribute(attribute, values[15]);
            db.AddAttributeValueToAttribute(attribute, values[16]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Safety,
                Name = "Jaki jest poziom bezpieczeństwa kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[17]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[18]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Medicine,
                Name = "Jaki jest poziom medycyny w kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[17]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[18]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Population,
                Name = "Jak dużo ludności mieszka w kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[14]);
            db.AddAttributeValueToAttribute(attribute, values[1]);
            db.AddAttributeValueToAttribute(attribute, values[16]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Density,
                Name = "Jak duży jest kraj?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[19]);
            db.AddAttributeValueToAttribute(attribute, values[20]);
            db.AddAttributeValueToAttribute(attribute, values[21]);
            db.AddAttributeValueToAttribute(attribute, values[22]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Jet,
                Name = "Jak duży chcesz mieć jetlag?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[9]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[11]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Sea,
                Name = "Czy leży nad morzem?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[23]);
            db.AddAttributeValueToAttribute(attribute, values[24]);

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Mountain,
                Name = "Czy występują góry?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[23]);
            db.AddAttributeValueToAttribute(attribute, values[24]);

        }

        public static void InitializeCountries()
        {
            var db = new DbTablesInterface();
            SerializationManager m = new SerializationManager();
            var countries = m.Deserialize<List<Country>>(@"..\..\..\WUT_MSI.ModelsLib\data\Countries.xml");

            foreach (var element in countries)
            {
                db.AddCountry(new DbCountry { Name = element.DisplayName });
            }
        }
    }
}
