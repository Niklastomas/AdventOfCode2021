namespace day1.extensions;


public static class CollectionExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> soruce)
    {
        return soruce.Select((item, index) => (item, index));
    }
}
