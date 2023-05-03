using System;
using System.Net;

namespace SW
{
    internal interface IResponseHandler
    {
        SW.Entities.Response GetResponse(WebRequest request);
        SW.Entities.Response HandleException(Exception ex);
    }
}
