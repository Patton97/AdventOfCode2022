using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day9;

internal class Day9 : Day, IDay9
{
    public override void SolvePart1()
    {
        IEnumerable<Vector2Int> ropeMovements = this.ReadLines()
            .Select(this.LineToRopeMovement);
        var ropeSimulator = new RopeSimulator();
        foreach (Vector2Int ropeMovement in ropeMovements)
        {
            ropeSimulator.PerformMovement(ropeMovement);
        }
        Console.WriteLine($"Tail visited {ropeSimulator.Tail.AllLocations.Count} unique locations.");
    }

    public override void SolvePart2()
    {

    }

    Vector2Int LineToRopeMovement(string line)
    {
        char direction = line[0];
        int amount = int.Parse(string.Concat(line.Skip(2)));

        switch(direction)
        {
            case 'U':
                return new Vector2Int(0, -amount);
            case 'R':
                return new Vector2Int(amount, 0);
            case 'D':
                return new Vector2Int(0, amount);
            case 'L':
                return new Vector2Int(-amount, 0);
            default:
                throw new Exception($"Invalid direction '{direction}'.");
        }
    }
}