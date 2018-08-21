using DataContracts.Reestr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Interfaces
{
    public interface IReestr
    {
        Response<IEnumerable<ReestrData>> GetUrls();

        Response<object> AddUrl(ReestrData response);

        Response<object> EditUrl(ReestrData response);

        Response<object> DeleteUrl(long urlId);
    }
}
