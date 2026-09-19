namespace prog;

public static class CustomQueryExtensionsf
{
    public static List<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        List<T> newlist = new List<T>();
        foreach (var item in source)
        {
            if (predicate(item))
            {
                newlist.Add(item);
            }
        }
        return newlist;
    }
    public static List<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        List<TResult> newlist = new List<TResult>();
        foreach (var item in source)
        {
            newlist.Add(selector.Invoke(item));
        }
        return newlist;
    }
    public static List<T> SortBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

        List<T> newlist = new List<T>();
        foreach (var item in source)
        {
            newlist.Add(item);
        }
        for (int j = 0; j < newlist.Count(); j++)
        {
            for (int i = 0; i < newlist.Count() - 1; i++)
            {
                TKey keyA = keySelector(newlist[i]);
                TKey keyB = keySelector(newlist[i + 1]);


                if (keyA.CompareTo(keyB) > 0)
                {
                    T temp = newlist[i];

                    newlist[i] = newlist[i + 1];

                    newlist[i + 1] = temp;
                }
            }

        }
        return newlist;

    }

    public static List<T> ToFreshList<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        List<T> newList = new List<T>();
        foreach (var item in source)
        {
            newList.Add(item);
        }
        return newList;
    }

    public static bool HasAny<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        foreach (var item in source)
        {
            return true;
        }
        return false;
    }
    public static bool HasAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item)) return true;
        }

        return false;
    }
    public static bool MatchAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (!predicate(item)) return false;
        }
        return true;
    }

    public static int CountWhere<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        int counter = 0;
        foreach (var item in source)
        {
            counter++;
        }
        return counter;
    }
    public static int CountWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        int counter = 0;
        foreach (var item in source)
        {
            if (predicate(item))
                counter++;
        }
        return counter;
    }

    public static T? FindFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate((T)item))
            {
                return item;
            }
        }
        return default;
    }

    public static List<T> SortByDescending<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

        List<T> result = new List<T>();
        foreach (var item in source)
        {
            result.Add(item);
        }
        for (var i = 0; i < result.Count; i++)
        {
            for (var j = 0; j < result.Count -1 ; j++)
            {
                var keyA = keySelector(result[j]);
                var keyB = keySelector(result[j + 1]);
                if (keyA.CompareTo(keyB) < 0)
                {
                    var temp = result[j];
                    result[j] = result[j + 1];
                    result[j + 1] = temp;
                }
            }
        }
        return result;
    }
    public static List<T> TakeFirst<T>(this IEnumerable<T> source, int count)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if(count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        List<T> result = new List<T>();
        if (count == 0) return result;
        foreach (var item in source)
        {
            result.Add(item);
            if (result.Count == count) break; 
        }
        return result;
    }
}