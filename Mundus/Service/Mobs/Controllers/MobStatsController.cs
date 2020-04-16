using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.SuperLayers;

namespace Mundus.Service.Mob.Controllers {
    public static class MobStatsController {
        public static int GetPlayerHealth() {
            return MI.Player.Health;
        }

        public static string GetPlayerHearth(int index) {
            string stock_id = "empty";

            int diff = GetPlayerHealth() - index * 4;
            if (diff >= 4) stock_id = "hearth_4-4";
            else if (diff == 1) stock_id = "hearth_1-4";
            else if (diff == 2) stock_id = "hearth_2-4";
            else if (diff == 3) stock_id = "hearth_3-4";

            return stock_id;
        }

        public static void DamagePlayer(int healthPoints) {
            MI.Player.Health -= healthPoints;

            if (MI.Player.Health <= 0) {
                //do smth
            }
        }

        public static void TryHealPlayer(int healthPoints) {
            MI.Player.Health += healthPoints;

            if (MI.Player.Health > MapSizes.CurrSize / 5 * 4) {
                MI.Player.Health = MapSizes.CurrSize / 5 * 4;
            }
        }

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

        public static bool ExistsHoleOnTopOfPlayer() {
            //There can't be a hole if there is nothing above layer
            if (HeightController.GetLayerAboveMob(MI.Player) == null) {
                return false;
            }
            return HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerTile(MI.Player.YPos, MI.Player.XPos) == null ||
                   !HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerTile(MI.Player.YPos, MI.Player.XPos).Solid;
        }
    }
}
