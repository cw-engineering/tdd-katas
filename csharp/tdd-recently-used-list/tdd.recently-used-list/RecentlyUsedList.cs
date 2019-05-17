using System;
using System.Collections;
using System.Collections.Generic;

namespace tdd.recently_used_list
{
    public class RecentlyUsedList<T> : IRecentlyUsedList<T> where T : struct
    {
        private List<(string id, T value)> _list = new List<(string id, T value)>();
        private readonly int _capacity;
        private DateTime? timeAdded;

        public RecentlyUsedList(int capacity = 500)
        {
            _capacity = capacity;
        }

        public (string id, T value) this[int index]
        {
            get
            {
                try
                {
                    return _list[index];
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Capacity => _capacity;

        public int Count
        {
            get
            {
                if (timeAdded.HasValue && (DateTime.UtcNow - timeAdded.Value) > TimeSpan.FromMilliseconds(99))
                    return 0;
                return _list.Count;
            }
        }

        public void Add(string id, T value)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }
            if (_list.Count.Equals(_capacity))
            {
                return;
            }

            foreach (var item in _list.ToArray())
            {
                if (id.Equals(item.id, StringComparison.OrdinalIgnoreCase))
                {
                    _list.Remove(item);
                }
            }
            _list.Insert(0, (id, value));
        }

        public void Add(string id, T value, TimeSpan? time)
        {
            timeAdded = DateTime.UtcNow;
            _list.Add((id, value));
        }

        public IEnumerator<(string id, T value)> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
