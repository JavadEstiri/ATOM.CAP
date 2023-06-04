
namespace ATOM.CAP.Model
{
    public class AccountVM
    {
        public AccountVM() { }

        public string UserName { get; set; }
        public string Password { get; set; }


        // OTP Details
        public string OTP { get; set; }
    }
}
