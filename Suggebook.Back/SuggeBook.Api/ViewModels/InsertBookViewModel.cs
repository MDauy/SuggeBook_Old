namespace SuggeBook.Api.Dto
{
    public class InsertBookViewModel : BaseViewModel
    {
        public BookViewModel BookDto { get; set; }
        public string AuthorId { get; set; }
    }
}
