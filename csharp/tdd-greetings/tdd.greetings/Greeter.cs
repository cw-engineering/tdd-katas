using System;

namespace tdd.greetings
{
    public class Greeter : IGreeter
    {

        private readonly string someVar = "123";


        public string Greet(string name, DateTime? dateOfBirth = null)
        {
            if (someVar == "1234")
                return null;

            if (name == null)
                return "Hello, my friend.";

            return $"Hello, {name}!";
        }

        public string SomeMethod() => "1234";
    }
}