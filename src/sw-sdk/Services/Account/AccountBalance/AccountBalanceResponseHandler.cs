using SW.Entities;
using SW.Handlers;
using SW.Helpers;
using SW.Services.Account.AccountBalance;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sw_sdk.Services.Account.AccountBalance
{
    internal class BalanceResponseHandler : ResponseHandler<AccountBalanceResponse>
    {
        internal async Task<AccountBalanceResponse> SendRequestBalanceAsync(ActionsAccountBalance action, string url, Dictionary<string, string> headers, string path, HttpContent content, HttpClientHandler proxy)
        {
            var result = new AccountBalanceResponse();
            switch (action)
            {
                case ActionsAccountBalance.Add:
                    result = await GetPostResponseAsync(url, path, headers, content, proxy);
                    break;
                case ActionsAccountBalance.Remove:
                    result = await DeleteResponseAsync(url, headers, path,content, proxy);
                    break;
            }
            return result;
        }
    }
}
