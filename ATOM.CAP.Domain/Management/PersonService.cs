using ATOM.CAP.Core;
using ATOM.CAP.DataSource;
using ATOM.CAP.Model;
using ATOM.CAP.Service;
using System.Collections.Generic;

namespace ATOM.Domain
{
    public class PersonService : Service , IPersonService
    {
        private readonly IPersonDataSource _dataSource;
        public PersonService(IAppSetting appSetting, IRequestInfo requestInfo, IPersonDataSource dataSource) : base(appSetting, requestInfo)
        {
            _dataSource = dataSource;
        }

        public Person Save(Person model)
        {
            return _dataSource.Save(model);
        }

        public Person Get(int id)
        {
            return new Person()
            {
                
                    FirstName = _requestInfo.FirstName,
                    LastName  = _requestInfo.LastName,
                    CellPhone= _requestInfo.CellPhone,

            };
        }

        public IEnumerable<Person> GetList(PersonListVM model)
        {
            return _dataSource.GetList(new PersonListVM { });
        }

        public bool Delete(int id)
        {
            return _dataSource.Delete(id);
        }
    }
}
