﻿using System;
using SW.Helpers;
using SW.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SW.Services.Account
{
    public class BalanceAccount : BalanceAccountService
    {

        BalanceAccountResponseHandler _handler;
        /// <summary>
        /// This Service is Not Implemented
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public BalanceAccount(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxy, proxyPort)
        {
            _handler = new BalanceAccountResponseHandler();
        }
        /// <summary>
        /// This Service is Not Implemented
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        public BalanceAccount(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxy, proxyPort)
        {
            _handler = new BalanceAccountResponseHandler();
        }

        internal async override Task<Response> GetBalance()
        {
            try
            {
                new Validation(Url, User, Password, Token).ValidateHeaderParameters();
                await this.SetupRequestAsync();

                Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url, headers, "account/balance", proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<AccountResponse> ConsultarSaldo()
        {
            return (AccountResponse)await GetBalance();
        }
    }
}
