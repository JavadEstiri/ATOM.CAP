using ATOM.CAP.Model;
using ATOM.CAP.Service;
using Microsoft.AspNetCore.Mvc;

namespace ATOM.API.Controllers
{
    [Route("api/v1/Person")]
    public class PersonController : BaseApiController<IPersonService>
    {
        public PersonController(IPersonService service) : base(service)
        {
        }

        [HttpPost , Route("Save")]
        public Person Save(Person model)
        {
            return _service.Save(model);
        }

        [HttpPost, Route("Get/{id:int}")]
        public Person Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost, Route("GetList")]
        public IEnumerable<Person> GetList(PersonListVM model)
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
