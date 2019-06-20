using SuggeBook.Domain.Exceptions;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCases
{
    public class RegisterMissedAuthor : IRegisterMissedAuthor
    {
        private IMissedAuthorRepository _missedAuthorRepository;

        public RegisterMissedAuthor (IMissedAuthorRepository missedAuthorRepository)
        {
            _missedAuthorRepository = missedAuthorRepository;
        }

        public async Task<MissedAuthor> Register(MissedAuthor missedAuthor)
        {
            try
            {
                missedAuthor.TestCreationValidation();

            }
            catch (Exception)
            {
                throw;
            }
            return await _missedAuthorRepository.Register(missedAuthor);
        }
    }
}
