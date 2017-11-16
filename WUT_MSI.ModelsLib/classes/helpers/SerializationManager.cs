using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class SerializationManager
    {
        public void Serialize<T>(string fileName, T @object)
        {
            using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(file, @object);
            }
        }

        public T Deserialize<T>(string fileName) where T : class
        {
            T @object = null;
            if (File.Exists(fileName))
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    @object = deserializer.Deserialize(file) as T;
                }
            return @object;
        }
    }
}
