using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Crower
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CrowerData
    {
        [DataMember]
        public  string Url { get; set; }

        [DataMember]
        public  bool Status { get; set; }

        [DataMember]
        public  long CountIndex { get; set; }
    }
}
