using Gtk;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service.Mobs {
    public static class MobStatsController {
        public static int GetPlayerHealth() {
            return LMI.Player.Health;
        }

        public static Image GetPlayerHearth(int index) {
            Image img = new Image("empty", IconSize.Dnd);

            int diff = GetPlayerHealth() - index * 4;
            if (diff >= 4) img = new Image("hearth_4-4", IconSize.Dnd);
            else if (diff == 1) img = new Image("hearth_1-4", IconSize.Dnd);
            else if (diff == 2) img = new Image("hearth_2-4", IconSize.Dnd);
            else if (diff == 3) img = new Image("hearth_3-4", IconSize.Dnd);

            return img;
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
    }
}
