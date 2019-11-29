using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tdd.Collections
{
    public class RecentlyUsedList<T> : IRecentlyUsedList<T>
        where T : struct
    {
        private readonly List<(string Id, T Value)> arr = new List<(string Id, T Value)>();

        // Define the indexer to allow client code to use [] notation.
        public (string Id, T Value) this[int index] => arr[index];

        public int Capacity => throw new NotImplementedException();

        public int Count
        {
            get
            {
                return arr.Count;
            }
        }

        public void Add(string id, T value) {
            
            for(int i=0; i<Count; i++)
            {
                if(arr[i].Id == id)
                {
                    arr.RemoveAt(i);
                    break;
                }
            }
            


            arr.Add((id,value));
        }
        public IEnumerator<(string Id, T Value)> GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }
}
