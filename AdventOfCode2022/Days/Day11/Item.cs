namespace AdventOfCode2022.Days.Day11;

internal class Item
{
    internal ulong WorryLevel { get; set; }
    internal Item(ulong worryLevel)
    {
        this.WorryLevel = worryLevel;
    }
}