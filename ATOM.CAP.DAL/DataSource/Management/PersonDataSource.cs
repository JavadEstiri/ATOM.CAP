using ATOM.CAP.Core;
using ATOM.CAP.DataSource;
using ATOM.CAP.Model;
using System.Data;

namespace ATOM.CAP.DAL
{
    public class PersonDataSource : DataSource, IPersonDataSource
    {
        public PersonDataSource(IAppSetting appSetting, IRequestInfo requestInfo) : base(appSetting, requestInfo)
        {
        }

        public Person Save(Person model)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetList(PersonListVM model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
