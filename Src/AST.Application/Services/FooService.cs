using AST.Core.Entities;
using AST.Core.Interfaces;
using AST.Application.Interfaces;
using System.Collections.Generic;

namespace AST.Application.Services
{
    public class FooService: IFooService
    {
        private readonly IRepository<Foo> _fooRepository;

        public FooService(IRepository<Foo> fooRepository)
        {
            _fooRepository = fooRepository;
        }

        IEnumerable<Foo> IFooService.GetAll()
        {
            return _fooRepository.GetAll();
        }
    }
}
