using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATOM.CAP.Model
{
    public class AuthenticateVM
    {
        public AuthenticateVM() { }

        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }
        public AudienceType AudienceType { get; set; }

        public string PasswordHash
        {
            get
            {
                if (String.IsNullOrEmpty(this.Password) 
                    || String.IsNullOrWhiteSpace(this.Password)
                    || String.IsNullOrWhiteSpace(this.UserName)
                    || String.IsNullOrWhiteSpace(this.UserName))
                    return null;

                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(this.Password , salt , 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0,16);
                Array.Copy(hash, 0, hashBytes,16,20);

                return Convert.ToBase64String(hashBytes);
                
            }
        }
    }

    public enum LoginType : int
    {
        None = 0,
        ByUserNameAndPassword = 1,
        SSO = 2,
    }
    public enum AudienceType : int
    {
        None = 0,
        Admin = 1,
        User = 2,
    }
}
