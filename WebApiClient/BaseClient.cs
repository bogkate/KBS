using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using DataContracts;

    public class BaseClient
    {
        private string webApiUrl;

        public BaseClient(string webApiUrl)
        {
            this.webApiUrl = webApiUrl;
        }

        protected Response<TResult> ApiCall<TResult, TParam>(string relativeUrl, TParam param)
        {
            var result = new Response<TResult> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var client = new HttpClient() { BaseAddress = new Uri(webApiUrl) })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var responseTask = client.PostAsJsonAsync(client.BaseAddress.AbsoluteUri + relativeUrl, param))
                    {
                        using (var response = responseTask.Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                using (var contentTask = response.Content.ReadAsAsync<Response<TResult>>())
                                {
                                    var content = contentTask.Result;

                                    if (content.Status != ResponseStatus.Success)
                                    {

                                    }

                                    result = content;
                                }
                            }
                            else
                            {

                                if (response.StatusCode == HttpStatusCode.Forbidden)
                                {
                                    result.Status = ResponseStatus.UnknownError;
                                }
                            }
                        }
                    }

                }
            }
            catch (AggregateException aggregateException)
            {
                //Logger.Error($"AggregateException! Server base address:{serverBaseAddress}.", aggregateException);

               // result.Status = HandleException(aggregateException);
            }
            catch (Exception exception)
            {
              //  Logger.Error(exception, $"Unexpected error! Server base address:{serverBaseAddress}.");
            }

            return result;
        }

        protected Response<TResult> ApiCall<TResult>(string relativeUrl)
        {
            var result = new Response<TResult> { Status = ResponseStatus.UnknownError };

            try
            {

                using (var client = new HttpClient() { BaseAddress = new Uri(webApiUrl) })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var responseTask = client.GetAsync(client.BaseAddress.AbsoluteUri + relativeUrl))
                    {
                        using (var response = responseTask.Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                using (var contentTask = response.Content.ReadAsAsync<Response<TResult>>())
                                {
                                    var content = contentTask.Result;

                                    if (content.Status != ResponseStatus.Success)
                                    {
                                        //Logger.Error("API Server error! response.IsSuccessStatusCode = TRUE, ApiResultStatus = {0}", content.Status);
                                    }

                                    result = content;
                                }
                            }
                            else
                            {
                                //Logger.Error("Call to API Server fails! response.IsSuccessStatusCode = FALSE, StatusCode = {0}", response.StatusCode);

                                if (response.StatusCode == HttpStatusCode.Forbidden)
                                {
                                    result.Status = ResponseStatus.AccessDenied;
                                }
                            }
                        }
                    }
                }

            }
            catch (AggregateException aggregateException)
            {
                // Logger.Error(aggregateException, $"AggregateException! Server base address:{serverBaseAddress}.");

                //  result.Status = HandleException(aggregateException);
            }
            catch (Exception exception)
            {
                //  Logger.Error(exception, $"Unexpected error! Server base address:{serverBaseAddress}.");
            }

            return result;
        }
    }
}
