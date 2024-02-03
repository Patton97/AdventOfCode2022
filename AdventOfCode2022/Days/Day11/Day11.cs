using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2022.Days.Day11.Monkeys;

namespace AdventOfCode2022.Days.Day11;

internal class Day11 : Day
{
    internal MonkeyParser Parser { get; } = new MonkeyParser();

    public override void SolvePart1()
    {
        this.Solve<Part1Monkey>(20);
    }

    public override void SolvePart2()
    {
        this.Solve<Part2Monkey>(1000);
    }

    void Solve<TMonkey>(in int numRounds)
        where TMonkey : Monkey
    {
        ReadOnlyCollection<Monkey> monkeys = this.Parser.Parse<TMonkey>(this.ReadLines(true));
        int lcm = monkeys.Select(m => m.Operation.ModifierAmount)
            .Where(x => x!= null)
            .Select(x => (int)x)
            .Aggregate(1, (a, b) => a * b);
        var monkeyManager = new MonkeyManager(monkeys);
        monkeyManager.ProcessRounds(numRounds);
        ulong monkeyBusiness = monkeyManager.GetMonkeyBusiness();
        Console.WriteLine($"Monkey business after {numRounds} rounds is: {monkeyBusiness}");
    }
}
