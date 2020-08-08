using System.Collections.Generic;
using AST.Core.Entities;

namespace AST.Application.Interfaces
{
    public interface IFooService
    {
        IEnumerable<Foo> GetAll();
    }
}
