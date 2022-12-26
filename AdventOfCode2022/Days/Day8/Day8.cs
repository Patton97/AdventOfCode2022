using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022.Days.Day8;

internal class Day8 : Day, IDay8
{
    public override void SolvePart1()
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

        var treeGrid = new TreeGrid(
            this.ReadLines()
                .Select(LineToTreeCollection)
                .ToArray()
                .AsReadOnly()
        );

        ReadOnlyCollection<Tree> visibleTrees = this.FindVisible(treeGrid)
            .ToArray()
            .AsReadOnly();
        Console.WriteLine($"Visible trees: {visibleTrees.Count}");
    }

    bool IsOuterTree(TreeGrid treeGrid, Tree tree)
    {
        return tree.Coord.X == 0
            || tree.Coord.X == treeGrid.Rows[0].Count - 1
            || tree.Coord.Y == 0
            || tree.Coord.Y == treeGrid.Rows.Count - 1;
    }

    IEnumerable<Tree> FindVisible(TreeGrid treeGrid)
    {
        foreach (IEnumerable<Tree> treeRow in treeGrid.Rows)
        {
            foreach (Tree tree in treeRow)
            {
                if (this.IsVisible(treeGrid, tree))
                {
                    yield return tree;
                }
            }
        }
    }

    bool IsVisible(TreeGrid treeGrid, Tree candidateTree)
    {
        if (this.IsOuterTree(treeGrid, candidateTree))
        {
            return true;
        }

        bool IsCandidateVisibleWhenBehind(Tree tree)
        {
            return tree.Height < candidateTree.Height;
        }

        IEnumerable<Tree> treesToTheLeft = treeGrid.Rows[candidateTree.Coord.Y]
            .Take(candidateTree.Coord.X);
        bool isVisibleFromLeft = treesToTheLeft
            .All(IsCandidateVisibleWhenBehind);
        if (isVisibleFromLeft)
        {
            return true;
        }

        IEnumerable<Tree> treesToTheRight = treeGrid.Rows[candidateTree.Coord.Y]
            .Skip(candidateTree.Coord.X + 1);
        bool isVisibleFromRight = treesToTheRight
            .All(IsCandidateVisibleWhenBehind);
        if (isVisibleFromRight)
        {
            return true;
        }

        IEnumerable<Tree> treesAbove = treeGrid.Rows.Take(candidateTree.Coord.Y)
            .Select(treeColumn => treeColumn[candidateTree.Coord.X]);
        bool isVisibleFromAbove = treesAbove
            .All(IsCandidateVisibleWhenBehind);
        if (isVisibleFromAbove)
        {
            return true;
        }

        IEnumerable<Tree> treesBelow = treeGrid.Rows.Skip(candidateTree.Coord.Y + 1)
            .Select(treeColumn => treeColumn[candidateTree.Coord.X]);
        bool isVisibleFromBelow = treesBelow
            .All(IsCandidateVisibleWhenBehind);
        if (isVisibleFromBelow)
        {
            return true;
        }

        return false;
    }

    public override void SolvePart2()
    {

    }

    private readonly record struct TreeGrid(ReadOnlyCollection<ReadOnlyCollection<Tree>> Rows);
    [DebuggerDisplay("({Coord.X}, {Coord.Y}) | {Height}")]
    private readonly record struct Tree(int Height, Coord Coord);
    [DebuggerDisplay("({X}, {Y})")]
    private record struct Coord(int X, int Y);
}
