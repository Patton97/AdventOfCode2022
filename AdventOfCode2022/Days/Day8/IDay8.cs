using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode2022.Days.Day8;

internal interface IDay8 : IDay
{
    /// <summary>
    /// The expedition comes across a peculiar patch of tall trees
    /// all planted carefully in a grid. The Elves explain that a
    /// previous expedition planted these trees as a reforestation
    /// effort. Now, they're curious if this would be a good location
    /// for a tree house.
    /// <br/>
    /// First, determine whether there is enough tree cover here to
    /// keep a tree house hidden.To do this, you need to count the number
    /// of trees that are visible from outside the grid when looking directly
    /// along a row or column.
    /// <br/>
    /// The Elves have already launched a quadcopter to generate a map with
    /// the height of each tree (your puzzle input). For example:
    /// <br/>
    /// <code>
    /// 30373
    /// 25512
    /// 65332
    /// 33549
    /// 35390
    /// </code>
    /// Each tree is represented as a single digit whose value is its height,
    /// where 0 is the shortest and 9 is the tallest.
    /// <br/>
    /// A tree is visible if all of the other trees between it and an edge of
    /// the grid are shorter than it.Only consider trees in the same row or
    /// column; that is, only look up, down, left, or right from any given tree.
    /// <br/>
    /// All of the trees around the edge of the grid are visible - since they are
    /// already on the edge, there are no trees to block the view. In this example,
    /// that only leaves the interior nine trees to consider:
    /// <list type="bullet">
    ///     <item>
    ///         The top-left 5 is visible from the left and top. (It isn't visible
    ///         from the right or bottom since other trees of height 5 are in the way.)
    ///     </item>
    ///     <item>
    ///         The top-middle 5 is visible from the top and right.
    ///     </item>
    ///     <item>
    ///         The top-right 1 is not visible from any direction; for it to be visible,
    ///         there would need to only be trees of height 0 between it and an edge.
    ///     </item>
    ///     <item>
    ///         The left-middle 5 is visible, but only from the right.
    ///     </item>
    ///     <item>
    ///         The center 3 is not visible from any direction; for it to be visible,
    ///         there would need to be only trees of at most height 2 between it and an edge.
    ///     </item>
    ///     <item>
    ///         The right-middle 3 is visible from the right.
    ///     </item>
    ///     <item>
    ///         In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
    ///     </item>
    /// </list>
    /// With 16 trees visible on the edge and another 5 visible in the interior,
    /// a total of 21 trees are visible in this arrangement.
    /// <br/>
    /// Consider your map; how many trees are visible from outside the grid?
    /// </summary>
    void SolvePart1();

}
