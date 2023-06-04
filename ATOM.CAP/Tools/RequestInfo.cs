using ATOM.CAP.Core;
using ATOM.CAP.Model;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace ATOM.CAP.Tools
{
    public class RequestInfo : IRequestInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestInfo( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string RequestToken => _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        private List<Claim> Claims => _httpContextAccessor.HttpContext.User.Claims?.ToList() ?? new List<Claim>();


        public int UserID
        {
            get
            {
                var result = GetValueFromToken("UserID");
                if (result == null)
                    return 0;
                else
                    return Convert.ToInt32(result);
            }
        }
        public UserType UserType
        {
            get
            {
                var result = GetValueFromToken("UserType");
                if (result == null)
                    return 0;
                else
                    return (UserType)Convert.ToInt32(result);
            }
        }
        public string UserTypeName => UserType.ToString().Replace("_"," ");
        public string? CellPhone => GetValueFromToken("CellPhone");
        public string? FirstName => GetValueFromToken("FirstName");
        public string? LastName=> GetValueFromToken("LastName");
        public string? RemoteIP => GetValueFromToken("RemoteIP");
        public string? AppURL => GetValueFromToken("AppURL");
        private string GetValueFromToken(string key)
        {
            try
            {
                if (!Claims.Any(x => x.Type == key))
                    return null;

                return Claims.FirstOrDefault(x => x.Type == key).Value;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
