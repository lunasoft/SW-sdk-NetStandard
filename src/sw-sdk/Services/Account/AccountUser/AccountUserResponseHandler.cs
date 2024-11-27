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
        internal async Task<AccountUserTempResponse> SendRequestAsync(AccountUserAction action, string url, Dictionary<string, string> headers, string path, HttpContent content, HttpClientHandler proxy)
        {
            var result = new AccountUserTempResponse();
            switch (action)
            {
                case AccountUserAction.Update:
                    result = await PutResponseAsync(url, headers, path, content, proxy);
                    if (result.Message == "500")
                    {
                        result.SetMessage("Error al Actualizar usuario");
                        result.SetMessageDetail("Problemas al generar petición");
                    }
                    break;
                case AccountUserAction.Delete:
                    result = await DeleteResponseAsync(url, headers, path, proxy);
                    if (result.Message == "204")
                    {
                        result.SetStatus("success");
                        result.SetMessage("Usuario eliminado con exito");
                    }
                    else if (result.Message == "500" || result.Message=="404") 
                    {
                        result.SetMessage("Error al eliminar");
                        result.SetMessageDetail("El usuario no puede eliminarse ya que tiene timbres o no exista"); 
                    }
                    break;
            }
            if(result.Status == "400") {result.SetStatus("error");}
            return result;
        }
    }
    internal class AccountCreateUserResponseHandler : ResponseHandler<AccountUserResponse>
    {
        internal async Task<AccountUserResponse> SendRequestAsync(string url, Dictionary<string, string> headers, string path, HttpContent content, HttpClientHandler proxy)
        {
            var result = new AccountUserResponse();
            result = await GetPostResponseAsync(url, path, headers, content, proxy);
            if(result.Status == "400") { result.SetStatus("error"); }
            return result;
        }
    }
}
