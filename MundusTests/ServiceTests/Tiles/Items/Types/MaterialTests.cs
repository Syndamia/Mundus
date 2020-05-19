namespace MundusTests.ServiceTests.Tiles.Items.Types 
{
    using Mundus.Service.Tiles.Items.Types;
    using NUnit.Framework;

    [TestFixture]
    public static class MaterialTests 
    {
        [Test]
        [TestCase(null)]
        [TestCase("test")]
        public static void InstantiatesFromStock(string stock_id) 
        {
            Material gt = new Material(stock_id);

            Assert.AreEqual(stock_id, gt.stock_id, "Material doesn't set stock_id properly");
        }

        [Test]
        public static void InstantiatesFromAnotherMaterial() 
        {
            Material gt = new Material("testing");
            Material gt1 = new Material(gt);

            Assert.AreEqual(gt.stock_id, gt1.stock_id, "Material constructor doesn't work properly with a groundtile as a parameter");
        }
    }
}
