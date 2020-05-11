using System;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items.Presets;
using Mundus.Service.Tiles.Mobs;
using Mundus.Service.Tiles.Mobs.LandMobs;

namespace Mundus.Service.Tiles.Mobs.Controllers {
    public static class MobMovement {
        private static Random rnd = new Random();

        /// <summary>
        /// Moves all mobs that have a RndMovementRate of more than one on a random tile 
        /// in a 3x3 radius (including the tile they are currently on)
        /// </summary>
        public static void MoveRandomlyAllMobs() {
            foreach(var superLayer in DataBaseContexts.SuperLayerContexts) 
            {
                for (int y = 0; y < (int)Values.CurrMapSize; y++) 
                {
                    for (int x = 0; x < (int)Values.CurrMapSize; x++) 
                    {
                        MobTile mob = LandMobsPresets.GetFromStock(superLayer.GetMobLayerStock(y, x));

                        if (mob != null) {
                            // Checks validity of RndMovementRate and descides if a mob will move to another tile
                            if (mob.RndMovementRate > 0 && rnd.Next(0, mob.RndMovementRate) == 1) 
                            {
                                int newYPos = rnd.Next(mob.YPos - 1, mob.YPos + 2);
                                int newXPos = rnd.Next(mob.XPos - 1, mob.XPos + 2);

                                ChangeMobPosition(mob, newYPos, newXPos, (int)Values.CurrMapSize);
                            }
                        }
                    }
                }
            }
        }

        public static void ChangeMobPosition(MobTile mob, int yPos, int xPos, int mapSize) {
            if (InBoundaries(yPos, xPos)) {
                if (CanWalkTo(mob, yPos, xPos)) {
                    ChangeMobPosition(mob, yPos, xPos);
                }
                else if (mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"Cannot walk to Y:{yPos}, X:{xPos}");
                }
            }
        }

        private const double TAKEN_ENERGY_FROM_MOVEMENT = 0.1;
        public static void MovePlayer(int yPos, int xPos, int mapSize) {
            ChangeMobPosition(MI.Player, yPos, xPos, mapSize);

            if (MI.Player.YPos == yPos && MI.Player.XPos == xPos) {
                MI.Player.DrainEnergy(TAKEN_ENERGY_FROM_MOVEMENT + Values.DifficultyValueModifier());
            }
        }

        private static void ChangeMobPosition(MobTile mob, int yPos, int xPos) {
            // Mob is removed from his current superlayer and in the end is added to the new one
            // Note: mob could not move, but will still be removed and readded to the superlayer
            mob.CurrSuperLayer.RemoveMobFromPosition(mob.YPos, mob.XPos);

            // If mob can go down a layer from a hole
            if (mob.CurrSuperLayer.GetGroundLayerStock(yPos, xPos) == null &&
                HeightController.GetLayerUnderneathMob(mob) != null) 
                {
                if (HeightController.GetLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos) == null) 
                {
                    mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);

                    if (mob.GetType() == typeof(Player)) {
                        GameEventLogController.AddMessage($"Player fell down a superlayer, to {mob.CurrSuperLayer}");
                    }
                }
                else if (mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"Cannot fall down a superlayer, blocked by {HeightController.GetLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos)}");
                }
            }
            // If mob can go down a layer from non-solid ground
            else if (!GroundPresets.GetFromStock(mob.CurrSuperLayer.GetGroundLayerStock(yPos, xPos)).Solid &&
                     HeightController.GetLayerUnderneathMob(mob) != null) 
                {

                if (HeightController.GetLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos) == null) 
                {
                    mob.CurrSuperLayer = HeightController.GetLayerUnderneathMob(mob);

                    if (mob.GetType() == typeof(Player)) {
                        GameEventLogController.AddMessage($"Player descended a superlayer, to {mob.CurrSuperLayer}");
                    }
                }
                else if (mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"Cannot descend a superlayer, blocked by {HeightController.GetLayerUnderneathMob(mob).GetMobLayerStock(yPos, xPos)}");
                }
            }
            // If mob can climb up
            else if (mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos) != null &&
                     HeightController.GetLayerAboveMob(mob).GetMobLayerStock(yPos, xPos) == null) 
                {
                // Mobs can only climb to the superlayer on top of them, if 
                // there is a climable structure and there is a "hole" on top of the climable structure
                if (StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsClimable &&
                    HeightController.GetLayerAboveMob(mob) != null) 
                {
                    // The ground above isn't solid or doesnt exist and there are no mobs on top
                    if (HeightController.GetLayerAboveMob(mob).GetGroundLayerStock(yPos, xPos) == null ||
                        !GroundPresets.GetFromStock(HeightController.GetLayerAboveMob(mob).GetGroundLayerStock(yPos, xPos)).Solid) 
                    {
                        mob.CurrSuperLayer = HeightController.GetLayerAboveMob(mob);

                        if (mob.GetType() == typeof(Player)) {
                            GameEventLogController.AddMessage($"Player climbed up a superlayer");
                        }
                    }
                    else if (HeightController.GetLayerAboveMob(mob).GetGroundLayerStock(yPos, xPos) != null && mob.GetType() == typeof(Player)) {
                        GameEventLogController.AddMessage($"Cannot climb up a superlayer, there is solid ground above");
                    }
                }
                else if (!StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsClimable && mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"Cannot climb up a superlayer using a \"{mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)}\"");
                }
                else if (HeightController.GetLayerAboveMob(mob) == null && mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"There is no superlayer to climb up to");
                }
            }
            else if (HeightController.GetLayerAboveMob(mob).GetMobLayerStock(yPos, xPos) != null && mob.GetType() == typeof(Player)) {
                GameEventLogController.AddMessage($"Cannot climb up a superlayer, {HeightController.GetLayerAboveMob(mob).GetMobLayerStock(yPos, xPos)} is blocking the way");
            }

            mob.YPos = yPos;
            mob.XPos = xPos;
            mob.CurrSuperLayer.SetMobAtPosition(mob.stock_id, mob.Health, yPos, xPos);
        }

        private static bool CanWalkTo(MobTile mob, int yPos, int xPos) {
            //Mobs can only walk on free ground (no structure or mob) or walkable structures
            if (StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)) == null) {
                return mob.CurrSuperLayer.GetMobLayerStock(yPos, xPos) == null ||
                    LandMobsPresets.GetFromStock(mob.CurrSuperLayer.GetMobLayerStock(yPos, xPos)) == mob;
            }
            else if (StructurePresets.GetFromStock(mob.CurrSuperLayer.GetStructureLayerStock(yPos, xPos)).IsWalkable) {
                return mob.CurrSuperLayer.GetMobLayerStock(yPos, xPos) == null ||
                    LandMobsPresets.GetFromStock(mob.CurrSuperLayer.GetMobLayerStock(yPos, xPos)) == mob;
            }
            return false;
        }

        // Returns if the chosen new location is inside the map
        private static bool InBoundaries(int yPos, int xPos) {
            return yPos >= 0 && xPos >= 0 && yPos < (int)Values.CurrMapSize && xPos < (int)Values.CurrMapSize;
        }
    }
}
