using System;
using System.Collections;
using System.Collections.Generic;

namespace Tdd.Collections
{
    public class RecentlyUsedList<T> : IRecentlyUsedList<T>
        where T : struct
    {
        public (string Id, T Value) this[int index] => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public void Add(string id, T value) => throw new NotImplementedException();

        public IEnumerator<(string Id, T Value)> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }
}
