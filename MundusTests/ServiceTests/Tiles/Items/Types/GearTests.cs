namespace MundusTests.ServiceTests.Tiles.Items.Types 
{
    using Mundus.Service.Tiles.Items.Types;
    using NUnit.Framework;

    [TestFixture]
    public static class GearTests 
    {
        [Test]
        [TestCase(null)]
        [TestCase("test")]
        public static void InstantiatesFromStock(string stock_id) 
        {
            Gear gt = new Gear(stock_id);

            Assert.AreEqual(stock_id, gt.stock_id, "Gear doesn't set stock_id properly");
        }

        [Test]
        public static void InstantiatesFromAnotherGear() 
        {
            Gear gt = new Gear("testing");
            Gear gt1 = new Gear(gt);

            Assert.AreEqual(gt.stock_id, gt1.stock_id, "Gear constructor doesn't work properly with a groundtile as a parameter");
        }
    }
}
