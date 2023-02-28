using System;

namespace SW.Helpers
{
    internal static class ResponseHelper
    {   
        internal static string GetErrorDetail(this Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return (ex.StackTrace ?? String.Empty).Trim();
        }
    }
}
