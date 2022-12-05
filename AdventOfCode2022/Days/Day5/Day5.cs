using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days.Day5;

internal class Day5 : Day, IDay5
{
    /// <inheritdoc cref="IDay5.SolvePart1"/>
    public override void SolvePart1()
    {
        string[] lines = this.ReadLines();
        var crateLines = new List<string>();
        while (lines[crateLines.Count].Contains('['))
        {
            crateLines.Add(lines[crateLines.Count]);
        }
        int numberOfCrates = this.ParseNumberOfStacks(lines[crateLines.Count]);
        Stack<Crate>[] stacks = this.ParseStacks(crateLines.ToArray(), numberOfCrates);

        string[] movementOperationLines = lines.Skip(crateLines.Count + 2).ToArray();
        MovementOperation[] movementOperations = this.ParseMovementOperations(movementOperationLines).ToArray();

        this.PerformMovementOperations(ref stacks, movementOperations);

        foreach (Crate topCrate in this.GetCrateAtTopOfEachStack(stacks))
        {
            Console.Write(topCrate.ID);
        }
    }

    int ParseNumberOfStacks(string crateNumberLine)
    {
        char lastNumberChar = crateNumberLine.Where(char.IsNumber).Last();
        return int.Parse(new ReadOnlySpan<char>(lastNumberChar));
    }

    Stack<Crate>[] ParseStacks(string[] crateLines, int numberOfCrates)
    {
        var stacks = new Stack<Crate>[numberOfCrates];
        foreach (string crateLine in crateLines.Reverse())
        {
            for (int i = 1; i < crateLine.Length; i+=4)
            {
                int stackID = (i - 1) / 4;
                if (char.IsWhiteSpace(crateLine[i]) || stacks.Length <= stackID)
                {
                    continue;
                }

                var crate = new Crate(crateLine[i]);
                if (stacks[stackID] == null)
                {
                    stacks[stackID] = new Stack<Crate>();
                }
                stacks[stackID].Push(crate);
            }
        }
        return stacks;
    }

    IEnumerable<MovementOperation> ParseMovementOperations(string[] movementOperationLines)
    {
        return movementOperationLines
            .SelectMany(this.ParseMovementOperations);
    }

    private readonly static Regex movementOperationLineRegex = new Regex(@"(?:move\s)(\d+)(?:\sfrom\s)(\d+)(?:\sto\s)(\d+)", RegexOptions.Compiled);
    IEnumerable<MovementOperation> ParseMovementOperations(string movementOperationLine)
    {
        Match match = movementOperationLineRegex.Match(movementOperationLine);
        int numMoves = int.Parse(match.Groups[1].Value);
        int fromStack = int.Parse(match.Groups[2].Value);
        int toStack = int.Parse(match.Groups[3].Value);
        for (int i = 0; i < numMoves; ++i)
        {
            yield return new MovementOperation(fromStack, toStack);
        }
    }

    void PerformMovementOperations(ref Stack<Crate>[] stacks, MovementOperation[] movementOperations)
    {
        foreach (MovementOperation movementOperation in movementOperations)
        {
            this.PerformMovementOperation(ref stacks, movementOperation);
        }
    }

    void PerformMovementOperation(ref Stack<Crate>[] stacks, MovementOperation movementOperation)
    {
        if (stacks[movementOperation.FromStack - 1].TryPop(out Crate crate))
        {
            stacks[movementOperation.ToStack - 1].Push(crate);
        }
    }

    IEnumerable<Crate> GetCrateAtTopOfEachStack(Stack<Crate>[] stacks)
    {
        foreach (Stack<Crate> stack in stacks)
        {
            if (stack.TryPop(out Crate topCrate))
            {
                yield return topCrate;
            }
        }
    }

    /// <inheritdoc cref="IDay5.SolvePart2"/>
    public override void SolvePart2()
    {
        
    }

    private readonly record struct Crate(char ID);
    private readonly record struct MovementOperation(int FromStack, int ToStack);
}
