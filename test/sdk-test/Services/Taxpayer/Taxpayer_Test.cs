using SW.Services.Taxpayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_SW.Helper;
using Test_SW.Helpers;
using Xunit;

namespace Test_SW.Services.Taxpayer_Test
{
    public class Taxpayer_Test
    {
        private readonly BuildSettings _build;

        public Taxpayer_Test()
        {
            _build = new BuildSettings();
        }
        [Fact]
        public async Task Taxpayer_Success()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url, _build.Token);
            TaxpayerResponse response = await taxpayer.GetTaxpayer("ZNS1101105T3");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.NotNull(response.Data.id);
            Assert.NotNull(response.Data.rfc);
            Assert.NotNull(response.Data.situacion_del_contribuyente);
            Assert.NotNull(response.Data.numero_y_fecha_oficio_global_presuncion);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_presuntos);
            Assert.NotNull(response.Data.publicacion_DOF_presuntos);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_definitivos);
            Assert.NotNull(response.Data.publicacion_DOF_definitivos);
            Assert.NotNull(response.Data.numero_fecha_oficio_global_sentencia_favorable);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_sentencia_favorable);

        }
        [Fact]
        public async Task Taxpayer_Auth_Success()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url, _build.User, _build.Password);
            TaxpayerResponse response = await taxpayer.GetTaxpayer("ZNS1101105T3");
            CustomAssert.SuccessResponse(response, response.Data);
            Assert.NotNull(response.Data.id);
            Assert.NotNull(response.Data.rfc);
            Assert.NotNull(response.Data.situacion_del_contribuyente);
            Assert.NotNull(response.Data.numero_y_fecha_oficio_global_presuncion);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_presuntos);
            Assert.NotNull(response.Data.publicacion_DOF_presuntos);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_definitivos);
            Assert.NotNull(response.Data.publicacion_DOF_definitivos);
            Assert.NotNull(response.Data.numero_fecha_oficio_global_sentencia_favorable);
            Assert.NotNull(response.Data.publicacion_pagina_SAT_sentencia_favorable);
        }
        [Fact]
        public async Task Taxpayer_Error()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url,"token");
            TaxpayerResponse response = await taxpayer.GetTaxpayer("ZNS1101105T3");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("Token Mal Formado"));
        }
        [Fact]
        public async Task Taxpayer_Auth_Error()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url, "user", _build.Password);
            TaxpayerResponse response = await taxpayer.GetTaxpayer("ZNS1101105T3");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("El token debe contener 3 partes"));
        }
        [Fact]
        public async Task Taxpayer_Rfc_Error()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url, _build.Token);
            TaxpayerResponse response = await taxpayer.GetTaxpayer("ZNS1101105T");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("Error en la consulta."));
            Assert.True(response.MessageDetail.Equals("CS1002 - RFC malformado: ZNS1101105T"));
        }
        [Fact]
        public async Task Taxpayer_Rfc_NotFound_Error()
        {
            Taxpayer taxpayer = new Taxpayer(_build.Url, _build.Token);
            TaxpayerResponse response = await taxpayer.GetTaxpayer("EKU9003173C9");
            CustomAssert.ErrorResponse(response);
            Assert.True(response.Message.Equals("Error en la consulta."));
            Assert.True(response.MessageDetail.Equals("CS1002 - La consulta no arrojo resultados."));
        }
    }
}
