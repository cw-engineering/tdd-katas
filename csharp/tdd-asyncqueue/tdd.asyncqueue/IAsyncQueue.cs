using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tdd
{
    public interface IAsyncQueue<T>: IReadOnlyCollection<T>
    {
        void Enqueue(T value);

        ValueTask<T> DequeueAsync(CancellationToken cancellationToken = default);
    }
}
