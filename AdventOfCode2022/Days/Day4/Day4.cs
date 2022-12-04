using System;
using System.Linq;

namespace AdventOfCode2022.Days.Day4
{
    internal class Day4 : Day, IDay4
    {
        /// <inheritdoc cref="IDay4.SolvePart1"/>
        public override void SolvePart1()
        {
            string[] lines = this.ReadLines();
            int fullyContainCounter = 0;
            foreach (string line in lines)
            {
                Assignment[] assignments = line.Split(',')
                    .Select(assignmentStr => assignmentStr.Split('-').Select(int.Parse).ToArray())
                    .Select(assignmentBounds => new Assignment(assignmentBounds[0], assignmentBounds[1]))
                    .ToArray();

                if (this.CheckForFullyContain(assignments[0], assignments[1]))
                {
                    ++fullyContainCounter;
                }
            }
            Console.WriteLine($"Number of pairs where one assignment fully contains the other: {fullyContainCounter}");
        }

        bool CheckForFullyContain(Assignment assignment1, Assignment assignment2)
        {
            if (assignment1.LowerBound <= assignment2.LowerBound
                && assignment1.UpperBound >= assignment2.UpperBound)
            {
                return true;
            }

            if (assignment2.LowerBound <= assignment1.LowerBound
                && assignment2.UpperBound >= assignment1.UpperBound)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc cref="IDay4.SolvePart2"/>
        public override void SolvePart2()
        {
            
        }
    }
    readonly record struct Assignment(int LowerBound, int UpperBound);
}
