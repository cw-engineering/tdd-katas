# Csv reader

_TDD kata with NUnit and Shouldly._

#### Create a CSV reader class that reads csv records from a text reader.

The class name should be `CsvReader` and its constructor should take a `System.IO.TextReader` instance. The method name should be `ReadNext`. The method should return the next record (line) as array of strings that represent the csv fields of the record separated by a delimiter.

* Do not use any 3rd party or system libraries
* Do not use regular expressions

#### TDD Kata Rules

 * You can't write any production code until you have first written a failing unit test.
 * You can't write more of a unit test than is sufficient to fail, and not compiling is failing.
 * You can't write more production code than is sufficient to pass the currently failing unit test.

#### CSV Requirements

_Loosely based on [RFC 4180](https://tools.ietf.org/html/rfc4180)_  
_Assume comma `','` as the delimiter and double quote `'"'` as the qualifier for the requirements below._  
_Newlines are symbolised with ⏎ and are represented by `"\n"` escape sequence in strings._

1.  **Each record is located on a separate line.**  
    _For example:_
    ```
    aaa⏎
    zzz
    ```
    _should return two records._

2.  **Empty lines are reported as record with a single empty string.**  
    _For example:_
    ```
    aaa⏎

    ```
    _should return two records; first with one field `{ "aaa" }`, second with one field `{ "" }`._

3.  **Within the each record, there may be one or more fields, separated by delimiter.**  
    _For example:_
    ```
    aaa,bbb,ccc
    ```
    _should return one record with three fields._

4.  **Spaces are considered part of a field and must not be ignored.**  
    _For example:_
    ```
    aaa,bbb , ccc
    ```
    _should return one record with three fields `{ "aaa", "bbb ", " ccc" }`._

5.  **Fields may be empty.**  
    _For example:_
    ```
    ,a,,
    ```
    _should return one record with four fields `{ "", "a", "", "" }`._

6.  **Each field may be enclosed using qualifier. Such field is said to be "qualified".**  
    _For example:_
    ```
    "zzz","yyy"
    ```
    _should return one record with two fields `{ "zzz", "yyy" }`._

7.  **Qualifier may not appear in fields that are not qualified.**  
    _For example:_
    ```
    aaa,b"bb,ccc
    ```
    _or_
    ```
    aaa, "bb",ccc
    ```
    _should throw an exception._

8.  **Qualifier appearing inside a field must be escaped by preceding it with another qualifier.**  
    _For example:_
    ```
    "a""a",bbb,ccc
    ```
    _should return one record with three fields `{ "a\"a", "bbb", "ccc" }`._

9.  **Fields containing delimiter(s) must be qualified.**  
    _For example:_

    ```
    bbb,"c,cc"
    ```
    _should return one records with two fields `{ "bbb", "c,cc" }`._

10. **Fields containing newline(s) must be qualified.**  
    _For example:_
    ```
    aaa,"b⏎
    bb",ccc⏎
    ddd,eee
    ```
    _should return two records; first with three fields `{ "aaa", "b\nbb", "ccc" }`, second with two fields `{ "ddd", "eee" }`._

11. **Fields can contain any number of delimiters, newlines and qualifiers.**  
    _For example:_
    ```
    ,bbb,"cc""c⏎
    ddd,eee,f"""
    ```
    _should return one record with three fields `{ "", "bbb", "cc\"c\nddd,eee,f\"" }`._

#### Optional

12.  **Make delimiter, qualifier and record separator (newline) configurable.**  
     _For example pipe `|` as delimiter and single quote `'` as qualifier:_
     ```
     aaa|bbb|'ccc|d''dd⏎
     eee',fff
     ```
     _should return one record with four fields `{ "aaa", "bbb", "ccc|d'dd\neee", "fff" }`_

13.  **Add (boolean) setting to trim non-qualified fields; if enabled, trim all non-qualified fields.**  
     _For example, if trim non-qualified fields enabled:_
     ```
     aaa,  bbb,ccc ," ddd "
     ```
     _should return one record with the following fields: `{ "aaa", "bbb", "ccc", " ddd " }`_
