namespace AdventOfCode2022.Tests;

[TestClass]
public class UtilsTests
{
    [TestMethod]
    [DataRow(   0,  0,1,2,3,4)]
    [DataRow( 120,  1,2,3,4,5)]
    [DataRow(-120, -1,2,3,4,5)]
    public void CanCalculateProductFromInts(int expectedProduct, params int[] ints)
    {
        int actualProduct = ints.Product();
        Assert.AreEqual(expectedProduct, actualProduct);
    }

    [TestMethod]
    [DataRow( 0, 1)]
    [DataRow( 0, 2, 1)]
    [DataRow( 0, 5, 1, 2, 3, 4)]
    [DataRow( 0,-5,-1,-2,-3,-4)]
    [DataRow(-5, 5,-4,-3,-2,-1,0, 1, 2, 3, 4)]
    [DataRow( 5,-5, 4, 3, 2, 1,0,-1,-2,-3,-4)]
    public void CanGetAllIntsBetween(int fromInt, int toInt, params int[] expectedIntsBetween)
    {
        //expectedIntsBetween = expectedIntsBetween ?? Array.Empty<int>();
        IEnumerable<int> actualIntsBetween = Utils.GetAllIntsBetween(fromInt, toInt);
        Assert.IsTrue(expectedIntsBetween.SequenceEqual(actualIntsBetween));
    }
}
