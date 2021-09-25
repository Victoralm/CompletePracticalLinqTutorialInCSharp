# Section 09 - Extendibility in C# #

## Functional programming ##

Is a programming paradigm - a style of building the structure and elements of
computer programs - that treats computations as the evaluation of mathematical
functions and avoids changing-state and mutable data.

It is a declarative programming paradigm, which means programming is done with
expressions or declarations instead of statements.

```csharp
y = F(X)
```

Always produces the same result for the same input!

For example, `y = x ^ 2` always returns the same value for the same input:

`4 = 2 ^ 2`, or `8 = 2 ^ 3`, etc...

In functional code, the output value of a function depends only on the arguments
that are passed to the function. In contrast to procedures depending on the
local or global state. Which may produce different results at different times
when called with the same arguments but a different state, eliminating side
effects.

### Paradigms terms ###

-   Functional Programming -> Function
-   Object Orientation -> Method

These two different paradigms treat functions differently.
Classic functions in FP are true mathematical functions, which will return the
same result. A function express all the information about itself in its
signature.

> OO makes code understandable by encapsulating moving parts. FP makes code
> understandable by minimizing moving parts.
>
> Michael Feathers

OO is all about changing states of objects, whereas FP tries to avoid state
changes at any means.

FP implies that we build systems by sticking with independent functions
together. Every function just depends on the inputs it receives and doesn't
depend on any external state. It is a paradigm which concentrates on computing
results rather than performing actions.

Programs written in a functional style are:

- More predictable
- Easier to mantain
- Easier to test

That means that you don't need to use difficult mocking techniques and other
advanced approaches to achieve testable design.

OO an FB try to achieve the same goals, with different approaches.

### Functions are Everywhere ###

- The core concept of the OO programming is "object".
- Functional paradigm is based on functions

Best practices of implementing functions in OOP-languages are aligned with how
we write functions in functional languages:

- Keep functions small
- Don't repeat yourself (there should be only one source of authoritative knowledge)
- Functions have to do only one thing
- Avoid side effects
- Functions should accept no more than 3 parameters

### OOP vs FP ###


| OOP         | FP |
| ----------- | ----------- |
| Single Responsibility Principle      | Functions       |
| Open/Close Principle      | Functions       |
| Dependency Inversion Principle and other SOLID principles      | Functions       |
| Strategy pattern      | Functions       |
| Abstract Factory pattern      | Functions       |
| Decorator pattern      | Functions       |
| Visitor pattern      | Functions       |
| Tons of patterns     | Functions       |

### Why Functional Programming? ###

You'll get a better developer learning new programming concepts and looking at
the same code base from other perspectives.

Get a fresh look!

Direct advantages:

- Minimizing the code base, Functional style in the end leads to more
understandable and shorter code
- FP leads to constructing more composable components which have very high reusability
- **Concurrency (safe concurrent access) since there's no shared state.**

FP paradigm enforces:

- Immutability of Types
- Functions without side effects
- Improved composability of types and functions

### What is Immutability? ###

What does it mean for an object to be immutable?

Such an object **doesn't mutate its internal state**.

Recall that strings are immutable! When you change a string instance, you get a
new modifies string instance as result. The initial instance, the original one,
stays unchanged.

### What is a Side Effect? ###

in terms of programming, a side effect is an **observable change made to the
state** of the system.
