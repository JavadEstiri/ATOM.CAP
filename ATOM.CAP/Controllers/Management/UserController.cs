using ATOM.CAP.Model;
using ATOM.CAP.Service;
using Microsoft.AspNetCore.Mvc;

namespace ATOM.API.Controllers
{
    [Route("api/v1/User")]
    public class UserController : BaseApiController<IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [HttpPost , Route("Save")]
        public User Save(User model)
        {
            return _service.Save(model);
        }

        [HttpPost, Route("Get/{id:int}")]
        public User Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost, Route("GetList")]
        public IEnumerable<User> GetList(UserListVM model)
        {
            return _service.GetList(model);
        }

        [HttpPost, Route("Delete/{id:int}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
