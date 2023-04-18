using System;
using System.Net;

namespace SW
{
    internal interface IResponseHandler
    {
        SW.Entities.Response GetResponse(WebRequest Request);
        SW.Entities.Response HandleException(Exception Ex);
    }
}
