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

        [Test]
        public static void CreatesPlayerInstance() 
        {
            Assert.IsNotNull(MI.Player, "Player isn't instantiated");
        }
    }
}
