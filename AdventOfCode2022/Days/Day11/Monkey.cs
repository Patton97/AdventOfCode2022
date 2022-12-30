using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022.Days.Day11;

internal delegate long MonkeyOperation(long oldWorryLevel, Action<string> printDebugInfo);
internal delegate int MonkeyTest(long worryLevel, Action<string> printDebugInfo);

[DebuggerDisplay("{ItemsInspected}")]
internal class Monkey
{
    internal required int ID { get; init; }
    internal required MonkeyOperation Operation { get; init; }
    internal required MonkeyTest Test { get; init; }
    internal ReadOnlyCollection<Item> Items { get; }
    List<Item> items { get; }
    internal int ItemsInspected { get; private set; }
    internal Action<string> PrintDebugInfo { get; init; }

    internal Monkey(IEnumerable<Item> startingItems)
    {
        this.items = startingItems.ToList();
        this.Items = new ReadOnlyCollection<Item>(this.items);
    }

    internal void ReceiveItem(Item item)
    {
        this.items.Add(item);
    }

    internal void TakeTurn(ReadOnlyDictionary<int, Monkey> monkeys)
    {
        this.PrintDebugInfo?.Invoke($"Monkey {this.ID}:");
        for (int i = 0; i < this.Items.Count; )
        {
            Item item = this.Items[i];
            this.Inspect(item);
            item.WorryLevel /= 3;
            this.PrintDebugInfo?.Invoke($"    Monkey gets bored with item. Worry level is divided by 3 to {item.WorryLevel}.");
            this.PassItem(item, monkeys);
            ++this.ItemsInspected;
        }
    }

    void Inspect(Item item)
    {
        this.PrintDebugInfo?.Invoke($"  Monkey inspects an item with a worry level of {item.WorryLevel}.");
        item.WorryLevel = this.Operation.Invoke(item.WorryLevel, this.PrintDebugInfo);
    }

    void PassItem(Item item, ReadOnlyDictionary<int, Monkey> monkeys)
    {
        int toMonkeyID = this.Test.Invoke(item.WorryLevel, this.PrintDebugInfo);
        this.items.Remove(item);
        monkeys[toMonkeyID].ReceiveItem(item);
    }
}
