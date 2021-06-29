using SW.Helpers;
using System;

namespace SW.Services.Relations
{
    internal class RelationsResponseHandler : ResponseHandler<RelationsResponse>
    {
        public override RelationsResponse HandleException(Exception ex)
        {
            return ex.Response<RelationsResponse>();
        }
    }
}
