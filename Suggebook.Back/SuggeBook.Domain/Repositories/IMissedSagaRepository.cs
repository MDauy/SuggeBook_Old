using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Domain.Repositories
{
    public interface IMissedSagaRepository
    {
        Task Register (string title, string message);
    }
}
