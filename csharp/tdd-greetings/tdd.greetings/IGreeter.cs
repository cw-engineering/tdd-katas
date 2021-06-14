using System;

namespace Tdd
{
    public interface IGreeter
    {
        string Greet(string name, DateTime? dateOfBirth = null);
    }
}
