
using ATOM.CAP.Core;
using ATOM.CAP.DataSource;
using ATOM.CAP.Model;
using System.Data;

namespace ATOM.CAP.DAL
{
    public class UserDataSource : DataSource, IUserDataSource
    {
        public UserDataSource(IAppSetting appSetting, IRequestInfo requestInfo) : base(appSetting, requestInfo)
        {
        }

        public User Save(User model)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetList(UserListVM model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
