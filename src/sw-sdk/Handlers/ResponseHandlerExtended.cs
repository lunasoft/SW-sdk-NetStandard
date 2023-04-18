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
                    if (Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!= null) { 
                    }

                   // return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                   return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()});
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
            return new T()
            {
                Message = ex.Message,
                Status = "error",
                MessageDetail = ex.StackTrace
            };
        }
        internal T GetExceptionResponse(Exception ex)
        {
            return new T()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = ResponseHelper.GetErrorDetail(ex)
            };
        }
        private T GetExceptionResponse(HttpResponseMessage response)
        {
            return new T()
            {
                Message = ((int)response.StatusCode).ToString(),
                Status = "error",
                MessageDetail = response.ReasonPhrase
            };
        }
    }
}
