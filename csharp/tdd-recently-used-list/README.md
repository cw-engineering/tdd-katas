# Most Recently Used List

_TDD kata with NUnit and Shouldly. Revamped for dotnet core 3._

#### Write a most recently used (MRU) list class

Write a generic class to hold list of most recently used items in a LIFO order.
The items are identified by an unique string and associated data that can be any
C# struct. You've been provided an interface that needs to be implemented.

#### Requirements

* Must implement `IRecentlyUsedList<T>` interface.
* List items are identified by `string Id`:
  * Item identifiers are unique and are **case insensitive**,
  * `Null` and empty (`""`) item identifiers are not allowed,
  * There cannot be two items with the same identifier,
  * If a duplicate identifier is found, old item is removed from the list and   new one is added.
* The most recently added item is always the first in the list. The least recently added is last.
* Items can be retrieved using [indexer](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/):
  * Index is zero based.
  * If the index is out of range, an exception is thrown.
* Capacity can be provided to specify upper limit to the number of items contained, with the least recently added items dropped on overflow.

#### Advanced

* Add optional items expiration timespan. Expired items should not be available in the list.
* Make the list thread safe