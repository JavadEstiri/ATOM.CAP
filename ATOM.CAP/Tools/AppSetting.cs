
namespace ATOM.CAP.Tools
{
    public class AppSetting : Core.IAppSetting
    {
        private readonly IConfiguration _configuration;
        public AppSetting(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SecretKey
        {
            get
            {
                return _configuration["CustomKeys:SecretKey"].ToString();
            }
        }

        public string ConnectionString => _configuration.GetConnectionString("ATOM");

        public string Salt
        {
            get
            {
                return _configuration["CustomKeys:Salt"].ToString();
            }
        }
    }
}
