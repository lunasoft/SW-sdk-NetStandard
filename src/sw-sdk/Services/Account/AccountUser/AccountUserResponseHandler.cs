using SW.Entities;
using SW.Handlers;
using SW.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Services.Account.AccountUser
{
    internal class AccountUserResponseHandler : ResponseHandler<AccountUserTempResponse>
    {
        internal async Task<Response> SendRequestAsync(AccountUserAction action, string url, Dictionary<string, string> headers, string path, HttpContent content, HttpClientHandler proxy)
        {
            var result = new AccountUserTempResponse();
            switch (action)
            {
                case AccountUserAction.Add:
                    result = await GetPostResponseAsync(url, path, headers, content, proxy);
                    break;
                case AccountUserAction.Update:
                    result = await PutResponseAsync(url, headers, path, content, proxy);
                    break;
                case AccountUserAction.Delete:
                    result = await DeleteResponseAsync(url, headers, path, proxy);
                    break;
            }
            return new Response()
            {
                status = result.status,
                message = result.status.Equals("success") ? result.Data : result.message,
                messageDetail = result.messageDetail
            };
        }
    }
}
