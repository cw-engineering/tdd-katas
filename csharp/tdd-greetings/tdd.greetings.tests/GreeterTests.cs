using NUnit.Framework;
using Shouldly;
using System;
using NSubstitute;

namespace tdd.greetings.tests
{
    [TestFixture]
    public class GreeterTests
    {
        [Test]
        public void Greeter_ImplementsIGreeterInterface()
        {
            typeof(IGreeter).IsAssignableFrom(typeof(Greeter)).ShouldBeTrue();
        }

        [TestCase("Bart")]
        [TestCase("Bert")]
        public void Greet_NameIsInterpolatedInGreeting(string name)
        {
            var greeter = new Greeter();

            var response = greeter.Greet(name, null);

            response.ShouldBe($"Hello, {name}.");
        }

        [Test]
        public void Greet_ReturnGenericGreetingWhenEmptyName()
        {
            var greeter = new Greeter();

            var response = greeter.Greet("", null);

            response.ShouldBe("Hello, my friend.");
        }
        [Test]
        public void Greet_ReturnGenericGreetingWhenNullName()
        {
            var greeter = new Greeter();

            var response = greeter.Greet(null, null);

            response.ShouldBe("Hello, my friend.");
        }

        [Test]
        public void Greet_ReturnBirthdayMessageWhenTodayIsYourBirthday()
        {
            var greeter = new Greeter();
            
            var response = greeter.Greet("Name", new DateTime(2000,6,28));

            response.ShouldBe("Hello, Name. Today is your birthday!.");
        }

        [Test]
        public void Greet_ShouldNotReturnBirthdayMessageWhenTodayIsNotYourBirthday()
        {
            var greeter = new Greeter();

            var response = greeter.Greet("Name", new DateTime(2000, 6, 29));

            response.ShouldNotBe("Hello, Name. Today is your birthday!.");
        }

        [Test]
        public void Greet_ShouldReturnBirthdayMessage_WhenDayIsTheSame()
        {
            var greeter = new Greeter();

            var response = greeter.Greet("Name", new DateTime(2000, 6, 28).AddMinutes(5));

            response.ShouldBe("Hello, Name. Today is your birthday!.");
        }

        [Test]
        public void Greet_ShouldReturnBirthdayMessage_WhenTodayIsNotLeapYear()
        {
            var provider = Substitute.For<ISystemDateTimeProvider>();
            provider.CurrentSystemTime.Returns(new DateTime(2021, 02, 28));
            var greeter = new Greeter(provider);

            var response = greeter.Greet("Name", new DateTime(2020, 2, 29));

            response.ShouldBe("Hello, Name. Today is your birthday!.");
        }
    }
}
