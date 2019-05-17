# Discounts calculator

_TDD kata with NUnit and Shouldly._

#### Create a method that, given an order and user details, calculates discounted price.

You work for a company named Amazin'. You've been asked to write a method to apply discounts on orders and calculate final order price. The method should accept the following:

 * order price
 * user registred period in years (only when user registered)
 * user account type (only when user registered)
    * potato
    * bronze
    * silver
    * gold

The method should return the discounted price.

#### TDD Kata Rules

 * You can't write any production code until you have first written a failing unit test.
 * You can't write more of a unit test than is sufficient to fail, and not compiling is failing.
 * You can't write more production code than is sufficient to pass the currently failing unit test.


#### Requirements

 1. Unregistered users do not get any discount
 2. Registered users get 1% loyalty discount for every year they have been registered up to 5% max
 3. Multiple discounts are stacked and then applied to the price, so that gold account that has been registered for 5 years gets 5%+7%=12% discount in total.
 4. Potato account type gets 0% additional discount
 5. Bronze account type gets additional 2% discount
 6. Silver account type gets additional 4% discount
 7. Gold account type gets additional 7% discount

#### Challenges _(optional)_

 * Minimise the use of `if` statements where possible.
 * New account type has been requested by the business called 'Composite'. Users with this account get gold discount plus additional 3% discount when they pay using Amazin' Composite credit card.