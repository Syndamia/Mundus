namespace MundusTests.DataTests.Mobs 
{
    using Gtk;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Windows;
    using NUnit.Framework;

    [TestFixture]
    public static class MITests 
    {
        [SetUp]
        public static void SetUp() 
        {
            Application.Init();
            DataBaseContexts.CreateInstances();
            WI.CreateInstances();
            WI.WNewGame.OnBtnGenerateClicked(null, null);
        }

        [Test]
        public static void CreatesPlayerInstance() 
        {
            Assert.AreNotEqual(null, MI.Player, "Player isn't instantiated");
        }
    }
}
