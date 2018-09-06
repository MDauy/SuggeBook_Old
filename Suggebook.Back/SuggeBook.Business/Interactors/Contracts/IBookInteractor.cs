using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Contracts
{
    public interface IBookInteractor
    {
        Task<BookDto> Get(string id);
        Task<List<BookDto>> GetSeveral (List<string> ids);
        Task<BookDto> GetRandom();
    }
}
