using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public static IEnumerable<object[]> InvalidTokens
            => StaticVars.INVALID_TOKENS.Select(token => new object[] { token });

        [DataTestMethod]
        [DynamicData(nameof(InvalidTokens))]
        public void TestMethod1(string invalidToken)
        {
            Assert.AreEqual(invalidToken, "abc");
        }
    }

    public static class StaticVars
    {
        public static string[] INVALID_TOKENS => new[] {"abc", "def"};
    }
}
