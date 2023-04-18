# SDK NetStandard
[![SW sapien](https://dka575ofm4ao0.cloudfront.net/pages-transactional_logos/retina/68712/SW_smarter-Servicios_web.png)](http://sw.com.mx/)

Librería NetStandard para el consumo de los servicios de SW sapien®.

## Contenido 

- [Compatibilidad](#Compatibilidad)
- [Dependencias](#Dependencias)
- [Documentación](#Documentación)
- [Instalación](#Instalación)
- [Implementación](#Implementación)
---

### Compatibilidad
- CFDI 3.3
- CFDI 4.0
- Net Framework 4.5 o superior.
---

### Dependencias
- RestSharp
- NewtonSoft
---

### Documentación
* [Inicio Rápido](https://developers.sw.com.mx/knowledge-base/conoce-el-proceso-de-integracion-en-solo-7-pasos/)
* [Documentacion Oficial Servicios](http://developers.sw.com.mx)
---

### Instalación

Instalar la libreria a traves Package Manager Console nuget.org

```cs
    Install-Package SW-sdk-netstandard
```

En caso de no utilizar Package Manager Console puedes descargar la libreria directamente a traves del siguiente [link](https://github.com/lunasoft/SW-sdk-NetStandard/releases) y agregarla como Referencia local a tu proyecto. Asegurate de utilizar la ultima version publicada.

---
### Implementación

La librería contara con los servicios principales como lo son Timbrado de CFDI, Cancelación, Consulta estatus CFDI, etc.

---
## Autenticaci&oacute;n ##
El servicio de Autenticación es utilizado principalmente para obtener el **token** el cual sera utilizado para poder timbrar nuestro CFDI (xml) ya emitido (sellado), para poder utilizar este servicio es necesario que cuente con un **usuario** y **contraseña** para posteriormente obtenga el token, usted puede utilizar los que estan en este ejemplo para el ambiente de **Pruebas**.

**Ejemplo de consumo de la librería para obtener token**
 ```cs
using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Authentication 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                Authentication auth = new Authentication("http://services.test.sw.com.mx", "user", "password");
                AuthResponse response = await auth.GetTokenAsync();
                }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
---

## Timbrado ##

<details>
<summary>
Timbrar CFDI V1
</summary>

## Timbrar CFDI V1 ##
**TimbrarV1** Recibe el contenido de un **XML** ya emitido (sellado) en formato **String**  ó tambien puede ser en **Base64**, posteriormente si la factura y el token son correctos devuelve el complemento timbre en un string (**TFD**), en caso contrario lanza una excepción.

Este método recibe los siguientes parametros:
* Archivo en formato **String** ó **Base64**
* Usuario y contraseña ó Token
* Url Servicios SW

**Ejemplo de consumo de la libreria para timbrar XML en formato string utilizando usuario y contraseña**
```cs
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el xml
                Stamp stamp = new Stamp("http://services.test.sw.com.mx", "user", "password");
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("file.xml"));
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para timbrar XML en formato string utilizando token** [¿Como obtener token?](http://developers.sw.com.mx/knowledge-base/generar-un-token-infinito/)
```cs
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url y el token
                //Despues se procedera a timbrar el xml
                Stamp stamp = new Stamp("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("file.xml"));
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para timbrar XML en Base64 utilizando token**
```cs
using SW.Services.Stamp;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url y el token
                //Despues se procedera a timbrar el xml
                Stamp stamp = new Stamp("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var xml = Convert.ToBase64String(Encoding.UTF8.GetBytes("file.xml"));
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml,true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Emisión Timbrado
</summary>

## Emisión Timbrado ##
**Emisión Timbrado** Realiza el sellado y timbrado de un comprobante CFDI 3.3 ó CFDI 4.0. Recibe el contenido de un **XML** en formato **String**  ó tambien puede ser en **Base64**, posteriormente si la factura y el token son correctos devuelve el complemento timbre en un string (**TFD**), en caso contrario lanza una excepción.

Este método recibe los siguientes parametros:
* Archivo en formato **String** ó **Base64**
* Usuario y contraseña ó Token
* Url Servicios SW

**Ejemplo de consumo de la libreria para la emisión Timbrado XML en formato string utilizando usuario y contraseña**
```cs
using SW.Services.Issue;
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Issue 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el xml
                Issue issue = new Issue("http://services.test.sw.com.mx", "user", "password");
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("file.xml"));
                var response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para la emisión Timbrado XML en formato string utilizando token**
```cs
using SW.Services.Issue;
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Issue 
                //A esta le pasamos la Url y el token
                //Despues se procedera a timbrar el XML
                Issue issue = new Issue("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("file.xml"));
                var response = (StampResponseV1)await issue.TimbrarV1Async(xml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Emisión Timbrado JSON
</summary>

## Emisión Timbrado JSON ##
**Emisión Timbrado JSON** Realiza el sellado y timbrado de un comprobante CFDI 3.3 ó CFDI 4.0. Recibe el contenido de un **JSON** en formato **String**, posteriormente si la factura y el token son correctos devuelve el complemento timbre en un string (**TFD**), en caso contrario lanza una excepción

Este método recibe los siguientes parametros:
* Archivo en formato **String**
* Usuario y contraseña ó Token
* Url Servicios SW

**Ejemplo de consumo de la libreria para la emisión Timbrado JSON en formato string utilizando usuario y contraseña**
```cs
using SW.Services.Issue;
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo IssueJson 
                //A esta le pasamos la Url, usuario y contraseña 
                //Despues se procedera a timbrar el XML
                IssueJson issue = new IssueJson("http://services.test.sw.com.mx", "user", "password");
                var json = Encoding.UTF8.GetString(File.ReadAllBytes("file.json"));
                var response = (StampResponseV1)await issue.TimbrarJsonV1Async(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
**Ejemplo de consumo de la libreria para la emisión Timbrado JSON en formato string utilizando token**
```cs
using SW.Services.Issue;
using SW.Services.Stamp;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo IssueJson 
                //A esta le pasamos la Url y su Token infinito 
                //Despues se procedera a timbrar el XML
                IssueJson issue = new IssueJson("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var json = Encoding.UTF8.GetString(File.ReadAllBytes("file.json"));
                var response = (StampResponseV1)await issue.TimbrarJsonV1Async(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

:pushpin: ***NOTA:*** Existen varias versiones de respuesta, las cuales son las siguientes:

| Version |                         Respuesta                             | 
|---------|---------------------------------------------------------------|
|  V1     | Devuelve el timbre fiscal digital                             | 
|  V2     | Devuelve el timbre fiscal digital y el CFDI timbrado          | 
|  V3     | Devuelve el CFDI timbrado                                     | 
|  V4     | Devuelve todos los datos del timbrado                         |

Para mayor referencia de estas versiones de respuesta, favor de visitar el siguiente [link](https://developers.sw.com.mx/knowledge-base/versiones-de-respuesta-timbrado/).

## Cancelación ##

Este servicio se utiliza para cancelar documentos xml y se puede hacer mediante varios metodos **Cancelación CSD**, **Cancelación PFX**, **Cancelacion por XML** y **Cancelación UUID**.

<details>
<summary>
Cancelacion por CSD
</summary>

## Cancelacion por CSD ##
Como su nombre lo indica, este método realiza la cancelacion mediante los CSD.

Este método recibe los siguientes parametros:
* Usuario y contraseña
* Url Servicios SW
* Certificado (.cer) en **Base64**
* Key (.key) en **Base64**
* RFC emisor
* Password del archivo key
* UUID
* Motivo
* Folio Sustitución (Si el motivo es 01)

**Ejemplo de consumo de la libreria para cancelar con CSD con motivo de cancelación 02 sin relación a documento mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string password = "12345678a";
                string rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                //Obtenemos Certificado y lo convertimos a Base 64
                string csdBase64 = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.cer"));
                //Obtenemos LLave y lo convertimos a Base 64
                string keyBase64 = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.key"));
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByCSDAsync(csdBase64, keyBase64, rfc, password, uuid, "02");
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para cancelar con CSD con motivo de cancelación 01 con relación a documento mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string password = "12345678a";
                string rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                string folioSustitucion = "01724196-ac5a-4735-b621-e3b42bcbb459";
                //Obtenemos Certificado y lo convertimos a Base 64
                string csdBase64 = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.cer"));
                //Obtenemos LLave y lo convertimos a Base 64
                string keyBase64 = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.key"));
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByCSDAsync(csdBase64, keyBase64, rfc, password, uuid, "01", folioSustitucion);
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Cancelacion por PFX
</summary>

## Cancelacion por PFX ##
Como su nombre lo indica, este método realiza la cancelacion mediante el PFX.

Este método recibe los siguientes parametros:
* Usuario y contraseña
* Url Servicios SW
* Archivo PFX en **Base64**
* RFC emisor
* Password (CSD)
* UUID
* Motivo
* Folio Sustitución

**Ejemplo de consumo de la libreria para cancelar con PFX con motivo de cancelación 02 sin relación a documento mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string password = "12345678a";
                string Rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                //Obtenemos y convertimos el PFX a base 64
                string Pfx = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.pfx"));
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByPFXAsync(Pfx, Rfc, password, uuid, "02");
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para cancelar con PFX con motivo 01 con documento relacionado mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string password = "12345678a";
                string Rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                string folioSustitucion = "01724196-ac5a-4735-b621-e3b42bcbb459";
                //Obtenemos Certificado y lo convertimos a Base 64
                string Pfx = Convert.ToBase64String(File.ReadAllBytes("EKU9003173C9.pfx"));
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByPFXAsync(Pfx, Rfc, password, uuid, "02");
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Cancelacion por XML
</summary>

## Cancelacion por XML ##
Como su nombre lo indica, este método realiza la cancelacion mediante el XML sellado con los UUID a cancelar.

Este método recibe los siguientes parametros:
* Usuario y contraseña
* Url Servicios SW
* XML sellado con los UUID a cancelar.

**Ejemplo de XML para Cancelar**
```xml
<Cancelacion xmlns="http://cancelacfd.sat.gob.mx"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:xsd="http://www.w3.org/2001/XMLSchema" Fecha="2021-12-26T18:15:28" RfcEmisor="EKU9003173C9">
    <Folios>
        <Folio UUID="fe4e71b0-8959-4fb9-8091-f5ac4fb0fef8" Motivo="02" FolioSustitucion=""/>
    </Folios>
    <Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
        <SignedInfo>
            <CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" />
            <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" />
            <Reference URI="">
                <Transforms>
                    <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature" />
                </Transforms>
                <DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1" />
                <DigestValue>XEdUtCptjdlz9DsYAP7nnU6MytU=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>ZnWh91e5tUc4/t1ZWnb3yOgB8zuCXNPioND+rv6aLOEwIw26/8sYYb+GT4wgyqlc09wOs32XTUwWoGQwtWMG8Euqq+4xJyobWvPCsX6CiURvD/Pd33xgkH92A0AGQxEMYGVT7wK+GFS2gDTYEYAXvZqzCe6+rXnlQvHML0TOOmhVu/wc8YrCbGt4z/F5sRxhjpa0eqwFEq4RmB4nkWjcD3Pnudn3XAI5NHIiOd8KVGVcDR+LvYvKj7h+18WxZgujpggYjbFN79i1jEsAEPDfgryUdTvjDw+KC7Mg+/ge6pssH42buEMIwVE4VX9Y3NtWSGTwdIK/8pxXk+Y5wyR6Gg==</SignatureValue>
        <KeyInfo>
            <X509Data>
                <X509IssuerSerial>
                    <X509IssuerName>OID.1.2.840.113549.1.9.2=responsable: ACDMA-SAT, OID.2.5.4.45=2.5.4.45, L=COYOACAN, S=CIUDAD DE MEXICO, C=MX, PostalCode=06370, STREET=3ra cerrada de cadiz, E=oscar.martinez@sat.gob.mx, OU=SAT-IES Authority, O=SERVICIO DE ADMINISTRACION TRIBUTARIA, CN=AC UAT</X509IssuerName>
                    <X509SerialNumber>292233162870206001759766198444326234574038512436</X509SerialNumber>
                </X509IssuerSerial>
                <X509Certificate>MIIFuzCCA6OgAwIBAgIUMzAwMDEwMDAwMDA0MDAwMDI0MzQwDQYJKoZIhvcNAQELBQAwggErMQ8wDQYDVQQDDAZBQyBVQVQxLjAsBgNVBAoMJVNFUlZJQ0lPIERFIEFETUlOSVNUUkFDSU9OIFRSSUJVVEFSSUExGjAYBgNVBAsMEVNBVC1JRVMgQXV0aG9yaXR5MSgwJgYJKoZIhvcNAQkBFhlvc2Nhci5tYXJ0aW5lekBzYXQuZ29iLm14MR0wGwYDVQQJDBQzcmEgY2VycmFkYSBkZSBjYWRpejEOMAwGA1UEEQwFMDYzNzAxCzAJBgNVBAYTAk1YMRkwFwYDVQQIDBBDSVVEQUQgREUgTUVYSUNPMREwDwYDVQQHDAhDT1lPQUNBTjERMA8GA1UELRMIMi41LjQuNDUxJTAjBgkqhkiG9w0BCQITFnJlc3BvbnNhYmxlOiBBQ0RNQS1TQVQwHhcNMTkwNjE3MTk0NDE0WhcNMjMwNjE3MTk0NDE0WjCB4jEnMCUGA1UEAxMeRVNDVUVMQSBLRU1QRVIgVVJHQVRFIFNBIERFIENWMScwJQYDVQQpEx5FU0NVRUxBIEtFTVBFUiBVUkdBVEUgU0EgREUgQ1YxJzAlBgNVBAoTHkVTQ1VFTEEgS0VNUEVSIFVSR0FURSBTQSBERSBDVjElMCMGA1UELRMcRUtVOTAwMzE3M0M5IC8gWElRQjg5MTExNlFFNDEeMBwGA1UEBRMVIC8gWElRQjg5MTExNk1HUk1aUjA1MR4wHAYDVQQLExVFc2N1ZWxhIEtlbXBlciBVcmdhdGUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCN0peKpgfOL75iYRv1fqq+oVYsLPVUR/GibYmGKc9InHFy5lYF6OTYjnIIvmkOdRobbGlCUxORX/tLsl8Ya9gm6Yo7hHnODRBIDup3GISFzB/96R9K/MzYQOcscMIoBDARaycnLvy7FlMvO7/rlVnsSARxZRO8Kz8Zkksj2zpeYpjZIya/369+oGqQk1cTRkHo59JvJ4Tfbk/3iIyf4H/Ini9nBe9cYWo0MnKob7DDt/vsdi5tA8mMtA953LapNyCZIDCRQQlUGNgDqY9/8F5mUvVgkcczsIgGdvf9vMQPSf3jjCiKj7j6ucxl1+FwJWmbvgNmiaUR/0q4m2rm78lFAgMBAAGjHTAbMAwGA1UdEwEB/wQCMAAwCwYDVR0PBAQDAgbAMA0GCSqGSIb3DQEBCwUAA4ICAQBcpj1TjT4jiinIujIdAlFzE6kRwYJCnDG08zSp4kSnShjxADGEXH2chehKMV0FY7c4njA5eDGdA/G2OCTPvF5rpeCZP5Dw504RZkYDl2suRz+wa1sNBVpbnBJEK0fQcN3IftBwsgNFdFhUtCyw3lus1SSJbPxjLHS6FcZZ51YSeIfcNXOAuTqdimusaXq15GrSrCOkM6n2jfj2sMJYM2HXaXJ6rGTEgYmhYdwxWtil6RfZB+fGQ/H9I9WLnl4KTZUS6C9+NLHh4FPDhSk19fpS2S/56aqgFoGAkXAYt9Fy5ECaPcULIfJ1DEbsXKyRdCv3JY89+0MNkOdaDnsemS2o5Gl08zI4iYtt3L40gAZ60NPh31kVLnYNsmvfNxYyKp+AeJtDHyW9w7ftM0Hoi+BuRmcAQSKFV3pk8j51la+jrRBrAUv8blbRcQ5BiZUwJzHFEKIwTsRGoRyEx96sNnB03n6GTwjIGz92SmLdNl95r9rkvp+2m4S6q1lPuXaFg7DGBrXWC8iyqeWE2iobdwIIuXPTMVqQb12m1dAkJVRO5NdHnP/MpqOvOgLqoZBNHGyBg4Gqm4sCJHCxA1c8Elfa2RQTCk0tAzllL4vOnI1GHkGJn65xokGsaU4B4D36xh7eWrfj4/pgWHmtoDAYa8wzSwo2GVCZOs+mtEgOQB91/g==</X509Certificate>
            </X509Data>
        </KeyInfo>
    </Signature>
</Cancelacion>
```
Para caso de motivo 01 deberá añadir el atributo "FolioSustitucion" dentro del Nodo <Folio>

Ejemplo de nodo Folio: 
```
<Folios>
	<Folio UUID="b374db50-a0a3-4028-9d01-32b93e2b925a" Motivo="01" FolioSustitucion="b3641a4b-7177-4323-aaa0-29bd34bf1ff8" />
</Folios>
```

**Ejemplo de consumo de la libreria para cancelar con XML mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Obtenemos el XML de cancelacion
                byte[] xml = File.ReadAllBytes("cancelacion.xml");
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByXMLAsync(xml);
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Cancelacion por UUID
</summary>

## Cancelacion por UUID ##
Como su nombre lo indica, este método realiza la cancelacion mediante el UUID a cancelar.

Este método recibe los siguientes parametros:
* Usuario y contraseña
* Url Servicios SW
* RFC emisor
* UUID
* Motivo
* Folio Sustitución

**Ejemplo de consumo de la libreria para cancelar con UUID con motivo de cancelación 02 sin documento relacionado mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByRfcUuidAsync(rfc, uuid, "02");
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para cancelar con UUID con motivo de cancelación 01 con documento relacionado mediante usuario y contraseña**
```cs
using SW.Services.Cancelation;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos de Cancelación
                string rfc = "EKU9003173C9";
                string uuid = "478569b5-c323-4dc4-91cf-b6e9f6979527";
                string folioSustitucion = "01724196-ac5a-4735-b621-e3b42bcbb459";
                //Creamos una instancia de tipo Cancelation 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a Cancelar el XML o CFDI
                Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la petición de cancelación al servicio.
                var response = await cancelation.CancelarByRfcUuidAsync(rfc, uuid, "01", folioSustitucion);
                if (response.status == "success" && response.data != null)
                {
                    //Acuse de cancelación
                    Console.WriteLine(response.data.acuse);
                    //Estatus por UUID
                    foreach (var folio in response.data.uuid)
                    {
                        Console.WriteLine("UUID: {0} Estatus: {1}", folio.Key, folio.Value);
                    }
                }
                else
                {
                    //Obtenemos el detalle del Error
                    Console.WriteLine("Error al Cancelar\n\n");
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## Usuarios

Servicios para trabajar con usuarios, incluye metodos para crear, modificar, obtener y eliminar usuarios.

### Inicializar

- Usuario y contraseña

```cs
 AccountUser user = new AccountUser(_build.UrlApi, _build.Url, _build.User, _build.Password);
```

- Token

```cs
 AccountUser user = new AccountUser(_build.UrlApi, _build.Token);
```

<details>
<summary>
Crear Usuario
</summary>

```cs
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
```

</details>

<details>
<summary>
Obtener Usuario Por Token
</summary>

```cs
var response = await user.ObtenerUsuarioAsync();
```

</details>

<details>
<summary>
Obtener Usuario Por UUID
</summary>

```cs
var response = await user.ObtenerUsuarioAsync(_idUser);
```

</details>

<details>
<summary>
Obtener Usuarios
</summary>

```cs
var response = await user.ObtenerUsuariosAsync();
```

</details>

<details>
<summary>
Editar Usuario
</summary>


```cs
var response = await user.ModificarUsuarioAsync(_idUser, "XAXX010101000", "Nombre Usuario");
```

</details>

<details>
<summary>
Eliminar Usuario
</summary>

```cs
var response = await user.EliminarUsuarioAsync(_idUser);
```

</details>

## Consulta de Saldos ##
Método mediante el cual puedes realizar la consulta de tu saldo para consumir los servicios de SW.

<details>
  <summary>Ejemplos</summary>

Este metodo recibe los siguientes parametros:
* Usuario y contraseña o Token
* Url Servicios SW

**Ejemplo de consumo de la libreria para consultar el saldo mediante usuario y contraseña**
```cs
using SW.Services.Account;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo BalanceAccount 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a la consulta de saldo
                BalanceAccount account = new BalanceAccount("http://services.test.sw.com.mx", "user", "password");
                AccountResponse response = await account.ConsultarSaldoAsync();
                if (response.status != "error")
                {
                     //Para Obtener el saldo Timbres
                    Console.WriteLine(response.data.saldoTimbres);

                    //Para Obtenerlos timbres Utilizados
                    Console.WriteLine(response.data.timbresUtilizados);

                    //Para Obtener si es Ilimitado (para cuentas hijo)
                    Console.WriteLine(response.data.unlimited);
                }
                else
                {
                    //En caso de error, se pueden visualizar los campos message y/o messageDetail
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para consultar el saldo mediante token**
```cs
using SW.Services.Account;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo BalanceAccount 
                //A esta le pasamos la Url y el token
                //Despues se procedera a la consulta de saldo
                BalanceAccount account = new BalanceAccount("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                AccountResponse response = await account.ConsultarSaldoAsync();
                if (response.status != "error")
                {
                     //Para Obtener el saldo Timbres
                    Console.WriteLine(response.data.saldoTimbres);

                    //Para Obtenerlos timbres Utilizados
                    Console.WriteLine(response.data.timbresUtilizados);

                    //Para Obtener si es Ilimitado (para cuentas hijo)
                    Console.WriteLine(response.data.unlimited);
                }
                else
                {
                    //En caso de error, se pueden visualizar los campos message y/o messageDetail
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## Validación ##

<details>
<summary>
Validación XML
</summary>

## Validación XML ##
Este servicio recibe un comprobante CFDI 3.3 ó 4.0 en formato XML mediante el cual se valida integridad, sello, errores de estructura, matriz de errores del SAT incluyendo complementos, se valida que exista en el SAT, así como el estatus en el SAT.

Este metodo recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña o token
* XML

**Ejemplo de consumo de la libreria para validación de XML mediante usuario y contraseña**
```cs
using SW.Services.Validate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Validate
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                Validate validate = new Validate("http://services.test.sw.com.mx", "user", "password");
                //Obtenemos el XML a validar
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("validacion.xml"));
                //Realizamos la peticion de validacion pasando el XML
                ValidateXmlResponse response = await validate.ValidateXmlAsync(xml);
                
                //El objeto response tendra los siguientes atributos:
                List<Detail> detail1 = response.detail;
                Console.Write("Status: " + response.status); 
                Console.Write("\ndetail: ");
                foreach (var i in detail1)
                {
                    foreach (var j in i.detail)
                    {
                        Console.Write("\n\tdetail: ");
                        Console.Write("\n\t\tMessage: " + j.message);
                        Console.Write("\n\t\tMessageDetail: " + j.messageDetail);
                        Console.Write("\n\t\tType: " + j.type);
                    }
                    Console.Write("\n\tSection: \n" + i.section);
                }
                //Para obtener la cadena original SAT
                Console.Write(response.cadenaOriginalSAT + "\n");
                //Para obtener la cadena original del comprobante
                Console.Write(response.cadenaOriginalComprobante + "\n");
                //Para obtener el uuid
                Console.Write(response.uuid + "\n");
                //Para obtener el status SAT
                Console.Write(response.statusSat + "\n");
                //Para obtener el status code SAT
                Console.Write(response.statusCodeSat + "\n");
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para validación de XML mediante token**
```cs
using SW.Services.Validate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Validate
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                Validate validate = new Validate("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                //Obtenemos el XML a validar
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes("validacion.xml"));
                //Realizamos la peticion de validacion pasando el XML
                ValidateXmlResponse response = await validate.ValidateXmlAsync(xml);
                
                //El objeto response tendra los siguientes atributos:
                List<Detail> detail1 = response.detail;
                Console.Write("Status: " + response.status); 
                Console.Write("\ndetail: ");
                foreach (var i in detail1)
                {
                    foreach (var j in i.detail)
                    {
                        Console.Write("\n\tdetail: ");
                        Console.Write("\n\t\tMessage: " + j.message);
                        Console.Write("\n\t\tMessageDetail: " + j.messageDetail);
                        Console.Write("\n\t\tType: " + j.type);
                    }
                    Console.Write("\n\tSection: \n" + i.section);
                }
                //Para obtener la cadena original SAT
                Console.Write(response.cadenaOriginalSAT + "\n");
                //Para obtener la cadena original del comprobante
                Console.Write(response.cadenaOriginalComprobante + "\n");
                //Para obtener el uuid
                Console.Write(response.uuid + "\n");
                //Para obtener el status SAT
                Console.Write(response.statusSat + "\n");
                //Para obtener el status code SAT
                Console.Write(response.statusCodeSat + "\n");
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>


## Consulta Estatus ##

<details>
<summary>
Consulta Estatus SAT
</summary>

## Consulta Estatus SAT ##
Este servicio sirve para consultar el estatus de un CFDI antes y después de enviarlo a cancelar, con él sabremos sí puede ser cancelado de forma directa, o en caso de que se necesite consultar los CFDI relacionados para poder generar la cancelación.

:pushpin: ***NOTA:*** El servicio de consulta es de tipo SOAP y es proporcionado directamente por parte del SAT.

Este metodo recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña o token
* RFC Emisor
* RFC Receptor
* Total declarado en el comprobante
* UUID del comprobante
* Sello digital del emisor

**Ejemplo de consumo de la libreria para la consulta del estatus SAT**
```cs
using SW.Services.Status;
using System;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Status
                //A esta le pasamos la Url.
                //Despues realizamos la peticion pasando los parametros necesarios en el orden mencionados.
                Status status = new Status("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
                var response = status.GetStatusCFDI("GOM0809114P5", "LSO1306189R5", "206.85", "021ea2fb-2254-4232-983b-9808c2ed831b", "WBjHe+9loaYIMM5wYwLxfhT6FnotG0KLRNheOlIxXoVMvsafsRdWY/aZ....");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## CFDI Relacionados ##
A través de estos siguientes métodos obtendremos un listado de los UUID que se encuentren relacionados a una factura.

<details>
<summary>
Relacionados por CSD
</summary>

## Relacionados por CSD ##
Este método obtendra un listado de los UUID relacionados mediante CSD

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* Certificado en base64
* Llave en base64 
* RFC del emisor 
* Contraseña del certificado 
* UUID de la factura.

**Ejemplo de consumo de la librería para la consulta de CFDI relacionados por CSD mediante usuario y contraseña**
```cs
sing SW.Services.Relations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string Rfc = "EKU9003173C9";
                string CerPassword = "12345678a";
                //Obtenemos Certificado y lo convertimos a Base 64
                string Cer = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.cer"));
                //Obtenemos LLave y lo convertimos a Base 64
                string Key = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.key"));
                //Creamos una instancia de tipo Relations
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a consultar las facturas relacionadas
                Relations relations = new Relations("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                RelationsResponse response = await relations.RelationsByCSDAsync(Cer, Key, Rfc, CerPassword, "31c885c8-6dcb-4d82-9cfd-01707c828c50");
                
                if (response.status == "success")
                {
                    Console.WriteLine(response.codStatus);
                    //Para obtener el uuid consultado
                    Console.WriteLine(response.data.uuidConsultado);
                    //Para obtener el resultado de la consulta
                    Console.WriteLine(response.data.resultado);
                    //Para obtener los uuid padres
                    Console.WriteLine(response.data.uuidsRelacionadosPadres);
                    //Para obtener los uuid hijo
                    Console.WriteLine(response.data.uuidsRelacionadosHijos);
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Relacionados por PFX
</summary>

## Relacionados por PFX ##
Este método obtendra un listado de los UUID relacionados mediante PFX.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* UUID del comprobante
* RFC del emisor
* Archivo Pfx en Base64
* Contraseña del certificado

**Ejemplo de consumo de la librería para la consulta CFDI relacionados por PFX mediante usuario y contraseña**
```cs
using SW.Services.Relations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string Rfc = "EKU9003173C9";
                string CerPassword = "12345678a";
                //Obtenemos PFX y lo convertimos a Base 64
                string Pfx = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.pfx"));
                //Creamos una instancia de tipo Relations
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a consultar las facturas relacionadas
                Relations relations = new Relations("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                RelationsResponse response = await relations.RelationsByPFXAsync(Pfx, Rfc, CerPassword, "31c885c8-6dcb-4d82-9cfd-01707c828c50");
                
                if (response.status == "success")
                {
                    //Para obtener el codigoStatus
                    Console.WriteLine(response.codStatus);
                    //Para obtener el uuid consultado
                    Console.WriteLine(response.data.uuidConsultado);
                    //Para obtener el resultado de la consulta
                    Console.WriteLine(response.data.resultado);
                    //Para obtener los uuid padres
                    Console.WriteLine(response.data.uuidsRelacionadosPadres);
                    //Para obtener los uuid hijo
                    Console.WriteLine(response.data.uuidsRelacionadosHijos);
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Relacionados por XML
</summary>

## Relacionados por XML ##
Este método obtendra un listado de los UUID relacionados mediante el XML.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* XML del comprobante

**Ejemplo de XML**
```xml
<?xml version="1.0" encoding="utf-8"?>
<PeticionConsultaRelacionados xmlns:xsd="http://www.w3.org/2001/XMLSchema" 
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Uuid="51BADE4D-8285-4597-A092-7DB1D50E5EFD" RfcReceptor="LAN7008173R5" RfcPacEnviaSolicitud="DAL050601L35" 
    xmlns="http://cancelacfd.sat.gob.mx">
    <Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
        <SignedInfo>
            <CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" />
            <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" />
            <Reference URI="">
                <Transforms>
                    <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature" />
                </Transforms>
                <DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1" />
                <DigestValue>yYGkb9DCJgiGl2O4vCf5B3gXTTI=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>VBBjMXJgS/oCb4iTazKrPmhWSICGT5wbeTf8G4tW2UuqnKBLS1NWD7Uf37kAX8+GBB04So7YlTcEw3I/X2JkHDadSxCiZ940YksNIVddmCqllJL6giMHVQJoXcTH8WQ9pO/4TbREQZ8/jxPqIvxCXrOn963PKFrZFB8eo5RQxLUa12WMi5RWgh8dSUwQxS2W3dm1XXP8bqXPOjy7GtZc3ObeTLMcXo/YoLyEAobVCnP+igOEXLxKEN2HZPzHGtA2g/5ONxuhu3UTxix9D/5ItjXdH9nk7VL0A58Xgw3qv6Q0vjmlxyu7RO0E2O3D2tLejfExt3WvsjZ8xvEKXSFp+A==</SignatureValue>
        <KeyInfo>
            <X509Data>
                <X509IssuerSerial>
                    <X509IssuerName>OID.1.2.840.113549.1.9.2=Responsable: ACDMA, OID.2.5.4.45=SAT970701NN3, L=Coyoacán, S=Distrito Federal, C=MX, PostalCode=06300, STREET="Av. Hidalgo 77, Col. Guerrero", E=asisnet@pruebas.sat.gob.mx, OU=Administración de Seguridad de la Información, O=Servicio de Administración Tributaria, CN=A.C. 2 de pruebas(4096)</X509IssuerName>
                    <X509SerialNumber>3230303031303030303030333030303232383135</X509SerialNumber>
                </X509IssuerSerial>
                <X509Certificate>MIIFxTCCA62gAwIBAgIUMjAwMDEwMDAwMDAzMDAwMjI4MTUwDQYJKoZIhvcNAQELBQAwggFmMSAwHgYDVQQDDBdBLkMuIDIgZGUgcHJ1ZWJhcyg0MDk2KTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExODA2BgNVBAsML0FkbWluaXN0cmFjacOzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5mb3JtYWNpw7NuMSkwJwYJKoZIhvcNAQkBFhphc2lzbmV0QHBydWViYXMuc2F0LmdvYi5teDEmMCQGA1UECQwdQXYuIEhpZGFsZ28gNzcsIENvbC4gR3VlcnJlcm8xDjAMBgNVBBEMBTA2MzAwMQswCQYDVQQGEwJNWDEZMBcGA1UECAwQRGlzdHJpdG8gRmVkZXJhbDESMBAGA1UEBwwJQ295b2Fjw6FuMRUwEwYDVQQtEwxTQVQ5NzA3MDFOTjMxITAfBgkqhkiG9w0BCQIMElJlc3BvbnNhYmxlOiBBQ0RNQTAeFw0xNjEwMjUyMTUyMTFaFw0yMDEwMjUyMTUyMTFaMIGxMRowGAYDVQQDExFDSU5ERU1FWCBTQSBERSBDVjEaMBgGA1UEKRMRQ0lOREVNRVggU0EgREUgQ1YxGjAYBgNVBAoTEUNJTkRFTUVYIFNBIERFIENWMSUwIwYDVQQtExxMQU43MDA4MTczUjUgLyBGVUFCNzcwMTE3QlhBMR4wHAYDVQQFExUgLyBGVUFCNzcwMTE3TURGUk5OMDkxFDASBgNVBAsUC1BydWViYV9DRkRJMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgvvCiCFDFVaYX7xdVRhp/38ULWto/LKDSZy1yrXKpaqFXqERJWF78YHKf3N5GBoXgzwFPuDX+5kvY5wtYNxx/Owu2shNZqFFh6EKsysQMeP5rz6kE1gFYenaPEUP9zj+h0bL3xR5aqoTsqGF24mKBLoiaK44pXBzGzgsxZishVJVM6XbzNJVonEUNbI25DhgWAd86f2aU3BmOH2K1RZx41dtTT56UsszJls4tPFODr/caWuZEuUvLp1M3nj7Dyu88mhD2f+1fA/g7kzcU/1tcpFXF/rIy93APvkU72jwvkrnprzs+SnG81+/F16ahuGsb2EZ88dKHwqxEkwzhMyTbQIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEAJ/xkL8I+fpilZP+9aO8n93+20XxVomLJjeSL+Ng2ErL2GgatpLuN5JknFBkZAhxVIgMaTS23zzk1RLtRaYvH83lBH5E+M+kEjFGp14Fne1iV2Pm3vL4jeLmzHgY1Kf5HmeVrrp4PU7WQg16VpyHaJ/eonPNiEBUjcyQ1iFfkzJmnSJvDGtfQK2TiEolDJApYv0OWdm4is9Bsfi9j6lI9/T6MNZ+/LM2L/t72Vau4r7m94JDEzaO3A0wHAtQ97fjBfBiO5M8AEISAV7eZidIl3iaJJHkQbBYiiW2gikreUZKPUX0HmlnIqqQcBJhWKRu6Nqk6aZBTETLLpGrvF9OArV1JSsbdw/ZH+P88RAt5em5/gjwwtFlNHyiKG5w+UFpaZOK3gZP0su0sa6dlPeQ9EL4JlFkGqQCgSQ+NOsXqaOavgoP5VLykLwuGnwIUnuhBTVeDbzpgrg9LuF5dYp/zs+Y9ScJqe5VMAagLSYTShNtN8luV7LvxF9pgWwZdcM7lUwqJmUddCiZqdngg3vzTactMToG16gZA4CWnMgbU4E+r541+FNMpgAZNvs2CiW/eApfaaQojsZEAHDsDv4L5n3M1CC7fYjE/d61aSng1LaO6T1mh+dEfPvLzp7zyzz+UgWMhi5Cs4pcXx1eic5r7uxPoBwcCTt3YI1jKVVnV7/w=</X509Certificate>
            </X509Data>
        </KeyInfo>
    </Signature>
</PeticionConsultaRelacionados>
```

**Ejemplo de consumo de la librería para la consulta CFDI relacionados por XML mediante usuario y contraseña**
```cs
using SW.Services.Relations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Obtenemos el XML
                byte[] Rxml = File.ReadAllBytes("cancelacion.xml");
                //Creamos una instancia de tipo Relations
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a consultar las facturas relacionadas
                Relations relations = new Relations("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                RelationsResponse response = await relations.RelationsByXMLAsync(Rxml);

                if (response.status == "success")
                {
                    //Para obtener el codigoStatus
                    Console.WriteLine(response.codStatus);
                    //Para obtener el uuid consultado
                    Console.WriteLine(response.data.uuidConsultado);
                    //Para obtener el resultado de la consulta
                    Console.WriteLine(response.data.resultado);
                    //Para obtener los uuid padres
                    Console.WriteLine(response.data.uuidsRelacionadosPadres);
                    //Para obtener los uuid hijo
                    Console.WriteLine(response.data.uuidsRelacionadosHijos);
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Relacionados por UUID
</summary>

## Relacionados por UUID ##
Este método obtendra un listado de los UUID relacionados mediante el UUID de la factura.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* UUID de la factura que ser requiere consultar relacionados
* RFC del emisor

:pushpin: ***NOTA:*** El usuario deberá tener sus certificados en el administrador de timbres para la utilización de este método.

**Ejemplo de consumo de la librería para la consulta CFDI relacionados por UUID mediante usuario y contraseña**
```cs
using SW.Services.Relations;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string Rfc = "EKU9003173C9";
                string uuid = "31c885c8-6dcb-4d82-9cfd-01707c828c50";
                //Creamos una instancia de tipo Relations
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a consultar las facturas relacionadas
                Relations relations = new Relations("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                RelationsResponse response = await relations.RelationsByRfcUuidAsync(Rfc, uuid);

                if (response.status == "success")
                {
                    //Para obtener el codigoStatus
                    Console.WriteLine(response.codStatus);
                    //Para obtener el uuid consultado
                    Console.WriteLine(response.data.uuidConsultado);
                    //Para obtener el resultado de la consulta
                    Console.WriteLine(response.data.resultado);
                    //Para obtener los uuid padres
                    Console.WriteLine(response.data.uuidsRelacionadosPadres);
                    //Para obtener los uuid hijo
                    Console.WriteLine(response.data.uuidsRelacionadosHijos);
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## Consulta solicitudes pendientes Aceptar / Rechazar ##
Este método obtendra una lista de los UUID que tenemos pendientes por aceptar o rechazar.

<details>
  <summary>Ejemplos</summary>

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* RFC Receptor

**Ejemplo de consumo de la librería para la consulta de solicitudes pendientes mediante usuario y contraseña**
```cs
using SW.Services.Pendings;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Pending
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a consultar las facturas relacionadas
                Pending pendientes = new Pending("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                PendingsResponse response = await pendientes.PendingsByRfcAsync("EKU9003173C9");
                //Para obtener el status de la consulta
                Console.Write(response.status);
                //Para obtener el codigoStatus
                Console.WriteLine(response.codStatus);
                //Para obtener la lista de uuid's
                Console.WriteLine(response.data.uuid);
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## Aceptar / Rechazar ##
Servicio mediante el cual aceptaremos o rechazaremos los UUID.

<details>
<summary>
Aceptar / Rechazar por CSD
</summary>

## Aceptar / Rechazar por CSD ##
Método mediante el cual el receptor podrá manifestar la aceptación o rechazo de la solicitud de cancelación mediante CSD.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* Certificado del receptor en Base64
* Llave(key) del receptor en Base64
* RFC del emisor
* Contraseña del certificado
* Arreglo de objetos donde se especifican los UUID y acción a realizar

**Ejemplo de consumo de la librería para la aceptacion/rechazo de la solicitud por CSD mediante usuario y contraseña**
```cs
using SW.Services.AcceptReject;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string RfcReceptor = "CACX7605101P8";
                string CerPassword = "12345678a";
                //Obtenemos Certificado del receptor y lo convertimos a Base 64 
                string CerReceptor = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/CACX7605101P8.cer"));
                //Obtenemos LLave del receptor y lo convertimos a Base 64
                string KeyReceptor = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/CACX7605101P8.key"));
                //Creamos una instancia de tipo AcceptReject
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a procesar las facturas con su acción
                AcceptReject acceptReject = new AcceptReject("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                var response = await acceptReject.AcceptByCSD(CerReceptor, KeyReceptor, RfcReceptor, CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = SW.Helpers.EnumAcceptReject.Aceptacion } });
                //Para obtener el status de la consulta
                Console.Write(response.status);
                //Para obtener el codigoStatus
                Console.WriteLine(response.codStatus);
                //Para obtener una lista con los folios
                Console.WriteLine(response.data.folios);
                //Para obtener el acuse
                Console.WriteLine(response.data.acuse);
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Aceptar / Rechazar por PFX
</summary>

## Aceptar / Rechazar por PFX ##
Método mediante el cual el receptor podrá manifestar la aceptación o rechazo de la solicitud de cancelación mediante PFX.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* Archivo Pfx en Base64
* Contraseña del certificado
* RFC del emisor
* Arreglo de objetos donde se especifican los UUID y acción a realizar

**Ejemplo de consumo de la librería para la aceptacion/rechazo de la solicitud por PFX mediante usuario y contraseña**
```cs
using SW.Services.AcceptReject;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string RfcReceptor = "CACX7605101P8";
                string CerPassword = "12345678a";
                //Obtenemos PFX del receptor y lo convertimos a Base 64 
                string PfxReceptor = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/CACX7605101P8.pfx"));
                //Creamos una instancia de tipo AcceptReject
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a procesar las facturas con su acción
                AcceptReject acceptReject = new AcceptReject("http://services.test.sw.com.mx", "user", "password");
                //Realizamos la peticion
                var response = await acceptReject.AcceptByPFX(PfxReceptor, RfcReceptor, CerPassword, new AceptacionRechazoItem[] { new AceptacionRechazoItem() { uuid = "DB68450F-355B-4915-AFDC-A980497C4D70", action = SW.Helpers.EnumAcceptReject.Aceptacion } });
                //Para obtener el status de la consulta
                Console.Write(response.status);
                //Para obtener el codigoStatus
                Console.WriteLine(response.codStatus);
                //Para obtener una lista con los folios
                Console.WriteLine(response.data.folios);
                //Para obtener el acuse
                Console.WriteLine(response.data.acuse);
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

```
</details>

<details>
<summary>
Aceptar / Rechazar por XML
</summary>

## Aceptar / Rechazar por XML ##
Método mediante el cual el receptor podrá manifestar la aceptación o rechazo de la solicitud de cancelación mediante XML.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* XML con datos requeridos para la aceptacion/rechazo de la cancelación

**Ejemplo de XML**
```xml
<?xml version='1.0' encoding='utf-8'?>
<SolicitudAceptacionRechazo xmlns:xsd='http://www.w3.org/2001/XMLSchema' 
    xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' RfcReceptor='LAN7008173R5' RfcPacEnviaSolicitud='DAL050601L35' Fecha='2018-08-22T18:38:05' 
    xmlns='http://cancelacfd.sat.gob.mx'>
    <Folios>
        <UUID>06a46e4b-b154-4c12-bb77-f9a63ed55ff2</UUID>
        <Respuesta>Aceptacion</Respuesta>
    </Folios>
    <Signature xmlns='http://www.w3.org/2000/09/xmldsig#'>
        <SignedInfo>
            <CanonicalizationMethod Algorithm='http://www.w3.org/TR/2001/REC-xml-c14n-20010315' />
            <SignatureMethod Algorithm='http://www.w3.org/2000/09/xmldsig#rsa-sha1' />
            <Reference URI=''>
                <Transforms>
                    <Transform Algorithm='http://www.w3.org/2000/09/xmldsig#enveloped-signature' />
                </Transforms>
                <DigestMethod Algorithm='http://www.w3.org/2000/09/xmldsig#sha1' />
                <DigestValue>AQ36cbqKJKHy5vaS6GhDTWtwKE4=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>HVlFUPmRLyxeztem827eaasDObRXi+oqedCNNvDyMsRizqsS99cHt5mJCEE4vWgpDGPGLrph/yd++R4aN+V562DPp9qreFkisFpEvJy5Z8o/KzG7vc5qqaD8z9ohPpRERPHvxFrIm3ryEBqnSV6zqJG02PuxkWvYonVc+B7RdsO5iAiDTMs9guUhOvHBK8BVXQHKCbUAPCp/4YepZ4LUkcdloCAMPsN0x9GaUty2RMtNJuwaRWy+5IIBUCeXXZmQhoQfS0QfPpCByt0ago5v+FocJQiYQrsUV/8mesmNw5JoOCmufQYliQFyZgsstV8+h76dU/rwLr6R8YlFOkTxKg==</SignatureValue>
        <KeyInfo>
            <X509Data>
                <X509IssuerSerial>
                    <X509IssuerName>OID.1.2.840.113549.1.9.2=Responsable: ACDMA, OID.2.5.4.45=SAT970701NN3, L=Coyoacán, S=Distrito Federal, C=MX, PostalCode=06300, STREET='Av. Hidalgo 77, Col. Guerrero', E=asisnet@pruebas.sat.gob.mx, OU=Administración de Seguridad de la Información, O=Servicio de Administración Tributaria, CN=A.C. 2 de pruebas(4096)</X509IssuerName>
                    <X509SerialNumber>3230303031303030303030333030303232383135</X509SerialNumber>
                </X509IssuerSerial>
                <X509Certificate>MIIFxTCCA62gAwIBAgIUMjAwMDEwMDAwMDAzMDAwMjI4MTUwDQYJKoZIhvcNAQELBQAwggFmMSAwHgYDVQQDDBdBLkMuIDIgZGUgcHJ1ZWJhcyg0MDk2KTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExODA2BgNVBAsML0FkbWluaXN0cmFjacOzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5mb3JtYWNpw7NuMSkwJwYJKoZIhvcNAQkBFhphc2lzbmV0QHBydWViYXMuc2F0LmdvYi5teDEmMCQGA1UECQwdQXYuIEhpZGFsZ28gNzcsIENvbC4gR3VlcnJlcm8xDjAMBgNVBBEMBTA2MzAwMQswCQYDVQQGEwJNWDEZMBcGA1UECAwQRGlzdHJpdG8gRmVkZXJhbDESMBAGA1UEBwwJQ295b2Fjw6FuMRUwEwYDVQQtEwxTQVQ5NzA3MDFOTjMxITAfBgkqhkiG9w0BCQIMElJlc3BvbnNhYmxlOiBBQ0RNQTAeFw0xNjEwMjUyMTUyMTFaFw0yMDEwMjUyMTUyMTFaMIGxMRowGAYDVQQDExFDSU5ERU1FWCBTQSBERSBDVjEaMBgGA1UEKRMRQ0lOREVNRVggU0EgREUgQ1YxGjAYBgNVBAoTEUNJTkRFTUVYIFNBIERFIENWMSUwIwYDVQQtExxMQU43MDA4MTczUjUgLyBGVUFCNzcwMTE3QlhBMR4wHAYDVQQFExUgLyBGVUFCNzcwMTE3TURGUk5OMDkxFDASBgNVBAsUC1BydWViYV9DRkRJMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgvvCiCFDFVaYX7xdVRhp/38ULWto/LKDSZy1yrXKpaqFXqERJWF78YHKf3N5GBoXgzwFPuDX+5kvY5wtYNxx/Owu2shNZqFFh6EKsysQMeP5rz6kE1gFYenaPEUP9zj+h0bL3xR5aqoTsqGF24mKBLoiaK44pXBzGzgsxZishVJVM6XbzNJVonEUNbI25DhgWAd86f2aU3BmOH2K1RZx41dtTT56UsszJls4tPFODr/caWuZEuUvLp1M3nj7Dyu88mhD2f+1fA/g7kzcU/1tcpFXF/rIy93APvkU72jwvkrnprzs+SnG81+/F16ahuGsb2EZ88dKHwqxEkwzhMyTbQIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEAJ/xkL8I+fpilZP+9aO8n93+20XxVomLJjeSL+Ng2ErL2GgatpLuN5JknFBkZAhxVIgMaTS23zzk1RLtRaYvH83lBH5E+M+kEjFGp14Fne1iV2Pm3vL4jeLmzHgY1Kf5HmeVrrp4PU7WQg16VpyHaJ/eonPNiEBUjcyQ1iFfkzJmnSJvDGtfQK2TiEolDJApYv0OWdm4is9Bsfi9j6lI9/T6MNZ+/LM2L/t72Vau4r7m94JDEzaO3A0wHAtQ97fjBfBiO5M8AEISAV7eZidIl3iaJJHkQbBYiiW2gikreUZKPUX0HmlnIqqQcBJhWKRu6Nqk6aZBTETLLpGrvF9OArV1JSsbdw/ZH+P88RAt5em5/gjwwtFlNHyiKG5w+UFpaZOK3gZP0su0sa6dlPeQ9EL4JlFkGqQCgSQ+NOsXqaOavgoP5VLykLwuGnwIUnuhBTVeDbzpgrg9LuF5dYp/zs+Y9ScJqe5VMAagLSYTShNtN8luV7LvxF9pgWwZdcM7lUwqJmUddCiZqdngg3vzTactMToG16gZA4CWnMgbU4E+r541+FNMpgAZNvs2CiW/eApfaaQojsZEAHDsDv4L5n3M1CC7fYjE/d61aSng1LaO6T1mh+dEfPvLzp7zyzz+UgWMhi5Cs4pcXx1eic5r7uxPoBwcCTt3YI1jKVVnV7/w=</X509Certificate>
            </X509Data>
        </KeyInfo>
    </Signature>
</SolicitudAceptacionRechazo>
```

**Ejemplo de consumo de la librería para la aceptacion/rechazo de la solicitud por XML mediante usuario y contraseña**
```cs
using SW.Services.AcceptReject;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo AcceptReject
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a procesar las facturas con su acción
                AcceptReject acceptReject = new AcceptReject("http://services.test.sw.com.mx", "user", "password");
                var xml = File.ReadAllText("Resources/aceptacionRechazo.xml");
                var response = await acceptReject.AcceptByXML(Encoding.UTF8.GetBytes(xml));
                //Para obtener el status de la consulta
                Console.Write(response.status);
                //Para obtener el codigoStatus
                Console.WriteLine(response.codStatus);
                //Para obtener una lista con los folios
                Console.WriteLine(response.data.folios);
                //Para obtener el acuse
                Console.WriteLine(response.data.acuse);
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Aceptar / Rechazar por UUID
</summary>

## Aceptar / Rechazar por UUID ##
Método mediante el cual el receptor podrá manifestar la aceptación o rechazo de la solicitud de cancelación mediante UUID.

Este método recibe los siguientes parametros:
* Url Servicios SW
* Usuario y contraseña ò token
* RFC del receptor
* UUID de la factura que se requiere aceptar/rechazar
* Acción que se requiera realizar Aceptacion/Rechazo

:pushpin: ***NOTA:*** El usuario deberá tener sus certificados en el administrador de timbres para la utilización de este método.

**Ejemplo de consumo de la librería para la aceptacion/rechazo de la solicitud por UUID mediante usuario y contraseña**
```cs
using SW.Services.AcceptReject;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Dato necesario
                string RfcReceptor = "CACX7605101P8";
                //Creamos una instancia de tipo AcceptReject
                //A esta le pasamos la Url, usuario y password o token
                //Automaticamente despues de obtenerlo se procedera a procesar las facturas con su acción
                AcceptReject acceptReject = new AcceptReject("http://services.test.sw.com.mx", "user", "password");
                //Realizamos peticion
                var response = await acceptReject.AcceptByRfcUuid(RfcReceptor, "DB68450F-355B-4915-AFDC-A980497C4D70", SW.Helpers.EnumAcceptReject.Aceptacion);
                //Para obtener el status de la consulta
                Console.Write(response.status);
                //Para obtener el codigoStatus
                Console.WriteLine(response.codStatus);
                //Para obtener una lista con los folios
                Console.WriteLine(response.data.folios);
                //Para obtener el acuse
                Console.WriteLine(response.data.acuse);
                //En caso de error se pueden consultar los siguientes campos
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## Recuperar XML ##
Servicio para recuperar información de un XML timbrado con SW.

<details>
<summary>
Recuperar por UUID
</summary>

## Recuperar por UUID ##
Método para recuperar la información de un XML enviando el UUID de la factura, así como el token de la cuenta en la cual fue timbrada.

Este metodo recibe los siguientes parametros:
* Url Api SW
* Url Servicios SW (Cuando se use usuario y contraseña)
* Usuario y contraseña ò token
* UUID

**Ejemplo de consumo de la libreria para la recuperación de XML mediante usuario y contraseña**
```cs
using SW.Services.Storage;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Storage
                //A esta le pasamos la Url de servicios y api, usuario y password
                //Automaticamente despues de obtenerlo se procedera a la recuperación
                Storage storage = new Storage("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                //Realizamos peticion enviando el UUID
                var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para la recuperación de XML mediante token**
```cs
using SW.Services.Storage;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Storage
                //A esta le pasamos la Url de api y token
                //Automaticamente despues de obtenerlo se procedera a la recuperación
                Storage storage = new Storage("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                //Realizamos peticion enviando el UUID
                var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

## PDF ##

<details>
<summary>
Generar PDF
</summary>

## Generar PDF ##
Este método genera y obtiene un pdf en base64 a partir de un documento XML timbrado y una plantilla. Puede ser consumido ingresando tu usuario y contraseña así como tambien ingresando solo el token. Este método recibe los siguientes parámetros:

* Url servicios SW
* Url Api
* Logo Base64 (opcional)
* Template id
* XML timbrado
* Datos extra (opcional)

**Ejemplo de consumo de la libreria para la generación de PDF mediante usuario y contraseña**
```cs
using SW.Services.Pdf;
using sw_sdk.Helpers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                //Creamos una instancia de tipo Pdf
                //A esta le pasamos la Url de servicios, url api, usuario y contraseña
                //Automaticamente despues de obtenerlo se procedera a la generación
                Pdf pdf = new Pdf("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await pdf.GenerarPdfAsync(xml,null, templateId);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puedes enviar logo en base 64
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puedes solicitar customizar tu propia plantilla para agregar datos adicionales que no vengan incluidos en el xml
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                Dictionary<string, string> observaciones = new Dictionary<string, string>() { { "Observaciones", "Entregar de 9am a 6pm" } };
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId, observaciones);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                Dictionary<string, string> observaciones = new Dictionary<string, string>() { { "Observaciones", "Entregar de 9am a 6pm" } };
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId, observaciones);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

**Ejemplo de consumo de la libreria para la generación de PDF mediante token**
```cs
using SW.Services.Pdf;
using sw_sdk.Helpers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                //Creamos una instancia de tipo Pdf
                //A esta le pasamos la Url api y token
                //Automaticamente despues de obtenerlo se procedera a la generación
                Pdf pdf = new Pdf("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await pdf.GenerarPdfAsync(xml,null, templateId);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puedes enviar logo en base 64
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puedes solicitar customizar tu propia plantilla para agregar datos adicionales que no vengan incluidos en el xml
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                Dictionary<string, string> observaciones = new Dictionary<string, string>() { { "Observaciones", "Entregar de 9am a 6pm" } };
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId, observaciones);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                //Datos necesarios
                string xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                PdfTemplates templateId = PdfTemplates.cfdi40;
                Dictionary<string, string> observaciones = new Dictionary<string, string>() { { "Observaciones", "Entregar de 9am a 6pm" } };
                string b64Logo = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgs......";
                Pdf pdf = new Pdf("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await pdf.GenerarPdfAsync(xml,b64Logo, templateId, observaciones);
                //Devuleve el pdf en formato Base64
                Console.WriteLine(response.data.contentB64);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

:pushpin: ***NOTA:*** Existen varias plantillas de PDF para ambas versiones de CFDI segun el tipo de comprobante, las cuales son las siguientes:

|    Version 3.3     |    Version 4.0     |  Plantilla para el complemento  | 
|--------------------|--------------------|---------------------------------|
| :white_check_mark: | :white_check_mark: | Factura ingreso, egreso         | 
| :white_check_mark: | :white_check_mark: | Nómina                          | 
| :white_check_mark: | :white_check_mark: | Pagos                           | 
| :white_check_mark: | :white_check_mark: | Carta porte                     |

Para mayor referencia de estas plantillas de PDF, favor de visitar el siguiente [link](https://developers.sw.com.mx/knowledge-base/plantillas-pdf/).
</details>

<details>
<summary>
Regenerar PDF
</summary>

## Regenerar PDF ##
El servicio podrá generar o regenerar un PDF de un CFDI previamente timbrados y podrá guardar o remplazar el archivo PDF para ser visualizado posteriormente desde el portal de Smarter. Puede ser consumido ingresando tu usuario y contraseña así como tambien ingresando solo el token. Este método recibe los siguientes parámetros:

* Url Servicios SW(cuando se añaden usuario y contraseña)
* Url Api
* UUID

**Ejemplo de consumo de la libreria para la regeneración de PDF mediante usuario y contraseña**
```cs
using SW.Services.Pdf;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Pdf
                //A esta le pasamos la Url api, Url Servicios, usuario y contraseña
                //Automaticamente despues de obtenerlo se procedera a la regeneración
                Pdf pdf = new Pdf("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await pdf.RegenerarPdfAsync(Guid.Parse("ac45f6b1-9b1b-473c-8a35-6fab7a3a3c36"));
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
**Ejemplo de consumo de la libreria para la regeneración de PDF mediante token**
```cs
using SW.Services.Pdf;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Pdf
                //A esta le pasamos la Url api y token
                //Automaticamente despues de obtenerlo se procedera a la regeneración
                Pdf pdf = new Pdf("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await pdf.RegenerarPdfAsync(Guid.Parse("ac45f6b1-9b1b-473c-8a35-6fab7a3a3c36"));
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Reenvio Email
</summary>

## Reenvio Email ##
Este servicio realiza el reenvío de un xml y/o pdf existente mediante su UUID
a través de correo electrónico.

Este método recibe los siguientes parametros:
* Url Servicios SW(cuando se añaden usuario y contraseña)
* Url Api
* UUID: Folico fiscal del comprobante timbrado
* Email: Correo electrónico (máximo 5 correos separados por ” , ” )

**Ejemplo de consumo de la libreria para el reenvio de email mediante usuario y contraseña**
```cs
using SW.Services.Resend;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Resend
                //A esta le pasamos la Url api, Url Servicios, usuario y contraseña
                //Automaticamente despues de obtenerlo se procedera al reenvio de email
                Resend resend = new Resend("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await resend.ResendEmailAsync(Guid.Parse("9c50a99e-93d4-499d-a6bc-ef1ad1360814"), "someemail@some.com");
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puede enviarse a mas de un correo
            try
            {
                //Lista de correos
                var emails = new[] 
                { 
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com"
                };
                Resend resend = new Resend("http://api.sw.com.mx", "http://services.test.sw.com.mx", "user", "password");
                var response = await resend.ResendEmailAsync(Guid.Parse("9c50a99e-93d4-499d-a6bc-ef1ad1360814"), emails);
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
```

**Ejemplo de consumo de la libreria para el reenvio de email mediante token**
```cs
using SW.Services.Resend;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo Pdf
                //A esta le pasamos la Url api y token
                //Automaticamente despues de obtenerlo se procedera al reenvio de email
                Resend resend = new Resend("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await resend.ResendEmailAsync(Guid.Parse("9c50a99e-93d4-499d-a6bc-ef1ad1360814"), "someemail@some.com");
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Puede enviarse a mas de 5 correos
            try
            {
                //Lista de correos
                var emails = new[] 
                { 
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com",
                    "someemail@some.com"
                };
                Resend resend = new Resend("http://api.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await resend.ResendEmailAsync(Guid.Parse("9c50a99e-93d4-499d-a6bc-ef1ad1360814"), emails);
                //Obtenemos el detalle de la respuesta 
                Console.WriteLine(response.status); 
                Console.WriteLine(response.message); 
                Console.WriteLine(response.messageDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
```
</details>

## Certificados ##
Servicio para gestionar los certificados CSD de tu cuenta, será posible cargar, consultar y eliminar los certificados.
Para administrar los certificados de manera gráfica, puede hacerlo desde el [Administrador de timbres](https://portal.sw.com.mx/).

<details>
<summary>
Consultar Certificados
</summary>

## Consultar Certificados ##
Método para consultar todos los certificados cargados en la cuenta.

Este metodo recibe los siguientes parametros:
* Url Servicios SW(cuando se añaden usuario y contraseña)
* Token

**Ejemplo de consumo de la libreria para la consulta de certificados mediante token**
```cs
using SW.Services.Csd;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo CsdUtils
                //A esta le pasamos la Url y token
                //Automaticamente se procedera a la consulta
                CsdUtils csd = new CsdUtils("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await csd.GetAllCsdAsync();
                //En caso exitoso se podran obtener los siguientes datos
                List<CsdData> detail = response.data;
                Console.Write("Status: " + response.status);
                if(response.status == "success")
                {
                    Console.Write("\ndetail: ");
                    foreach (var i in detail)
                    {
                        Console.Write(i.issuer_rfc + "\n");
                        Console.Write(i.certificate_number + "\n");
                        Console.Write(i.csd_certificate + "\n");
                        Console.Write(i.is_active + "\n");
                        Console.Write(i.issuer_business_name + "\n");
                        Console.Write(i.valid_from + "\n");
                        Console.Write(i.valid_to + "\n");
                        Console.Write(i.certificate_type + "\n");
                    }
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Consultar Certificado Por NoCertificado
</summary>

## Consultar Certificado Por NoCertificado ##
Método para obtener un certificado cargado enviando como parámetro el número de certificado.

Este metodo recibe los siguientes parametros:
* Url Servicios SW
* Token
* Número de certificado a obtener

**Ejemplo de consumo de la libreria para la consulta de certificados por Número de Certificado mediante token**
```cs
using SW.Services.Csd;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo CsdUtils
                //A esta le pasamos la Url y token
                //Automaticamente se procedera a la consulta
                CsdUtils csd = new CsdUtils("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await csd.GetAllCsdAsync("30001000000400002434");
                //En caso exitoso se podran obtener los siguientes datos
                List<CsdData> detail = response.data;
                Console.Write("Status: " + response.status);
                if(response.status == "success")
                {
                    Console.Write("\ndetail: ");
                    foreach (var i in detail)
                    {
                        Console.Write(i.issuer_rfc + "\n");
                        Console.Write(i.certificate_number + "\n");
                        Console.Write(i.csd_certificate + "\n");
                        Console.Write(i.is_active + "\n");
                        Console.Write(i.issuer_business_name + "\n");
                        Console.Write(i.valid_from + "\n");
                        Console.Write(i.valid_to + "\n");
                        Console.Write(i.certificate_type + "\n");
                    }
                }
                else
                {
                    //En caso de error se pueden consultar los siguientes campos
                    Console.WriteLine(response.message);
                    Console.WriteLine(response.messageDetail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Cargar Certificado
</summary>

## Cargar Certificado ##
Método para cargar un certificado en la cuenta.

Este metodo recibe los siguientes parametros:
* Url Servicios SW
* Token
* CSD en Base64
* Key en Base64
* Contraseña del certificado

**Ejemplo de consumo de la libreria para la carga de certificado mediante token**
```cs
using SW.Services.Csd;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Datos necesarios
                string CerPassword = "12345678a";
                //Obtenemos Certificado y lo convertimos a Base 64 
                string Cer = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.cer"));
                //Obtenemos LLave y lo convertimos a Base 64 
                string Key = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.key"));
                //Creamos una instancia de tipo CsdUtils
                //A esta le pasamos la Url y token
                //Automaticamente se procedera a la carga de los certificados
                CsdUtils csd = new CsdUtils("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await csd.UploadCsdAsync(Cer, Key, CerPassword);
                //obtenemos la respuesta
                Console.WriteLine(response.data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

<details>
<summary>
Eliminar Certificado
</summary>

## Eliminar Certificado ##
Método para eliminar un certificado de la cuenta.

Este metodo recibe los siguientes parametros:
* Url Servicios SW
* Token
* Número de certificado a eliminar

**Ejemplo de consumo de la libreria para eliminar un certificado mediante token**
```cs
using SW.Services.Csd;
using System;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creamos una instancia de tipo CsdUtils
                //A esta le pasamos la Url y token
                //Automaticamente se procedera a la eliminacion
                CsdUtils csd = new CsdUtils("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                var response = await csd.DeleteCsdAsync("30001000000400002442");
                //obtenemos la respuesta
                Console.WriteLine(response.data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>


## TimbradoV4 ##

<details>
  <summary>StampV4(XML) - Email</summary>

## StampV4(XML) - Email ##
Este servicio recibe un comprobante CFDI para ser timbrado y recibe un listado de uno o hasta 5 correos electrónicos a los que se requiera enviar el xml timbrado así como también su pdf.
Existen varias versiones de respuesta a este método, las cuales puede consultar mas a detalle en el siguiente [link](https://developers.sw.com.mx/knowledge-base/versiones-de-respuesta-timbrado/).

***NOTA:*** En caso de que no se cuente con una plantilla pdf customizada los pdf’s serán generados con las plantillas genéricas.

**Ejemplo del consumo de la librería para el servicio StampV4(Email) XML en formato string mediante usuario y contraseña con la version de respuesta 1**
```cs
using SW.Services.Stamp;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //obtenemos el XML
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                //Creamos una instancia de tipo StampV4 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el XML
                StampV4 stamp = new StampV4("http://services.test.sw.com.mx", "user", "password");
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
**Ejemplo del consumo de la librería para el servicio StampV4(Email) XML en formato string mediante token con la version de respuesta 1**
```cs
using SW.Services.Stamp;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //obtenemos el XML
                var xml = Encoding.UTF8.GetString(File.ReadAllBytes(file));
                //Creamos una instancia de tipo StampV4 
                //A esta le pasamos la Url y el token
                StampV4 stamp = new StampV4("http://services.test.sw.com.mx", "T2lYQ0t4L0R....ReplaceForRealToken");
                //Realizamos la peticion
                var response = (StampResponseV1)await stamp.TimbrarV1Async(xml, "someemail@some.com");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
</details>

Para mayor referencia de un listado completo de los servicios favor de visitar el siguiente [link](http://developers.sw.com.mx/).

Si deseas contribuir a la libreria o tienes dudas envianos un correo a **soporte@sw.com.mx**.