using SW.Services.Account.AccountBalance;
using System;
using System.Threading.Tasks;
using Test_SW.Helper;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Account
{
    public class AccountBalance_Test
    {
        [Fact]
        public async Task ConsultaDeSaldoAsync_Auth_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            BalanceResponse response = await balance.ConsultarSaldoAsync();
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Data.LastTransaction);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoAsync_Token_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Token);
            BalanceResponse response = await balance.ConsultarSaldoAsync();
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact]
        public async Task ConsultaDeSaldoAsync_Auth_ErrorV2()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, build.Url, build.User, "passerror", 0, null);
            BalanceResponse response = await balance.ConsultarSaldoAsync();
            CustomAssert.ErrorResponse(response);
            Assert.Null(response.Data);
            Assert.NotNull(response.Message);
            Assert.Null(response.MessageDetail);

        }
        [Fact]
        public async Task ConsultaDeSaldoAsync_Token_ErrorV2()
        {
            var build = new BuildSettings();
            AccountBalance balance = new AccountBalance(build.UrlApi, "0.0.0", 0, null);
            var response = await balance.ConsultarSaldoAsync();
            CustomAssert.ErrorResponse(response);
            Assert.Null(response.Data);
            Assert.NotNull(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact(Skip = "Se omite para no tener tema con los timbres en la cuenta de pruebas")]
        public async Task AsignarTimbresAsync_Auth_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("32501CF2-DC62-4370-B47D-25024C44E131");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "");
            Assert.NotNull(response.Data);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact(Skip = "Se omite para no tener tema con los timbres en la cuenta de pruebas")]
        public async Task AsignarTimbresAsync_Token_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("32501CF2-DC62-4370-B47D-25024C44E131");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact]
        public async Task AsignarTimbresAsync_Auth_idUserErrorV2()
        {
            var build = new BuildSettings();
            AccountBalance agregar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458650cfa");
            AccountBalanceResponse response = await agregar.AgregarTimbresAsync(idUser, 1, "prueba");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("El usuario no fue encontrado."));
            Assert.NotNull(response.Message);
        }
        [Fact(Skip = "Se omite para no tener tema con los timbres en la cuenta de pruebas")]
        public async Task EliminarTimbresAsync_Auth_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("32501CF2-DC62-4370-B47D-25024C44E131");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact(Skip = "Se omite para no tener tema con los timbres en la cuenta de pruebas")]
        public async Task EliminarTimbresAsync_Token_SuccessV2()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("32501CF2-DC62-4370-B47D-25024C44E131");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.Null(response.Message);
            Assert.Null(response.MessageDetail);
        }
        [Fact]
        public async Task EliminarTimbresAsync_Auth_idUserErrorV2()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Url, build.User, build.Password, 0, null);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("El usuario no fue encontrado."));
            Assert.NotNull(response.Message);
        }
        [Fact]
        public async Task EliminarTimbresAsync_Token_idUserErrorV2()
        {
            var build = new BuildSettings();
            AccountBalance eliminar = new AccountBalance(build.UrlApi, build.Token);
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            AccountBalanceResponse response = await eliminar.EliminarTimbresAsync(idUser, 1, "prueba");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("El usuario no fue encontrado."));
            Assert.NotNull(response.Message);
        }
    }
}

