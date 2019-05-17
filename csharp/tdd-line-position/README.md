# Line Position Kata

_TDD kata with NUnit and Shouldly._

#### Write a struct `LinePosition` that represents position (line and column) in a text file

Some characteristics to remember:
 - Structs should represent immutable objects and should be read-only (initialise them via contructors)
 - Structs are copied on assignment (meaning that they do not act as reference).
 - Example structs: `int`, `DateTime`

_Read more about C# structs [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/structs)_

### TDD practices

Follow the TDD rules:

 * You can't write any production code until you have first written a failing unit test.
 * You can't write more of a unit test than is sufficient to fail, and not compiling is failing.
 * You can't write more production code than is sufficient to pass the currently failing unit test.

Follow the RGR cycle.
 * Red - create a unit test that fails.
 * Green - Write code that makes the test pass.
 * Refactor - Clean up the mess you just made.

With the actual practices described below, try to not read ahead. Focus on the TDD rules and not on the final code.

**Write only minimum amount of code required to pass the test. A single practice below can end up having several unit tests.**

#### 1. Implement constructor:
   - The constructor accepts line and column as int (32 bit integer)
   - Line must be greater than zero. Throw `ArgumentOutOfRangeException` if line is invalid.
   - Column must be greater than zero. Throw `ArgumentOutOfRangeException` if column is invalid.

```csharp
new LinePosition(line: 1, column: 1); // <== OK
new LinePosition(0,1); // <== Error
new LinePosition(1,-1); // <== Error
```

#### 2. Implement properties
- Implement public getter only property `Line` - returns the line passed to constructor
- Implement public getter only property `Column` - returns the column passed to constructor

```csharp
var p = new LinePosition(2,3);
Console.WriteLine("{0}", p.Line); // should output 2
Console.WriteLine("{0}", p.Column); // should output 3
```

#### 3. Implement string representation
- Override base method `ToString()` and return line and column separated by colon - `"ln:col"`
```csharp
var p = new LinePosition(7,45);
Console.WriteLine(p.ToString()); // should output 7:45 to console
```

#### 4. Implement string parsing from the above format `"ln:col"`
- Implement static method `bool TryParse(string, out LinePosition)`
   - Returns false if string is invalid
   - Sets empty line position if string is invalid
   - Returns true if string is valid
   - Sets proper line position if string is valid
```csharp
LinePosition.TryParse("12:4", out linePosition); // <== returns true
LinePosition.TryParse("abc", out linePosition); // <== returns false
LinePosition.TryParse("0:0", out linePosition); // <== returns false
```

#### 5. Implement [deconstruct](https://docs.microsoft.com/en-us/dotnet/csharp/deconstruct)
- Implement deconstruct so location can be easily unpackaged into individual items.
Signature:
```csharp
public void Deconstruct(out int location, out int column)
```
Example:
```csharp
var p = new LinePosition(14, 4);
var (line, column) = p;
Console.WriteLine("{0},{1}", line, column); // should output 14,4
```


#### 6. Implement interface `IEquatable<LinePosition>`
- Implement method `bool Equals(LinePosition other)`
   - Returns true if positions equal (line and column are the same)
   - Returns false if positions do not equal
```csharp
var a = new LinePosition(14,3);
var b = new LinePosition(14,3);
var c = new LinePosition(1,3);
Console.WriteLine("{0}", a.Equals(a)); // should output True
Console.WriteLine("{0}", a.Equals(b)); // should output True
Console.WriteLine("{0}", a.Equals(c)); // should output False
```

#### 6a. Override base method `bool Equals(object other)`
- Returns true if other object is LinePosition and equals to this
- Returns false if other object is not LinePosition or does not equal to this
```csharp
var a = new LinePosition(14,3);
object b = new LinePosition(14,7);
object c = new LinePosition(14,3);
Console.WriteLine("{0}", a.Equals(true)); // should output False
Console.WriteLine("{0}", a.Equals(b)); // should output False
Console.WriteLine("{0}", a.Equals(c)); // should output True
```

#### 6b. Override base method `int GetHashCode()`
- Properly implements hash code - see [this link](https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2019) for more details

#### 6c. Implement equality `==` operator and inequality `!=` operator
- Start with failing unit test as usual
- Implementation should be in the end using `Equals(IEquatable other)`

See [this link](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/operator) for more details on how to overload operators.

Signature:
```csharp
public static bool operator ==(LinePosition left, LinePosition right);
public static bool operator !=(LinePosition left, LinePosition right);
```

Sample use:
```csharp
var a = new LinePosition(14,3);
var b = new LinePosition(14,3);
Console.WriteLine("{0}", a == b); // should output False
Console.WriteLine("{0}", a != b); // should output True
```

#### 7. Implement interface `IComparable<LinePosition>`
- Implement method `int CompareTo(LinePosition other)`
   - Returns 1 if this is greater than other
   - Returns -1 if other is greater than this
   - Returns 0 if positions are equal

Sample use:
```csharp
var a = new LinePosition(14,3);
var b = new LinePosition(14,4);
Console.WriteLine("{0}", a.CompareTo(b)); // should output -1
Console.WriteLine("{0}", b.CompareTo(a)); // should output 1
Console.WriteLine("{0}", a.CompareTo(a)); // should output 0
```

#### 7a. Implement operators `>`, `>=`, `<`, `<=`

Signature:
```csharp
public static bool operator >(LinePosition left, LinePosition right);;
```

#### 8. Implement implicit cast from `ValueTuple<int, int>`
- Implement implicit cast so line position can be easily set using value tuple vanilla syntax.
Signature:
```csharp
public static implicit operator LinePosition(ValueTuple<int, int> tuple)
```
Example use:
```csharp
LinePosition x = (13, 5);
Console.WriteLine(x.ToString()); // should output 13;5
```