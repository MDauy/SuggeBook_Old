using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuggeBook.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.UseCasesInterfaces;
using SuggeBook.Framework;
using System;
using System.Threading.Tasks;
using static SuggeBook.ViewModels.SuggestionViewModel;
using AutoMapper;

namespace SuggeBook.Api.Controllers
{
    [Route("suggestion")]
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
        [Route("create")]
        public async Task<JsonResult> Create([FromBody]CreateSuggestionViewModel suggestionToCreate)
        {
            var suggestion = CustomAutoMapper.Map<CreateSuggestionViewModel, Suggestion>(suggestionToCreate);
            suggestion.Book = await _getBook.Get(suggestionToCreate.BookId);
            suggestion = await _createSuggestion.Create(suggestion);
            var suggestionViewModel = CustomAutoMapper.Map<Suggestion, SuggestionViewModel>(suggestion);
            return new JsonResult(suggestionViewModel);
        }
    }
}
