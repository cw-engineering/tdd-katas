# Http headers Kata

_TDD kata with NUnit and Shouldly._

## Write a class that represents (simple) HTTP headers and simplifies working with it
Implement a C# class called `Headers` that represents a collection of headers
and contains a set of methods that can manipulate them.

## Requirements:

See https://tools.ietf.org/html/rfc2616#section-4.2 for formal specifications. **Header field names are case-insensitive.**

Try to follow the order of the steps below. You can add more tests to the current step if they are relevant to the context.

## Steps:

### 1. Implement C# indexer to get or set the header(s) based on their field name

_Note: The indexer signature is `string this[string]`_

- [ ] Create a getter and setter for the indexer:
```csharp
var headers = new Headers();
headers["Accept"] = "text/html";
var acceptHeader = headers["Accept"]; // should be "text/html"
```

- [ ] Indexer should be case-insensitive
```csharp
var headers = new Headers();
headers["Accept"] = "text/html";
var acceptHeader = headers["accept"]; // should be "text/html"
```

- [ ] Indexer returns null if the header with the given header does not exist:
```csharp
var headers = new Headers();
var acceptHeader = headers["Accept"]; // should be null
```

- [ ] Setting indexer header value to null will clear the value:
```csharp
var headers = new Headers();
headers["Accept"] = "text/html";
var acceptHeader = headers["Accept"]; // should be "text/html"
headers["Accept"] = null;
acceptHeader = headers["Accept"]; // should be null
```

- [ ] Clearing value via indexer is case-insensitive:
```csharp
var headers = new Headers();
headers["NameId"] = "13";
headers["nameId"] = null;
acceptHeader = headers["NameId"]; // should be null
```

- [ ] Indexer key cannot be null:
```csharp
var headers = new Headers();
headers[null] = "32"; // should throw ArgumentNullException
```

### 2. Implement property Count

- [ ] Property Count reports the number of headers in the collection:
```csharp
var headers = new Headers()
headers["Accept"] = "text/html";
headers["ETag"] = "5478";
var headerCount = headers.Count; // should be 2
```

### 3. Create method Add that adds a header

- [ ] Adds header to the collection
```csharp
var headers = new Headers();
headers.Add("Location", "home");
var acceptHeader = headers["Location"]; // should be "home"
```

- [ ] Header name cannot be null
```csharp
var headers = new Headers();
headers.Add(null, "text/json"); // throws ArgumentNullException
```

- [ ] Header value cannot be null
```csharp
var headers = new Headers();
headers.Add("X-MS-Options", null); // throws ArgumentNullException
```

### 4. Create method Remove that removes a header

- [ ] Removes header from the collection
```csharp
var headers = new Headers();
headers["X-Operation"] = "revoke";
headers.Remove("X-Operation");
var acceptHeader = headers["X-Operation"]; // should be null
```

- [ ] Header name cannot be null
```csharp
var headers = new Headers();
headers.Remove(null); // throws ArgumentNullException
```

### 5. Support multiple headers with the same name

- [ ] Header with the same name can be added and does not overwrite the previous one but appends it to the collection
```csharp
var headers = new Headers();
headers.Add("Accept", "text/json");
headers.Add("Accept", "text/html");
var headerCount = headers.Count; // should be 2
```

- [ ] Calling Remove with the given field name removes all headers with the name from the collection
```csharp
var headers = new Headers();
headers.Add("Opt", "A");
headers.Add("Opt", "B");
headers.Remove("Opt");
var headerCount = headers.Count; // should be 0
```

- [ ] Remove is case-insensitive
```csharp
var headers = new Headers();
headers.Add("tag", "13");
headers.Add("Tag", "7");
headers.Add("Foo", "7");
headers.Remove("tag");
var headerCount = headers.Count; // should be 1
```

- [ ] Indexer getter returns multiple header values with the same name joined by comma
```csharp
var headers = new Headers();
headers.Add("Accept", "text/json");
headers.Add("Accept", "text/html");
var acceptHeader = headers["Accept"]; // should be "text/json,text/html"
```

- [ ] Indexer getter returns multiple header values with the same name joined by comma and is case-insensitive
```csharp
var headers = new Headers();
headers.Add("Colour", "red");
headers.Add("colour", "green");
var acceptHeader = headers["Accept"]; // should be "red,green"
```

- [ ] Indexer getter returns multiple header values with the same name joined by comma in the order they were added
```csharp
var headers = new Headers();
headers.Add("Colour", "red");
headers.Add("colour", "green");
headers.Add("colour", "blue");
headers.Add("colour", "all");
var acceptHeader = headers["Accept"]; // should be "red,green,blue,all"
```

- [ ] Setting indexer value to null will clear all headers value and is case-insensitive:
```csharp
var headers = new Headers();
headers.Add("ETag", "012");
headers.Add("eTag", "234");
headers["ETag"] = null;
var eTagHeader = headers["ETag"]; // should be null
eTagHeader = headers["eTag"]; // should be null
```

### 6. Implement method ToString that returns the collection of headers as string formatted according to https://tools.ietf.org/html/rfc2616

```
field-name: field-value CR LF
field-name: field-value CR LF
```

- [ ] ToString() renders the header collection as string:
```csharp
var headers = new Headers();
headers.Add("ETag", "012");
var text = headers.ToString(); // should be "ETag: 012\r\n"
```

- [ ] ToString() renders the header collection as string in the order the headers were added:
```csharp
var headers = new Headers();
headers.Add("Tag", "yes; no");
headers.Add("Accept", "all");
var text = headers.ToString(); // should be "Tag: yes; no\r\nAccept: all\r\n"
```

- [ ] ToString() renders headers with the same name as individual elements:
```csharp
var headers = new Headers();
headers.Add("Accept", "all");
headers.Add("accept", "any");
headers.Add("accepT", "two");
var text = headers.ToString(); // should be "Accept: all\r\naccept: any\r\naccepT: two\r\n"
```

### 7. Implement interface `IEnumerable<KeyValuePair<string, string>>` that exposes all header elements as key value pairs
- [ ] Headers are returned in the order they were added
```csharp
var headers = new Headers();
headers.Add("Accept", "all");
headers.Add("accept", "any");
foreach(var element in headers)
{
    Console.WriteLine($"{element.Key}: {element.Value}");
}
```
The above program should output the following in the console:
```
Accept: all
accept: any
```

## Advanced

### 8. Implement static method `Headers FromString(string)` that parses a string into headers
- [ ] Input string cannot be null - throw ArgumentNullException
- [ ] Try to optimise the code, limit the number of allocations - you can use the new Span<T> for this or other technques
