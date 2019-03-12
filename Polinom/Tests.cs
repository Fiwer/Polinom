using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PolinomTask;

namespace ConsoleApp24
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void GornerTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            Assert.AreEqual(0, test.Value(1));
        }
        [Test]
        public void GornerTest2()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (1, 4),
                new Tuple<double, int> (3, 3),
                new Tuple<double, int> (4, 2),
                new Tuple<double, int> (-5, 1),
                new Tuple<double, int> (-47, 0)
            });
            Assert.AreEqual(4, test.Value(-3));
        }
        [Test]
        public void GornerTest3()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (3, 6),
                new Tuple<double, int> (9, 5),
                new Tuple<double, int> (-28, 4),
                new Tuple<double, int> (6, 3),
                new Tuple<double, int> (-30, 2),
                new Tuple<double, int> (-30, 1),
                new Tuple<double, int> (100, 0)
            });
            test.Value(2);
            Assert.AreEqual(0, test.Value(-5));
        }
        [Test]
        public void CombineTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0),
                new Tuple<double, int> (-11, 0)
            });
            test.Combine();
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-22, 0)
            });

            Assert.AreEqual(true, test2.ToString() == test.ToString());
        }
        [Test]
        public void SumTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            test.Sum(new Odnochlen(1, 4));
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (6, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0),
                new Tuple<double, int> (0, 0)
            });
            Assert.AreEqual(true, test2.ToString() == test.ToString());
        }
        [Test]
        public void ToStringTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            Assert.AreEqual("5x^4+5x^3+1x^2-11= 0", test.ToString());
        }
        [Test]
        public void FileReadTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            
            Assert.AreEqual(true, test.ToString() == test.ToString());
        }
        [Test]
        public void IndexTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            Assert.AreEqual(5, test[1]);
        }
        [Test]
        public void InsertTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            test.Insert(16, 4);
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (21, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            Assert.AreEqual(true, test.ToString() == test2.ToString());
        }
        [Test] 
        public void DeleteTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            test.Delete(4);
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-11, 0)
            });
            Assert.AreEqual(true, test.ToString() == test2.ToString());
        }
        [Test]
        public void DeleteOddTest()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (6, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-12, 0)
            });
            test.DeleteOdd();
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (6, 3),
                new Tuple<double, int> (-12, 0)
            });
            Assert.AreEqual(true, test.ToString() == test2.ToString());
        }
        [Test]
        public void Derivate()
        {
            var test = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (5, 4),
                new Tuple<double, int> (6, 3),
                new Tuple<double, int> (1, 2),
                new Tuple<double, int> (-12, 0)
            });
            test.Derivate();
            var test2 = new Polinom(new List<Tuple<double, int>>
            {
                new Tuple<double, int> (20, 3),
                new Tuple<double, int> (18, 2),
                new Tuple<double, int> (2, 1),
            });
            Assert.AreEqual(true, test.ToString() == test2.ToString());
        }
    }
}
