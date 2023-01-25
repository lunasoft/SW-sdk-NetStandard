using SW.Services.Account.BalanceManagement;
using sw_sdk.Services.Account.BalanceManagement;
using System;
using System.Threading.Tasks;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Account
{
    public class BalanceManagement_Test
    {
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_Auth_Success()
        {
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0,null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");

        }
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_Token_Success()
        {
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.Url,build.Token);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
        }
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_Token_Error()
        {
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.UrlApi, "0.0.0");
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");

        }
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_Auth_Error()
        {
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.UrlApi, build.Url, build.User, "passerror", 0, null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
        }
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_idUser_Error()
        {
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-9fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.True(response.status == "error");
            Assert.Null(response.data);
        }
        [Fact]
        public async Task BalanceManagement_Test_ConsultaDeSaldoByUserAsync_idUserEmpty_Error()
        {
            try{ 
            var build = new BuildSettings();
            BalanceManagement balance = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.True(response.status == "error");
            Assert.Null(response.data);
            }
            catch (Exception e){}
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_AsignarTimbresAsync()
        {
            var build = new BuildSettings();
            BalanceManagement agregar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            BalanceManagementResponse response = await agregar.AgregarTimbresAsync(idUser, 1,"");
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_AsignarTimbresAsync_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            BalanceManagement agregar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            BalanceManagementResponse response = await agregar.AgregarTimbresAsync(idUser, 100000, "prueba");
            Assert.NotNull(response.message);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_AsignarTimbresAsync_idUserError()
        {
            var build = new BuildSettings();
            BalanceManagement agregar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458650cfa");
            BalanceManagementResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "prueba");
            Assert.NotNull(response.message);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_EliminarTimbresAsync()
        {
            var build = new BuildSettings();
            BalanceManagement eliminar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            BalanceManagementResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            Assert.True(response.status == "success");
            Assert.NotNull(response.data);
        }

        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_EliminarTimbresAsync_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            BalanceManagement eliminar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            BalanceManagementResponse response = await eliminar.EliminarTimbresAsync(idUser, 100000, "prueba");
            Assert.NotNull(response.message);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task BalanceManagement_Test_EliminarTimbresAsync_idUserError()
        {
            var build = new BuildSettings();
            BalanceManagement eliminar = new BalanceManagement(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            BalanceManagementResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            Assert.NotNull(response.message);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
        }
    }
}

