using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    using DataContracts;
    using DataContracts.Crower;
    using DataContracts.Interfaces;
    using DataContracts.Reestr;
    using DataContracts.Search;

    public class Client : BaseClient, IReestr, ISearch, ICrower
    {

        public Client(string webApiUrl):base(webApiUrl)
        {
          
        }

        public Response<IEnumerable<CrowerData>> ExecuteIndexing()
        {
            return ApiCall<IEnumerable<CrowerData>, object>("api/crower/Execute", null);
        }

        public Response<IEnumerable<SearchData>> Search(string text)
        {
            return ApiCall<IEnumerable<SearchData>>($"api/crower/Search?text={text}");
        }

        public Response<IEnumerable<ReestrData>> GetUrls()
        {
            return ApiCall<IEnumerable<ReestrData>>($"api/reestr/GetUrls");
        }

        public Response<ReestrData> GetUrl(long id)
        {
            return ApiCall<ReestrData>($"api/reestr/GetUrl?id={id}");
        }

        public Response<object> AddUrl(ReestrData request)
        {
            return ApiCall<object,ReestrData>($"api/reestr/Add",request);
        }

        public Response<object> EditUrl(ReestrData request)
        {
            return ApiCall<object, ReestrData>($"api/reestr/Edit", request);
        }

        public Response<object> DeleteUrl(long urlId)
        {
            return ApiCall<object, long>($"api/reestr/Delete", urlId);
        }
    }
}
