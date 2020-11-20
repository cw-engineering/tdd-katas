using NUnit.Framework;
using Shouldly;
using System;
using NSubstitute;

namespace tdd.greetings.tests
{
    [TestFixture]
    public class GreeterTests
    {
        [TestCase("John")]
        [TestCase("Tom")]
        public void Greet_OutputsGreeting_WhenNamePassed(string name)
        {
            IGreeter greeter = new Greeter();

            var result = greeter.Greet(name);

            result.ShouldBe($"Hello, {name}!");
        }

        [Test]
        public void Greet_UsesStandIn_WhenNullPassed()
        {
            IGreeter greeter = new Greeter();

            var result = greeter.Greet(null);

            result.ShouldBe($"Hello, my friend A.");
        }
    }
}
