using System;
using Gtk;
using Mundus.Data.Windows;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Mobs.Controllers;
using Mundus.Views.Windows;

namespace Mundus.Service.Windows {
    public static class WindowController {

        /// <summary>
        /// Shows the settings window and hides the sender
        /// </summary>
        public static void ShowSettingsWindow(Window sender) {
           sender.Hide();
           WI.WSettings.Show(sender);
        }

        /// <summary>
        /// Shows the new game window, sets it's default values and hides the sender
        /// </summary>
        public static void ShowNewGameWindow(Window sender) {
            sender.Hide();
            WI.WNewGame.SetDefaults();
            WI.WNewGame.Show();
        }

        /// <summary>
        /// Shows the main window and hides the sender
        /// </summary>
        public static void ShowMainWindow(Window sender) {
            sender.Hide();
            WI.WMain.Show();
        }

        public static bool PauseWindowVisible { get; set; }

        /// <summary>
        /// Shows the pause window on top of all windows and "pauses" game input (bool PauseWindowVisible)
        /// </summary>
        public static void ShowPauseWindow() {
            WI.WPause.Show();
            WI.WPause.Present();
            PauseWindowVisible = true;
        }

        /// <summary>
        /// Shows the music window on top of all windows
        /// </summary>
        public static void ShowMusicWindow() {
            WI.WMusic.Show();
            WI.WMusic.Present();
        }

        /// <summary>
        /// Shows the crafting window on top of all windows and does initializes it
        /// </summary>
        public static void ShowCraftingWindow() {
            WI.WCrafting.Initialize();
            WI.WCrafting.Show();
            WI.WCrafting.Present();
        }

        public static void ShowLogWindow() {
            WI.WLog.Initialize();
            WI.WLog.Show();
            WI.WLog.Present();
        }

        public static void React(int button) 
        {
            int size = WI.SelWin.Size;

            int buttonYPos = (button - 1) / size;
            int buttonXPos = (button - (buttonYPos * size)) - 1;

            int mapXPos = Calculate.CalculateXFromButton(buttonXPos, size);
            int mapYPos = Calculate.CalculateYFromButton(buttonYPos, size);

            if (!ItemController.HasSelectedItem()) {
                MobMovement.MovePlayer(mapYPos, mapXPos, size);
                MobMovement.MoveRandomlyAllMobs();
            }
            else {
                if (Inventory.GetPlayerItemFromItemSelection() != null) {
                    if (MobFighting.ExistsFightTargetForPlayer(mapYPos, mapXPos)) {
                        MobFighting.PlayerTryFight(mapYPos, mapXPos);
                    }
                    else {
                        MobTerraforming.PlayerTerraformAt(mapYPos, mapXPos);
                    }
                }

                ItemController.ResetSelection();
            }

            WI.SelWin.PrintWorldScreen();
            WI.SelWin.PrintMainMenu();

            WI.SelWin.PrintMapOrInv();
        }
    }
}
