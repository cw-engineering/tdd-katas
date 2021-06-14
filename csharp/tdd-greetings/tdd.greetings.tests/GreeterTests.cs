using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class GreeterTests
    {
        [Test]
        public void Greet_OutputsGreetingWithName_WhenNamePassed()
        {
            IGreeter greeter = new Greeter();

            var result = greeter.Greet("Tom");

            result.ShouldBe("Hello, Tom!");
        }
    }
}
