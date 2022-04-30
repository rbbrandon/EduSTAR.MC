using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Models
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/service_core")]
    [XmlRoot(ElementName = "ArrayOfSchool", Namespace = "http://schemas.datacontract.org/2004/07/service_core",
        IsNullable = false)]
    public class ArrayOfSchool
    {
        [XmlElement(ElementName = "School")]
        public School[] Items { get; set; }

        [XmlIgnore] public int Count => Items.Length;
        [XmlIgnore] public int Length => Items.Length;
    }
}