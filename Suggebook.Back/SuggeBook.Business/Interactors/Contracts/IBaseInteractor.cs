using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors.Contracts
{
    public interface IBaseInteractor<T1, T2>
    {
        Task<T2> Get(string id);
        Task<List<T2>> GetSeveral(List<string> ids);
        Task<T2> GetRandom();
    }
}
