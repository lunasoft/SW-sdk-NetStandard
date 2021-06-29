using System;
using SW.Helpers;

namespace SW.Services.Validate
{
    internal class ValidateXmlResponseHandler : ResponseHandler<ValidateXmlResponse>
    {
        public override ValidateXmlResponse HandleException(Exception ex)
        {
            return ex.Response<ValidateXmlResponse>();
        }
    }
    internal class ValidateLrfcResponseHandler : ResponseHandler<ValidateLrfcResponse>
    {
        public override ValidateLrfcResponse HandleException(Exception ex)
        {
            return ex.Response<ValidateLrfcResponse>();
        }
    }
    internal class ValidateLcoResponseHandler : ResponseHandler<ValidateLcoResponse>
    {
        public override ValidateLcoResponse HandleException(Exception ex)
        {
            return ex.Response<ValidateLcoResponse>();
        }
    }
}
