using SuggeBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Domain.UseCasesInterfaces
{
    public interface IRegisterMissedBook
    {
        Task<MissedBook> Register (MissedBook missedBook);
    }
}
