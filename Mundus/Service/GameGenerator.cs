namespace Mundus.Service 
{
    using System;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Windows;
    using Mundus.Service.SuperLayers.Generators;

    public static class GameGenerator 
    {
        /// <summary>
        /// Sets the map size and starts generation of all superlayers
        /// </summary>
        /// <param name="size">Size of the map ("small", "medium" or "large")</param>
        public static void GenerateMap(Values.MapSize size) 
        {
            Values.CurrMapSize = size;

            SkySuperLayerGenerator.GenerateAllLayers(Values.CurrMapSize);
            LandSuperLayerGenerator.GenerateAllLayers(Values.CurrMapSize);
            UndergroundSuperLayerGenerator.GenerateAllLayers(Values.CurrMapSize);
        }

        /// <summary>
        /// Sets the game window size and setups mob inventory for certain mobs
        /// Note: certain mobs base their inventory size from the game window size
        /// </summary>
        /// <param name="size">Size of the game window ("small", "medium" or "large")</param>
        public static void GameWindowSizeSetup(string size) 
        {
            switch (size.ToLower()) 
            {
                case "small": WI.SelWin = WI.WSGame; break;
                case "medium": WI.SelWin = WI.WMGame; break;
                case "large": WI.SelWin = WI.WLGame; break;
                default: throw new ArgumentException("Screen & inventory size must be \"small\", \"medium\" or \"large\"");
            }

           WI.SelWin.SetDefaults();
           MI.CreateInstances();
        }

        public static void GameWindowInitialize() 
        {
            WI.WPause.GameWindow = WI.SelWin;
            WI.SelWin.PrintWorldScreen();
            WI.SelWin.PrintMainMenu();
            WI.SelWin.Show();
        }

        /// <summary>
        /// Sets the game difficulty (that affects map generation).
        /// </summary>
        /// <param name="value">Must be "peaceful", "easy", "normal", "hard" or "insane"</param>
        public static void SetDifficulty(Values.Difficulty difficulty) 
        {
            Values.CurrDifficulty = difficulty;
        }
    }
}
