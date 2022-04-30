using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EduSTAR.MC.API.Models
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(TypeName = "_npsMapping", AnonymousType = true,
        Namespace = "http://schemas.datacontract.org/2004/07/service_core")]
    public class NpsMapping
    {
        public object CreationCommand { get; set; }
        public object CreationCommandResult { get; set; }

        [XmlElement(IsNullable = false)]
        public DateTime LastUpdate { get; set; } = DateTime.Parse("0001-01-01T00:00:00");

        public object ModifiedBy { get; set; }
        public object SchoolId { get; set; }
        public object ServerName { get; set; }
        public object VirtualDomainId { get; set; }
        public object VirtualDomainName { get; set; }
    }
}