# Jumping Number Kata

Write a method that, given a number, finds if the number is a jumping number.

## Jumping Number

A **jumping number** (code name "jumporion") is a natural number in which all adjacent digits differ by 1.

For example, `123` is a jumporion because:

```js
Difference between 1 and 2 is 1
Difference between 2 and 3 is 1
```

## Notes

 * The difference between `9` and `0` (either way) is not considered as 1.
 * All single digit numbers are considered as jumping numbers.
 * The method should return an enum or a known string, not a boolean. I.e. `abc(123) => 'JUMPORION'`, `abc(0) => ''`


## Sample tests

 1. `7` is a jumporion. Any single digit natural number is a jumporion
 2. `12` is a jumporion, adjacent digits differ by 1
 3. `21` is a jumporion, adjacent digits differ by 1
 4. `890` is NOT a jumporion, 9-0 does not differ by one
 5. `10` is a jumporion, difference between 1-0 is one.
 6. `101` is a jumporion, adjacent digits differ by 1.
 7. `100` is NOT a jumporion, adjacent digits differ by 1.
 8. `4323210121` is a jumporion, adjacent digits differ by 1.


## Optional

Extend the method to find out if the number is A Tidy jumporion. Tidy jumporion is a jumporion whose digits are in non-decreasing order. For example `123` is a tidy jumporion, `121` is not.

