using System;

namespace AdventOfCode2022.Days.Day2;

class Day2 : Day
{
    /// <inheritdoc cref="IDay2.SolvePart1"/>
    public override void SolvePart1() => this.SolvePart(new Day2GameLogicPart1());
    /// <inheritdoc cref="IDay2.SolvePart2"/>
    public override void SolvePart2() => this.SolvePart(new Day2GameLogicPart2());

    void SolvePart(Day2GameLogic logic)
    {
        int score = logic.GetTotalScore(this.ReadLines());
        Console.WriteLine($"Score: {score}");
    }
}
