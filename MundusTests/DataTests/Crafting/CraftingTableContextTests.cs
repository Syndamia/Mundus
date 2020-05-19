namespace MundusTests.DataTests.Crafting 
{
    using System.Linq;
    using Mundus.Data.Crafting;
    using NUnit.Framework;

    [TestFixture]
    public static class CraftingTableContextTests 
    {
        [Test]
        public static void AddsRecipesUponInitialization() 
        {
            CraftingTableContext craftingTC = new CraftingTableContext();

            Assert.Less(0, craftingTC.CraftingRecipes.Count(), "CraftingTableContext doesn't add any recipes upon initialization");
        }
    }
}
