using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Windows;
using Mundus.Service.SuperLayers.Generators;

namespace Mundus.Service {
    public static class GameGenerator {
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

        public static void GameWindowInventorySetup(string size) {
            switch (size.ToLower()) {
                case "small": WI.SelWin = WI.WSGame; break;
                case "medium": WI.SelWin = WI.WMGame; break;
                case "large": WI.SelWin = WI.WLGame; break;
                default: throw new ArgumentException("Screen & inventory size must be \"small\", \"medium\" or \"large\"");
            }
            GameWindowInventorySetup();
        }

        public static void GameWindowInventorySetup() {
            WI.SelWin.SetDefaults();
            WI.WPause.GameWindow = WI.SelWin;
            MI.CreateInventories(WI.SelWin.Size);
            WI.SelWin.PrintScreen();
            WI.SelWin.PrintMainMenu();
            WI.SelWin.Show();
        }
    }
}
