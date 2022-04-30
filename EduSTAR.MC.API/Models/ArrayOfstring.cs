using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Models
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
    public class ArrayOfstring
    {
        [XmlElement("string")] public string[] Items { get; set; }

        [XmlIgnore] public int Count => Items.Length;
        [XmlIgnore] public int Length => Items.Length;
    }
}