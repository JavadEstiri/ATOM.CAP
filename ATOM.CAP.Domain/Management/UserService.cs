using ATOM.CAP.Core;
using ATOM.CAP.DataSource;
using ATOM.CAP.Model;
using ATOM.CAP.Service;
using System.Collections.Generic;

namespace ATOM.Domain
{
    public class UserService : Service , IUserService
    {
        private readonly IUserDataSource _dataSource;
        public UserService(IAppSetting appSetting, IRequestInfo requestInfo, IUserDataSource dataSource) : base(appSetting, requestInfo)
        {
            _dataSource = dataSource;
        }

        public User Save(User model)
        {
            return _dataSource.Save(model);
        }

        public User Get(int id)
        {
            return new User()
            {
                ID = _requestInfo.UserID,
                Person = new Person
                {
                    FirstName = _requestInfo.FirstName,
                    LastName  = _requestInfo.LastName,
                    CellPhone= _requestInfo.CellPhone,
                },
                UserType = _requestInfo.UserType,
            };
        }

        public IEnumerable<User> GetList(UserListVM model)
        {
            return _dataSource.GetList(new UserListVM { });
        }

        public bool Delete(int id)
        {
            return _dataSource.Delete(id);
        }
    }
}
