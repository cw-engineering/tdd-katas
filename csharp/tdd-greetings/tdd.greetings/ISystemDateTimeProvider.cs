using System;
using System.Collections.Generic;
using System.Text;

namespace tdd.greetings
{
    public interface ISystemDateTimeProvider
    {
        DateTime CurrentSystemTime { get; }
    }
}
