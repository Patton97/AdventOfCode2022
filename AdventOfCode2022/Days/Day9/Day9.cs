using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day9;

internal class Day9 : Day
{
    /// <inheritdoc cref="IDay9.SolvePart1"/>
    public override void SolvePart1()
    {
        this.RunSimulationForRopeOfLength(numRopeElements: 2);
    }

    /// <inheritdoc cref="IDay9.SolvePart2"/>
    public override void SolvePart2()
    {
        this.RunSimulationForRopeOfLength(numRopeElements: 10);
    }

    void RunSimulationForRopeOfLength(uint numRopeElements)
    {
        IEnumerable<Vector2Int> ropeMovementVectors = this.ReadLines()
            .Select(this.LineToRopeMovementVector);
        var ropeSimulator = new RopeSimulator(numRopeElements);
        foreach (Vector2Int ropeMovementVector in ropeMovementVectors)
        {
            ropeSimulator.MoveHead(ropeMovementVector);
        }
        Console.WriteLine($"Tail visited {ropeSimulator.Tail.AllLocations.Count} unique locations.");
    }

    Vector2Int LineToRopeMovementVector(string line)
    {
        char direction = line[0];
        int amount = int.Parse(string.Concat(line.Skip(2)));

        switch (direction)
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