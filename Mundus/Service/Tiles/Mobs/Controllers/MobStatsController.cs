using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.SuperLayers;

namespace Mundus.Service.Tiles.Mobs.Controllers {
    public static class MobStatsController {
        public static int GetPlayerHealth() {
            return MI.Player.Health;
        }

        /// <summary>
        /// Returns the stock_id of the hearth icon that must be used on the given position of the health bar
        /// </summary>
        /// <returns>stock_id of hearth icon</returns>
        /// <param name="index">Health bar index</param>
        public static string GetPlayerHearth(int index) {
            string stock_id = "empty";

            int diff = GetPlayerHealth() - index * 4;
            if (diff >= 4) stock_id = "hearth_4-4";
            else if (diff == 1) stock_id = "hearth_1-4";
            else if (diff == 2) stock_id = "hearth_2-4";
            else if (diff == 3) stock_id = "hearth_3-4";

            return stock_id;
        }

        public static void DamagePlayer(int damagePoints) {
            if (!MI.Player.TakeDamage(damagePoints)) {
                //do smth
            }
        }

        /// <summary>
        /// Heals the player (unless/until he has full health)
        /// </summary>
        /// <param name="healthPoints">Health points to heal with</param>
        public static void HealPlayer(int healthPoints) {
            MI.Player.Heal(healthPoints);
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
            return HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerTile(MI.Player.YPos, MI.Player.XPos) == null ||
                   !HeightController.GetLayerAboveMob(MI.Player).GetGroundLayerTile(MI.Player.YPos, MI.Player.XPos).Solid;
        }
    }
}
