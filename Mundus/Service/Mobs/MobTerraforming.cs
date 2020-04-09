using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Data.Tiles;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs {
    public static class MobTerraforming {
        public static void PlayerTerraformAt(int mapYPos, int mapXPos, string inventoryPlace, int inventoryIndex) {
            var selectedType = Inventory.GetPlayerItem(inventoryPlace, inventoryIndex).GetType();

            if (selectedType == typeof(Structure) && PlayerCanBuildStructureAt(mapYPos, mapXPos)) {
                PlayerBuildStructureAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                LMI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
            }
            else if (selectedType == typeof(GroundTile) && PlayerCanPlaceGroundAt(mapYPos, mapXPos)) {
                PlayerPlaceGroundAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
                LMI.Player.Inventory.DeleteItemTile(inventoryPlace, inventoryIndex);
            }
            else if (selectedType == typeof(Tool) && PlayerCanDestroyAt(mapYPos, mapXPos)) {
                PlayerDestroyAt(mapYPos, mapXPos, inventoryPlace, inventoryIndex);
            }
        }


        private static bool PlayerCanDestroyAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null ||
                   LMI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) != null;
        }

        private static void PlayerDestroyAt(int mapYPos, int mapXPos, string place, int index) {
            var selectedTool = (Tool)LMI.Player.Inventory.GetItemTile(place, index);

            //Only shovels can destroy ground layer tiles, but not when there is something over the ground tile
            if (selectedTool.Type == ToolTypes.Shovel && LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) == null) {
                PlayerTryDestroyGroundAt(mapYPos, mapXPos, selectedTool);
            }
            else if (LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                PlayerTryDestroyStructureAt(mapYPos, mapXPos, selectedTool);
            }
        }

        private static void PlayerTryDestroyGroundAt(int mapYPos, int mapXPos, Tool shovel) {
            var selectedGround = LMI.Player.CurrSuperLayer.GetGroundLayerTile(mapYPos, mapXPos);

            if (selectedGround.ReqShovelClass <= shovel.Class) {
                LMI.Player.CurrSuperLayer.SetGroundAtPosition(null, mapYPos, mapXPos);

                //When a shovel destroys ground tile, it destroys the structure below (if it is not walkable)
                ISuperLayer under = LMI.Player.GetLayerUndearneathCurr();
                if (under != null && under.GetStructureLayerTile(mapYPos, mapXPos) != null) {
                    if (!under.GetStructureLayerTile(mapYPos, mapXPos).IsWalkable) {
                        under.RemoveStructureFromPosition(mapYPos, mapXPos);
                    }
                }

                if (LMI.Player.Inventory.Items.Contains(null)) {
                    LMI.Player.Inventory.AppendToItems(new GroundTile(selectedGround));
                }
            }
        }

        private static void PlayerTryDestroyStructureAt(int mapYPos, int mapXPos, Tool tool) {
            var selStructure = LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos);

            if (selStructure.ReqToolType == tool.Type && selStructure.ReqToolClass <= tool.Class) {
                int damagePoints = 1 + (tool.Class - selStructure.ReqToolClass);

                if (selStructure.GetDrop() != selStructure) {
                    for (int i = 0; i < damagePoints && i < selStructure.Health && LMI.Player.Inventory.Items.Contains(null); i++) {
                        LMI.Player.Inventory.AppendToItems(new Material((Material)selStructure.GetDrop()));
                    }
                }
                else if (LMI.Player.Inventory.Items.Contains(null)) {
                    LMI.Player.Inventory.AppendToItems((Structure)selStructure.GetDrop());
                }

                if (!selStructure.Damage(damagePoints)) {
                    LMI.Player.CurrSuperLayer.SetStructureAtPosition(null, mapYPos, mapXPos);
                }
            }
        }


        private static bool PlayerCanPlaceGroundAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null &&
                   LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        private static void PlayerPlaceGroundAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            GroundTile toPlace = (GroundTile)LMI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            LMI.Player.CurrSuperLayer.SetGroundAtPosition(toPlace, yPos, xPos);
        }


        private static bool PlayerCanBuildStructureAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        private static void PlayerBuildStructureAt(int yPos, int xPos, string inventoryPlace, int inventoryIndex) {
            Structure toBuild = (Structure)LMI.Player.Inventory.GetItemTile(inventoryPlace, inventoryIndex);

            //Climable structures will be placed under a hole (if they can be)
            if (toBuild.IsClimable && LMI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) == null
                && LMI.Player.GetLayerUndearneathCurr().GetStructureLayerTile(yPos, xPos) == null) {

                LMI.Player.GetLayerUndearneathCurr().SetStructureAtPosition(toBuild, yPos, xPos);
            }
            else if (LMI.Player.CurrSuperLayer.GetGroundLayerTile(yPos, xPos) != null) {
                LMI.Player.CurrSuperLayer.SetStructureAtPosition(toBuild, yPos, xPos);
            }
        }
    }
}
