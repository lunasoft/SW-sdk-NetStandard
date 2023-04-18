using System;
using SW.Services.Account;
using Test_SW.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace Test_SW.Services.Account_Test
{
    public class Account_Test_45
    {

        [Fact]
        public async Task Account_Test_45_ConsultaDeSaldoByUserAsync()
        {
            var build = new BuildSettings();
            BalanceAccount account = new BalanceAccount("http://services.test.sw.com.mx", build.User, build.Password);
            AccountResponse response = await account.ConsultarSaldoAsync();
            if(response.Status != "error")
            {
                //saldo timbres
                Console.WriteLine(response.Data.SaldoTimbres);
                //timbres utilizados
                Console.WriteLine(response.Data.TimbresUtilizados);
                //En caso de tener timbres infinitos (para cuentas hijo)
                Console.WriteLine(response.Data.Unlimited);
            }
            else
            {
                //errores
                Console.WriteLine(response.Message);
                Console.WriteLine(response.MessageDetail);
            }
            Assert.True(response.Status == "success", response.MessageDetail);
        }
        [Fact]
        public async Task Account_Test_45_ConsultaDeSaldoByTokenAsync()
        {
            var build = new BuildSettings();
            BalanceAccount account = new BalanceAccount(build.Url, build.Token);
            var response = await account.ConsultarSaldoAsync();
            Assert.True(response.Status == "success", response.MessageDetail);
        }
    }
}
