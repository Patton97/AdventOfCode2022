using System;
using System.Collections.Generic;
using AdventOfCode2022.Days.Day5.CraneLogic;
using AdventOfCode2022.Days.Day5.DTOs;
using AdventOfCode2022.Days.Day5.Parsers;

namespace AdventOfCode2022.Days.Day5;

internal class Day5 : Day, IDay5
{
    /// <inheritdoc cref="IDay5.SolvePart1"/>
    public override void SolvePart1()
    {
        this.RunCraneSimulation(new CraneLogicPart1());
    }

    /// <inheritdoc cref="IDay5.SolvePart2"/>
    public override void SolvePart2()
    {
        this.RunCraneSimulation(new CraneLogicPart2());
    }

    void RunCraneSimulation(CraneLogicBase craneLogic)
    {
        var inputParser = new Day5InputParser();
        (Stack<Crate>[] stacks, MovementOperation[] movementOperations) = inputParser.Parse(this.ReadLines());

        foreach (MovementOperation movementOperation in movementOperations)
        {
            craneLogic.PerformMovementOperation(ref stacks, movementOperation);
        }

        foreach (Crate topCrate in this.GetCrateAtTopOfEachStack(stacks))
        {
            Console.Write(topCrate.ID);
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
}
