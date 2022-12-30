using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Days.Day11;

internal class MonkeyParser
{
    internal ReadOnlyCollection<Monkey> Parse(string[] lines)
    {
        List<Monkey> monkeys = new List<Monkey>();
        const int MONKEY_LINES_LENGTH = 6;
        for (int i = 0; i < lines.Length; i += MONKEY_LINES_LENGTH+1)
        {
            string[] singleMonkeyLines = new string[MONKEY_LINES_LENGTH];
            for (int j = 0; j < MONKEY_LINES_LENGTH; ++j)
            {
                singleMonkeyLines[j] = lines[i+j];
            }
            monkeys.Add(this.ParseSingle(singleMonkeyLines));
        }
        return new ReadOnlyCollection<Monkey>(monkeys);
    }

    private Monkey ParseSingle(string[] lines)
    {
        return new Monkey(this.ParseStartingItems(lines[1]))
        {
            ID = this.ParseMonkeyID(lines[0]),
            Operation = this.ParseMonkeyOperation(lines[2]),
            Test = this.ParseMonkeyTest(lines.Skip(3).ToArray()),
            //PrintDebugInfo = Console.WriteLine,
        };
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
            .Select(int.Parse)
            .Select(worryLevel => new Item(worryLevel));
    }

    private MonkeyOperation ParseMonkeyOperation(string line)
    {
        const int OPERATOR_CHAR_INDEX = 23;
        const int DELTA_WORRY_LEVEL_START_INDEX = OPERATOR_CHAR_INDEX + 2;
        char operatorChar = line[OPERATOR_CHAR_INDEX];
        string worryLevelModifierAmountAsString = string.Concat(line.Skip(DELTA_WORRY_LEVEL_START_INDEX));

        return (long oldWorryLevel, Action<string> printDebugInfo) =>
        {
            long worryLevelModifierAmount = worryLevelModifierAmountAsString == "old"
                ? oldWorryLevel
                : long.Parse(worryLevelModifierAmountAsString);
            switch (operatorChar)
            {
                case '+':
                    printDebugInfo?.Invoke($"    Worry level increases by {(worryLevelModifierAmountAsString == "old" ? "itself" : worryLevelModifierAmount)} to {oldWorryLevel + worryLevelModifierAmount}.");
                    return oldWorryLevel + worryLevelModifierAmount;
                case '*':
                    printDebugInfo?.Invoke($"    Worry level is multiplied by {(worryLevelModifierAmountAsString == "old" ? "itself" : worryLevelModifierAmount)} to {oldWorryLevel * worryLevelModifierAmount}.");
                    return oldWorryLevel * worryLevelModifierAmount;
                default:
                    throw new InvalidDataException($"Could not determine operator from char '{operatorChar}'");
            }
        };
    }

    private MonkeyTest ParseMonkeyTest(string[] lines)
    {
        int divisor = int.Parse(lines[0].Split(" ").Last());
        int toMonkeyIdIfTrue = int.Parse(lines[1].Split(" ").Last());
        int toMonkeyIdIfFalse = int.Parse(lines[2].Split(" ").Last());
        return (long worryLevel, Action<string> printDebugInfo) =>
        {
            bool isDivisible = worryLevel % divisor == 0;
            int toMonkeyID = isDivisible
                ? toMonkeyIdIfTrue
                : toMonkeyIdIfFalse;
            printDebugInfo?.Invoke($"    Current worry level is {(isDivisible ? "" :"not ")}divisible by {divisor}.");
            printDebugInfo?.Invoke($"    Item with worry level {worryLevel} is thrown to monkey {toMonkeyID}.");

            return toMonkeyID;
        };
    }
}