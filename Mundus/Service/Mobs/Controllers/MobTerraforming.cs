using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Tiles;
using Mundus.Service.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs.Controllers {
    public static class MobTerraforming {
        /// <summary>
        /// Tries to place a selected structure/ground tile or to mine/dig (destroy) at the selected location
        /// </summary>
        /// <param name="inventoryPlace">Place where the selected item is located ("hotbar", "items", ...)</param>
        /// <param name="inventoryIndex">Index of the place where the item is located</param>
        public static void PlayerTerraformAt(int mapYPos, int mapXPos, string inventoryPlace, int inventoryIndex) {
            var selectedItemType = Inventory.GetPlayerItem(inventoryPlace, inventoryIndex).GetType();

            // If player can place strucure
            if (selectedItemType == typeof(Structure)) {
                if (PlayerCanBuildStructureAt(mapYPos, mapXPos)) {
                    PlayerBuildStructureAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                    MI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
                }
                else {
                    LogController.AddMessage($"Cannot build structure at Y:{mapYPos}, X:{mapXPos}");
                }

            }
            // If Player can place ground
            else if (selectedItemType == typeof(GroundTile)) {
                if (PlayerCanPlaceGroundAt(mapYPos, mapXPos)) {
                    PlayerPlaceGroundAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                    MI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
                }
                else {
                    LogController.AddMessage($"Cannot place ground at Y:{mapYPos}, X:{mapXPos}");
                }
            }
            // If player can mine/dig
            else if (selectedItemType == typeof(Tool)) {
                if (PlayerCanDestroyAt(mapYPos, mapXPos)) {
                    PlayerDestroyAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                }
                else {
                    LogController.AddMessage($"Cannot destroy at Y:{mapYPos}, X:{mapXPos}");
                }
            }
        }

        // Player can't destory structures/ground tiles if there are none
        private static bool PlayerCanDestroyAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null ||
                   MI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) != null;
        }

        private static void PlayerDestroyAt(int mapYPos, int mapXPos, string place, int index) {
            var selectedTool = (Tool)MI.Player.Inventory.GetItemTile(place, index);

            // Only shovels can destroy ground layer tiles, but not when there is something over the ground tile
            if (selectedTool.Type == ToolTypes.Shovel && MI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) == null) {
                PlayerTryDestroyGroundAt(mapYPos, mapXPos, selectedTool);
            }
            // Don't try to destroy structure if there is no structure
            else if (MI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                PlayerTryDestroyStructureAt(mapYPos, mapXPos, selectedTool);
            }
        }

        private static void PlayerTryDestroyGroundAt(int mapYPos, int mapXPos, Tool shovel) {
            var selectedGround = MI.Player.CurrSuperLayer.GetGroundLayerTile(mapYPos, mapXPos);

            // Ground tiles that should be unbreakable have a negative required shovel class
            if (selectedGround.ReqShovelClass <= shovel.Class && selectedGround.ReqShovelClass >= 0) {
                MI.Player.CurrSuperLayer.SetGroundAtPosition(null, mapYPos, mapXPos);

                ISuperLayer under = HeightController.GetLayerUnderneathMob(MI.Player);
                // When a shovel destroys ground tile, it destroys the structure below it (but only if it is not walkable)
                if (under != null && under.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                    if (!under.GetStructureLayerTile(mapYPos, mapXPos).IsWalkable) {
                        under.RemoveStructureFromPosition(mapYPos, mapXPos);
                    }
                }

                if (MI.Player.Inventory.Items.Contains(null)) {
                    MI.Player.Inventory.AppendToItems(new GroundTile(selectedGround));
                }

                LogController.AddMessage($"Player destroyed \"{selectedGround.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
            }
            else if (selectedGround.ReqShovelClass > shovel.Class) {
                LogController.AddMessage($"Ground \"{selectedGround.stock_id}\" requires minimum shovel class of: {selectedGround.ReqShovelClass}");
            }
            else { // selectedGround.ReqSHovelClass < 0
                LogController.AddMessage($"This ground cannot be destroyed.");
            }
        }

        private static void PlayerTryDestroyStructureAt(int mapYPos, int mapXPos, Tool tool) {
            var selStructure = MI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos);

            if (selStructure.ReqToolType == tool.Type && selStructure.ReqToolClass <= tool.Class) {
                int damagePoints = 1 + (tool.Class - selStructure.ReqToolClass);

                // Some structures have a "drop", a specific item that they give upon being damaged.
                // Other structures drop themselves (you "pick up" the structure after breaking it).
                if (selStructure.GetDrop() != selStructure) {
                    // The amount of dropped items it adds to inventory is that of the damage points.
                    // If the structure will "die" (health <= 0) before giving all items, it stops giving items.
                    for (int i = 0; i < damagePoints && i < selStructure.Health && MI.Player.Inventory.Items.Contains(null); i++) {
                        MI.Player.Inventory.AppendToItems(new Material((Material)selStructure.GetDrop()));
                    }
                }
                else if (MI.Player.Inventory.Items.Contains(null)) {
                    MI.Player.Inventory.AppendToItems((Structure)selStructure.GetDrop());
                }

                // Damage to the structure is done after adding the dropped item/items.
                if (!selStructure.TakeDamage(damagePoints)) {
                    MI.Player.CurrSuperLayer.SetStructureAtPosition(null, mapYPos, mapXPos);

                    LogController.AddMessage($"Player destroyed \"{selStructure.stock_id}\" from layer \"{MI.Player.CurrSuperLayer}\" at Y:{mapYPos}, X:{mapXPos}");
                }
                else {
                    LogController.AddMessage($"Player did {damagePoints} damage to \"{selStructure.stock_id}\" (H:{selStructure.Health})");
                }
            }
            else if (selStructure.ReqToolType != tool.Type) {
                LogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires tool type: {selStructure.ReqToolType}");
            }
            else { // selStructure.ReqToolClass > tool.Class
                LogController.AddMessage($"Structure \"{selStructure.stock_id}\" requires minimum tool class of: {selStructure.ReqToolClass}");
            }
        }

        // Ground can be placed if there isnt a structure on an empty ground layer spot
        private static bool PlayerCanPlaceGroundAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null &&
                   MI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        private static void PlayerPlaceGroundAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            GroundTile toPlace = (GroundTile)MI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            MI.Player.CurrSuperLayer.SetGroundAtPosition(toPlace, yPos, xPos);

            LogController.AddMessage($"Set ground \"{toPlace.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");
        }


        private static bool PlayerCanBuildStructureAt(int yPos, int xPos) {
            return MI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        private static void PlayerBuildStructureAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            Structure toBuild = (Structure)MI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            // Climable structures will be placed under a hole (if they can be).
            // Non climable structures won't be placed anywhere if there is a hole.
            if (toBuild.IsClimable && MI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null && 
                HeightController.GetLayerUnderneathMob(MI.Player).GetStructureLayerTile(yPos, xPos) == null) 
            {
                HeightController.GetLayerUnderneathMob(MI.Player).SetStructureAtPosition(toBuild, yPos, xPos);

                LogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{HeightController.GetLayerUnderneathMob(MI.Player)}\" at Y:{yPos}, X:{xPos}");
            }
            else if (MI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) != null) {
                MI.Player.CurrSuperLayer.SetStructureAtPosition(toBuild, yPos, xPos);

                LogController.AddMessage($"Set structure \"{toBuild.stock_id}\" on layer \"{MI.Player.CurrSuperLayer}\" at Y:{yPos}, X:{xPos}");
            }
        }
    }
}
