using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace tdd.asyncqueue
{
    public interface IAsyncQueue<T>  : IEnumerable<T>
    {
        int Count { get; }

        void Enqueue(T value);

        Task<T> DequeueAsync(CancellationToken cancellationToken = default);
    }
}
