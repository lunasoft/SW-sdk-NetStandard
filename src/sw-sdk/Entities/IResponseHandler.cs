using SW.Entities;
using System;
using System.Net;

namespace SW
{
    internal interface IResponseHandler
    {
        Response GetResponse(WebRequest request);
        Response HandleException(Exception ex);
    }
}
