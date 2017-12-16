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
        static void Main(string[] args)
        {
            InitializeAttributes();
            InitializeCountries();
        }

        public static void InitializeAttributes()
        {
            var db = new DbTablesInterface();
            var values = new Dictionary<int, DbAttributeValue>
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

            foreach (var element in values)
                db.AddAttributeValue(element.Value);

            db.AddAttribute(new DbAttribute
            {
                Name = "Jak daleko znajduje się państwo?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[0],
                    values[1],
                    values[2],
                    values[3],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak panuje temperatura?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[4],
                    values[5],
                    values[6],
                    values[7],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak duży jest kraj?",
                AttributeValues = new DbAttributeValue[]
                {
                     values[8],
                    values[9],
                    values[10],
                    values[11],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "W jakim stopniu kraj jest rozwinięty?",
                AttributeValues = new DbAttributeValue[]
               {
                    values[12],
                    values[1],
                    values[13],
               },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak dużo opadów występuje?",
                AttributeValues = new DbAttributeValue[]
              {
                    values[14],
                    values[15],
                    values[16],
              },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jaki jest poziom bezpieczeństwa kraju?",
                AttributeValues = new DbAttributeValue[]
              {
                    values[17],
                    values[10],
                    values[18],
              },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jaki jest poziom medycyny w kraju?",
                AttributeValues = new DbAttributeValue[]
              {
                    values[17],
                    values[10],
                    values[18],
              },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak dużo opadów występuje?",
                AttributeValues = new DbAttributeValue[]
              {
                  values[14],
                    values[1],
                    values[16],
              },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak duży jest kraj?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[19],
                    values[20],
                    values[21],
                    values[22],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Jak duży chcesz mieć jetlag?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[9],
                    values[10],
                    values[11],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Czy leży nad morzem?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[23],
                    values[24],
                },
            });
            db.AddAttribute(new DbAttribute
            {
                Name = "Czy występują góry?",
                AttributeValues = new DbAttributeValue[]
                {
                    values[23],
                    values[24],
                },
            }); 
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
