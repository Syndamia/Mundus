using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles;

namespace Mundus.Service.Mobs.Controllers {
    public static class MobMovement {
        private static Random rnd = new Random();

        public static void MovePlayer(int yPos, int xPos, int size) {
            ChangePosition(MI.Player, yPos, xPos, size);
        }

        public static void MoveRandomlyAllMobs() {
            foreach(var superLayer in LI.AllSuperLayers()) {
                for (int y = 0; y < MapSizes.CurrSize; y++) {
                    for (int x = 0; x < MapSizes.CurrSize; x++) {
                        MobTile mob = MI.Player.CurrSuperLayer.GetMobLayerTile(y, x);

                        if (mob != null) {
                            if (mob != MI.Player &&
                                rnd.Next(0, mob.RndMovementRate) == 1) {
                                int newYPos = rnd.Next(mob.YPos - 1, mob.YPos + 2);
                                int newXPos = rnd.Next(mob.XPos - 1, mob.XPos + 2);

                                ChangePosition(mob, newYPos, newXPos, MapSizes.CurrSize);
                            }
                        }
                    }
                }
            }
        }

        public static void ChangePosition(MobTile mob, int yPos, int xPos, int size) {
            if (InBoundaries(yPos, xPos)) {
                if (CanWalkAt(mob, yPos, xPos)) {
                    ChangePosition(mob, yPos, xPos);
                }
            }
        }

        public static void ChangePosition(MobTile mob, int yPos, int xPos) {
            mob.CurrSuperLayer.RemoveMobFromPosition(mob.YPos, mob.XPos);

            if (mob.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null &&
                HeightController.GetLayerUnderneathMob(mob) != null) {
                if (HeightController.GetLayerUnderneathMob(mob).GetMobLayerTile(yPos, xPos) == null) {
                    mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);
                }
            }
            else if (!mob.CurrSuperLayer.GetGroundLayerTile(yPos, xPos).Solid &&
                     HeightController.GetLayerUnderneathMob(mob) != null) {
                if (HeightController.GetLayerUnderneathMob(mob).GetMobLayerTile(yPos, xPos) == null) {
                    mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);
                }
            }
            else if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null &&
                     HeightController.GetLayerAboveMob(mob).GetMobLayerTile(yPos, xPos) == null) {
                //Mobs can only climb to the superlayer on top of them, if there is a climable structure
                //and there is a "hole" on top of the climable structure
                if (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsClimable &&
                    HeightController.GetLayerAboveMob(mob) != null) 
                {
                    // The ground above isn't solid or doesnt exist and there are no mobs on top
                    if (HeightController.GetLayerAboveMob(mob).GetGroundLayerTile(yPos, xPos) == null ||
                        !HeightController.GetLayerAboveMob(mob).GetGroundLayerTile(yPos, xPos).Solid) 
                    {
                        mob.CurrSuperLayer = HeightController.GetLayerAboveMob(mob);
                    }
                    else {
                        // TODO: add a message to log
                    }
                }
            }

            mob.YPos = yPos;
            mob.XPos = xPos;
            mob.CurrSuperLayer.SetMobAtPosition(mob, yPos, xPos);
        }

        private static bool CanWalkAt(MobTile mob, int yPos, int xPos) {
            //Mobs can only walk on free ground (no structure or mob) or walkable structures
            return (mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null ||
                    mob.CurrSuperLayer.GetStructureLayerTile(yPos, xPos).IsWalkable) &&
                   (mob.CurrSuperLayer.GetMobLayerTile(yPos, xPos) == null ||
                    mob.CurrSuperLayer.GetMobLayerTile(yPos, xPos) == mob);
        }

        private static bool InBoundaries(int yPos, int xPos) {
            return yPos >= 0 && xPos >= 0 && yPos < MapSizes.CurrSize && xPos < MapSizes.CurrSize;
        }
    }
}
