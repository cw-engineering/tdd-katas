using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace tdd.asyncqueue
{
    public class AsyncQueue<T> : IAsyncQueue<T>
    {
        private int count;
        private List<T> _Items = new List<T>();

        public int Count => count;

        public async Task<T> DequeueAsync(CancellationToken cancellationToken = default)
        {
            count--;
            while(_Items.Count == 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(10);
            }

            var value = _Items[0];
            _Items.RemoveAt(0);
            return value;
        }

        public void Enqueue(T value)
        {
            count++;
            _Items.Add(value);

        }

        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>)
                .Reverse()
                .ToList()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
