namespace MundusTests.DataTests.GameEventLogs 
{
    using System.Linq;
    using Mundus.Data.GameEventLogs;
    using NUnit.Framework;

    [TestFixture]
    public static class GameEventLogContextTests 
    {
        [Test]
        public static void TableGetsResetOnInitialization() 
        {
            GameEventLogContext gelc = new GameEventLogContext();

            Assert.AreEqual(0, gelc.GameEventLogs.Count(), "GameEventLogContext doesn't remove all values from table after being initialized.");
        }

        [Test]
        [TestCase("Test message one.", "Test message two.")]
        public static void AddsMessageToTable(string message1, string message2) 
        {
            GameEventLogContext gelc = new GameEventLogContext();

            gelc.AddMessage(message1);
            gelc.AddMessage(message2);

            Assert.AreEqual(message1, gelc.GetMessage(1), "First message isn't properly added or can't get it from table.");
            Assert.AreEqual(message2, gelc.GetMessage(2), "Second message isn't properly added or can't get it from table.");
        }

        [Test]
        [TestCase("Test message 1.", "Test message 2.")]
        public static void AddsMessagesToTable(string message1, string message2) 
        {
            GameEventLogContext gelc = new GameEventLogContext();

            gelc.AddMessage(message1);
            gelc.AddMessage(message2);

            Assert.AreEqual(message1, gelc.GameEventLogs.Find(1).Message, "Didn't get the first message");
            Assert.AreEqual(message2, gelc.GameEventLogs.Find(2).Message, "Didn't get the second message");
        }

        [Test]
        [TestCase("Test message 1.", "Test message 2.")]
        public static void CountsProperAmmountOfMessages(string message1, string message2) 
        {
            GameEventLogContext gelc = new GameEventLogContext();

            gelc.AddMessage(message1);
            gelc.AddMessage(message2);

            Assert.AreEqual(2, gelc.GetCount(), "Count of messages is wrong");
        }
    }
}
