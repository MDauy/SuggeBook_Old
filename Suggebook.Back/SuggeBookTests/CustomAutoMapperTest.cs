using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuggeBook.Framework;
using System.Collections.Generic;

namespace SuggeBookTests
{
    [TestClass]
    public class CustomAutoMapperTest
    {
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
