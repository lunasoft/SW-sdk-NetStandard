using SW.Services.Stamp;
using sw_sdk.Helpers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Test_SW.Helper;
using Test_SW.Helpers;
using Xunit;

namespace sdk_test.Services.Pdf
{
    public class Pdf_Test
    {
        private BuildSettings build;
        public Pdf_Test()
        {
            build = new BuildSettings();
        }
        /// <summary>
        /// Generar PDF mediante usuario y contraseña
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_User()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, build.templateId);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF mediante usuario y contraseña, XML en B64
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_GenerateB64_User()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml, true);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, build.templateId, null, true);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF, XML en B64, error XML vacio.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDF_Test_GenerateB64_EmptyXML_Error()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.GenerarPdfAsync(String.Empty, build.b64Logo, PdfTemplates.cfdi40, null, true);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "500"));
            Assert.True(String.Equals(response.MessageDetail, "Internal Server Error"));
        }
        /// <summary>
        /// Generar PDF, XML en B64, string B64 invalido.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDF_Test_GenerateB64_InvalidB64_Error()
        {
            var expectedResult = "The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.";
            var xml = GetXml(build);
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.GenerarPdfAsync(xml, build.b64Logo, PdfTemplates.cfdi40, null, true);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, expectedResult));
            Assert.Contains("at System.Convert.FromBase64_ComputeResultLength", response.MessageDetail);
        }
        /// <summary>
        /// Generar PDF, XML en B64, XML no timbrado.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDF_Test_GenerateB64_NonTFD_Error()
        {
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.GenerarPdfAsync(xml, build.b64Logo, PdfTemplates.cfdi40, null, true);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "500"));
            Assert.True(String.Equals(response.MessageDetail, "Internal Server Error"));
        }
        /// <summary>
        /// Generar PDF, error XML vacio.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDF_Test_Generate_EmptyXML_Error()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.GenerarPdfAsync(String.Empty, build.b64Logo, PdfTemplates.cfdi40, null);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "500"));
            Assert.True(String.Equals(response.MessageDetail, "Internal Server Error")); ;
        }
        /// <summary>
        /// Generar PDF, XML no timbrado.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDF_Test_Generate_NonTFD_Error()
        {
            var xml = GetXml(build);
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.GenerarPdfAsync(xml, build.b64Logo, PdfTemplates.cfdi40, null);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "500"));
            Assert.True(String.Equals(response.MessageDetail, "Internal Server Error"));
        }
        /// <summary>
        /// Generar PDF mediante token
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_Token()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, build.templateId);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF mediante token, XML en B64
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_GenerateB64_Token()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
            var xml = GetXml(build);
            xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml, true);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, build.templateId, null, true);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF mendiante usuario y contraseña, plantilla default
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_GenerateDefault_User()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfDefaultAsync(response.Data.Cfdi, build.b64Logo);
                Assert.True(responsePdf.Data != null && responsePdf.Status == "success");
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF mediante token, plantilla default.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_GenerateDefault_Token()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.Token);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
                var responsePdf = await pdf.GenerarPdfDefaultAsync(response.Data.Cfdi, build.b64Logo);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Genenerar PDF de Pagos 2.0
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_Payment20()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build, "payment20");
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, PdfTemplates.payment20);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF de Nomina Rev. C
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_Payroll40()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build, "payroll40");
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, PdfTemplates.payroll40);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF de Carta Porte 3.1 Cfdi 4.0
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_Billoflading40()
        {
            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build, "billoflading40");
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, PdfTemplates.billoflading40cp31);
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// Generar PDF con plantilla personalizada.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PDf_Test_Generate_CustomTemplateId()
        {

            SW.Services.Issue.Issue issue = new SW.Services.Issue.Issue(build.Url, build.User, build.Password);
            var xml = GetXml(build);
            var response = (StampResponseV2)await issue.TimbrarV2Async(xml);
            if (response.Status == "success")
            {
                SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
                var responsePdf = await pdf.GenerarPdfAsync(response.Data.Cfdi, build.b64Logo, "cfdi40");
                CustomAssert.SuccessResponse(responsePdf, responsePdf.Data);
            }
            else
            {
                Assert.True(false);
            }
        }
        [Fact]
        public async Task Pdf_Test_RegeneratePdf_Success()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.RegenerarPdfAsync(Guid.Parse("60a24e29-2cde-4151-b5d6-4fd59f85b588"));
            CustomAssert.SuccessResponse(response, response);
            Assert.True(response.Message.Contains("Solicitud se proceso correctamente."));
        }
        [Fact]
        public async Task Pdf_Test_RegeneratePdf_Auth_Success()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Url, build.User, build.Password);
            var response = await pdf.RegenerarPdfAsync(Guid.Parse("60a24e29-2cde-4151-b5d6-4fd59f85b588"));
            CustomAssert.SuccessResponse(response, response);
            Assert.True(response.Message.Equals("Solicitud se proceso correctamente."));
        }
        [Fact]
        public async Task Pdf_Test_RegeneratePdf_NotFound_Error()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.UrlApi, build.Token);
            var response = await pdf.RegenerarPdfAsync(Guid.Empty);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "404"));
            Assert.True(String.Equals(response.MessageDetail, "Not Found"));
        }
        [Fact]
        public async Task Pdf_Test_RegeneratePdf_InvalidUrl_Error()
        {
            SW.Services.Pdf.Pdf pdf = new SW.Services.Pdf.Pdf(build.Url, build.Token);
            var response = await pdf.RegenerarPdfAsync(Guid.Empty);
            CustomAssert.ErrorResponse(response);
            Assert.True(String.Equals(response.Message, "404"));
            Assert.True(String.Equals(response.MessageDetail, "Not Found"));
        }
        static Random randomNumber = new Random(1);
        private string GetXml(BuildSettings build, string fileName = null)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(string.Format("Resources/CFDI40/{0}.xml", fileName ?? "cfdi40")));
            xml = Test_SW.Helpers.SignTools.RemoverCaracteresInvalidosXml(xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
            doc.DocumentElement.SetAttribute("Folio", DateTime.Now.Ticks.ToString() + randomNumber.Next(100));
            xml = doc.OuterXml;
            return xml;
        }
    }
}
