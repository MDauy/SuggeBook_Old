using System.Threading.Tasks;

namespace SuggeBook.Framework
{
    public interface ICommandHandlerAsync<T1, T2>
    {
        Task<T2> ExecuteAsync(T1 obj);
    }
}
