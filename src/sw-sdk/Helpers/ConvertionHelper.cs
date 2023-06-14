using SW.Services.Stamp;
using SW.Tools.Helpers;
using SW.Tools.Services.Convertion;

namespace SW.Helpers
{
    internal static class ConvertionHelper
    {
        internal static StampResponseV4 ConvertV2ToV4Response(StampResponseV2 response)
        {
            StampResponseV4 responseV4 = new StampResponseV4();
            if (response.Data != null && !string.IsNullOrEmpty(response.Data.Cfdi) && !string.IsNullOrEmpty(response.Data.Tfd))
            {
                string json = Serializer.SerializeJson(response);
                json = Convertion.ConvertResponseToV4(json);
                responseV4 = Serializer.DeserializeJson<StampResponseV4>(json);
            }
            responseV4.MessageDetail = response.MessageDetail;
            responseV4.Message = response.Message;
            responseV4.Status = response.Status;

            return responseV4;
        }
    }
}
