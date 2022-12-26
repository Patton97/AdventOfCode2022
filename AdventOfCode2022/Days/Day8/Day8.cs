using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace AdventOfCode2022.Days.Day8;

internal class Day8 : Day, IDay8
{
    public override void SolvePart1()
    {
        TreeGrid treeGrid = this.LoadTreeGrid();
        IEnumerable<Tree> visibleTrees = treeGrid
            .GetAllTreesVisibleFromOutsideOfGrid();
        Console.WriteLine($"Visible trees: {visibleTrees.Count()}");
    }

    public override void SolvePart2()
    {

    }

    TreeGrid LoadTreeGrid()
    {
        Tree CharToTree(char @char, int charIndex, int lineIndex)
        {
            return new Tree(int.Parse(new ReadOnlySpan<char>(@char)), new Coord(charIndex, lineIndex));
        }

        ReadOnlyCollection<Tree> LineToTreeCollection(string line, int lineIndex)
        {
            return line
                .Select((@char, charIndex) => CharToTree(@char, charIndex, lineIndex))
                .ToArray()
                .AsReadOnly();
        }

        return new TreeGrid(
            this.ReadLines()
                .Select(LineToTreeCollection)
                .ToArray()
                .AsReadOnly()
        );
    }
}
