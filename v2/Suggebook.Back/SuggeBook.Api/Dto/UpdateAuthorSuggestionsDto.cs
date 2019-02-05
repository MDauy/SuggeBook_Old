using SuggeBookDAL.Dao;

namespace SuggeBook.Api.Dto
    public class UpdateAuthorSuggestionsDto
    {
        public string AuthorId { get; set; }

        public SuggestionDao Suggestion { get; set; }
    }
}
