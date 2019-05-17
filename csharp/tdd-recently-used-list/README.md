# Most Recently Used List

_TDD kata with NUnit and Shouldly._

#### Write a most recently used (MRU) list class

Develop a class to hold list of most recently used items in a LIFO order. The items
are identified by an unique string and associated data that can be any C# struct.
You've been provided an interface that needs to be implemented.

#### Requirements

* Must implement IRecentlyUsedList<T> interface.
* The most recently added item is always the first in the list. The least recently
  added is last.
* Items can be looked up by zero based index. If the index is out of range, an
  exception is thrown.
* Item identifiers are unique and are case insensitive, there cannot be two items
  with the same identifier. If a duplicate identifier is found, old item is removed
  from the list and new one is added.
* Capacity can be provided to specify upper limit to the number of items contained
  with the least recently added items dropped on overflow.
* Null and empty item identifiers are not allowed.

#### Advanced

* Add items expiration timespan (null = available forever). Expired items should not be available in the list.
* Make the list thread safe