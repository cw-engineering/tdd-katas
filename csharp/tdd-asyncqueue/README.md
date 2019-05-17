# Async queue

_TDD kata with NUnit and Shouldly. You will need NUnit 3 Test Adapter extension._

### Implement generic async queue.

This is similar to normal queue, but instead of method `Dequeue`, use method `DequeueAsync` to dequeue the items in asynchronous matter. The `DequeueAsync` method should wait for an item to be available.

Requirements:

* The class should implement interface `IAsyncQueue<T>`.
* Enqueue should add new item.
* Count should return valid count.
* `GetEnumerator()` should return valid enumerator, so i.e. if 2 items are enqueued, then these should be available using foreach loop or linq query.
* `DequeueAsync` should return immediately, if item exists.
* If it does not, it should wait for the item to be available and return as soon as it is available.
* `DequeueAsync` should cancel waiting for available item if the cancellation token is cancelled and should throw TaskCancelledException.
* `Count` should return the number of items in the queue.
* The queue can be enumerated while it is being modified.
  ```csharp
    queue.Enqueue(1);
    queue.Enqueue(2);
    foreach(var item in queue) {
        queue.Enqueue(3); // should not throw
    }
  ```


Optional:
* The queue should be thread safe; i.e. multiple threads can enqueue / dequeue and the results should be consistent.

