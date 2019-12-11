using System;
using SW.Helpers;

namespace SW.Services.Account
{
    internal class BalanceAccountResponseHandler : ResponseHandler<AccountResponse>
    {
        public override AccountResponse HandleException(Exception ex)
        {
            return ex.ToAccountResponse();
        }
    }
}
