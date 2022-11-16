using System;
using SW.Helpers;

namespace SW.Services.Pdf
{
    internal class PdfResponseHandler : ResponseHandler<PdfResponse>
    {
        public override PdfResponse HandleException(Exception ex)
        {
            return ex.Response<PdfResponse>();
        }
    }
}
