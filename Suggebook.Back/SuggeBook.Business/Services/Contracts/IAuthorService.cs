using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Services.Contracts
{
    public interface IAuthorService
    {
        Task Insert(AuthorDto dto);

        Task InsertSeveral(List<AuthorDto> dtos);
    }
}
