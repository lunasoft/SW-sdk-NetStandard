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
            return new T()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.StackTrace
            };
        }
        internal T GetExceptionResponse(Exception ex)
        {
            return new T()
            {
                status = "error",
                message = ex.Message,
                messageDetail = ResponseHelper.GetErrorDetail(ex)
            };
        }
        private T GetExceptionResponse(HttpResponseMessage response)
        {
            return new T()
            {
                message = ((int)response.StatusCode).ToString(),
                status = "error",
                messageDetail = response.ReasonPhrase
            };
        }
    }
}
