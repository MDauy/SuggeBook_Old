using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuggeBook.Api.ViewModels;
using SuggeBook.Domain.Model;
using SuggeBook.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuggeBookTests
{
    [TestClass]
    public class CustomAutoMapperTest
    {
        private CreateBookViewModel _createBookViewModel;
        private CreateAuthorViewModel _createAuthorViewModel;
        private Book _book;
        private BookViewModel _bookViewModel;
        private Author _author1;
        private Author _author2;
        private BookAuthorViewModel _authorVM1;
        private BookAuthorViewModel _authorVM2;

        public CustomAutoMapperTest ()
        {
        }

        private void InitializeData ()
        {
            _createBookViewModel = new CreateBookViewModel
            {
                AuthorsIds = new List<string>(new string[] {"1", "2"}),
                Categories = new List<string>(new string[] {"Roman"}),
                Isbn10 = "ISBN10",
                Title ="TOTO"
            };

            _createAuthorViewModel = new CreateAuthorViewModel
            {
                Name = "John Doe"
            };

            _author1 = new Author
            {
                Name = "Author One",
                NbSuggestions = 3,                
            };

             _author2 = new Author
            {
                Name = "Author Two",
                NbSuggestions = 45,                
            };

            _authorVM1 = new BookAuthorViewModel
            {
                Name = "Author One",       
            };

             _authorVM2 = new BookAuthorViewModel
            {
                Name = "Author Two",        
            };

            _book = new Book
            {
                Authors = new List<Author> (new Author[] {_author1, _author2}),
                PublishedDate =  DateTime.Now.ToString(),
                Isbn10 = "ISBN10",
                SagaPosition = 5
            };

            _bookViewModel = new BookViewModel
            {
                Authors = new List<BookAuthorViewModel> (new BookAuthorViewModel[] {_authorVM1, _authorVM2}),
                PublishedDate =  DateTime.Now.ToString(),
                SagaPosition = 8
            };
            _author1.Books = new List<Book>(new Book[]{_book});
            _author2.Books = new List<Book>(new Book[]{_book});
        }

        [TestMethod]
        public void TestNewDeclaration()
        {
            var test1 = new Type1
            {
                PropString = "toto"
            };

            var test2 = CustomAutoMapper.Map<Type2>(test1);

            Assert.IsNotNull(test2);
            Assert.AreNotEqual(test2, test1);
        }

        [TestMethod]
        public void TestSimpleReferencePropertyAssignment()
        {
            var test1 = new Type1
            {
                PropString = "toto"
            };

            var test2 = CustomAutoMapper.Map<Type2>(test1);

            Assert.AreNotEqual(test2, test1);
            Assert.AreEqual(test2.PropString, test2.PropString);
        }

        [TestMethod]
        public void TestSimpleValuePropertyAssignment()
        {
            var test1 = new Type1
            {
                PropInt = 1
            };

            var test2 = CustomAutoMapper.Map<Type2>(test1);

            Assert.AreNotEqual(test2, test1);
            Assert.AreEqual(test2.PropString, test2.PropString);
            Assert.AreEqual(test2.PropInt, test2.PropInt);
        }

        [TestMethod]
        public void TestSubtypePropertyAssignment()
        {
            var test1 = new Type1
            {
                PropInt = 2,
                PropString = "toto",
                PropSubtype = new Subtype1
                {
                    PropString = "tata",
                    PropInt = 3
                }
            };

            var test2 = CustomAutoMapper.Map<Type2>(test1);

            Assert.AreNotEqual(test1, test2);
            Assert.AreEqual(test1.PropInt, test2.PropInt);
            Assert.AreEqual(test1.PropString, test2.PropString);
            Assert.IsNotNull(test2.PropSubtype);
            Assert.AreNotEqual(test1.PropSubtype, test2.PropSubtype);
            Assert.AreEqual(test2.PropSubtype.PropString, test1.PropSubtype.PropString);
            Assert.AreEqual(test2.PropSubtype.PropInt, test1.PropSubtype.PropInt);
        }

        [TestMethod]
        public void TestListSubtypePropertyAssignment()
        {
            var test1 = new Type1
            {
                ListSubtypes = new List<Subtype1> {new Subtype1
                {
                    PropInt = 2,
                    PropString = "tutu"
                } },
                PropString = "tata",
                PropInt = 1,
                PropSubtype = new Subtype1
                {
                    PropInt = 12,
                    PropString = "toto"
                }
            };
            var test2  = CustomAutoMapper.Map<Type2> (test1);

            Assert.AreNotEqual(test1, test2);
            Assert.AreEqual(test1.PropInt, test2.PropInt);
            Assert.AreEqual(test1.PropString, test2.PropString);
            Assert.IsNotNull(test2.PropSubtype);
            Assert.AreNotEqual(test1.PropSubtype, test2.PropSubtype);
            Assert.AreEqual(test2.PropSubtype.PropString, test1.PropSubtype.PropString);
            Assert.AreEqual(test2.PropSubtype.PropInt, test1.PropSubtype.PropInt);

            Assert.IsNotNull(test2.ListSubtypes);
            Assert.AreNotEqual(test2.ListSubtypes.Count, 0);

            Assert.AreEqual(test1.ListSubtypes[0].PropString, test2.ListSubtypes[0].PropString);
            Assert.AreEqual(test1.ListSubtypes[0].PropInt, test2.ListSubtypes[0].PropInt);
    }

        [TestMethod]
        public void Test_BookViewModel_Book_PropertyAssignment()
        {
            InitializeData();
            var book = CustomAutoMapper.Map<Book>(_bookViewModel);
            var bookViewModel_Authors = _bookViewModel.Authors.ToList();
            var book_Authors = _book.Authors.ToList();
            Assert.AreNotEqual(_bookViewModel, book);
            Assert.AreEqual(_bookViewModel.Title, book.Title);

            Assert.AreEqual(_bookViewModel.PublishedDate, book.PublishedDate);
            Assert.AreEqual(_bookViewModel.SagaPosition, book.SagaPosition);
            Assert.AreEqual(bookViewModel_Authors.Count, book.Authors.ToList().Count);

            for (int index = 0; index < bookViewModel_Authors.Count(); index++)
            {
                Assert.AreEqual (bookViewModel_Authors[index].Name, book_Authors[index].Name);
                Assert.AreEqual (bookViewModel_Authors[index].Id, book_Authors[index].Id);
            }
        }

        [TestMethod]
        public void Test_Book_BookVM_PropertyAssignment()
        {
            InitializeData();
            var bookViewModel = CustomAutoMapper.Map<BookViewModel>(_book);
            var bookViewModel_Authors = bookViewModel.Authors.ToList();
            var book_Authors = _book.Authors.ToList();

            Assert.AreNotEqual(bookViewModel, _book);
            Assert.AreEqual(bookViewModel.Title, _book.Title);
            Assert.AreEqual(bookViewModel.PublishedDate, _book.PublishedDate);
            Assert.AreEqual(bookViewModel.SagaPosition, _book.SagaPosition);
            Assert.AreEqual(bookViewModel_Authors.Count, _book.Authors.ToList().Count);
            Assert.AreEqual(bookViewModel.SagaPosition, _book.SagaPosition);

            for (int index = 0; index < bookViewModel_Authors.Count(); index++)
            {
                Assert.AreEqual (bookViewModel_Authors[index].Name, book_Authors[index].Name);
                Assert.AreEqual (bookViewModel_Authors[index].Id, book_Authors[index].Id);
            }
        }

        public class Type1
        {
            public string PropString { get; set; }

            public int PropInt { get; set; }

            public Subtype1 PropSubtype { get; set; }

            public IList<Subtype1> ListSubtypes { get; set; }
        }

        public class Type2
        {
            public string PropString { get; set; }

            public int PropInt { get; set; }

            public Subtype2 PropSubtype { get; set; }

            public IList<Subtype2> ListSubtypes { get; set; }
        }

        public class Subtype1
        {
            public string PropString { get; set; }

            public int PropInt { get; set; }
        }

        public class Subtype2
        {
            public string PropString { get; set; }
            public int PropInt { get; set; }
        }
    }
}
