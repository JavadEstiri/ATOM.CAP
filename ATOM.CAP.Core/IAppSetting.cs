
namespace ATOM.CAP.Core
{
    public interface IAppSetting
    {
        public string SecretKey { get; }
        public string ConnectionString { get; }
        public string Salt { get; }
    }
}
