using ATOM.CAP.Model;
using ATOM.CAP.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace ATOM.API.Controllers
{
    [Route("api/v1/Login")]
    public class LoginController : BaseApiController
    {
        private readonly JwtAuthenticationManager authenticationManager;
        public LoginController(JwtAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        [HttpPost, Route("Authenticate")]
        public AuthenticationResult Authenticate(AuthenticateVM model)
        {
            var tokenResult = authenticationManager.Authenticate(model);
            if (tokenResult == null)
                throw new Exception(message: "Authentication Failed . . .");

            return new AuthenticationResult()
            {
                UserName = model.UserName,
                Password = model.Password,
                AccessToken = tokenResult
            };
        }

        [HttpGet, Route("CheckToken")]
        public string CheckToken() => Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

        //_httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "")

    }
}
