using System;
using Test_SW.Helpers;
using System.Threading.Tasks;
using Xunit;
using SW.Services.Account.AccountUser;
using System.Linq;
using Test_SW.Helper;

namespace Test_SW.Services.AccountUser_Test
{
    public class AccountUser_Test
    {
        private readonly BuildSettings _build;
        private readonly Guid _idUser;
        public AccountUser_Test() 
        {
            _build = new BuildSettings();
            _idUser = Guid.Parse("32501CF2-DC62-4370-B47D-25024C44E131");
        }
        //Crear Usuario
        [Fact]
        public async Task AccountUser_Test_AgregarUsuario_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Url, _build.User, _build.Password);
            string messageExpect = $"El email 'userNet_{_build.User}' ya esta en uso.";
            var response = await user.CrearUsuarioAsync(new AccountUserRequest()
            {
                Name = "Prueba UT Hijo NetStandard",
                TaxId = "XAXX010101000",
                Email = $"userNet_{_build.User}",
                Stamps = 0,
                IsUnlimited = false,
                Password = $"_{_build.Password}",
                NotificationEmail = $"user_{_build.User}",
                Phone = "0000000000"
            });
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("success") || (response.Status.Equals("error") && response.Message.Equals(messageExpect)));
        }
        [Fact]
        public async Task AccountUser_Test_AgregarUsuario_ErrorV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await user.CrearUsuarioAsync(new AccountUserRequest()
            {
                Name = "Prueba UT Hijo NetStandard",
                TaxId = "",
                Email = $"userdotnet_{_build.User}",
                Stamps = 1,
                IsUnlimited = false,
                Password = $"_{_build.Password}",
                NotificationEmail = $"user_{_build.User}",
                Phone = "0000000000"
            });
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Status.Equals("error"));
        }
        //Actualizar Usuario
        [Fact]
        public async Task AccountUser_Test_UpdateUser_SuccessV2()
        {
            string messageExpect = "No es posible actualizar, los datos enviados son identicos a los actuales";
            Guid idUser = Guid.Parse("5343376c-ca13-43a2-adbc-bad372095aa0");
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ModificarUsuarioAsync(idUser, "Nombre Usuario NETStandard", "AAAA000101010", null, "1234567890", false);
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("success") || (response.Status.Equals("error") && response.Message.Equals(messageExpect)));
        }
        [Fact]
        public async Task AccountUser_Test_UpdateUser_IdErrorV2()
        {
            Guid idUser = Guid.Parse("d1defb8a-f7f8-4a70-83f2-989458560cfa");
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ModificarUsuarioAsync(idUser, "Nombre Usuario NETStandard", "AAAA000101010", null, "1234567890", false);
            CustomAssert.ErrorResponse(response);
        }
        //Eliminar
        [Fact(Skip = "Se omite ya que afecta las demas UT, habilitar segun se requiera.")]
        public async Task AccountUser_Test_EliminarUsuario_SuccessV2()
        {
            Guid idUser = Guid.Parse("da4bae40-af08-46ef-8fd6-4cdd982aedcf");
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.EliminarUsuarioAsync(idUser);
            CustomAssert.SuccessResponse(response, response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_EliminarUsuarioConTimbres_ErrorV2()
        {
            Guid idUser = Guid.Parse("5343376c-ca13-43a2-adbc-bad372095aa0");
            string messageExpect = "Error al eliminar";
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.EliminarUsuarioAsync(idUser);
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
            Assert.True(response.Message.Equals(messageExpect));
        }
        [Fact]
        public async Task AccountUser_Test_EliminarUsuario_ErrorV2()
        {
            string messageExpect = "Error al eliminar";
            Guid idUser = Guid.Parse("fbed157d-1949-4531-8058-0a8ee0209d36");
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.EliminarUsuarioAsync(idUser);
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
            Assert.True(response.Message.Equals(messageExpect));
        }
        //Consultas
        [Fact]
        public async Task AccountUser_Test_GetUsers_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosAsync();
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count() > 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUsers_ErrorV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, "");
            var response = await user.ObtenerUsuariosAsync();
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByUuid_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByIdAsync(_idUser);
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Count() > 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByUuid_ErrorV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByIdAsync(Guid.NewGuid());
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Count() == 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByTaxId_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByTaxIdAsync("AAAA000101010");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Count() > 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByTaxId_ErrorV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByTaxIdAsync("AAAA000101020");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Count() == 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByEmail_SuccessV2()
        {
            var email = $"userNet_{_build.User}";
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByEmailAsync(email);
            Assert.True(response.Data.Count() > 0);
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByEmail_ErrorV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByEmailAsync("correo_fake@example.com");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.True(response.Data.Count() == 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByActive_True_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByIsActiveAsync(true);
            Assert.True(response.Data.Count() > 0);
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByActive_False_SuccessV2()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosByIsActiveAsync(false);
            Assert.True(response.Data.Count() == 0);
            CustomAssert.SuccessResponse(response, response.Data);
        }
    }
}
