namespace MundusTests.DataTests.Mobs 
{
    using Mundus.Service.Tiles.Mobs;
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
