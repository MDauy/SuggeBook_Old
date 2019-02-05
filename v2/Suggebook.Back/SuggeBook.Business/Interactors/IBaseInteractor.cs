using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors
{
    public interface IBaseInteractor<T1>
    {
        Task<T1> Get(string id);
        Task<List<T1>> GetSeveral(List<string> ids);
        Task<T1> GetRandom();
    }
}
