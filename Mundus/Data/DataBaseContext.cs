using System;
using Mundus.Data.Crafting;

namespace Mundus.Data {
    public static class DataBaseContext {
        public static CraftingTableContext CTContext { get; private set; }
        public static GameEventLogContext GELContext { get; private set; }

        public static void CreateInstances() {
            CTContext = new CraftingTableContext();
            CTContext.AddRecipes();
            GELContext = new GameEventLogContext();
        }
    }
}
