using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Search
{
    using System.Runtime.Serialization;

    [DataContract]
    public struct SearchData
    {
        [DataMember]
        public string Url { get; set; } 

        [DataMember]
        public long Count { get; set; }
    }
}
