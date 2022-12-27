using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2022.Days.Day8;

internal record TreeGrid(ReadOnlyCollection<ReadOnlyCollection<Tree>> Rows)
{
    internal static TreeGrid Create(string[] lines)
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
            lines
                .Select(LineToTreeCollection)
                .ToArray()
                .AsReadOnly()
        );
    }

    internal bool IsOnEdgeOfGrid(Coord coord)
    {
        return coord.X == 0
            || coord.X == this.Rows[0].Count - 1
            || coord.Y == 0
            || coord.Y == this.Rows.Count - 1;
    }

    internal IEnumerable<Tree> GetAllTreesVisibleFromOutsideOfGrid()
    {
        foreach (IEnumerable<Tree> treeRow in this.Rows)
        {
            foreach (Tree tree in treeRow)
            {
                if (this.IsTreeVisibleFromOutsideGrid(tree))
                {
                    yield return tree;
                }
            }
        }
    }

    internal IEnumerable<int> GetScenicScoresForAllTrees()
    {
        foreach (IEnumerable<Tree> treeRow in this.Rows)
        {
            foreach (Tree tree in treeRow)
            {
                yield return this.GetScenicScore(tree);
            }
        }
    }

    int GetScenicScore(Tree tree)
    {
        return this.GetVisibilityScores(tree).Product();
    }

    IEnumerable<int> GetVisibilityScores(Tree fromTree)
    {
        return this.GetAllTreesToEachEdgeFrom(fromTree.Coord)
            .Select(treesInOneDirection => this.GetVisibilityScore(fromTree, treesInOneDirection.ToArray()));
    }
    internal int GetVisibilityScore(Tree fromTree, Tree[] treesInOneDirection)
    {
        if (!treesInOneDirection.Any())
        {
            return 0;
        }

        int i = 0;
        bool ShouldStop()
        {
            if (i >= treesInOneDirection.Length)
            {
                return true;
            }
            if (fromTree.Height <= treesInOneDirection[i].Height)
            {
                ++i;
                return true;
            }
            return false;
        }

        while (!ShouldStop())
        {
            ++i;
        }

        return i;
    }

    bool IsTreeVisibleFromOutsideGrid(Tree tree)
    {
        if (this.IsOnEdgeOfGrid(tree.Coord))
        {
            return true;
        }

        return this.GetAllTreesFromEachEdgeTo(tree.Coord)
            .Any(treesInOneDirection => treesInOneDirection.All(tree.IsTreeVisibleWhenBehind));
    }

    internal IEnumerable<IEnumerable<Tree>> GetAllTreesFromEachEdgeTo(Coord toCoord)
    {
        Coord topEdgeCoord = new Coord(toCoord.X, -1);
        Coord bottomEdgeCoord = new Coord(toCoord.X, this.Rows.Count);
        Coord leftEdgeCoord = new Coord(-1, toCoord.Y);
        Coord rightEdgeCoord = new Coord(this.Rows[0].Count, toCoord.Y);
        return Enumerable.Empty<IEnumerable<Coord>>()
            .Append(Coord.GetAllCoordsBetween(topEdgeCoord, toCoord))
            .Append(Coord.GetAllCoordsBetween(rightEdgeCoord, toCoord))
            .Append(Coord.GetAllCoordsBetween(bottomEdgeCoord, toCoord))
            .Append(Coord.GetAllCoordsBetween(leftEdgeCoord, toCoord))
            .Select(this.CoordsToTrees);
    }

    internal IEnumerable<IEnumerable<Tree>> GetAllTreesToEachEdgeFrom(Coord fromCoord)
    {
        Coord topEdgeCoord = new Coord(fromCoord.X, -1);
        Coord bottomEdgeCoord = new Coord(fromCoord.X, this.Rows.Count);
        Coord leftEdgeCoord = new Coord(-1, fromCoord.Y);
        Coord rightEdgeCoord = new Coord(this.Rows[0].Count, fromCoord.Y);
        return Enumerable.Empty<IEnumerable<Coord>>()
            .Append(Coord.GetAllCoordsBetween(fromCoord, topEdgeCoord))
            .Append(Coord.GetAllCoordsBetween(fromCoord, rightEdgeCoord))
            .Append(Coord.GetAllCoordsBetween(fromCoord, bottomEdgeCoord))
            .Append(Coord.GetAllCoordsBetween(fromCoord, leftEdgeCoord))
            .Select(this.CoordsToTrees);
    }

    Tree CoordToTree(Coord coord)
    {
        return this.Rows[coord.Y][coord.X];
    }
    IEnumerable<Tree> CoordsToTrees(IEnumerable<Coord> coords)
    {
        return coords.Select(this.CoordToTree);
    }
}
