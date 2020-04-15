using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.SuperLayers;

namespace Mundus.Service.Mobs {
    public static class MobMovement {
        public static void MovePlayer(int yPos, int xPos, int size) {
            ChangePosition(LMI.Player, yPos, xPos, size);
        }

        public static void ChangePosition(IMob mob, int yPos, int xPos, int size) {
            if (InBoundaries(yPos, xPos)) {
                if (CanWalkAt(mob, yPos, xPos)) {
                    ChangePosition(mob, yPos, xPos);
                }
            }
        }

        public static void ChangePosition(IMob mob, int yPos, int xPos) {
            mob.CurrSuperLayer.RemoveMobFromPosition(mob.YPos, mob.XPos);

            if (mob.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null) {
                mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);
            }
            else if (!mob.CurrSuperLayer.GetGroundLayerTile(yPos, xPos).Solid) {
                mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);
            }
            else if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null) {
                //Mobs can only climb to the superlayer on top of them, if there is a climable structure
                //and there is a "hole" on top of the climable structure
                if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsClimable &&
                    HeightController.GetLayerAboveMob(mob) != null) 
                {
                    if (HeightController.GetLayerAboveMob(mob).GetGroundLayerTile(yPos, xPos) == null ||
                        !HeightController.GetLayerAboveMob(mob).GetGroundLayerTile(yPos, xPos).Solid) 
                    {
                        mob.CurrSuperLayer = HeightController.GetLayerAboveMob(mob);
                    }
                }
            }

            mob.YPos = yPos;
            mob.XPos = xPos;
            mob.CurrSuperLayer.SetMobAtPosition(mob.Tile, yPos, xPos);
        }

        private static bool CanWalkAt(IMob mob, int yPos, int xPos) {
            //Mobs can only walk on free ground (no structure on top) or walkable structures
            return (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null ||
                    mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsWalkable) ||
                    mob.CurrSuperLayer.GetMobLayerTile(yPos, xPos) != null;
        }

        private static bool InBoundaries(int yPos, int xPos) {
            return yPos >= 0 && xPos >= 0 && yPos < MapSizes.CurrSize && xPos < MapSizes.CurrSize;
        }
    }
}
