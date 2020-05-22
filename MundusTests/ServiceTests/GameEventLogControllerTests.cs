namespace MundusTests.ServiceTests 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Service;
    using NUnit.Framework;

    [TestFixture]
    public static class GameEventLogControllerTests 
    {
        [Test]
        [TestCase("Testing")]
        public static void AddsCorrectlyMessages(string message) 
        {
            GameEventLogController.AddMessage(message);

            Assert.AreEqual(message, DataBaseContexts.GELContext.GameEventLogs.Single(x => x.ID == DataBaseContexts.GELContext.GameEventLogs.Count()).Message);
        }

        [Test]
        [TestCase("Testing1")]
        public static void GetsCorrectlyMessage(string message) 
        {
            GameEventLogController.AddMessage(message);

            Assert.AreEqual(message, GameEventLogController.GetMessagage(GameEventLogController.GetCount() - 1));
        }

        [Test]
        public static void GetsCorrectCount() 
        {
            Assert.AreEqual(DataBaseContexts.GELContext.GetCount(), GameEventLogController.GetCount());
        }
    }
}
