using System.Collections.Generic;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal class Part2Monkey : Monkey
{
    internal Part2Monkey(IEnumerable<Item> startingItems)
        : base(startingItems)
    {

    }

    protected override void GetBored(Item item)
    {
        this.PrintDebugInfo?.Invoke($"    Monkey gets bored with item. Nothing happens to worry level in Part2.");
    }
}
