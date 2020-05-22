namespace MundusTests.DataTests 
{
    using Mundus.Data;
    using NUnit.Framework;

    [TestFixture]
    public static class DataBaseContextsTests 
    {
        [Test]
        public static void CreatesInstances() 
        {
            Assert.IsNotNull(DataBaseContexts.SContext, "Doesn't create SContext instance");
            Assert.IsNotNull(DataBaseContexts.LContext, "Doesn't create LContext instance");
            Assert.IsNotNull(DataBaseContexts.UContext, "Doesn't create UContext instance");
            Assert.IsNotNull(DataBaseContexts.CTContext, "Doesn't create CTContext instance");
            Assert.IsNotNull(DataBaseContexts.GELContext, "Doesn't create GELContext instance");
            Assert.IsNotNull(DataBaseContexts.SuperLayerContexts, "Doesn't create SuperLayerContexts instance");
        }
    }
}
