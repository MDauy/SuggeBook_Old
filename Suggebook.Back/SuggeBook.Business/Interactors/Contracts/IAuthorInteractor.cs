using SuggeBook.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Interactors.Contracts
{
    public interface IAuthorInteractor
    {
        Task<AuthorDto> GetRandom();
        Task<AuthorDto> Get(string id);
        Task<List<AuthorDto>> GetSeveral(List<string> ids);
    }
}
