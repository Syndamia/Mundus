using System;
using System.Linq;
using Mundus.Data.Crafting;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service;
using Mundus.Service.Tiles.Mobs.LandMobs;
using NUnit.Framework;

namespace MundusTests.DataTests.Crafting {
    [TestFixture]
    public static class CraftingTableContextTests {
        [Test]
        public static void AddsRecipesUponInitialization() {
            CraftingTableContext craftingTC = new CraftingTableContext();

            Assert.Less(0, craftingTC.CraftingRecipes.Count(), "CraftingTableContext doesn't add any recipes upon initialization");
        }
    }
}
