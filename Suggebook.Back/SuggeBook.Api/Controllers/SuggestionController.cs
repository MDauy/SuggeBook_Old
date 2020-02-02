using Microsoft.AspNetCore.Mvc;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace SuggeBook.Api.Controllers
{
    [Route("api/suggestion")]
    public class SuggestionController : Controller
    {
        private readonly ICreateSuggestion _createSuggestion;
        private readonly IGetBook _getBook;
        private readonly IMapper _mapper;
        public SuggestionController(ICreateSuggestion createSuggestion,
            IGetBook getBook, IMapper mapper)
        {
            _createSuggestion = createSuggestion;
            _getBook = getBook;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody]CreateSuggestionViewModel suggestionToCreate)
        {
                var suggestion = _mapper.Map<Suggestion>(suggestionToCreate);
                suggestion.Book = await _getBook.Get(suggestionToCreate.BookId);
                suggestion = await _createSuggestion.Create(suggestion);
                var suggestionViewModel = _mapper.Map<SuggestionViewModel>(suggestion);
                return new JsonResult(suggestionViewModel);            
        }
    }
}
