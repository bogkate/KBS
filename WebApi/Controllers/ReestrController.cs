﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    using System.Web.WebSockets;
    using DataContracts;
    using DataContracts.Interfaces;
    using DataContracts.Reestr;
    using KBSDb;

    [RoutePrefix("api/Reestr")]
    public class ReestrController : ApiController, IReestr
    {
        [HttpGet]
        [ActionName("GetUrls")]
        public Response<IEnumerable<ReestrData>> GetUrls()
        {
            var result = new Response<IEnumerable<ReestrData>> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    result.Data = storage.Reestr.ToList().Select(s => new ReestrData
                    {
                        Depth = s.Depth,
                        Priority = s.Priority,
                        ReeestId = s.ReeestrId
                    });

                    result.Status = ResponseStatus.Success;
                }
            }
            catch (Exception exception)
            {

            }

            return result;
        }

        [HttpPost]
        [ActionName("Add")]
        public Response<object> AddUrl(ReestrData requestData)
        {
            var result = new Response<object> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    storage.Reestr.Add(new Reestr
                    {
                        Priority = requestData.Priority,
                        Depth = requestData.Depth,
                        Url = requestData.Url
                    });

                    storage.SaveChanges();
                    result.Status = ResponseStatus.Success;
                }
            }
            catch (Exception exception)
            {

            }

            return result;
        }

        [HttpPost]
        [ActionName("Edit")]
        public Response<object> EditUrl(ReestrData requestData)
        {
            var result = new Response<object> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    var reestrDb = storage.Reestr.Find(requestData.ReeestId);
                    if (reestrDb != null)
                    {
                        reestrDb.Priority = requestData.Priority;
                        reestrDb.Url = requestData.Url;
                        reestrDb.Depth = requestData.Depth;

                        storage.SaveChanges();

                        result.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        result.Status = ResponseStatus.NotFound;
                    }
                }
            }
            catch (Exception exception)
            {

            }

            return result;
        }

        [HttpPost]
        [ActionName("Delete")]
        public Response<object> DeleteUrl([FromBody]long urlId)
        {
            var result = new Response<object> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    var reestrDb = storage.Reestr.Find(urlId);
                    if (reestrDb != null)
                    {
                        storage.Reestr.Remove(reestrDb);

                        storage.SaveChanges();

                        result.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        result.Status = ResponseStatus.NotFound;
                    }
                }
            }
            catch (Exception exception)
            {

            }

            return result;
        }
    }
}
