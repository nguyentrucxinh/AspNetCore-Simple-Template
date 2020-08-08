using AST.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AST.Web.Controllers
{
    public class FooController : ApiController
    {
        private readonly IFooService _fooService;

        public FooController(IFooService fooService)
        {
            _fooService = fooService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }
    }
}
