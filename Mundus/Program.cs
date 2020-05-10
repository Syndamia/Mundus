using Gtk;
using Mundus.Data.Crafting;
using Mundus.Data.Dialogues;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Windows;
using Mundus.Data;
using Mundus.Service;
using Mundus.Service.Tiles.Crafting;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus {
    public static class MainClass {
        public static bool runGame = true;
        public static CraftingTableContext CTController { get; private set; }

        public static void Main(string[] args) {
            //DBController = new DatabaseController();
            //Data.Crafting.CraftingTableContext.CreateRecipes();
            CTController = new CraftingTableContext();
            CTController.AddRecipes();

            Application.Init();
            //All windows and dialogues that are used by user (instances) are saved and created in WindowInstances.cs
            LogController.Initialize();
            WI.CreateInstances();
            DI.CreateInstances();
            LI.CreateInstances();

            WI.WMain.Show();
            Application.Run();
        }
    }
}
