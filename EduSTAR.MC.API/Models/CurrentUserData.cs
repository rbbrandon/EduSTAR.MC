using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Models
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/service_core")]
    [XmlRoot(ElementName = "User",Namespace = "http://schemas.datacontract.org/2004/07/service_core", IsNullable = false)]
    public class CurrentUserData
    {
        public bool IsAdmin { get; set; }
        public bool IsConsoleOperator { get; set; }
        public bool IsLtCoord { get; set; }
        public bool IsSDM { get; set; }
        public bool IsSSPAdmin { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsTech { get; set; }
        public string RawLogin { get; set; }

        [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] PwdAdminSchools { get; set; }
        
        [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] SdmRegion { get; set; }

        [XmlElement(ElementName = "_cn")]
        public string Cn { get; set; }

        [XmlElement(ElementName = "_displayName")]
        public string DisplayName { get; set; }

        [XmlElement(ElementName = "_dn")]
        public string DistinguishedName { get; set; }

        [XmlElement(ElementName = "_samAccountName")]
        public string SamAccountName { get; set; }

        [XmlArray(ElementName = "_schools")]
        [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays",
            IsNullable = false)]
        public string[] Schools { get; set; }

        [XmlArray(ElementName = "_staticLinks")]
        [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays",
            IsNullable = false)]
        public string[] StaticLinks { get; set; }
    }
}