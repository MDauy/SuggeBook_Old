using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuggeBook.Domain.UseCasesInterfaces;

namespace SuggeBookTests
{
    [TestClass]
    public class BookTest
    {
        private Mock<ICreateBook> _createBookUseCase;
        private IGetBook _getBookUseCase;

        public BookTest ()
        {
            _createBookUseCase = new Mock<ICreateBook>();            
        }

    }
}
