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

```