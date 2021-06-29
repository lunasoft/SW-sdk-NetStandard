using SW.Helpers;
using SW.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw_sdk.Services.Resend
{
    internal class ResendResponseHandler : ResponseHandler<ResendResponse>
    {
        public override ResendResponse HandleException(Exception ex)
        {
            return ex.Response<ResendResponse>();
        }
    }
}
