using System;
using Mundus.Service.Crafting;
using Mundus.Service.Tiles.Items;

namespace Mundus.Data.Crafting {
    public static class RI { //short for Recipie Instances
        public static CraftingRecipie StoneAxe { get; private set; }

        public static void CreateInstances() {
            StoneAxe = new CraftingRecipie(new Tool());
        }
    }
}
