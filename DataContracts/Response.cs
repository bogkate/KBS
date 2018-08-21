using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public class Response<T>
    {
        public ResponseStatus Status { get; set; }
        public T Data { get; set; }
    }
}
