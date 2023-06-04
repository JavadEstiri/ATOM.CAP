
namespace ATOM.CAP.Model
{
    public class Person : Model
    {
        public Person() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string FullName => (FirstName ?? "") + " " + (LastName ?? "");
        public DateTime? BirthDate { get; set; }

        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public int ProvinceID { get; set; }
        public int CityID { get; set; }

    }
}
