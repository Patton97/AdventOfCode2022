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
            return new Tree(int.Parse(new ReadOnlySpan<char>(@char)), new Vector2Int(charIndex, lineIndex));
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

    internal bool IsOnEdgeOfGrid(Vector2Int coord)
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

    internal IEnumerable<IEnumerable<Tree>> GetAllTreesFromEachEdgeTo(Vector2Int toCoord)
    {
        Vector2Int topEdgeCoord = new Vector2Int(toCoord.X, -1);
        Vector2Int bottomEdgeCoord = new Vector2Int(toCoord.X, this.Rows.Count);
        Vector2Int leftEdgeCoord = new Vector2Int(-1, toCoord.Y);
        Vector2Int rightEdgeCoord = new Vector2Int(this.Rows[0].Count, toCoord.Y);
        return Enumerable.Empty<IEnumerable<Vector2Int>>()
            .Append(Vector2Int.GetAllVectorsBetween(topEdgeCoord, toCoord))
            .Append(Vector2Int.GetAllVectorsBetween(rightEdgeCoord, toCoord))
            .Append(Vector2Int.GetAllVectorsBetween(bottomEdgeCoord, toCoord))
            .Append(Vector2Int.GetAllVectorsBetween(leftEdgeCoord, toCoord))
            .Select(this.CoordsToTrees);
    }

    internal IEnumerable<IEnumerable<Tree>> GetAllTreesToEachEdgeFrom(Vector2Int fromCoord)
    {
        Vector2Int topEdgeCoord = new Vector2Int(fromCoord.X, -1);
        Vector2Int bottomEdgeCoord = new Vector2Int(fromCoord.X, this.Rows.Count);
        Vector2Int leftEdgeCoord = new Vector2Int(-1, fromCoord.Y);
        Vector2Int rightEdgeCoord = new Vector2Int(this.Rows[0].Count, fromCoord.Y);
        return Enumerable.Empty<IEnumerable<Vector2Int>>()
            .Append(Vector2Int.GetAllVectorsBetween(fromCoord, topEdgeCoord))
            .Append(Vector2Int.GetAllVectorsBetween(fromCoord, rightEdgeCoord))
            .Append(Vector2Int.GetAllVectorsBetween(fromCoord, bottomEdgeCoord))
            .Append(Vector2Int.GetAllVectorsBetween(fromCoord, leftEdgeCoord))
            .Select(this.CoordsToTrees);
    }

    Tree CoordToTree(Vector2Int coord)
    {
        return this.Rows[coord.Y][coord.X];
    }
    IEnumerable<Tree> CoordsToTrees(IEnumerable<Vector2Int> coords)
    {
        return coords.Select(this.CoordToTree);
    }
}
