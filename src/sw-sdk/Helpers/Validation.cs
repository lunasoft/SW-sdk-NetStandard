using System;
using System.Linq;
using System.Net.Mail;

namespace SW.Helpers
{
    public class Validation
    {
        private string _url;
        private string _user;
        private string _password;
        private string _token;
        public Validation()
        {
        }
        public Validation(string url, string user, string password, string token)
        {
            _url = url;
            _user = user;
            _password = password;
            _token = token;
            ValidateHeaderParameters();
        }
        public void ValidateHeaderParameters()
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
    }
}
