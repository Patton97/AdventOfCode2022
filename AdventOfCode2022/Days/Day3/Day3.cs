using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days.Day3;

internal class Day3 : Day, IDay3
{
    char[] priority { get; } = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public override void SolvePart1()
    {
        string[] lines = this.ReadLines();
        int sum = 0;
        foreach (string line in lines)
        {
            IEnumerable<char> itemsInCompartment1 = line.Take(line.Length / 2);
            IEnumerable<char> itemsInCompartment2 = line.Skip(line.Length / 2);
            IEnumerable<char> itemsInBothCompartments = itemsInCompartment1
                .Intersect(itemsInCompartment2);
            sum += itemsInBothCompartments
                .Select(item => Array.IndexOf(this.priority, item))
                .Sum();
        }

        Console.WriteLine($"Sum: {sum}");
    }

    public override void SolvePart2()
    {

    }
}
