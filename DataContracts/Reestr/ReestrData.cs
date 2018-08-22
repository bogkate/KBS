using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Reestr
{
    [DataContract]
    public struct ReestrData
    {
        [DataMember]
        public long ReestrId { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public int Depth { get; set; }
        [DataMember]
        public int Priority { get; set; }
    }
}
