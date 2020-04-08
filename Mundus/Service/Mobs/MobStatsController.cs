using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service.Mobs {
    public static class MobStatsController {
        public static int GetPlayerHealth() {
            return LMI.Player.Health;
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
            LMI.Player.Health -= healthPoints;

            if (LMI.Player.Health <= 0) {
                //do smth
            }
        }

        public static void TryHealPlayer(int healthPoints) {
            LMI.Player.Health += healthPoints;

            if (LMI.Player.Health > MapSizes.CurrSize / 5 * 4) {
                LMI.Player.Health = MapSizes.CurrSize / 5 * 4;
            }
        }

        public static string GetPlayerSuperLayerName() {
            return LMI.Player.CurrSuperLayer.ToString();
        }

        /// <summary>
        /// Returns the player's horizontal (X) coordinates
        /// </summary>
        /// <returns>Player.XPos</returns>
        public static int GetPlayerXCoord() {
            return LMI.Player.XPos;
        }

        /// <summary>
        /// Returns the player's vertical (Y) coordinates
        /// </summary>
        /// <returns>Player.YPos</returns>
        public static int GetPlayerYCoord() {
            return LMI.Player.YPos;
        }

        public static bool ExistsHoleOnTopOfPlayer() {
            if (LMI.Player.GetLayerOnTopOfCurr() == null) {
                return false;
            }
            return LMI.Player.GetLayerOnTopOfCurr().GetGroundLayerTile(LMI.Player.YPos, LMI.Player.XPos) == null;
        }
    }
}
