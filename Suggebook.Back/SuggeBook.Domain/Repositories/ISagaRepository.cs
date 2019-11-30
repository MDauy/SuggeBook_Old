using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.Repositories
{
    public interface ISagaRepository
    {
        Task<Saga> Get(string title);

        Task<Saga> GetById (string id);

        Task<Saga> Create(Saga saga);
    }
}
