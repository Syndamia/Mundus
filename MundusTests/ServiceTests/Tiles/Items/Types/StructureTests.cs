namespace MundusTests.ServiceTests.Tiles.Items.Types 
{
    using Mundus.Service.Tiles.Items.Types;
    using NUnit.Framework;
    using static Mundus.Data.Values;

    [TestFixture]
    public static class StructureTests 
    {
        [Test]
        [TestCase(null)]
        [TestCase("test")]
        public static void InstantiatesFromStock(string stock_id) 
        {
            Structure gt = new Structure(stock_id, "", 0, ToolType.Axe, 0);

            Assert.AreEqual(stock_id, gt.stock_id, "Structure doesn't set stock_id properly");
        }

        [Test]
        public static void InstantiatesFromAnotherStructure() 
        {
            Structure gt = new Structure("testing", "", 0, ToolType.Axe, 0);
            Structure gt1 = new Structure(gt);

            Assert.AreEqual(gt.stock_id, gt1.stock_id, "Structure constructor doesn't work properly with a groundtile as a parameter");
        }
    }
}
