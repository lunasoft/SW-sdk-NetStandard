using SW.Services.Account.AccountBalance;
using System;
using System.Threading.Tasks;
using Test_SW.Helpers;
using SW.Helpers;
using Xunit;

namespace sdk_test.Services.Account
{
    public class AccountBalance_Test
    {
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_Auth_Success()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0,null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_Token_Success()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi,build.Token);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_Auth_Error()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, "passerror", 0, null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.Null(response.messageDetail);

        }
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_Token_Error()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, "0.0.0", 0, null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_idUser_Error()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("f0f11ef6-e4c5-425b-9fc9-b17465bf6f53");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoByUserAsync_idUserEmpty_Error()
        {
            try{ 
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("");
            BalanceResponse response = await balance.ConsultarSaldoAsync(idUser);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
            }
            catch (Exception e){}
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task AsignarTimbresAsync_Auth_Success()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "");
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task AsignarTimbresAsync_Token_Success()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "");
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task AsignarTimbresAsync_Auth_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 100000, "prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task AsignarTimbresAsync_Token_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 100000, "prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task AsignarTimbresAsync_Auth_idUserError()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458650cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1,"prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Auth_Success()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1,"prueba");
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Token_Success()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            Assert.NotNull(response.data);
            Assert.True(response.status == "success");
            Assert.Null(response.message);
            Assert.Null(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Auth_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 100000, "prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Token_SaldoInsuficiente()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458750cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 100000,  "prueba");
            Assert.NotNull(response.message);
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Auth_idUserError()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
        [Fact(Skip = "En espera de una cuenta dealer")]
        public async Task EliminarTimbresAsync_Token_idUserError()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            Assert.Null(response.data);
            Assert.True(response.status == "error");
            Assert.NotNull(response.message);
            Assert.NotNull(response.messageDetail);
        }
    }
}

