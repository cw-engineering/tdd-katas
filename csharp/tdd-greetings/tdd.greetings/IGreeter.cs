using System;

namespace tdd.greetings
{
    public interface IGreeter
    {
        string Greet(string name, DateTime? dateOfBirth = null);
    }
}
