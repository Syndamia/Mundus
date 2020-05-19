namespace MundusTests.DataTests.SuperLayers.DBTables 
{
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class UGPlacedTileTests 
    {
        [Test]
        [TestCase(null, 0, 0)]
        [TestCase("test", 50, 23)]
        public static void ConstructorWorksProperly(string stock_id, int yPos, int xPos) 
        {
            UGPlacedTile pt = new UGPlacedTile(stock_id, yPos, xPos);

            Assert.AreEqual(stock_id, pt.stock_id, "stock_id isn't set properly");
            Assert.AreEqual(yPos, pt.YPos, "YPos isn't set properly");
            Assert.AreEqual(xPos, pt.XPos, "XPos isn't set properly");
        }
    }
}
