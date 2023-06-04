using ATOM.CAP.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATOM.API.Controllers
{
    [Authorize]
    //[EnableCors("*")]
    public class BaseApiController : Controller
    {

    }

    public class BaseApiController<T> : BaseApiController
        where T : IService
    {
        public BaseApiController()
        {
        }

        public BaseApiController(T service)
        {
            _service = service;
        }

        protected readonly T _service;

    }
}
