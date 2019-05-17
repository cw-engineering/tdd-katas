# Counting Words in a Sentence

_TDD kata with NUnit and Shouldly. You will need NUnit 3 Test Adapter extension._

#### Create a method that, given a sentence, returns number of words in the sentence.

Follow the TDD rules:

 * You can't write any production code until you have first written a failing unit test.
 * You can't write more of a unit test than is sufficient to fail, and not compiling is failing.
 * You can't write more production code than is sufficient to pass the currently failing unit test.

Follow the RGR cycle.
 * Red - create a unit test that fails.
 * Green - Write code that makes the test pass.
 * Refactor - Clean up the mess you just made.

With the actual tests described below, try to not read ahead. Focus on the above and not on the final code.

#### 1. Null string returns zero
```js
Count(null) ==> returns 0
```

#### 2. String consisting of whitespaces only returns zero
```js
Count(" \n\n\t\r ") ==> returns 0
```

#### 3. Single word returns one
```js
Count("Hello") ==> returns 1
```

#### 4. Two words separated by a space return two
```js
Count("Hello world") ==> returns 2
```

#### 5. Single word surrounded by any whitespaces returns one
```js
Count("  \nHello  \r ") ==> returns 1
```

#### 6. Words can be separated by any whitespace(s)
```js
Count("Hello crazy \n  world") ==> returns 3
```

#### 7. Count only unique words
```js
Count("Hello world in world") ==> returns 3
```

#### 8. Words are case insensitive
```js
Count("Hello world hello") ==> returns 2
```

#### 9. Trailing periods are ignored
```js
Count("Hello world hello.") ==> returns 2
```

#### 10. Any punctuation is ignored.
```js
Count("Hello (world) - 123.") ==> returns 3
```

#### 11. Words are accent insensitive.
```js
Count("Allô? Allo est la fin.") ==> returns 4
```