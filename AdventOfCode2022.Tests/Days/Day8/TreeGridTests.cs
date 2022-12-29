using AdventOfCode2022.Days.Day8;

namespace AdventOfCode2022.Tests.Days.Day8;

[TestClass]
public class TreeGridTests : DayTests
{
    protected override uint DayNumber => 8;

    #region CanCheckIfCoordIsOnEdgeOfGrid
    readonly record struct CanCheckIfCoordIsOnEdgeOfGridTestCase(string Description, Vector2Int Coord, bool ExpectedIsOnEdgeOfGrid);
    [TestMethod]
    public void CanCheckIfCoordIsOnEdgeOfGrid()
    {
        var treeGrid = TreeGrid.Create(ReadLines(useExample: true));
        void CanCheckIfCoordIsOnEdgeOfGrid(CanCheckIfCoordIsOnEdgeOfGridTestCase testCase)
        {
            bool actualIsOnEdgeOfGrid = treeGrid.IsOnEdgeOfGrid(testCase.Coord);
            Assert.AreEqual(testCase.ExpectedIsOnEdgeOfGrid, actualIsOnEdgeOfGrid, testCase.Description);
        }

        var testCases = new CanCheckIfCoordIsOnEdgeOfGridTestCase[]
        {
            // should pass
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-left corner", new Vector2Int(0,0), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-right corner", new Vector2Int(4,0), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-left corner", new Vector2Int(0,4), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-right corner", new Vector2Int(4,4), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-middle", new Vector2Int(2,0), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-middle", new Vector2Int(2,4), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Left-middle", new Vector2Int(0,2), ExpectedIsOnEdgeOfGrid: true),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Right-middle", new Vector2Int(4,2), ExpectedIsOnEdgeOfGrid: true),
            // should fail
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-left corner inner", new Vector2Int(1,1), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-right corner inner", new Vector2Int(3,1), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-left corner inner", new Vector2Int(1,3), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-right corner inner", new Vector2Int(3,3), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Top-middle inner", new Vector2Int(2,1), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Bottom-middle inner", new Vector2Int(2,3), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Left-middle inner", new Vector2Int(1,2), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Right-middle inner", new Vector2Int(3,2), ExpectedIsOnEdgeOfGrid: false),
            new CanCheckIfCoordIsOnEdgeOfGridTestCase("Middle", new Vector2Int(2,2), ExpectedIsOnEdgeOfGrid: false),
        };
        foreach (CanCheckIfCoordIsOnEdgeOfGridTestCase testCase in testCases)
        {
            CanCheckIfCoordIsOnEdgeOfGrid(testCase);
        }
    }
    #endregion

    #region CanGetAllTreesFromEachEdgeTo
    readonly record struct CanGetAllTreesFromEachEdgeToTestCase(string Description, Vector2Int ToCoord, Tree[][] ExpectedTrees);
    [TestMethod]
    public void CanGetAllTreesFromEachEdgeTo()
    {
        var treeGrid = TreeGrid.Create(ReadLines(useExample: true));
        void CanGetAllTreesFromEachEdgeTo(CanGetAllTreesFromEachEdgeToTestCase testCase)
        {
            Tree[][] actualTrees = treeGrid.GetAllTreesFromEachEdgeTo(testCase.ToCoord)
                .Select(trees => trees.ToArray())
                .ToArray();
            bool condition = true;
            for (int i = 0; i < testCase.ExpectedTrees.Length; ++i)
            {
                condition &= testCase.ExpectedTrees[i].SequenceEqual(actualTrees[i]);
            }
            Assert.IsTrue(condition, testCase.Description);
        }

        var testCases = new CanGetAllTreesFromEachEdgeToTestCase[]
        {
            new CanGetAllTreesFromEachEdgeToTestCase(
                "To centre",
                new Vector2Int(2,2),
                new Tree[][]
                {
                    // from top
                    new Tree[]
                    {
                        new Tree(Height:3, new Vector2Int(2, 0)),
                        new Tree(Height:5, new Vector2Int(2, 1)),
                    },
                    // from right
                    new Tree[]
                    {
                        new Tree(Height:2, new Vector2Int(4, 2)),
                        new Tree(Height:3, new Vector2Int(3, 2)),
                    },
                    // from bottom
                    new Tree[]
                    {
                        new Tree(Height:3, new Vector2Int(2, 4)),
                        new Tree(Height:5, new Vector2Int(2, 3)),
                    },
                    // from left
                    new Tree[]
                    {
                        new Tree(Height:6, new Vector2Int(0, 2)),
                        new Tree(Height:5, new Vector2Int(1, 2)),
                    },
                }
            ),
        };
        foreach (CanGetAllTreesFromEachEdgeToTestCase testCase in testCases)
        {
            CanGetAllTreesFromEachEdgeTo(testCase);
        }
    }
    #endregion

    #region CanGetAllTreesToEachEdgeFrom
    readonly record struct CanGetAllTreesToEachEdgeFromTestCase(string Description, Vector2Int FromCoord, Tree[][] ExpectedTrees);
    [TestMethod]
    public void CanGetAllTreesToEachEdgeFrom()
    {
        var treeGrid = TreeGrid.Create(ReadLines(useExample: true));
        void CanGetAllTreesToEachEdgeFrom(CanGetAllTreesToEachEdgeFromTestCase testCase)
        {
            Tree[][] actualTrees = treeGrid.GetAllTreesToEachEdgeFrom(testCase.FromCoord)
                .Select(trees => trees.ToArray())
                .ToArray();
            bool condition = true;
            for (int i = 0; i < testCase.ExpectedTrees.Length; ++i)
            {
                condition &= testCase.ExpectedTrees[i].SequenceEqual(actualTrees[i]);
            }
            Assert.IsTrue(condition, testCase.Description);
        }

        var testCases = new CanGetAllTreesToEachEdgeFromTestCase[]
        {
            new CanGetAllTreesToEachEdgeFromTestCase(
                "To centre",
                new Vector2Int(2,2),
                new Tree[][]
                {
                    // to top
                    new Tree[]
                    {
                        new Tree(Height:5, new Vector2Int(2, 1)),
                        new Tree(Height:3, new Vector2Int(2, 0)),
                    },
                    // to right
                    new Tree[]
                    {
                        new Tree(Height:3, new Vector2Int(3, 2)),
                        new Tree(Height:2, new Vector2Int(4, 2)),
                    },
                    // to bottom
                    new Tree[]
                    {
                        new Tree(Height:5, new Vector2Int(2, 3)),
                        new Tree(Height:3, new Vector2Int(2, 4)),
                    },
                    // to left
                    new Tree[]
                    {
                        new Tree(Height:5, new Vector2Int(1, 2)),
                        new Tree(Height:6, new Vector2Int(0, 2)),
                    },
                }
            ),
        };
        foreach (CanGetAllTreesToEachEdgeFromTestCase testCase in testCases)
        {
            CanGetAllTreesToEachEdgeFrom(testCase);
        }
    }
    #endregion

    #region CanGetVisibilityScore
    readonly record struct CanGetVisibilityScoreTestCase(string Description, Tree FromTree, Tree[] TreesInOneDirection, int ExpectedVisibilityScore);
    [TestMethod]
    public void CanGetVisibilityScore()
    {
        var treeGrid = TreeGrid.Create(ReadLines(useExample: true));
        void CanGetVisibilityScore(CanGetVisibilityScoreTestCase testCase)
        {
            int actualVisibilityScore = treeGrid.GetVisibilityScore(testCase.FromTree, testCase.TreesInOneDirection);
            Assert.AreEqual(testCase.ExpectedVisibilityScore, actualVisibilityScore, testCase.Description);
        }
        var firstExampleFromTree = new Tree(Height: 5, new Vector2Int(2, 1));
        var secondExampleFromTree = new Tree(Height: 5, new Vector2Int(2, 3));
        var testCases = new CanGetVisibilityScoreTestCase[]
        {
            #region 1st Example
            new CanGetVisibilityScoreTestCase(
                "1st Example looking up",
                firstExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:3, new Vector2Int(2, 0)),
                },
                ExpectedVisibilityScore:1
            ),
            new CanGetVisibilityScoreTestCase(
                "1st Example looking right",
                firstExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:1, new Vector2Int(1, 2)),
                    new Tree(Height:2, new Vector2Int(0, 2)),
                },
                ExpectedVisibilityScore:2
            ),
            new CanGetVisibilityScoreTestCase(
                "1st Example looking down",
                firstExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:3, new Vector2Int(2, 2)),
                    new Tree(Height:5, new Vector2Int(2, 1)),
                    new Tree(Height:3, new Vector2Int(2, 0)),
                },
                ExpectedVisibilityScore:2
            ),
            new CanGetVisibilityScoreTestCase(
                "1st Example looking left",
                firstExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:5, new Vector2Int(1, 2)),
                    new Tree(Height:2, new Vector2Int(0, 2)),
                },
                ExpectedVisibilityScore:1
            ),
            #endregion

            #region 2nd Example
            new CanGetVisibilityScoreTestCase(
                "2nd Example looking up",
                secondExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:3, new Vector2Int(2, 2)),
                    new Tree(Height:5, new Vector2Int(2, 1)),
                    new Tree(Height:3, new Vector2Int(2, 0)),
                },
                ExpectedVisibilityScore:2
            ),
            new CanGetVisibilityScoreTestCase(
                "2nd Example looking right",
                secondExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:4, new Vector2Int(3, 3)),
                    new Tree(Height:9, new Vector2Int(4, 3)),
                },
                ExpectedVisibilityScore:2
            ),
            new CanGetVisibilityScoreTestCase(
                "2nd Example looking down",
                secondExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:3, new Vector2Int(2, 4)),
                },
                ExpectedVisibilityScore:1
            ),
            new CanGetVisibilityScoreTestCase(
                "2nd Example looking left",
                secondExampleFromTree,
                new Tree[]
                {
                    new Tree(Height:3, new Vector2Int(1, 3)),
                    new Tree(Height:3, new Vector2Int(0, 3)),
                },
                ExpectedVisibilityScore:2
            ),
            #endregion
        };
        foreach (CanGetVisibilityScoreTestCase testCase in testCases)
        {
            CanGetVisibilityScore(testCase);
        }
    }
    #endregion
}
