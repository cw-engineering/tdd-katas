using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Tdd.Collections
{
    public class RecentlyUsedList<T> : IRecentlyUsedList<T>
        where T : struct
    {
        private T _value;

        private List<(string Id, T Value)> _list;

        public RecentlyUsedList(int capacity = 10)
        {
            _list = new List<(string Id, T Value)>();
            Capacity = capacity;
        }

        public (string Id, T Value) this[int index] => _list[index];

        public int Capacity { get; set; } 

        public int Count => _list.Count;

        public void Add(string id, T value)
        {
            if (id==null) throw new ArgumentNullException("id");
            
            if (id.Length == 0) throw new ArgumentOutOfRangeException("id");

            if (Count == Capacity) return;

            var existId = _list.Any(i => String.Equals(i.Id, id, StringComparison.OrdinalIgnoreCase));

            if (!existId)
                _list.Insert(0, (id, value));
        }

        public void Add(string id, T value, TimeSpan expiresIn) => throw new NotImplementedException();

        public IEnumerator<(string Id, T Value)> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
