using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuggeBook.Infrastructure
{
    interface ITestBaseRepository<T> : IBaseRepository<T>
    {
        Task<T> GetRandom();
    }
}
