using System;
using System.Linq;

namespace AdventOfCode2022.Days.Day4
{
    internal class Day4 : Day, IDay4
    {
        /// <inheritdoc cref="IDay4.SolvePart1"/>
        public override void SolvePart1()
        {
            int numFullyContain = this.LoadAssignmentPairs()
                .Where(this.IsOneFullyContainingOther)
                .Count();
            Console.WriteLine($"Number of pairs where one assignment fully contains the other: {numFullyContain}");
        }

        bool IsOneFullyContainingOther(AssignmentPair pair)
        {
            if (pair.Assignment1.LowerBound <= pair.Assignment2.LowerBound
                && pair.Assignment1.UpperBound >= pair.Assignment2.UpperBound)
            {
                return true;
            }

            if (pair.Assignment2.LowerBound <= pair.Assignment1.LowerBound
                && pair.Assignment2.UpperBound >= pair.Assignment1.UpperBound)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc cref="IDay4.SolvePart2"/>
        public override void SolvePart2()
        {
            int numOverlap = this.LoadAssignmentPairs()
                .Where(this.HasOverlap)
                .Count();
            Console.WriteLine($"Number of pairs where one assignment fully contains the other: {numOverlap}");
        }

        bool HasOverlap(AssignmentPair pair)
        {
            if (pair.Assignment1.LowerBound <= pair.Assignment2.LowerBound
                && pair.Assignment1.UpperBound >= pair.Assignment2.LowerBound)
            {
                return true;
            }

            if (pair.Assignment2.LowerBound <= pair.Assignment1.LowerBound
                && pair.Assignment2.UpperBound >= pair.Assignment1.LowerBound)
            {
                return true;
            }

            return false;
        }

        AssignmentPair[] LoadAssignmentPairs()
        {
            return this.ReadLines()
                .Select(assignmentPairStr => assignmentPairStr.Split(','))
                .Select(assignmentPair => assignmentPair
                    .Select(assignmentStr => assignmentStr.Split('-').Select(int.Parse).ToArray())
                    .Select(assignmentBounds => new Assignment(assignmentBounds[0], assignmentBounds[1]))
                    .ToArray()
                )
                .Select(assignmentBoundsPair => new AssignmentPair(assignmentBoundsPair[0], assignmentBoundsPair[1]))
                .ToArray();
        }
    }
    readonly record struct Assignment(int LowerBound, int UpperBound);
    readonly record struct AssignmentPair(Assignment Assignment1, Assignment Assignment2);
}
