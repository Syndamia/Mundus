using System;
using Mundus.Data.Crafting;
using Mundus.Data.SuperLayers;

namespace Mundus.Data {
    public static class DataBaseContexts {
        public static CraftingTableContext CTContext { get; private set; }
        public static GameEventLogContext GELContext { get; private set; }

        public static SkyContext SContext { get; private set; }
        public static LandContext LContext { get; private set; }
        public static UndergroundContext UContext { get; private set; }
        public static ISuperLayerContext[] SuperLayerContexts { get; private set; }

        public static void CreateInstances() {
            CTContext = new CraftingTableContext();
            CTContext.AddRecipes();
            GELContext = new GameEventLogContext();

            SContext = new SkyContext();
            LContext = new LandContext();
            UContext = new UndergroundContext();
            SuperLayerContexts = new ISuperLayerContext[] { SContext, LContext, UContext };
        }
    }
}
