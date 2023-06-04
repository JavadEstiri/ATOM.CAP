
namespace ATOM.CAP.Model
{
    public class User : Model
    {
        public User() { }

        public int PersonID { get;set; }
        public Person Person { get; set; }

        public UserType UserType { get; set; }
        public string UserTypeName => UserType.ToString().Replace("_", " ");

        public UserStatusType StatusType { get; set; }
        public string StatusTypeName => StatusType.ToString().Replace("_"," ");

    }
}
