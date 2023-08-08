using SW.Entities;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using SW.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SW.Handlers
{
    internal class ResponseHandlerExtended<TResponse> where TResponse : Response, new()
    {
        internal virtual async Task<TResponse> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync(),
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                }
                else
                    return GetExceptionResponse<TResponse>(response);
            }
            catch
            {
                return GetExceptionResponse<TResponse>(response);
            }
        }

        internal TResponse GetExceptionRespons<T>(HttpRequestException ex)
        {
            TResponse response = new TResponse();
            response.SendStatus("error");
            response.SetMessage(ex.Message);
            response.SetMessageDetail(ex.StackTrace);
            return response;
        }

        internal TResponse GetExceptionResponse<T>(Exception ex)
        {
            TResponse response = new TResponse();
            response.SendStatus("error");
            response.SetMessage(ex.Message);
            response.SetMessageDetail(ResponseHelper.GetErrorDetail(ex));
            return response;
        }

        internal TResponse GetExceptionResponse<T>(HttpResponseMessage ex)
        {
            TResponse response = new TResponse();
            response.SendStatus("error");
            response.SetMessage(((int)ex.StatusCode).ToString());
            response.SetMessageDetail(ex.ReasonPhrase);
            return response;
        }
    }
}