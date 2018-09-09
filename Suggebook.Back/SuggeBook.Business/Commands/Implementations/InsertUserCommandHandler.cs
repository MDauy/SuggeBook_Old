using SuggeBook.Business.Commands.Contracts;
using SuggeBook.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Business.Commands.Implementations
{
    public class InsertUserCommandHandler : IInsertUserCommandHandler
    {
        public Task<bool> ExecuteAsync(UserDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
