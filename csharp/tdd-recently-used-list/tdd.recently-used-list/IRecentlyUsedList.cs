using System;
using System.Collections.Generic;

namespace Tdd.Collections
{
    public interface IRecentlyUsedList<T> : IEnumerable<(string Id, T Value)>
        where T: struct
    {
        (string Id, T Value) this[int index] { get; }

        int Capacity { get; }

        int Count { get; }

        void Add(string id, T value);

        void Add(string id, T value, TimeSpan expiresIn);
    }
}
