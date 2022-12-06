using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day6;

internal class Day6 : Day, IDay6
{
    /// <inheritdoc cref="IDay6.SolvePart1"/>
    public override void SolvePart1()
    {
        string dataStream = this.ReadLines()[0];
        var potentialMarker = new Queue<char>(dataStream.Take(4));
        int i = potentialMarker.Count;
        for (; i < dataStream.Length - 1; ++i)
        {
            if (this.IsValidMarker(potentialMarker))
            {
                break;
            }
            potentialMarker.Dequeue();
            potentialMarker.Enqueue(dataStream[i]);
        }
        Console.WriteLine($"First marker '{string.Concat(potentialMarker)}' ends at index {i}");
    }

    bool IsValidMarker(IEnumerable<char> potentialMarker)
    {
        return potentialMarker.ToHashSet().Count == potentialMarker.Count();
    }

    /// <inheritdoc cref="IDay6.SolvePart2"/>
    public override void SolvePart2()
    {

    }
}
