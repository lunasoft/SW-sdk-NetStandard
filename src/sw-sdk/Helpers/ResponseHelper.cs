using SW.Entities;
using System;

namespace SW.Helpers
{
    internal static class ResponseHelper
    {
        internal static T Response<T>(this Exception ex) where T : Response, new()
        {
            return new T()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }

        internal static string GetErrorDetail(this Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return "";
        }
    }
}
