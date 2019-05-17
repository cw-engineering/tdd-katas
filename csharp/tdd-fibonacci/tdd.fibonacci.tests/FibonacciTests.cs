using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tdd.fibonacci.tests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void GetFibonacci_StartsWithZero()
        {
            const byte n = 0;
            const ulong expectedFn = 0;
            ulong fn = Fibonacci.GetFibonacci(n);

            Assert.AreEqual(expectedFn, fn);
        }

        [TestMethod]
        public void GetFibonacci_ReturnsCorrectValueForTheSecondNumber()
        {
            var fn = Fibonacci.GetFibonacci(1);
            Assert.AreEqual(1u, fn);
        }

        [TestMethod]
        public void GetFibonacci_ReturnsCorrectValueForTheThirdNumber()
        {
            var fib = Fibonacci.GetFibonacci(2);
            Assert.AreEqual(1u, fib);
        }

        [TestMethod]
        public void GetFibonacci_ReturnsCorrectValueForTheFifthNumber()
        {
            var fib = Fibonacci.GetFibonacci(7);
            Assert.AreEqual(13u, fib);
        }

        [TestMethod]
        public void GetFibonacci_ReturnsCorrectValueForThe92thNumber()
        {
            var fib = Fibonacci.GetFibonacci(92);
            Assert.AreEqual(7540113804746346429ul, fib);
        }

        [TestMethod]
        public void GetFibonacci_ThrowsExceptionWhenNumberWhenRecursion()
        {
            Assert.ThrowsException<ArgumentException>(() => { Fibonacci.GetFibonacci(-1); });
        }

        [TestMethod]
        public void GetFibonacci_ThrowsExceptionWhenNumberDoesntFitInReturnType()
        {
            Assert.ThrowsException<ArgumentException>(() => { Fibonacci.GetFibonacci(200); });
        }
    }
}
