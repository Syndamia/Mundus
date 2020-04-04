using System.Linq;
using Mundus.Data.Superlayers.Mobs;
using Mundus.Data.SuperLayers;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Mobs {
    public static class MobTerraforming {

        public static void PlayerDestroyAt(int mapYPos, int mapXPos, string place, int index) {
            if (LMI.Player.Inventory.GetTile(place, index).GetType() == typeof(Tool)) {
                var selTool = (Tool)LMI.Player.Inventory.GetTile(place, index);
                var selStructure = LMI.Player.CurrSuperLayer.GetStructureLayerTile(mapYPos, mapXPos);

                if (selStructure.ReqToolType == selTool.Type && selStructure.ReqToolClass == selTool.Class) {
                    if (LMI.Player.Inventory.Items.Any(x => x == null)) {
                        LMI.Player.Inventory.AppendToItems(new Material(selStructure.DroppedMaterial.stock_id));

                        if (!selStructure.Damage()) {
                            LMI.Player.CurrSuperLayer.SetStructureAtPosition(null, mapYPos, mapXPos);
                        }
                    }
                    else {
                        //TODO: put the item on the ground
                    }
                }
                else {
                    //TODO: add error to log
                }
            }
        }

        public static void PlayerBuildAt(int mapYPos, int mapXPos, string inventoryPlace, int inventoryPlaceIndex) {
            if (PlayerCanBuildAt(mapYPos, mapXPos)) {
                ItemTile[] toPlace = null;

                switch (inventoryPlace) {
                    case "hotbar": toPlace = LMI.Player.Inventory.Hotbar; break;
                    case "items": toPlace = LMI.Player.Inventory.Items; break;
                }

                if (toPlace != null) {
                    PlayerBuildAt(mapYPos, mapXPos, (Structure)toPlace[inventoryPlaceIndex]);
                    toPlace[inventoryPlaceIndex] = null;
                }
            }
        }

        private static void PlayerBuildAt(int mapYPos, int mapXPos, Structure toPlace) {
            LMI.Player.CurrSuperLayer.SetStructureAtPosition(toPlace, mapYPos, mapXPos);
        }

        public static void TryPlaceStructure(ISuperLayer superLayer, int yPos, int xPos, Structure toPlace) {
            if (superLayer.GetStructureLayerTile(yPos, xPos) != null) {
                superLayer.SetStructureAtPosition(toPlace, yPos, xPos);
            }
        }

        public static bool PlayerCanBuildAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) == null;
        }

        public static bool PlayerCanDestroyAt(int yPos, int xPos) {
            return LMI.Player.CurrSuperLayer.GetStructureLayerTile(yPos, xPos) != null;
        }
    }
}
