using SW.Services.AcceptReject;
using SW.Services.Account;
using SW.Services.Authentication;
using SW.Services.Cancelation;
using SW.Services.Csd;
using SW.Services.Pdf;
using SW.Services.Pendings;
using SW.Services.Relations;
using SW.Services.Stamp;
using SW.Services.Storage;
using SW.Services.Validate;
using sw_sdk.Services.Resend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Helpers
{
    internal static class ResponseHelper
    {   
        internal static string GetErrorDetail(this Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return ex.StackTrace ?? String.Empty;
        }
    }
}
