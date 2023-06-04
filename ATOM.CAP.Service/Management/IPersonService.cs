
using ATOM.CAP.Model;

namespace ATOM.CAP.Service
{
    public interface IPersonService : IService
    {
        public Person Save(Person model);
        public Person Get(int id);
        public IEnumerable<Person> GetList(PersonListVM model);
        public bool Delete(int id);
    }
}
