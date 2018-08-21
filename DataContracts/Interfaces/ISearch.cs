using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Interfaces
{
    public interface ISearch
    {
        Response<IEnumerable<SearchData>> Search(string text);
    }
}
