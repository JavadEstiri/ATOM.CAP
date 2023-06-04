using ATOM.CAP.Model;


namespace ATOM.CAP.DataSource
{
    public interface IOTPDataSource : IDataSource
    {
        public OTPModel Save(OTPModel model);

        public OTPModel Get(OTPModelVM model);

        public bool DeleteOTP(OTPModelVM model);

        public bool ClearOTP();

        public bool Delete(OTPModelVM model);
    }
}
