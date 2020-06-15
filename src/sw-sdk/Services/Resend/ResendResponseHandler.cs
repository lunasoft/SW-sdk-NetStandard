using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw_sdk.Services.Resend
{
    internal class ResendResponseHandler : SW.Services.ResponseHandler<ResendResponse>
    {
        public override ResendResponse HandleException(Exception ex)
        {
            return ex.ToResendResponse();
        }
    }
}
