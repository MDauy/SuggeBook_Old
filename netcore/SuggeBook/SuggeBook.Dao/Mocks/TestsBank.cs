using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuggeBook.Dto.Models;

namespace SuggeBook.Dto.Mocks
{
    public class TestsBank : ITestsBank
    {
        private IFakeUserService _fakeUserService;
        private IFakeBooksService _fakeBooksService;
        private IFakeSuggestionsService _fakeSuggestionsService;
        private IFakeAuthorService _fakeAuthorService;

      public TestsBank (IFakeUserService fakeUserService, IFakeBooksService fakeBooksService,
           IFakeSuggestionsService fakeSuggestionsService, IFakeAuthorService fakeAuthorService)
        {
            _fakeSuggestionsService = fakeSuggestionsService;
            _fakeUserService = fakeUserService;
            _fakeBooksService = fakeBooksService;
            _fakeAuthorService = fakeAuthorService;
        }

        public Author Author()
        {
            return Authors(1).FirstOrDefault();
        }

        public List<Author> Authors(int howMany)
        {
            return _fakeAuthorService.Generate(howMany);        
        }

        public Book Book()
        {
            return Books(1).FirstOrDefault();
        }

        public List<Book> Books(int howMany)
        {
            return _fakeBooksService.Generate(howMany);
        }

        public Suggestion Suggestion()
        {
            return Suggestions(1).FirstOrDefault();
        }

        public List<Suggestion> Suggestions(int howMany)
        {
            return _fakeSuggestionsService.Generate(howMany);
        }

        public User User()
        {
            return Users(1).FirstOrDefault();
        }

        public List<User> Users(int howMany)
        {
            return _fakeUserService.Generate(howMany);
        }
    }
}
