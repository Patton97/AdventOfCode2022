using System;
using System.Collections.ObjectModel;

namespace AdventOfCode2022.Days.Day11;

internal class Day11 : Day
{
    internal MonkeyParser Parser { get; } = new MonkeyParser();

    public override void SolvePart1()
    {
        const int NUM_ROUNDS = 20;
        ReadOnlyCollection<Monkey> monkeys = this.Parser.Parse(this.ReadLines());
        var monkeyManager = new MonkeyManager(monkeys);
        monkeyManager.ProcessRounds(NUM_ROUNDS);
        int monkeyBusiness = monkeyManager.GetMonkeyBusiness();
        Console.WriteLine($"Monkey business after {NUM_ROUNDS} rounds is: {monkeyBusiness}");
    }

    public override void SolvePart2()
    {
        
    }
}
