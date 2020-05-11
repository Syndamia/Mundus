using System.Linq;
using Mundus.Data;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Mobs.LandMobs;
using static Mundus.Data.Values;

namespace Mundus.Service.Tiles.Mobs.Controllers {
    public static class MobFighting {
        /// <summary>
        /// Returns if for the specified position in the superlayer the payer is in, there exists a mob
        /// </summary>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static bool ExistsFightTargetForPlayer(int mapYPos, int mapXPos) {
            return ExistsFightTargetForMob(MI.Player, mapYPos, mapXPos);
        }

        /// <summary>
        /// Returns if for the specified position in the superlayer the given mob is in, there exists a mob
        /// </summary>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static bool ExistsFightTargetForMob(MobTile mob, int mapYPos, int mapXPos) {
            return mob.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) != null;
        }

        private const double TAKEN_ENERGY_FROM_FIGHTING = 0.5;
        /// <summary>
        /// The player tries to damage (or kill) mob on the specified map position
        /// Note: will fail of the player uses an invalid item
        /// </summary>
        /// <param name="selPlace">Inventory place of the selected item (item will be checked if its a valid tool)</param>
        /// <param name="selIndex">Inventory index of the selected item place (item will be checked if its a valid tool)</param>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static void PlayerTryFight(string selPlace, int selIndex, int mapYPos, int mapXPos) {
            if (MobTryFight(MI.Player, selPlace, selIndex, mapYPos, mapXPos)) {
                MI.Player.DrainEnergy(TAKEN_ENERGY_FROM_FIGHTING + DifficultyValueModifier());
            }
        }

        // Checks if the mob has a proper fighting item selected
        private static bool MobCanFight(MobTile mob, string selPlace, int selIndex, int mapYPos, int mapXPos) {
            return Inventory.GetPlayerItem(selPlace, selIndex).GetType() == typeof(Tool) &&
                   ((Tool)Inventory.GetPlayerItem(selPlace, selIndex)).Type == ToolType.Sword && 
                   mob.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) != null;
        }

        /// <summary>
        /// The given mob tries to damage (or kill) mob on the specified map position
        /// Note: will fail of the given mob uses an invalid item
        /// </summary>
        /// <returns><c>true</c> If mob was able to fight <c>false</c> otherwise.</returns>
        /// <param name="mob">Mob that will fight</param>
        /// <param name="selPlace">Inventory place of the selected item (item will be checked if its a valid tool)</param>
        /// <param name="selIndex">Inventory index of the selected item place (item will be checked if its a valid tool)</param>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static bool MobTryFight(MobTile mob, string selPlace, int selIndex, int mapYPos, int mapXPos) {
            if (MobCanFight(mob, selPlace, selIndex, mapYPos, mapXPos)) {
                Tool selTool = (Tool)Inventory.GetPlayerItem(selPlace, selIndex);
                MobTile targetMob = LandMobsPresets.GetFromStock(mob.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos));

                if (selTool.Class >= targetMob.Defense) {
                    int damagePoints = 1 + (selTool.Class - targetMob.Defense);

                    if (!targetMob.TakeDamage(damagePoints)) {
                        mob.CurrSuperLayer.SetMobAtPosition(null, mapYPos, mapXPos);

                        if (mob.Inventory.Items.Contains(null)) {
                            mob.Inventory.AppendToItems(targetMob.DroppedUponDeath);
                        }

                        if (mob.GetType() == typeof(Player)) {
                            GameEventLogController.AddMessage($"Player killed \"{targetMob.stock_id}\"");
                        }
                    } else if (mob.GetType() == typeof(Player)) {
                        GameEventLogController.AddMessage($"Player did {damagePoints} damage to \"{targetMob.stock_id}\" (H:{targetMob.Health}) ");
                    }
                    return true;
                }
                else if (mob.GetType() == typeof(Player)) {
                    GameEventLogController.AddMessage($"You need a tool class of atleast {targetMob.Defense} to fight this mob");
                }
            }
            else if (mob.CurrSuperLayer.GetMobLayerStock(mapYPos, mapXPos) == null && mob.GetType() == typeof(Player)) {
                GameEventLogController.AddMessage($"There is no mob to fight on \"{mob.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
            }
            else if (mob.GetType() == typeof(Player)) { // Inventory.GetPlayerItem(selPlace, selIndex).GetType() != typeof(Tool) || ((Tool)Inventory.GetPlayerItem(selPlace, selIndex)).Type != ToolTypes.Sword
                GameEventLogController.AddMessage($"You need a Tool of type {ToolType.Sword} to fight with other mobs");
            }
            return false;
        }
    }
}
