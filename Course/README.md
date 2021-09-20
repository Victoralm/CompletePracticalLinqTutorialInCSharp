# Course

## Classification of LINQ Operators

The LINQ to Objects implementations of the standard query operator methods execute in one of two main ways: immediate or deferred. The query operators that use deferred execution can be additionally divided into two categories: streaming and non-streaming. If you know how the different query operators execute, it may help you understand the results that you get from a given query. This is especially true if the data source is changing or if you are building a query on top of another query. This topic classifies the standard query operators according to their manner of execution.

### Manners of Execution

#### Immediate

Immediate execution means that the data source is read and the operation is performed at the point in the code where the query is declared. All the standard query operators that return a single, non-enumerable result execute immediately.

#### Deferred

Deferred execution means that the operation is not performed at the point in the
code where the query is declared. The operation is performed only when the query
variable is enumerated, for example by using a `Foreach` statement. This means
that the results of executing the query depend on the contents of the data
source when the query is executed rather than when the query is defined. If the
query variable is enumerated multiple times, the results might differ every
time. Almost all the standard query operators whose return type is
`IEnumerable<T>` or `IOrderedEnumerable<TElement>` execute in a deferred manner.

Query operators that use deferred execution can be additionally classified as streaming or non-streaming.

##### Streaming

Streaming operators do not have to read all the source data before they yield elements. At the time of execution, a streaming operator performs its operation on each source element as it is read and yields the element if appropriate. A streaming operator continues to read source elements until a result element can be produced. This means that more than one source element might be read to produce one result element.

##### Non-Streaming

Non-streaming operators must read all the source data before they can yield a result element. Operations such as sorting or grouping fall into this category. At the time of execution, non-streaming query operators read all the source data, put it into a data structure, perform the operation, and yield the resulting elements.

Look at the table of operators: [Read more](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution)
