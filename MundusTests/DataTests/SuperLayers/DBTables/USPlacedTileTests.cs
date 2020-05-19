namespace MundusTests.DataTests.SuperLayers.DBTables 
{
    using Mundus.Data.SuperLayers.DBTables;
    using NUnit.Framework;

    [TestFixture]
    public static class USPlacedTileTests 
    {
        [Test]
        [TestCase(null, -1, 0, 0)]
        [TestCase("test", 10, 50, 23)]
        public static void ConstructorWorksProperly(string stock_id, int health, int yPos, int xPos) 
        {
            USPlacedTile pt = new USPlacedTile(stock_id, health, yPos, xPos);

            Assert.AreEqual(stock_id, pt.stock_id, "stock_id isn't set properly");
            Assert.AreEqual(yPos, pt.YPos, "YPos isn't set properly");
            Assert.AreEqual(xPos, pt.XPos, "XPos isn't set properly");
            Assert.AreEqual(health, pt.Health, "XPos isn't set properly");
        }
    }
}
