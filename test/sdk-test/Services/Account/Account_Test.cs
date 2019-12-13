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
            BalanceAccount account = new BalanceAccount("http://services.test.sw.com.mx", "demo", "123456789");
            AccountResponse response = await account.ConsultarSaldoAsync();
            if(response.status != "error")
            {
                //saldo timbres
                Console.WriteLine(response.data.saldoTimbres);
                //timbres utilizados
                Console.WriteLine(response.data.timbresUtilizados);
                //En caso de tener timbres infinitos (para cuentas hijo)
                Console.WriteLine(response.data.unlimited);
            }
            else
            {
                //errores
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            Assert.True(response.status == "success", response.messageDetail);
        }
        [Fact]
        public async Task Account_Test_45_ConsultaDeSaldoByTokenAsync()
        {
            var build = new BuildSettings();
            BalanceAccount account = new BalanceAccount(build.Url, build.Token);
            var response = await account.ConsultarSaldoAsync();
            Assert.True(response.status == "success", response.messageDetail);
        }
    }
}
