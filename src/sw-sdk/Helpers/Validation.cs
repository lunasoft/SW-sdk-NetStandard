using System;
using System.Linq;
using System.Net.Mail;

namespace SW.Helpers
{
    internal class Validation
    {
        private readonly string _url;
        private readonly string _user;
        private readonly string _password;
        private readonly string _token;
        internal Validation()
        {
        }
        internal Validation(string url, string user, string password, string token)
        {
            _url = url;
            _user = user;
            _password = password;
            _token = token;
            ValidateHeaderParameters();
        }
        internal void ValidateHeaderParameters()
        {
            if (string.IsNullOrEmpty(_url) || _url == "/")
                throw new ServicesException("Falta Capturar URL");

            if (string.IsNullOrEmpty(_token))
            {
                if (string.IsNullOrEmpty(_user) && string.IsNullOrEmpty(_password))
                {
                    throw new ServicesException("Falta Capturar Token");
                }
                if (string.IsNullOrEmpty(_user))
                {
                    throw new ServicesException("Falta Capturar Usuario");
                }
                if (string.IsNullOrEmpty(_password))
                {
                    throw new ServicesException("Falta Capturar Contraseña");
                }
            }
            else
            {
                ValidateToken(_token);
            }
        }
        private void ValidateToken(string token)
        {
            string[] validToken = token.Split('.');
            if (validToken.Length != 3)
            {
                throw new ServicesException("Token Mal Formado");
            }
        }
        internal static void ValidateEmailStamp(string email)
        {
            string[] emails = email.Split(',');
            if (emails.Count() == 0 || emails.Count() > 5)
            {
                throw new ServicesException("El listado de correos contiene más de 5 correos o está vacío.");
            }
            try
            {
                emails.ToList().ForEach(e =>
                {
                    var addr = new System.Net.Mail.MailAddress(e);
                    if (addr.Address != e)
                    {
                        throw new FormatException(); 
                    }
                });
            }
            catch (FormatException)
            {
                throw new ServicesException("El formato de uno o más correos no es correcto.");
            }
        }
        internal static void ValidateEmail(string[] email)
        {
            if (email != null && email.Count() > 0 && email.Count() <= 5)
            {
                try
                {
                    email.ToList().ForEach(l => new MailAddress(l));
                }
                catch (Exception ex)
                {
                    throw new ServicesException("El email no tiene un formato válido.", ex);
                }
            }
            else
            {
                throw new ServicesException("El listado de correos no tiene un formato válido, está vacío o contiene más de 5 correos.");
            }
        }
        internal static void ValidateCustomId(string customId)
        {
            if(customId.Length <= 0 || customId.Length > 150)
            {
                throw new ServicesException("El CustomId no es válido o viene vacío.");
            }
        }
    }
}
