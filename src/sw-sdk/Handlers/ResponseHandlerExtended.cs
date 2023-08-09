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
    internal class ResponseHandlerExtended<T> where T : Response, new()
    {
        internal virtual async Task<T> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(),
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                }
                else
                    return GetExceptionResponse(response);
            }
            catch
            {
                return GetExceptionResponse(response);
            }
        }

        internal T GetExceptionResponse(HttpRequestException ex)
        {
            var response = new T(); 
            response.SetStatus("error");
            response.SetMessage(ex.Message);
            response.SetMessageDetail(ex.StackTrace);
            return response;
        }

        internal T GetExceptionResponse(Exception ex)
        {
            var response = new T();
            response.SetStatus("error");
            response.SetMessage(ex.Message);
            response.SetMessageDetail(ResponseHelper.GetErrorDetail(ex));
            return response;
        }

        internal T GetExceptionResponse(HttpResponseMessage ex)
        {
            var response = new T();
            response.SetStatus("error");
            response.SetMessage(((int)ex.StatusCode).ToString());
            response.SetMessageDetail(ex.ReasonPhrase);
            return response;
        }
    }
}