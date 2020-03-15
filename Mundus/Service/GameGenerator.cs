using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service.SuperLayers;
using Mundus.Views.Windows;

namespace Mundus.Service {
    public static class GameGenerator {
        public static void GenerateMap(string size) {
            switch (size.ToLower()) {
                case "small": MapSizes.CurrSize = MapSizes.SMALL; break;
                case "medium": MapSizes.CurrSize = MapSizes.MEDIUM; break;
                case "large": MapSizes.CurrSize = MapSizes.LARGE; break;
                default: throw new ArgumentException( "Map size must be \"small\", \"medium\" or \"large\"" );
            }

            //Add the other layers
            LandSuperLayerGenerator.GenerateAllLayers( MapSizes.CurrSize );
        }

        public static void GameWindowInventorySetup(string size) {
            switch (size.ToLower()) {
                case "small": GameWindowInventorySetup(WI.WSGame); break;
                case "medium": GameWindowInventorySetup(WI.WMGame); break;
                case "large": GameWindowInventorySetup(WI.WLGame); break;
                default: throw new ArgumentException("Screen & inventory size must be \"small\", \"medium\" or \"large\"");
            }
        }

        public static void GameWindowInventorySetup(IGameWindow gameWindow) {
            gameWindow.SetDefaults();
            WI.WPause.GameWindow = gameWindow;
            LMI.CreateInventories(gameWindow.Size);
            gameWindow.PrintScreen();
            gameWindow.PrintMainMenu();
            gameWindow.Show();
        }
    }
}
