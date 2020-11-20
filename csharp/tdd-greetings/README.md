# Greeting Kata

_TDD kata with NUnit, NSubstitute and Shouldly._

#### Write a method `greet` that interpolates name into a greeting.
You work for a company called SofTele on a communication product called E-Pistler. You team has been asked to write a method that, given a username and an optional date of birth, generates a greeting message. The contract has been provided via the `IGreeter` interface.

#### Requirement 1
Name is interpolated in a simple greeting. For example, when name is "Bert", the method should return a string `"Hello, Bert!"`.

#### Requirement 2
Handle nulls end empty strings by introducing a stand-in. For example, when name is empty, then the method should return `"Hello, my friend."`

#### Requirement 3
If date of birth is provided and today is their birthday, generate a birthday message, i.e. `"Hello, Luke. Today is your birthday!"`.

#### Requirement 4
Ensure you account for users born on 29/02 (leap year). If they were born on this day, then the birthday message must be generated on 28/02 if the current year is a non-leap year.
