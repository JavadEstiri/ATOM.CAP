using ATOM.CAP.Core;
using ATOM.CAP.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATOM.CAP.Tools
{
    public class JwtAuthenticationManager
    {
        private readonly IAppSetting _appSetting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtAuthenticationManager(IAppSetting appSetting, IHttpContextAccessor httpContextAccessor)
        {
            _appSetting = appSetting;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Authenticate(AuthenticateVM model)
        {
            try
            {
                // Check Inputs
                if (String.IsNullOrEmpty(model.UserName) || String.IsNullOrEmpty(model.Password))
                    return null;

                // Check DB
                var user = new User() {
                    ID = 1,
                    Person = new Person()
                    {
                        FirstName = "جواد",
                        LastName  = "استیری",
                        CellPhone = "09330884150"
                    },
                    UserType = UserType.مدیر
                };

                // Token Options
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_appSetting.SecretKey);

                var request = _httpContextAccessor.HttpContext.Request;

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, model.UserName),
                            new Claim(Claims.UserID , value: user.ID.ToString()),
                            new Claim(Claims.FirstName , value: user.Person.FirstName.ToString()),
                            new Claim(Claims.LastName , value: user.Person.LastName.ToString()),
                            new Claim(Claims.CellPhone , value: user.Person.CellPhone.ToString()),
                            new Claim(Claims.UserType , value: ((int)user.UserType).ToString()),
                            new Claim(Claims.RemoteIP , value: request.HttpContext.Connection.RemoteIpAddress.ToString()),
                            new Claim(Claims.AppURL , value: $"{request.Scheme??""}://{request.Host}{request.PathBase}"),
                        }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                        )
                };

                // Generate Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // Return Token
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
