using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Models
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(TypeName = "School", AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/service_core")]
    public class School
    {
        public string Region { get; set; }
        public string SchoolId { get; set; }
        public string SchoolName { get; set; }

        [XmlElement(ElementName = "_adminServers")]
        public object AdminServers { get; set; }

        [XmlElement(ElementName = "_adminWorkstationExceptions")]
        public object AdminWorkstationExceptions { get; set; }

        [XmlElement(ElementName = "_campus")]
        public object Campus { get; set; }

        [XmlElement(ElementName = "_caseComputers")]
        public object CaseComputers { get; set; }

        [XmlElement(ElementName = "_centralExceptions")]
        public object CentralExceptions { get; set; }

        [XmlElement(ElementName = "_centralExceptionstoRemove")]
        public object CentralExceptionstoRemove { get; set; }

        [XmlElement(ElementName = "_centralGroups")]
        public object CentralGroups { get; set; }

        [XmlElement(ElementName = "_curricComputers")]
        public object CurricComputers { get; set; }

        [XmlElement(ElementName = "_curricServers")]
        public object CurricServers { get; set; }

        [XmlElement(ElementName = "_dls")]
        public object Dls { get; set; }

        [XmlElement(ElementName = "_gpo")]
        public object Gpo { get; set; }

        [XmlElement(ElementName = "_integratedServers")]
        public object IntegratedServers { get; set; }

        [XmlElement(ElementName = "_ipam")]
        public object Ipam { get; set; }

        [XmlElement(ElementName = "_isIntegrated")]
        public bool IsIntegrated { get; set; }

        [XmlElement(ElementName = "_localGroups")]
        public object LocalGroups { get; set; }

        [XmlElement(ElementName = "_managedComputers")]
        public object ManagedComputers { get; set; }

        [XmlElement(ElementName = "_notes")]
        public object Notes { get; set; }

        [XmlElement(ElementName = "_npsMapping")]
        public NpsMapping NpsMapping { get; set; }

        [XmlElement(ElementName = "_ns_admin_dc")]
        public object NsAdminDc { get; set; }

        [XmlElement(ElementName = "_ns_admin_dns")]
        public object NsAdminDns { get; set; }

        [XmlElement(ElementName = "_ns_curric_dc")]
        public object NsCurricDc { get; set; }

        [XmlElement(ElementName = "_ns_curric_dns")]
        public object NsCurricDns { get; set; }

        [XmlElement(ElementName = "_rodcs")]
        public object Rodcs { get; set; }

        [XmlElement(ElementName = "_screenSaverPolicy")]
        public object ScreenSaverPolicy { get; set; }

        [XmlElement(ElementName = "_serviceAccounts")]
        public object ServiceAccounts { get; set; }

        [XmlElement(ElementName = "_staff")]
        public object Staff { get; set; }

        [XmlElement(ElementName = "_students")]
        public object Students { get; set; }

        [XmlElement(ElementName = "_techs")]
        public object Techs { get; set; }

        [XmlElement(ElementName = "_tsspTechs")]
        public object TsspTechs { get; set; }

        public override string ToString() => $"{SchoolId} - {SchoolName}";
    }
}