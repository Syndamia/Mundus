namespace MundusTests.ServiceTests.Tiles.Crafting 
{
    using System.Linq;
    using Mundus.Data;
    using Mundus.Service.Tiles;
    using Mundus.Service.Tiles.Items.Presets;
    using Mundus.Service.Tiles.Mobs;
    using NUnit.Framework;

    [TestFixture]
    public static class CraftingControllerTests 
    {
        [Test]
        public static void PlayerSuccessfullyCrafts() 
        {
            var recipe = DataBaseContexts.CTContext.CraftingRecipes.First(x => x.ResultItem == "wooden_shovel");

            for (int i = 0; i < recipe.Count1; i++) 
            {
                MI.Player.Inventory.AppendToItems(MaterialPresets.GetALandStick());
            }

            RecipeController.CraftItemPlayer(recipe);

            Assert.Contains(recipe.ResultItem, MI.Player.Inventory.Items.Where(x => x != null).Select(x => x.stock_id).ToArray(), "Result item isn't added to player's inventory");
            Assert.AreEqual(1, MI.Player.Inventory.Items.Where(x => x != null).Count(), "Not all required items are removed from player's inventory");
        }
    }
}
