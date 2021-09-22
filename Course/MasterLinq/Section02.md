# Section 02

-   LINQ stands for Language Integrated Query and it is a query "language" which
    abstracts away the technology of accesssing data stored in different sources.
-   LINQ is heavily based on Extension Methods.
-   Pipelining is a functional programming concept and it is implemented in C# as
    Methods Chaining.
-   LINQ allows us to use the same technology for accessing different sources of
    data in a declarative style what improves readability and maintenability.
-   IEnumerable is a simple yet powerful interface which abstracts away the
    concept of "iteratable" collections.
-   Implement your own extension method and use it as part of LINQ queries
-   Pass named methods as predicate if it is significantly complex and long. If a
    predicate is short, then stick with lambda expressions. Forget about the old
    feature of anonymous methods.
-   Query Syntax sometimes can look more readable, however in most cases you can
    works with regular method chains.
-   Classification of LINQ Operators: they can be immediately executed and
    deferred. Deferred can be streaming and non-streaming.
-   Yield Return enables deferred execution of queries.
-   LINQ queries built with deferred operators will fire up only at the iteration step.
-   LINQ queries built with deferred operators will throw exceptions only at the
    iteration step. (ATTENTION: Doesn't look to be the case with .Net v5.0.400)
-   Be careful with closures taken from within `for` and `foreach` loops. The
    results may be unexpected.
-   Be careful altering a list, you can't mindlessly modify the list within a
    `for` or `foreach` loop.
