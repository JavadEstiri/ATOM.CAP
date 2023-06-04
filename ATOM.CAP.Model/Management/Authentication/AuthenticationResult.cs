using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOM.CAP.Model
{
    public class AuthenticationResult
    {
        public AuthenticationResult() { }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string AccessToken { get; set; }
    }
}
