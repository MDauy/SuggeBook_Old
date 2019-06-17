using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuggeBook.Domain.Model;

namespace SuggeBook.Domain.Repositories
{
    public interface ISagaRepository
    {
        Task<Saga> Get(string title);

        Task<Saga> Create(Saga saga);
    }
}
