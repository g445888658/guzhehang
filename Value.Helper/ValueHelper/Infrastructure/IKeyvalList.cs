using System;

namespace ValueHelper.Infrastructure
{
    public interface IKeyvalList<TKey, TValue>
    {
        Int32 Count { get; }
        TValue this[String key] { get; set; }
        Keyval<TKey, TValue> this[Int32 index] { get; set; }
        void Add(TKey key, TValue value);
        Boolean RemoveAt(Int32 index);
        Boolean Remove(String key);
    }
}
