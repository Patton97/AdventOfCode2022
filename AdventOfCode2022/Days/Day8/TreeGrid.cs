using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2022.Days.Day8;

internal record TreeGrid(ReadOnlyCollection<ReadOnlyCollection<Tree>> Rows)
{
    bool IsOnEdgeOfGrid(Coord coord)
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

    bool IsTreeVisibleFromOutsideGrid(Tree tree)
    {
        if (this.IsOnEdgeOfGrid(tree.Coord))
        {
            return true;
        }

        return this.GetAllTreesInEachDirectionFrom(tree.Coord)
            .Any(treesInOneDirection => treesInOneDirection.All(tree.IsTreeVisibleWhenBehind));
    }

    IEnumerable<IEnumerable<Tree>> GetAllTreesInEachDirectionFrom(Coord coord)
    {
        return Enumerable.Empty<IEnumerable<Tree>>()
            .Append(this.GetAllTreesToTheLeftOf(coord))
            .Append(this.GetAllTreesToTheRightOf(coord))
            .Append(this.GetAllTreesAbove(coord))
            .Append(this.GetAllTreesBelow(coord));
    }

    IEnumerable<Tree> GetAllTreesToTheLeftOf(Coord coord)
    {
        return this.Rows[coord.Y]
            .Take(coord.X);
    }

    IEnumerable<Tree> GetAllTreesToTheRightOf(Coord coord)
    {
        return this.Rows[coord.Y]
            .Skip(coord.X + 1);
    }

    IEnumerable<Tree> GetAllTreesAbove(Coord coord)
    {
        return this.Rows.Take(coord.Y)
            .Select(treeColumn => treeColumn[coord.X]);
    }

    IEnumerable<Tree> GetAllTreesBelow(Coord coord)
    {
        return this.Rows.Skip(coord.Y + 1)
            .Select(treeColumn => treeColumn[coord.X]);
    }
}
