namespace AdventOfCode2022.Days.Day11;

internal class Item
{
    internal long WorryLevel { get; set; }
    internal Item(long worryLevel)
    {
        this.WorryLevel = worryLevel;
    }
}