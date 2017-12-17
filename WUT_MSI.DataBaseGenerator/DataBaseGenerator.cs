using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes.helpers;
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.DataBaseGenerator
{
    public class DataBaseGenerator
    {
        private DbTablesInterface db;
        private Question[] questions;

        public DataBaseGenerator()
        {
            db = new DbTablesInterface();
        }

        public void Generate()
        {
            db.ClearDb();
            InitializeAttributes();
            InitializeCountries();
        }

        public void InitializeAttributes()
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

            var questions = new List<Question>();

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

            questions.Add(new Question
            {
                AttributeType = AttributeType.Distance,
                Answears = new List<Answear>
                {
                    new Answear(values[0],-0.4,0.4),
                    new Answear(values[1],0,0.66),
                    new Answear(values[2],0.33,0.99),
                    new Answear(values[3],0.6,1.4),
                },
                MatchingValue = 0.75,
                Function = FuzzyFunctions.DistanceFuzzy.Invoke,
            });

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

            questions.Add(new Question
            {
                AttributeType = AttributeType.Climate,
                Answears = new List<Answear>
                {
                    new Answear(values[4],0.8,1),
                    new Answear(values[5],0.6,0.8),
                    new Answear(values[6],0.3,0.5),
                    new Answear(values[7],0.1,0.3),
                },
                MatchingValue = 0.75,
                Function = FuzzyFunctions.ClimeteFuzzy.Invoke,
            });

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


            questions.Add(new Question
            {
                AttributeType = AttributeType.Area,
                Answears = new List<Answear>
                {
                    new Answear(values[8],0.5556,1.444),
                    new Answear(values[9],0.4,0.7),
                    new Answear(values[10],0.35,0.65),
                    new Answear(values[11],0.4385,0.5615),
                },
                MatchingValue = 0.75,
                Function = FuzzyFunctions.AreaFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Development,
                Name = "W jakim stopniu kraj jest rozwinięty?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[12]);
            db.AddAttributeValueToAttribute(attribute, values[1]);
            db.AddAttributeValueToAttribute(attribute, values[13]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Development,
                Answears = new List<Answear>
                {
                    new Answear(values[12],0.2,1.8),
                    new Answear(values[1],-0.2,0.6),
                    new Answear(values[13],-0.05,0.05),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.DevelopementFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Rains,
                Name = "Jak dużo opadów występuje?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[14]);
            db.AddAttributeValueToAttribute(attribute, values[15]);
            db.AddAttributeValueToAttribute(attribute, values[16]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Rains,
                Answears = new List<Answear>
                {
                    new Answear(values[14],0.1,0.3),
                    new Answear(values[15],0.6,0.8),
                    new Answear(values[16],0.3,0.4),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.RainsFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Safety,
                Name = "Jaki jest poziom bezpieczeństwa kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[17]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[18]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Safety,
                Answears = new List<Answear>
                {
                    new Answear(values[17],0.6,1.4),
                    new Answear(values[10],0.1,0.9),
                    new Answear(values[18],-0.4,0.4),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.SafetyFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Medicine,
                Name = "Jaki jest poziom medycyny w kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[17]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[18]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Medicine,
                Answears = new List<Answear>
                {
                    new Answear(values[17],0.6,1.4),
                    new Answear(values[10],0.1,0.9),
                    new Answear(values[18],-0.4,0.4),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.MedicineFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Population,
                Name = "Jak dużo ludności mieszka w kraju?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[14]);
            db.AddAttributeValueToAttribute(attribute, values[1]);
            db.AddAttributeValueToAttribute(attribute, values[16]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Population,
                Answears = new List<Answear>
                {
                    new Answear(values[14],0.02,1.98),
                    new Answear(values[1],-0.02,0.06),
                    new Answear(values[16],-0.04,0.04),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.PopulationFuzzy.Invoke,
            });

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

            questions.Add(new Question
            {
                AttributeType = AttributeType.Density,
                Answears = new List<Answear>
                {
                    new Answear(values[19],0.0,2.0),
                    new Answear(values[20],-0.394,0.406),
                    new Answear(values[21],-0.296,0.304),
                    new Answear(values[22],-0.12,0.12),
                },
                MatchingValue = 0.75,
                Function = FuzzyFunctions.DensityFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Jet,
                Name = "Jak duży chcesz mieć jetlag?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[9]);
            db.AddAttributeValueToAttribute(attribute, values[10]);
            db.AddAttributeValueToAttribute(attribute, values[11]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Jet,
                Answears = new List<Answear>
                {
                    new Answear(values[9],0.6,1.4),
                    new Answear(values[10],0.1,0.9),
                    new Answear(values[11],-0.4,0.4),
                },
                MatchingValue = 0.66,
                Function = FuzzyFunctions.JetFuzzy.Invoke,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Sea,
                Name = "Czy leży nad morzem?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[23]);
            db.AddAttributeValueToAttribute(attribute, values[24]);

            questions.Add(new Question
            {
                AttributeType = AttributeType.Sea,
                Answears = new List<Answear>
                {
                    new Answear(values[23],0.5,1.5),
                    new Answear(values[24],-0.5,0.5),
                },
                MatchingValue = 0.5,
                Function = element => element.Sea ? 1 : 0,
            });

            db.AddAttribute(attribute = new DbAttribute
            {
                Id = AttributeType.Mountain,
                Name = "Czy występują góry?",
                AttributeValues = new List<DbAttributeValue>(),
            });

            db.AddAttributeValueToAttribute(attribute, values[23]);
            db.AddAttributeValueToAttribute(attribute, values[24]);


            questions.Add(new Question
            {
                AttributeType = AttributeType.Mountain,
                Answears = new List<Answear>
                {
                    new Answear(values[23],0.5,1.5),
                    new Answear(values[24],-0.5,0.5),
                },
                MatchingValue = 0.5,
                Function = element => element.Mountain ? 1 : 0,
            });

            this.questions = questions.ToArray();
        }

        public void InitializeCountries()
        {
            SerializationManager m = new SerializationManager();
            var countries = m.Deserialize<List<Country>>(@"..\..\..\WUT_MSI.ModelsLib\data\Countries.xml");

            foreach (var element in countries)
            {
                var country = db.AddCountry(new DbCountry { Name = element.DisplayName });

                InitializeCountryAttributes(element, country);
            }
        }

        private void InitializeCountryAttributes(Country country, DbCountry dbCountry)
        {
            var allAttributes = db.GetAttributes(item => true);
            var attributes = new List<DbAttributeValue>[allAttributes.Length];

            for (int i = 0; i < allAttributes.Length; i++)
            {
                attributes[i] = new List<DbAttributeValue>();

                var matching = new List<KeyValuePair<DbAttributeValue, double>>();
                
                for(int k = 0; k< questions[i].Length; k++)
                    matching.Add(new KeyValuePair<DbAttributeValue, double>(questions[i][k].Value,questions[i][k].Matching(country, questions[i].Function)));

                matching = matching.OrderByDescending(item => item.Value).ToList();

                attributes[i].AddRange(matching.Take(2).TakeWhile(item => item.Value >= questions[i].MatchingValue).Select(item=>item.Key));

                if (attributes[i].Count() == 0)
                    attributes[i].Add(matching.First().Key);
            }

            var permutations = new List<DbAttributeValue[]>();
            GeneratePermutations(0, attributes, permutations, new List<DbAttributeValue>(), allAttributes.Length - 1);

            foreach (var element in permutations)
                db.AddCountryAttributes(new DbCountryAttributes
                {
                    Country = dbCountry,
                    DistanceAttributeValue = element[0],
                    ClimateAttributeValue = element[1],
                    AreaAttributeValue = element[2],
                    DevelopmentAttributeValue = element[3],
                    RainsAttributeValue = element[4],
                    SafetyAttributeValue = element[5],
                    MedicineAttributeValue = element[6],
                    PopulationAttributeValue = element[7],
                    DensityAttributeValue = element[8],
                    JetAttributeValue = element[9],
                    SeaAttributeValue = element[10],
                    MountainAttributeValue = element[11],
                });
        }

        private void GeneratePermutations(int step, List<DbAttributeValue>[] values, List<DbAttributeValue[]> permutations, List<DbAttributeValue> currentPermutation, int maxStep)
        {
            for(int i=0; i<values[step].Count(); i++)
            {
                currentPermutation.Add(values[step][i]);
                if (step < maxStep)
                    GeneratePermutations(step + 1, values, permutations, currentPermutation, maxStep);
                else
                    permutations.Add(currentPermutation.ToArray());
                currentPermutation.Remove(values[step][i]);
            }
        }
}
}
