using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBook.Domain.UseCases
{
    public class GetYouMightLikeSuggestions : IGetYouMightLikeSuggestions
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public GetYouMightLikeSuggestions(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Get(string userId)
        {
            var user = await _userRepository.Get(userId);
            var books = await _bookRepository.GetFromCategories(user.FavoriteCategories.ToList());
            return books.OrderByDescending(b => b.Likes).Take(15).ToList();

        }
    }
}