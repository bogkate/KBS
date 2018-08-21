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
        public long ReeestId { get; set; }
        public string Url { get; set; }
        public int Depth { get; set; }
        public int Priority { get; set; }
    }
}
