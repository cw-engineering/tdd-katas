# Word Wrapping Kata

Write a method that, given a string and a number, wraps the string by word boundaries to fit within the number.

## Requirements

 * Consider only space `' '` and tab `\t` character as whitespace. Wrap by using `\n` character.
 * Example1: `wrap("hello world", 5)` returns `"hello\nworld"`
 * Example2: `wrap("hello\tworld", 5)` returns `"hello\nworld"`
 * Consider multiple spaces at the boundary as a single space for wrapping, i.e. `wrap("hello  \tjon", 5)` should return `"hello\njon"`
 * Averylongwords split onto multiple lines - Example: `wrap("hello averylongworld", 5)` returns `"hello\navery\nlongw\norld"`



