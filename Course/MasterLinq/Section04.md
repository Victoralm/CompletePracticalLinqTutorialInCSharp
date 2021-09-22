# Section 04 - Filtering, Ordering and Projecting

-   `Select` projects a sequence of data of one type to project into another
    sequence of data of another type.
-   Order by ascending and descending calling `OrderBy` or `OrderByDescending`.
    Use `ThenBy` operator if more than one property are involved.
-   `First`, `Last` and `Single` - search for particular elements passing a
    predicate. `Single` is more strict (allows having only one item which
    satisfies the predicate).
-   `FirstOrDefault`, `LastOrDefault` and `SingleOrDefault` allow to avoid
    exceptions being thrown, use it if you're OK with having null as a result og
    your query.
-   `TakeWhile` and `SkipWhile` are rarely used filtering operators.
-   `TakeWhile` takes all the items until a predicate turns false for the first
    time (this is a point of attention), it won't continue to iterate over a
    collection after that.
-   `SkipWhile` skips all the items until a predicate turns false, all the
    remaining items will be added to the resulting collection.
-   `Any` and `Contains` allow to know if a collection contains a specific item.
    `Any` accepts a predicate, `Contains` accepts an instance of an item. The
    `All` operator returns true only if all the items satisfy the predicate.
-   `SequenceEqual` will compare sequences by references by default. Need to
    compare collections by elements? -> Provide an implementation of the
    `IEqualityComparer` interface.
-   `SelectMany` is beneficial when regular `Select` returns a collection of
    collections. `SelectMany` flattens the result of such a query joining the elements.
