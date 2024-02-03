using System;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal record MonkeyTest(uint Divisor, int ToMonkeyIDIfTrue, int ToMonkeyIDIfFalse)
{
    internal int GetNextMonkeyID(Item item, Action<string> printDebugInfo)
    {
        bool isDivisible = item.WorryLevel % this.Divisor == 0;
        int toMonkeyID = isDivisible
            ? this.ToMonkeyIDIfTrue
            : this.ToMonkeyIDIfFalse;
        printDebugInfo?.Invoke($"    Current worry level is {(isDivisible ? "" : "not ")}divisible by {this.Divisor}.");
        printDebugInfo?.Invoke($"    Item with worry level {item.WorryLevel} is thrown to monkey {toMonkeyID}.");

        return toMonkeyID;
    }
}
