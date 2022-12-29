using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day3;

internal class Day3 : Day
{
    char[] priority { get; } = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public override void SolvePart1()
    {
        int sum = 0;
        foreach (string line in this.ReadLines())
        {
            IEnumerable<char> itemsInCompartment1 = line.Take(line.Length / 2);
            IEnumerable<char> itemsInCompartment2 = line.Skip(line.Length / 2);
            IEnumerable<char> itemsInBothCompartments = itemsInCompartment1
                .Intersect(itemsInCompartment2);
            sum += this.GetSumOfPriorities(itemsInBothCompartments);
        }

        Console.WriteLine($"Sum: {sum}");
    }

    public override void SolvePart2()
    {
        int sum = 0;
        int numElvesInGroup = 3;
        string[] elfInventories = this.ReadLines();
        for (int i = 0; i < elfInventories.Length; i += numElvesInGroup)
        {
            IEnumerable<char> intersectOfItems = elfInventories[i];
            for (int j = 1; j < numElvesInGroup; ++j)
            {
                intersectOfItems = intersectOfItems.Intersect(elfInventories[i + j]);
            }
            char badge = intersectOfItems.Single();

            sum += this.GetPriority(badge);
        }

        Console.WriteLine($"Sum: {sum}");
    }

    int GetSumOfPriorities(IEnumerable<char> items)
    {
        return items.Select(this.GetPriority).Sum();
    }

    int GetPriority(char item)
    {
        return Array.IndexOf(this.priority, item);
    }
}
