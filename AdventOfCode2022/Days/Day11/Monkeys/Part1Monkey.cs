using System.Collections.Generic;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal class Part1Monkey : Monkey
{
    internal Part1Monkey(IEnumerable<Item> startingItems)
        : base(startingItems)
    {

    }

    protected override void GetBored(Item item)
    {
        item.WorryLevel /= 3;
        this.PrintDebugInfo?.Invoke($"    Monkey gets bored with item. Worry level is divided by 3 to {item.WorryLevel}.");
    }
}
