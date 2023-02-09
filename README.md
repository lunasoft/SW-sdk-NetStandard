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