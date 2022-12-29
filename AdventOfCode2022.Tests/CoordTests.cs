using AdventOfCode2022.Tests.Days.Day8;

namespace AdventOfCode2022.Tests;

[TestClass]
public class Vector2IntTests : DayTests
{
    protected override uint DayNumber => 8;

    #region CanGetAllVectorsBetween
    readonly record struct CanGetAllVectorsBetweenTestCase(string Description, Vector2Int FromVector, Vector2Int ToVector, Vector2Int[] ExpectedVectorsBetween);

    [TestMethod]
    public void CanGetAllVectorsBetween()
    {
        void CanGetAllVectorsBetween(CanGetAllVectorsBetweenTestCase testCase)
        {
            IEnumerable<Vector2Int> actualVectorsBetween = Vector2Int.GetAllVectorsBetween(testCase.FromVector, testCase.ToVector);
            bool condition = testCase.ExpectedVectorsBetween.SequenceEqual(actualVectorsBetween);
            string description = $"Test case '{testCase.Description}' failed.";
            Assert.IsTrue(condition, description);
        }

        var testCases = new CanGetAllVectorsBetweenTestCase[]
        {
            new CanGetAllVectorsBetweenTestCase(
                "Vertical",
                new Vector2Int(0,0),
                new Vector2Int(0,5),
                new Vector2Int[]
                {
                    new Vector2Int(0,1),
                    new Vector2Int(0,2),
                    new Vector2Int(0,3),
                    new Vector2Int(0,4),
                }
            ),
            new CanGetAllVectorsBetweenTestCase(
                "Vertical Reversed",
                new Vector2Int(0,5),
                new Vector2Int(0,0),
                new Vector2Int[]
                {
                    new Vector2Int(0,4),
                    new Vector2Int(0,3),
                    new Vector2Int(0,2),
                    new Vector2Int(0,1),
                }
            ),
            new CanGetAllVectorsBetweenTestCase(
                "Horizontal",
                new Vector2Int(0,0),
                new Vector2Int(5,0),
                new Vector2Int[]
                {
                    new Vector2Int(1,0),
                    new Vector2Int(2,0),
                    new Vector2Int(3,0),
                    new Vector2Int(4,0),
                }
            ),
            new CanGetAllVectorsBetweenTestCase(
                "Horizontal Reversed",
                new Vector2Int(5,0),
                new Vector2Int(0,0),
                new Vector2Int[]
                {
                    new Vector2Int(4,0),
                    new Vector2Int(3,0),
                    new Vector2Int(2,0),
                    new Vector2Int(1,0),
                }
            ),
        };

        foreach (CanGetAllVectorsBetweenTestCase testCase in testCases)
        {
            CanGetAllVectorsBetween(testCase);
        }
    }
    #endregion

}