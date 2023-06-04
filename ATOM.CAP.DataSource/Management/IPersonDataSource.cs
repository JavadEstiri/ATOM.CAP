using ATOM.CAP.Model;


namespace ATOM.CAP.DataSource
{
    public interface IPersonDataSource : IDataSource
    {
        public Person Save(Person model);

        public Person Get(int id);

        public IEnumerable<Person> GetList(PersonListVM model);

        public bool Delete(int id);
    }
}
