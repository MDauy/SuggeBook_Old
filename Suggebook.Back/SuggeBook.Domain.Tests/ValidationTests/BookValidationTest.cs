using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuggeBook.Domain.Model;

namespace SuggeBookTests.ValidationTests
{
    [TestClass]
    public class BookValidationTest
    {
        private Fixture _fixture;

        public BookValidationTest()
        {
            _fixture = new Fixture();
        }
        
        [TestMethod]
        public void Should_Be_Valid()
        {
            var book = new Book
            {
                Title = _fixture.Create<string>(),
                Authors = new[] { _fixture.Create<Author>() },
                Categories = new[] { "Comedie", "Historique" }

            };
            book.IsValid();
            Assert.IsTrue(true);
        }
    }
}