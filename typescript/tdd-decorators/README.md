# Decorators

Write a method decorator in Typescript called `@log`, that will log method name and its arguments.

https://www.typescriptlang.org/docs/handbook/decorators.html
https://www.youtube.com/watch?v=mM3zJ86QfBk

#### Example use of decorator

If the decorator is used in a class like the one below:

```ts
class Name {

    @log()
    public isCapitalized(name: string): boolean {
        ...
    }
}

```
then calling the method
```ts
new Name().isCapitalized('John')
```
should output the following log:

```ts
// console.log($`Method '${methodName}' called with: `, methodArgs);
"Method 'isCapitalized' called with: ", John
```

#### Requirements

You can use the following as a guidance to the unit tests:

  1. The decorator should use the decorator factory pattern as it will accept additional parameters  
     Create as many unit tests as required to fulfill this requirement.

  2. The decorator should accept an optional logger  
     `@log(logger)` => uses logger.log to log the statement

  3. If no logger is provided, use console instead  
     `@log()` => uses console.log to log the statement

  4. The decorator should log the correct method name  
     `@log() function fooBarBaz() {}` => should contain `fooBarBaz` in the log message

  5. The decorator should log the method arguments  
     `@log() function fooBarBaz(age: number) {}` => should contain value of the age parameter in the log statement

  6. Ensure the decorator does not break the function context  
     `this` context within the decorated function should not change

  7. Ensure the decorator does not break the function return value  
     Decorated function `@log() function fooBarBaz(age: number) { return number - 2; }` => when called as `x.fooBarBaz(20);` should return `18` 


#### Hints

**Decorator factory pattern for class methods**:

The decorator must return a function:

```ts
function someDecorator(decoratorParam: any) {
    return function(target: any, methodName: string, descriptor: PropertyDescriptor) {
    };
}
```

**Retrieve original method using decorator**

```ts
function someDecorator(decoratorParam: any) {
    return function(target: any, methodName: string, descriptor: PropertyDescriptor) {
        const method = (descriptor.value as Function);
    };
}
```