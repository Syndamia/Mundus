namespace MundusTests.ServiceTests.SuperLayers 
{
    using Mundus.Data;
    using Mundus.Service.SuperLayers;
    using NUnit.Framework;

    [TestFixture]
    public static class HeightControllerTests 
    {
        [Test]
        public static void GetsCorrectSuperLayerUnderneath()
        {
            Assert.AreEqual(DataBaseContexts.LContext, HeightController.GetSuperLayerUnderneath(DataBaseContexts.SContext), "GetSuperLayerUnderneath doesn't return that land is below sky");
            Assert.AreEqual(DataBaseContexts.UContext, HeightController.GetSuperLayerUnderneath(DataBaseContexts.LContext), "GetSuperLayerUnderneath doesn't return that underground is below land");
            Assert.IsNull(HeightController.GetSuperLayerUnderneath(DataBaseContexts.UContext), "GetSuperLayerUnderneath doesn't return that there is nothing (null) below underground");
        }

        [Test]
        public static void GetsCorrectSuperLayerAbove() 
        {
            Assert.IsNull(HeightController.GetSuperLayerAbove(DataBaseContexts.SContext), "GetSuperLayerUnderneath doesn't return that there is nothing (null) above sky");
            Assert.AreEqual(DataBaseContexts.SContext, HeightController.GetSuperLayerAbove(DataBaseContexts.LContext), "GetSuperLayerUnderneath doesn't return that sky is above land");
            Assert.AreEqual(DataBaseContexts.LContext, HeightController.GetSuperLayerAbove(DataBaseContexts.UContext), "GetSuperLayerUnderneath doesn't return that land is above underground");
        }
    }
}
