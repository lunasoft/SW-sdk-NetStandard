
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using SW.Services.Stamp;

namespace SW.Helpers
{
static internal class DowloadFile
{
   public static async Task<StampResponseV2> DowloadFileAsync(string url, HttpClientHandler proxy)
    {
        try
        {
            using (HttpClient client = new HttpClient(proxy))
            {
                var result = await client.GetAsync(url);
                return await TryGetFileAsync(result);
            }
        }
        catch (HttpRequestException wex)
        {
            return new StampResponseV2()
            {
                message = wex.Message,
                status = "error",
                messageDetail = wex.StackTrace
            };
        }
    } 

     internal static async Task<StampResponseV2> TryGetFileAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new StampResponseV2
                    {
                        data = new Data_CFDI_TFD
                        {   
                            cfdi = await response.Content.ReadAsStringAsync(),
                            tfd = null
                        },
                        status = "error"
                    };
                }
                else
                    return new StampResponseV2()
                    {
                        message = ((int)response.StatusCode).ToString(),
                        status = "error",
                        messageDetail = response.ReasonPhrase
                    };
            }
            catch (Exception)
            {
                return new StampResponseV2()
                {
                    message = ((int)response.StatusCode).ToString(),
                    status = "error",
                    messageDetail = response.ReasonPhrase
                };
            }
        }
}
}