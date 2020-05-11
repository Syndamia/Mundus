using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items.Presets;

namespace Mundus.Service.Tiles.Mobs.Controllers {
    public static class MobStatsController {
        public static object GroundPresetsHeightController { get; private set; }

        /// <summary>
        /// Returns the stock_id of the hearth icon that must be used on the given position of the health bar
        /// </summary>
        /// <returns>stock_id of hearth icon</returns>
        /// <param name="index">Health bar index</param>
        public static string GetPlayerHearthStock(int index) {
            string stock_id = "hearth_0";

            int diff = MI.Player.Health - index * 4;
            if (diff >= 4) stock_id = "hearth_4";
            else if (diff == 1) stock_id = "hearth_1";
            else if (diff == 2) stock_id = "hearth_2";
            else if (diff == 3) stock_id = "hearth_3";

            return stock_id;
        }

        /// <summary>
        /// Returns the stock_id of the energy icon that must be used on the given position of the energy bar
        /// </summary>
        /// <returns>stock_id of energy icon</returns>
        /// <param name="index">Energy bar index</param>
        public static string GetPlayerEnergyStock(int index) {
            string stock_id = "energy_0";

            int diff = (int)MI.Player.Energy - index * 6;
            if (diff >= 6) stock_id = "energy_6";
            else if (diff == 1) stock_id = "energy_1";
            else if (diff == 2) stock_id = "energy_2";
            else if (diff == 3) stock_id = "energy_3";
            else if (diff == 4) stock_id = "energy_4";
            else if (diff == 5) stock_id = "energy_5";

            return stock_id;
        }

        /// <summary>
        /// Returns the name of the superlayer the player is curently on
        /// </summary>
        public static string GetPlayerSuperLayerName() {
            return MI.Player.CurrSuperLayer.ToString();
        }

        /// <summary>
        /// Returns the player's horizontal (X) coordinates
        /// </summary>
        /// <returns>Player.XPos</returns>
        public static int GetPlayerXCoord() {
            return MI.Player.XPos;
        }

        /// <summary>
        /// Returns the player's vertical (Y) coordinates
        /// </summary>
        /// <returns>Player.YPos</returns>
        public static int GetPlayerYCoord() {
            return MI.Player.YPos;
        }

        /// <summary>
        /// Checks if the player has an an empty/non-solid tile directly on the superlayer above him
        /// </summary>
        public static bool ExistsHoleOnTopOfPlayer() {
            //There can't be a hole if there isn't a layer above the player
            if (HeightController.GetLayerAboveMob(MI.Player) == null) {
                return false;
            }
            return HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerStock(MI.Player.YPos, MI.Player.XPos) == null ||
                   !GroundPresets.GetFromStock(HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerStock(MI.Player.YPos, MI.Player.XPos)).Solid;
        }
    }
}
