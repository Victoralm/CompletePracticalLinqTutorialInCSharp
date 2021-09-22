# Section 05 - Joining, Grouping and Aggregating

-   `Join` method which is very similar to the Join operator in SQL. If you have a
    key for joining collections, then use it.
-   `GroupBy` accepts a property by which you want to group two collections.
    `GroupBy` returns an IEnumerable of IGrouping. Calling `GroupBy`, you'll end
    up with a one-to-many data relationship.
-   `GroupJoin` just simplifies grouping and joining which can be done in one shot.
-   `Zip` is kinda like `Join` without relying on a key for joining. Calling `Zip`,
    you decide which data to include into a newly created joined collection.
-   `Min`, `Max`, allow to provide a predicate for searching specific minimums and
    maximums. `Sum` and `Average` not surprisingly calculate sum and average.
