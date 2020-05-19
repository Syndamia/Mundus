namespace MundusTests.DataTests.GameEventLogs 
{
    using Mundus.Data.GameEventLogs;
    using NUnit.Framework;

    [TestFixture]
    public static class GameEventLogTests 
    {
        [Test]
        [TestCase("Testing message")]
        public static void InitializesWithProperMessageValue(string message) 
        {
            GameEventLog log = new GameEventLog(message);

            Assert.AreEqual(message, log.Message, "GameEventLog doesn't properly set message on initialization");
        }
    }
}
