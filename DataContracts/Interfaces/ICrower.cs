using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Interfaces
{
    using Crower;

    public interface ICrower
    {
        Response<IEnumerable<CrowerData>> ExecuteIndexing();
    }
}
