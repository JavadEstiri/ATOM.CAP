
namespace ATOM.CAP.Model
{
    public class OTPModel : Model
    {
        public OTPModel() { }
        public int AccountID { get; set; }
        public string OTP { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool Expired { get; set; }
        public int ValidityPeriodInMinutes { get; set; }
    }
}
