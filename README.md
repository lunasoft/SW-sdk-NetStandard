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

### Documentacion
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
## Auntenticaci&oacute;n ##
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
# Timbrado #

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
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el xml
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
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el xml
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
                //Creamos una instancia de tipo Stamp 
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
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url, Usuario y Contraseña para obtener el token
                //Automaticamente despues de obtenerlo se procedera a timbrar el xml
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
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url y su Token infinito 
                //Este lo puede obtener ingresando al administrador de timbres con su usuario y contraseña
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
                //Creamos una instancia de tipo Stamp 
                //A esta le pasamos la Url y su Token infinito 
                //Este lo puede obtener ingresando al administrador de timbres con su usuario y contraseña
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

:pushpin: ***NOTA:*** Existen varias versiones de respuesta, las cuales son las siguientes:

| Version |                         Respuesta                             | 
|---------|---------------------------------------------------------------|
|  V1     | Devuelve el timbre fiscal digital                             | 
|  V2     | Devuelve el timbre fiscal digital y el cfdi timbrado          | 
|  V3     | Devuelve el CFDI timbrado                                     | 
|  V4     | Devuelve todos los datos del timbrado                         |

Para mayor referencia de estas versiones de respuesta, favor de visitar el siguiente [link](https://developers.sw.com.mx/knowledge-base/versiones-de-respuesta-timbrado/).

---
# Cancelación #

Este servicio se utiliza para cancelar documentos xml y se puede hacer mediante varios metodos **Cancelación CSD**, **Cancelación PFX**, **Cancelacion por XML** y **Cancelación UUID**.

 ## Cancelacion por CSD ##
Como su nombre lo indica, este método realiza la cancelacion mediante los CSD.

Este método recibe los siguientes parametros:
- Usuario y contraseña
- Url Servicios SW
* Certificado (.cer) en **Base64**
* Key (.key) en **Base64**
* RFC emisor
* Password del archivo key
* UUID
* Motivo
* Folio Sustitución (Si el motivo es 01)

**Ejemplo de consumo de la libreria para cancelar con CSD con motivo de cancelación 02 sin relación a documento mediante token**
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

**Ejemplo de consumo de la libreria para cancelar con CSD con motivo de cancelación 01 con relación a documento mediante token**
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

## Cancelacion por PFX ##
Como su nombre lo indica, este método realiza la cancelacion mediante el PFX.

Este método recibe los siguientes parametros:
- Usuario y contraseña
- Url Servicios SW
* Archivo PFX en **Base64**
* RFC emisor
* Password (CSD)
* UUID
* Motivo
* Folio Sustitución
**Ejemplo de consumo de la libreria para cancelar con PFX con motivo de cancelación 02 sin relación a documento mediante token**
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

**Ejemplo de consumo de la libreria para cancelar con PFX con motivo 01 con documento relacionado mediante token**
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

## Cancelacion por XML ##
Como su nombre lo indica, este método realiza la cancelacion mediante el XML sellado con los UUID a cancelar.

Este método recibe los siguientes parametros:
- Usuario y contraseña
- Url Servicios SW
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

**Ejemplo de consumo de la libreria para cancelar con XML mediante token**
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

## Cancelacion por UUID ##
Como su nombre lo indica, este método realiza la cancelacion mediante el UUID a cancelar.

Este método recibe los siguientes parametros:
- Usuario y contraseña
- Url Servicios SW
* RFC emisor
* UUID
* Motivo
* Folio Sustitución

**Ejemplo de consumo de la libreria para cancelar con UUID con motivo de cancelación 02 sin documento relacionado mediante token**
```cs
using SW.Services.Cancelation;
using System;
using System.Threading.Tasks;

namespace PruebaReadme
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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

**Ejemplo de consumo de la libreria para cancelar con UUID con motivo de cancelación 01 con documento relacionado mediante token**
```cs
using SW.Services.Cancelation;
using System;
using System.Threading.Tasks;

namespace PruebaReadme
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
                //Automaticamente despues de obtenerlo se procedera a Cancelar el xml o cfdi
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
---
# Consulta de Saldos #
Método mediante el cual puedes realizar la consulta de tu saldo para consumir los servicios de SW.

Este metodo recibe los siguientes parametros:
- Usuario y contraseña o Token
- Url Servicios SW

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
---
# Validación #

## Validación XML ##
Este servicio recibe un comprobante CFDI 3.3 ó 4.0 en formato XML mediante el cual se valida integridad, sello, errores de estructura, matriz de errores del SAT incluyendo complementos, se valida que exista en el SAT, así como el estatus en el SAT.

Este metodo recibe los siguientes parametros:
- Url Servicios SW
- Usuario y contraseña o token
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
---
