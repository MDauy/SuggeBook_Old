using AutoMapper;
using SuggeBook.Domain.Model;
using SuggeBook.Domain.Repositories;
using SuggeBook.Framework;
using SuggeBook.Infrastructure.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Infrastructure.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly IBaseRepository<ShowDocument> _baseRepository;
        private readonly IMapper _mapper;

        public ShowRepository(IBaseRepository<ShowDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public void Create(Show show)
        {
            throw new NotImplementedException();
        }

        public Show Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Show> GetShowsAccordingToCategory(List<Category> categories, ShowType showType)
        {
            throw new NotImplementedException();
        }
    }
}
