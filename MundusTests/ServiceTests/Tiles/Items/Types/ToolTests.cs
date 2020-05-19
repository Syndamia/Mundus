namespace MundusTests.ServiceTests.Tiles.Items.Types 
{
    using Mundus.Service.Tiles.Items.Types;
    using NUnit.Framework;
    using static Mundus.Data.Values;

    [TestFixture]
    public static class ToolTests 
    {
        [Test]
        [TestCase(null)]
        [TestCase("test")]
        public static void InstantiatesFromStock(string stock_id) 
        {
            Tool gt = new Tool(stock_id, ToolType.Axe, 0);

            Assert.AreEqual(stock_id, gt.stock_id, "Tool doesn't set stock_id properly");
        }

        [Test]
        public static void InstantiatesFromAnotherTool() 
        {
            Tool gt = new Tool("testing", ToolType.Axe, 0);
            Tool gt1 = new Tool(gt);

            Assert.AreEqual(gt.stock_id, gt1.stock_id, "Tool constructor doesn't work properly with a groundtile as a parameter");
        }
    }
}
