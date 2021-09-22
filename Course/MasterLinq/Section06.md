Section 06 - Conversions

-   `OfType` converts only those types which can actually be converted into a
    requested type. `Cast` throws an InvalidCastException if it stumbles upon an
    element which can't be converted.
-   `ToList` and `ToArray` are straightforward and their aims is clear. `ToList`
    converts a collection into a list and `ToArray` converts a collection into an
    array.
-   `ToDictionary` allows to convert a collection into a dictionary but you have
    to provide a unique key.
-   `ToLookup` it's a cross between an IGrouping and a dictionary. It lets you
    group items together by the key, but then access them via that key in an
    efficient manner.
-   `AsEnumerable` is usually used for converting to an IEnumerable from
    IQueryable and `AsQueryable` to convert to an IQueriable from an IEnumerable.
-   Generics can't "see" conversions operators: boxing, reference and nullable
    conversions. If you need to cast, say, IEnumerable<int> to IEnumerable<double>,
    try to cast within a Select expression explicitly
