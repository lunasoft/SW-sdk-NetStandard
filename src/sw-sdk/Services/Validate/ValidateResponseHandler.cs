using System;
using SW.Helpers;

namespace SW.Services.Validate
{
    internal class ValidateXmlResponseHandler : ResponseHandler<ValidateXmlResponse>
    {
        public override ValidateXmlResponse HandleException(Exception ex)
        {
            return ex.ToValidateXmlResponse();
        }
    }
}
