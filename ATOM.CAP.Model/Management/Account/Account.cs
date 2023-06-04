
namespace ATOM.CAP.Model
{
    public class Account : Model
    {
        public Account() { }

        public string UserName { get; set; }
        public string Password { get; set; }


        // OTP Details
        public OTPModel OTP { get; set; }
    }
}
