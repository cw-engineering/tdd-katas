# Counting Code Lines

_TDD kata with JUnit5._

#### Create a method that, given java code, returns number of lines of code.

Follow the TDD rules:

 * You can't write any production code until you have first written a failing unit test.
 * You can't write more of a unit test than is sufficient to fail, and not compiling is failing.
 * You can't write more production code than is sufficient to pass the currently failing unit test.

Follow the RGR cycle.
 * Red - create a unit test that fails.
 * Green - Write code that makes the test pass.
 * Refactor - Clean up the mess you just made.

With the actual tests described below, try to not read ahead. Focus on the above and not on the final code.

#### Requirements

* do not count `package` declarations and `import` statements
* a line is counted if it contains something other than whitespace or text in a comment
* whitespace includes tabs, spaces, and vertical tabs
* single line comments start with //
* block (multiline) comments start with /* and end with */ and they do not nest
* multiple block comments can be on a single line
* comment start sequences that appear inside strings should be ignored

Example:

```java
-   package org.vehicles;
-
-   // This file contains 3 lines of code
-
1   public interface Bicycle {
-     /**
-      * count the number of wheels a bicycle has
-      */
2     int countWheels(); // it's always 2!
3   }
```

```java
-   /*****
-   * This is a test program with 6 lines of code
-   *  \/* no nesting allowed!
-   //*****//***/// Slightly pathological comment ending...
-   package org.vehicles;
-
-   import java.io.*;
-
1   public final class Lorry {
-
2     public static final void main(String [] args) { // gotta love Java
-        // use System
3        System./*wait*/out./*for*/println/*it*/("Vroom \" /* beep " +
4                                                " beep */");
5     }
-
6  }
```

#### Extra fun:
In Java 12, one of the new features will be [JEP 326: Raw String Literals](http://openjdk.java.net/jeps/326).  Java decided to use backtick ` notation, which is currently used by Javascript/Typescript. Update the code to account for raw string literals and ensure comment start sequences that appear inside raw string literals should be ignored

Example:

```ts
-   package org.vehicles;
-
-   import java.io.*;
-
1   public final class Bus {
-
2     public static final void main(String [] args) {
3        System.out.println(`Vroom /* beep
4                                  */ beep
5                                     beep`);
6     }
-
7  }
```