using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Utilities
{
    internal static class Convert
    {
        internal static T XmlStringToObject<T>(string xmlString) where T : class {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(xmlString)) {
                var deserialisedObject = serializer.Deserialize(reader);
                return (T)deserialisedObject;
            }
        }
    }
}
