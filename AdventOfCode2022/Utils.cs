using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdventOfCode2022;

internal static class Utils
{
    internal static void WaitForKeyPress()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(false);
        }

        Console.ReadKey();
    }

    internal static int Product(this IEnumerable<int> ints)
    {
        return ints.Aggregate(1, (x, y) => x * y);
    }

    internal static ulong Product(this IEnumerable<ulong> ints)
    {
        return ints.Aggregate((ulong)1, (x, y) => x * y);
    }

    internal static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> kvps)
    {
        return kvps.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    internal static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> kvps)
    {
        return new ReadOnlyDictionary<TKey, TValue>(kvps.ToDictionary());
    }

    internal static IEnumerable<int> GetAllIntsBetween(int fromInt, int toInt)
    {
        if (fromInt == toInt)
        {
            return Enumerable.Empty<int>();
        }
        int lowestInt = fromInt < toInt
            ? fromInt
            : toInt;

        int start = lowestInt + 1;
        int count = Math.Abs(fromInt - toInt) - 1;
        IEnumerable<int> betweenInts = Enumerable.Range(start, count);
        if (lowestInt == toInt)
        {
            betweenInts = betweenInts.Reverse();
        }
        return betweenInts;
    }
}
