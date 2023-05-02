using System;
using SW.Helpers;

namespace SW.Services.Cancelation
{
    internal class CancelationValidation : Validation
    {
        internal CancelationValidation(string url, string user, string password, string token) : base(url, user, password, token)
        {
        }
        internal void ValidateRequest(string certificado, string key, string contraseña, string[] uuids)
        {
            if (uuids.Length == 0)
            {
                throw new ServicesException("Faltan especificar los UUIDs a Cancelar");
            }
            if (string.IsNullOrEmpty(certificado))
            {
                throw new ServicesException("Falta Capturar el Certificado");
            }
            else
            {
                ValidateIsBase64("Certificado", certificado);
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ServicesException("Falta Capturar Key del Certificado");
            }
            else
            {
                ValidateIsBase64("Key", key);
            }
            if (string.IsNullOrEmpty(contraseña))
            {
                throw new ServicesException("Falta Capturar Contraseña del Certificado");
            }
            else
            {
                ValidateIsBase64("Contraseña", contraseña);
            }
        }
        private static void ValidateIsBase64(string key, string value)
        {
            try
            {
                Convert.FromBase64String(value);
            }
            catch (Exception)
            {
                throw new ServicesException("El valor " + key + " no es Base64");
            }
        }
    }
}