using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdventOfCode2022.Days.Day8;

internal class Day8 : Day, IDay8
{
    public override void SolvePart1()
    {
        IEnumerable<Tree> visibleTrees = this.LoadTreeGrid()
            .GetAllTreesVisibleFromOutsideOfGrid();
        Console.WriteLine($"Visible trees: {visibleTrees.Count()}");
    }

    public override void SolvePart2()
    {
        int highestScenicScore = this.LoadTreeGrid()
            .GetScenicScoresForAllTrees()
            .OrderByDescending(x=>x)
            .FirstOrDefault();
        Console.WriteLine($"Highest scenic score: {highestScenicScore}");
    }

    TreeGrid LoadTreeGrid()
    {
        return TreeGrid.Create(this.ReadLines());
    }
}
