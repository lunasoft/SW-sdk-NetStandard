using SW.Helpers;
using System;

namespace SW.Services.Authentication
{
    internal class AuthenticationResponseHandler : ResponseHandler<AuthResponse>
    {
        public override AuthResponse HandleException(Exception ex)
        {
            return ex.Response<AuthResponse>();
        }
    }
}
