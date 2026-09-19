# Custom LINQ & Pipeline Extensions (.NET C#)

A custom C# implementation of LINQ-like query methods built using Extension Methods, Generics, Delegates (`Func<T, bool>`, `Func<TSource, TResult>`), and Generic Constraints (`IComparable<TKey>`).

This repository demonstrates building a custom fluent data engine from scratch to process, filter, transform, and aggregate standard collections.

---

## 🛠️ Implemented Extension Methods

All query methods are implemented in `CustomQueryExtensions.cs` as static extension methods on `IEnumerable<T>`:

| Method | Signature | Description |
| :--- | :--- | :--- |
| **`Filter`** | `IEnumerable<T> Filter<T>(this IEnumerable<T>, Func<T, bool>)` | Filters elements based on a boolean predicate. |
| **`Transform`** | `IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource>, Func<TSource, TResult>)` | Projects/maps each element into a new form. |
| **`SortBy`** | `List<T> SortBy<T, TKey>(this IEnumerable<T>, Func<T, TKey>)` | Sorts collection ascending using Bubble Sort algorithm and `IComparable<TKey>`. |
| **`SortByDescending`** | `List<T> SortByDescending<T, TKey>(this IEnumerable<T>, Func<T, TKey>)` | Sorts collection descending using Bubble Sort algorithm. |
| **`ToFreshList`** | `List<T> ToFreshList<T>(this IEnumerable<T>)` | Materializes the query sequence into a new `List<T>`. |
| **`HasAny`** | `bool HasAny<T>(this IEnumerable<T>, Func<T, bool>?)` | Determines whether any element exists or satisfies a condition. |
| **`MatchAll`** | `bool MatchAll<T>(this IEnumerable<T>, Func<T, bool>)` | Determines whether all elements satisfy a specified condition. |
| **`CountWhere`** | `int CountWhere<T>(this IEnumerable<T>, Func<T, bool>?)` | Returns the number of elements that satisfy a condition. |
| **`FindFirst`** | `T? FindFirst<T>(this IEnumerable<T>, Func<T, bool>)` | Returns the first element that matches the predicate, or `default(T?)`. |
| **`TakeFirst`** | `List<T> TakeFirst<T>(this IEnumerable<T>, int count)` | Yields up to `count` elements from the sequence safely. |

---

## ⚙️ Data Model

`Employee.cs` encapsulates basic employee payload and a computed read-only property `NetSalary`:

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    
    // Computed Property
    public decimal NetSalary => BasicSalary + Bonus - Deductions;

    public override string ToString()
    {
        return $"[ID: {Id}] {Name,-12} | Basic: {BasicSalary,6:C0} | Net: {NetSalary,6:C0}";
    }
}
```
Fluent Pipeline Usage
The core execution flow in Program.cs chains multiple extension methods into a single fluent processing pipeline:
```csharp
// 1. Initialize dataset
List<Employee> staff = GetEmployees();

// 2. Execute Method Chaining Pipeline
var result = staff
    .Filter(e => e.NetSalary >= 3500)
    .SortBy(e => e.NetSalary)
    .Transform(e => $"Employee: {e.Name} | Net: {e.NetSalary:C0}")
    .ToFreshList();

// 3. Print Results
foreach (var item in result)
{
    Console.WriteLine(item);
}
```
Additional Operations
```csharp
// Quantifiers & Aggregates
bool hasBonus = staff.HasAny(e => e.Bonus > 1000);
bool validBasic = staff.MatchAll(e => e.BasicSalary >= 2000);
int zeroDeductions = staff.CountWhere(e => e.Deductions == 0);

// Single Element Retrieval
var firstM = staff.FindFirst(e => e.Name.StartsWith("M"));

// Sorting & Partitioning
var sortedDesc = staff.SortByDescending(e => e.NetSalary);
var topFive = staff.TakeFirst(5);
```
Tech Stack
Language: C# (.NET Core / Console App)

Concepts: Generics, Extension Methods, Lambda Expressions, Delegates (Func<T>), System.IComparable.
