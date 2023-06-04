
using ATOM.CAP.Model;

namespace ATOM.CAP.Service
{
    public interface IUserService : IService
    {
        public User Save(User model);
        public User Get(int id);
        public IEnumerable<User> GetList(UserListVM model);
        public bool Delete(int id);
    }
}
