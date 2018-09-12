using SuggeBook.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IAuthorService
    {
        Task Insert(InsertAuthorDto dto);

        Task<AuthorDto> GetRandom(int howMany = 1);

        Task<AuthorDto> Get(string id);
        Task<List<AuthorDto>> GetSeveral(List<string> ids);
    }
}
