using AST.Core.Entities;
using AST.Core.Interfaces;
using AST.Application.Interfaces;
using System.Collections.Generic;
using AST.Application.ViewModels;
using System.Threading.Tasks;

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

        public async Task<Foo> GetById(int id)
        {
            return await _fooRepository.GetAsync(id);
        }

        public async Task<Foo> Add(FooFormModel model)
        {
            return await _fooRepository.AddAsync(new Foo
            {
                Bar = model.Bar,
                FooBar = model.FooBar,
            });
        }

        public async Task<int> UpdateById(int id, FooFormModel model)
        {
            var foo = await _fooRepository.GetAsync(id);
            foo.Bar = model.Bar;
            foo.FooBar = model.FooBar;
            return await _fooRepository.UpdateAsync(foo);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _fooRepository.DeleteAsync(id);
        }
    }
}
