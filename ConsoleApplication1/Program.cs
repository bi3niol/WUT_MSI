using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes.helpers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> list;

            SerializationManager m = new SerializationManager();
            list = m.Deserialize<List<Country>>("Countries.xml");

            //foreach (var item in list)
            //    Console.WriteLine(FuzzyFunctions.JetFuzzy.Invoke(item));
            GeneratorCSV generatorArea = new GeneratorCSV("Area");

            foreach (var item in list)
                generatorArea.Generate(item.DisplayName, item.Area);
            generatorArea.Save();

            GeneratorCSV generatorPopulation = new GeneratorCSV("Population");

            foreach (var item in list)
                generatorPopulation.Generate(item.DisplayName, item.Population);
            generatorPopulation.Save();

            GeneratorCSV generatorGINI = new GeneratorCSV("GINI");

            foreach (var item in list)
                generatorGINI.Generate(item.DisplayName, item.GINI);
            generatorGINI.Save();

            GeneratorCSV generatorDensity = new GeneratorCSV("Density");

            foreach (var item in list)
                try
                {
                    generatorDensity.Generate(item.DisplayName, item.Population / item.Area);
                }
                catch (Exception) { }
            generatorDensity.Save();
        }
    }
}
