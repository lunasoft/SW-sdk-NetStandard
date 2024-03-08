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
            _idUser = Guid.Parse("dec88273-6587-4f1e-9673-317b30e07aab");
        }
        [Fact]
        public async Task AccountUser_Test_AgregarUsuario_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await user.CrearUsuarioAsync(new AccountUserRequest()
            {
                Email = $"hijo_{_build.User}",
                Password = $"${_build.Password}",
                ProfileType = SW.Helpers.AccountUserProfile.Hijo,
                Rfc = "XAXX010101000",
                Name = "Pruebas UT Hijo",
                Unlimited = false,
                Stamps = 1
            });
            Assert.NotNull(response);
            Assert.True(response.Status.Equals("success") || (response.Status.Equals("error") && response.Message.Contains("AU1001")));
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_AgregarUsuario_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Url, _build.User, _build.Password);
            var response = await user.CrearUsuarioAsync(new AccountUserRequest()
            {
                Password = $"${_build.Password}",
                ProfileType = SW.Helpers.AccountUserProfile.Hijo,
                Rfc = "XAXX010101000",
                Name = "Pruebas UT Hijo",
                Unlimited = false,
                Stamps = 1
            });
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
            Assert.True(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [Fact]
        public async Task AccountUser_Test_GetUsers_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuariosAsync();
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count() > 0);
        }
        [Fact]
        public async Task AccountUser_Test_GetUsers_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, "");
            var response = await user.ObtenerUsuariosAsync();
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_GetUser_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuarioAsync();
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact]
        public async Task AccountUser_Test_GetUser_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, "");
            var response = await user.ObtenerUsuarioAsync();
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByUuid_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuarioAsync(_idUser);
            CustomAssert.SuccessResponse(response, response.Data);
        }
        [Fact]
        public async Task AccountUser_Test_GetUserByUuid_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ObtenerUsuarioAsync(Guid.NewGuid());
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_UpdateUser_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ModificarUsuarioAsync(Guid.Parse("4ee2d8af-a663-45c0-8128-7f0b7b153c7d"), "XAXX010101000", "Nombre Usuario");
            CustomAssert.SuccessResponse(response, response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_UpdateUser_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.ModificarUsuarioAsync(_idUser, "XAXX010101000", "Nombre Usuario");
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact(Skip = "Se omite ya que afecta las demas UT, habilitar segun se requiera.")]
        public async Task AccountUser_Test_EliminarUsuario_Success()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.EliminarUsuarioAsync(_idUser);
            CustomAssert.SuccessResponse(response, response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
        [Fact]
        public async Task AccountUser_Test_EliminarUsuario_Error()
        {
            AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
            var response = await user.EliminarUsuarioAsync(Guid.NewGuid());
            CustomAssert.ErrorResponse(response);
            Assert.True(!String.IsNullOrEmpty(response.Message));
        }
    }
}
