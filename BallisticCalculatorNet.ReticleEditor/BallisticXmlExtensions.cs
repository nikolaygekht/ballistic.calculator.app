using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BallisticCalculator.Serialization;

namespace BallisticCalculatorNet.ReticleEditor
{
    internal static class BallisticXmlExtensions
    {
        public static T BallisticXmlDeserialize<T>(this Stream stream)
            where T : class
        {
            XmlDocument document = new XmlDocument();
            document.Load(stream);
            var xmlDeseralizer = new BallisticXmlDeserializer();
            return xmlDeseralizer.Deserialize<T>(document.DocumentElement);
        }

        public static void BallisticXmlSerialize<T>(this T value, Stream stream)
            where T : class
        {
            var xmlSeralizer = new BallisticXmlSerializer();
            xmlSeralizer.Document.AppendChild(xmlSeralizer.Serialize(value));
            xmlSeralizer.Document.Save(stream);
        }
    }
}
