using SW.Helpers;

namespace SW.Services.Authentication
{
    internal class AuthenticationValidation : Validation
    {
        internal AuthenticationValidation(string url, string user, string password, string token) : base(url, user, password, token)
        {
        }
    }
}
