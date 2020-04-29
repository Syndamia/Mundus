using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service.SuperLayers.Generators;

namespace Mundus.Service {
    public static class GameGenerator {
        /// <summary>
        /// Sets the map size and starts generation of all superlayers
        /// </summary>
        /// <param name="size">Size of the map ("small", "medium" or "large")</param>
        public static void GenerateMap(string size) {
            switch (size.ToLower()) {
                case "small": MapSizes.CurrSize = MapSizes.SMALL; break;
                case "medium": MapSizes.CurrSize = MapSizes.MEDIUM; break;
                case "large": MapSizes.CurrSize = MapSizes.LARGE; break;
                default: throw new ArgumentException( "Map size must be \"small\", \"medium\" or \"large\"" );
            }

            SkySuperLayerGenerator.GenerateAllLayers(MapSizes.CurrSize);
            LandSuperLayerGenerator.GenerateAllLayers(MapSizes.CurrSize);
            UndergroundSuperLayerGenerator.GenerateAllLayers(MapSizes.CurrSize);
        }

        /// <summary>
        /// Sets the game window size and setups mob inventory for certain mobs
        /// Note: certain mobs base their inventory size from the game window size
        /// </summary>
        /// <param name="size">Size of the game window ("small", "medium" or "large")</param>
        public static void GameWindowSizeSetup(string size) {
            switch (size.ToLower()) {
                case "small": WI.SelWin = WI.WSGame; break;
                case "medium": WI.SelWin = WI.WMGame; break;
                case "large": WI.SelWin = WI.WLGame; break;
                default: throw new ArgumentException("Screen & inventory size must be \"small\", \"medium\" or \"large\"");
            }

            WI.SelWin.SetDefaults();
            MI.CreateInstances(WI.SelWin.Size);
        }

        public static void GameWindowInitialize() {
            WI.WPause.GameWindow = WI.SelWin;
            WI.SelWin.PrintScreen();
            WI.SelWin.PrintMainMenu();
            WI.SelWin.Show();
        }
    }
}
