using AST.Core.Entities;
using AST.Core.Interfaces;
using AST.Application.Interfaces;

namespace AST.Application.Services
{
    public class FooService: IFooService
    {
        private readonly IRepository<Foo> _fooRepository;

        public FooService(IRepository<Foo> fooRepository)
        {
            _fooRepository = fooRepository;
        }
    }
}
