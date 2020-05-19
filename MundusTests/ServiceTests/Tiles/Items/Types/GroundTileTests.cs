namespace MundusTests.ServiceTests.Tiles.Items.Types 
{
    using Mundus.Service.Tiles.Items.Types;
    using NUnit.Framework;

    [TestFixture]
    public static class GroundTileTests 
    {
        [Test]
        [TestCase(null)]
        [TestCase("test")]
        public static void InstantiatesFromStock(string stock_id) 
        {
            GroundTile gt = new GroundTile(stock_id, 0);

            Assert.AreEqual(stock_id, gt.stock_id, "GroundTile doesn't set stock_id properly");
        }

        [Test]
        public static void InstantiatesFromAnotherGroundTile() 
        {
            GroundTile gt = new GroundTile("testing", 0);
            GroundTile gt1 = new GroundTile(gt);

            Assert.AreEqual(gt.stock_id, gt1.stock_id, "GroundTile constructor doesn't work properly with a groundtile as a parameter");
        }
    }
}
