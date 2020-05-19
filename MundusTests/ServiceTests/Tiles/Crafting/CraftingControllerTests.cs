namespace MundusTests.ServiceTests.Tiles.Crafting 
{
    using System.Linq;
    using Gtk;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Tiles.Presets;
    using Mundus.Data.Windows;
    using Mundus.Service.Tiles.Crafting;
    using NUnit.Framework;

    [TestFixture]
    public static class CraftingControllerTests 
    {
        [OneTimeSetUp]
        public static void SetUp() 
        {
            Application.Init();
            DataBaseContexts.CreateInstances();
            WI.CreateInstances();
            WI.WNewGame.OnBtnGenerateClicked(null, null);
        }

        [OneTimeTearDown]
        public static void TearDown() 
        {
            Application.Quit();
        }

        [Test]
        public static void PlayerSuccessfullyCrafts() 
        {
            var recipe = DataBaseContexts.CTContext.CraftingRecipes.First(x => x.ResultItem == "wooden_shovel");

            for(int i = 0; i < recipe.Count1; i++) 
            {
                MI.Player.Inventory.AppendToItems(MaterialPresets.GetALandStick());
            }
            CraftingController.CraftItemPlayer(recipe);

            Assert.Contains(recipe.ResultItem, MI.Player.Inventory.Items.Where(x => x != null).Select(x => x.stock_id).ToArray(), "Result item isn't added to player's inventory");
            Assert.AreEqual(1, MI.Player.Inventory.Items.Where(x => x != null).Count(), "Not all required items are removed from player's inventory");
        }
    }
}
