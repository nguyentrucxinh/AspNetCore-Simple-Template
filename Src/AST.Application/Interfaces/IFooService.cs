using System.Collections.Generic;
using System.Threading.Tasks;
using AST.Application.ViewModels;
using AST.Core.Entities;

namespace AST.Application.Interfaces
{
    public interface IFooService
    {
        IEnumerable<Foo> GetAll();
        Task<Foo> GetById(int id);
        Task<Foo> Add(FooFormModel model);
        Task<int> UpdateById(int id, FooFormModel model);
        Task<int> DeleteById(int id);
    }
}
