using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    public class GeneratorCSV
    {
        private StringBuilder content;
        private string propertyName;

        public GeneratorCSV(string pName)
        {
            this.propertyName = pName;
            content = new StringBuilder();
        }

        public void Generate(string country, double value)
        {
            content.AppendLine($"{country};{value}");
        }

        public void Save()
        {
            using (FileStream file = new FileStream($"{propertyName}.csv", FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(content.ToString());
            }
        }
    }
}
