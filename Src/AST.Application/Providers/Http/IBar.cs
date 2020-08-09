using System.Threading.Tasks;
using Refit;

namespace AST.Application.Providers
{
    public interface IBar
    {
        [Get("/")]
        Task<object> GetAll();
    }
}
