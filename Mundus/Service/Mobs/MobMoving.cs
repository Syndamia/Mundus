using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;

namespace Mundus.Service.Mobs {
    public static class MobMoving {
        public static void MovePlayer(int yPos, int xPos, int size) {
            ChangePosition(LMI.Player, yPos, xPos, size);
        }

        public static void ChangePosition(IMob mob, int buttonYPos, int buttonXPos, int size) {
            int newYPos = (LMI.Player.YPos - 2 >= 0) ? LMI.Player.YPos - 2 + buttonYPos : buttonYPos;
            if (LMI.Player.YPos > MapSizes.CurrSize - 3) newYPos = buttonYPos + MapSizes.CurrSize - size;
            int newXPos = (LMI.Player.XPos - 2 >= 0) ? LMI.Player.XPos - 2 + buttonXPos : buttonXPos;
            if (LMI.Player.XPos > MapSizes.CurrSize - 3) newXPos = buttonXPos + MapSizes.CurrSize - size;

            if (newYPos >= 0 && newXPos >= 0 && newYPos < MapSizes.CurrSize && newXPos < MapSizes.CurrSize) {
                ChangePosition(mob, newYPos, newXPos);
            }
        }

        public static void ChangePosition(IMob mob, int yPos, int xPos) {
            if (mob.CurrSuperLayer.GetItemLayerTile( yPos, xPos ) == null ||
                mob.CurrSuperLayer.GetItemLayerTile( yPos, xPos ).IsWalkable) {
                mob.CurrSuperLayer.RemoveMobFromPosition( mob.YPos, mob.XPos );
                mob.YPos = yPos;
                mob.XPos = xPos;
                mob.CurrSuperLayer.SetMobAtPosition( mob.Tile, yPos, xPos );
            }
        }
    }
}
