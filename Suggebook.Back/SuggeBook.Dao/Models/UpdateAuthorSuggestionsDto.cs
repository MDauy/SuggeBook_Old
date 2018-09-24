using SuggeBookDAL.Dao;

namespace SuggeBook.Dto.Models
{
    public class UpdateAuthorSuggestionsDto
    {
        public string AuthorId { get; set; }

        public SuggestionDao Suggestion { get; set; }
    }
}
