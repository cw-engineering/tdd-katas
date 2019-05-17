using System;
using System.Collections.Generic;

namespace tdd.recently_used_list
{
    public interface IRecentlyUsedList<T> : IEnumerable<(string id, T value)>
        where T: struct
    {
        (string id, T value) this[int index] { get; }
        int Capacity { get; }
        int Count { get; }
        void Add(string id, T value);
        // TODO: Optional
        // void Add(string id, T value, TimeSpan expiresIn);
    }
}
