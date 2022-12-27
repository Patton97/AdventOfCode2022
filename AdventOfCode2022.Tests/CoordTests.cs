using AdventOfCode2022.Days.Day8;

namespace AdventOfCode2022.Tests.Day8;

[TestClass]
public class CoordTests : DayTests
{
    protected override uint DayNumber => 8;

    #region CanGetAllCoordsBetween
    readonly record struct CanGetAllCoordsBetweenTestCase(string Description, Coord FromCoord, Coord ToCoord, Coord[] ExpectedCoordsBetween);

    [TestMethod]
    public void CanGetAllCoordsBetween()
    {
        void CanGetAllCoordsBetween(CanGetAllCoordsBetweenTestCase testCase)
        {
            IEnumerable<Coord> actualCoordsBetween = Coord.GetAllCoordsBetween(testCase.FromCoord, testCase.ToCoord);
            bool condition = testCase.ExpectedCoordsBetween.SequenceEqual(actualCoordsBetween);
            string description = $"Test case '{testCase.Description}' failed.";
            Assert.IsTrue(condition, description);
        }

        var testCases = new CanGetAllCoordsBetweenTestCase[]
        {
            new CanGetAllCoordsBetweenTestCase(
                "Vertical",
                new Coord(0,0),
                new Coord(0,5),
                new Coord[]
                {
                    new Coord(0,1),
                    new Coord(0,2),
                    new Coord(0,3),
                    new Coord(0,4),
                }
            ),
            new CanGetAllCoordsBetweenTestCase(
                "Vertical Reversed",
                new Coord(0,5),
                new Coord(0,0),
                new Coord[]
                {
                    new Coord(0,4),
                    new Coord(0,3),
                    new Coord(0,2),
                    new Coord(0,1),
                }
            ),
            new CanGetAllCoordsBetweenTestCase(
                "Horizontal",
                new Coord(0,0),
                new Coord(5,0),
                new Coord[]
                {
                    new Coord(1,0),
                    new Coord(2,0),
                    new Coord(3,0),
                    new Coord(4,0),
                }
            ),
            new CanGetAllCoordsBetweenTestCase(
                "Horizontal Reversed",
                new Coord(5,0),
                new Coord(0,0),
                new Coord[]
                {
                    new Coord(4,0),
                    new Coord(3,0),
                    new Coord(2,0),
                    new Coord(1,0),
                }
            ),
        };

        foreach (CanGetAllCoordsBetweenTestCase testCase in testCases)
        {
            CanGetAllCoordsBetween(testCase);
        }
    }
    #endregion

}