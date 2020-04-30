using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs.Controllers {
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
            return mob.CurrSuperLayer.GetMobLayerTile(mapYPos, mapXPos) != null;
        }


        /// <summary>
        /// The player tries to damage (or kill) mob on the specified map position
        /// Note: will fail of the player uses an invalid item
        /// </summary>
        /// <param name="selPlace">Inventory place of the selected item (item will be checked if its a valid tool)</param>
        /// <param name="selIndex">Inventory index of the selected item place (item will be checked if its a valid tool)</param>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static void PlayerTryFight(string selPlace, int selIndex, int mapYPos, int mapXPos) {
            MobTryFight(MI.Player, selPlace, selIndex, mapYPos, mapXPos);
        }

        // Checks if the mob has a proper fighting item selected
        private static bool MobCanFight(MobTile mob, string selPlace, int selIndex, int mapYPos, int mapXPos) {
            return Inventory.GetPlayerItem(selPlace, selIndex).GetType() == typeof(Tool) &&
                   ((Tool)Inventory.GetPlayerItem(selPlace, selIndex)).Type == ToolTypes.Sword && 
                   mob.CurrSuperLayer.GetMobLayerTile(mapYPos, mapXPos) != null;
        }

        /// <summary>
        /// The given mob tries to damage (or kill) mob on the specified map position
        /// Note: will fail of the given mob uses an invalid item
        /// </summary>
        /// <param name="mob">Mob that will fight</param>
        /// <param name="selPlace">Inventory place of the selected item (item will be checked if its a valid tool)</param>
        /// <param name="selIndex">Inventory index of the selected item place (item will be checked if its a valid tool)</param>
        /// <param name="mapYPos">YPos of target mob</param>
        /// <param name="mapXPos">XPos of target mob</param>
        public static void MobTryFight(MobTile mob, string selPlace, int selIndex, int mapYPos, int mapXPos) {
            if (MobCanFight(mob, selPlace, selIndex, mapYPos, mapXPos)) {
                Tool selTool = (Tool)Inventory.GetPlayerItem(selPlace, selIndex);
                MobTile targetMob = mob.CurrSuperLayer.GetMobLayerTile(mapYPos, mapXPos);

                if (selTool.Class >= targetMob.Defense) {
                    if (!targetMob.TakeDamage(1 + (selTool.Class - targetMob.Defense))) {
                        mob.CurrSuperLayer.SetMobAtPosition(null, mapYPos, mapXPos);

                        if (mob.Inventory.Items.Contains(null)) {
                            mob.Inventory.AppendToItems(targetMob.DroppedUponDeath);
                        }
                    }
                }
            }
        }
    }
}
