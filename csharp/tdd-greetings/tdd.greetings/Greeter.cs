using System;

namespace tdd.greetings
{
    public class Greeter : IGreeter
    {
        ISystemDateTimeProvider _systemDateProvider;
        public Greeter(ISystemDateTimeProvider systemDateTimeProvider = null)
        {
            _systemDateProvider = systemDateTimeProvider;
        }

        public string Greet(string name, DateTime? dateOfBirth)
        {
            if (dateOfBirth != null && DateTime.IsLeapYear(dateOfBirth.Value.Year) && dateOfBirth.Value.Month == 2 && dateOfBirth.Value.Day == 29)
                dateOfBirth = new DateTime(dateOfBirth.Value.Year, 2, 28);
                
            var currentSystemDate = DateTime.Now;
            if(_systemDateProvider != null)
            {
                currentSystemDate = _systemDateProvider.CurrentSystemTime;
            }
            name = string.IsNullOrEmpty(name) ? "my friend" : name;
            var greeting = $"Hello, {name}.";
            var birthdayMessage = "";
            if (dateOfBirth.HasValue
                && dateOfBirth.Value.Month == currentSystemDate.Month 
                && dateOfBirth.Value.Day == currentSystemDate.Day)
            {
                birthdayMessage = " Today is your birthday!.";
            }
            return greeting + birthdayMessage;
        }
    }
}