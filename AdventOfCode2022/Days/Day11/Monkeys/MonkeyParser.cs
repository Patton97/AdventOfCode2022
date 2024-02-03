using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal class MonkeyParser
{
    internal ReadOnlyCollection<Monkey> Parse<TMonkey>(string[] lines)
        where TMonkey : Monkey
    {
        var monkeys = new List<Monkey>();
        const int MONKEY_LINES_LENGTH = 6;
        for (int i = 0; i < lines.Length; i += MONKEY_LINES_LENGTH + 1)
        {
            string[] singleMonkeyLines = new string[MONKEY_LINES_LENGTH];
            for (int j = 0; j < MONKEY_LINES_LENGTH; ++j)
            {
                singleMonkeyLines[j] = lines[i + j];
            }
            monkeys.Add(this.ParseSingle<TMonkey>(singleMonkeyLines));
        }
        return new ReadOnlyCollection<Monkey>(monkeys);
    }

    private Monkey ParseSingle<TMonkey>(string[] lines)
        where TMonkey : Monkey
    {
        // generics don't allow parameterised constructors
        // but i cba to set up full on factories for this
        switch (typeof(TMonkey).Name)
        {
            case nameof(Part1Monkey):
                return new Part1Monkey(this.ParseStartingItems(lines[1]))
                {
                    ID = this.ParseMonkeyID(lines[0]),
                    Operation = this.ParseMonkeyOperation(lines[2]),
                    Test = this.ParseMonkeyTest(lines.Skip(3).ToArray()),
                    //PrintDebugInfo = Console.WriteLine,
                } as TMonkey;
            case nameof(Part2Monkey):
                return new Part2Monkey(this.ParseStartingItems(lines[1]))
                {
                    ID = this.ParseMonkeyID(lines[0]),
                    Operation = this.ParseMonkeyOperation(lines[2]),
                    Test = this.ParseMonkeyTest(lines.Skip(3).ToArray()),
                    //PrintDebugInfo = Console.WriteLine,
                } as TMonkey;
            default:
                throw new InvalidOperationException($"No idea what type of monkey that is m8.");
        }
    }

    private int ParseMonkeyID(string line)
    {
        string monkeyIDAsString = string.Concat(line.Split(" ")[1].SkipLast(1));
        return int.Parse(monkeyIDAsString);
    }

    private IEnumerable<Item> ParseStartingItems(string line)
    {
        string itemWorryLevelsAsString = string.Concat(line.Trim().Split(" ").Skip(2));
        return itemWorryLevelsAsString.Split(",")
            .Select(ulong.Parse)
            .Select(worryLevel => new Item(worryLevel));
    }

    private MonkeyOperation ParseMonkeyOperation(string line)
    {
        const int OPERATOR_CHAR_INDEX = 23;
        const int DELTA_WORRY_LEVEL_START_INDEX = OPERATOR_CHAR_INDEX + 2;
        char operatorChar = line[OPERATOR_CHAR_INDEX];
        string worryLevelModifierAmountAsString = string.Concat(line.Skip(DELTA_WORRY_LEVEL_START_INDEX));

        uint? worryLevelModifierAmount = worryLevelModifierAmountAsString == "old"
                ? null
                : uint.Parse(worryLevelModifierAmountAsString);

        return new MonkeyOperation(worryLevelModifierAmount, operatorChar);
    }

    private MonkeyTest ParseMonkeyTest(string[] lines)
    {
        uint divisor = uint.Parse(lines[0].Split(" ").Last());
        int toMonkeyIdIfTrue = int.Parse(lines[1].Split(" ").Last());
        int toMonkeyIdIfFalse = int.Parse(lines[2].Split(" ").Last());
        return new MonkeyTest(divisor, toMonkeyIdIfTrue, toMonkeyIdIfFalse);
    }
}