using System;
using Mundus.Data;
using NUnit.Framework;
using Gtk;
using Mundus.Data.Windows;
using static Mundus.Service.Tiles.Mobs.Inventory;
using Mundus.Service.Tiles.Items;
using Mundus.Service.Tiles.Mobs;

namespace MundusTests.ServiceTests.Tiles.Items {
    [TestFixture]
    public static class ItemControllerTests {
        [Test]
        [TestCase(InventoryPlace.Accessories, 1)]
        [TestCase(InventoryPlace.Hotbar, 4)]
        public static void SelectsItemProperly(InventoryPlace place, int index) {
            ItemController.SelectItem(place, index);

            Assert.AreEqual(place, ItemController.SelItemPlace, "Item place isn't set correctly");
            Assert.AreEqual(index, ItemController.SelItemIndex, "Item index isn't set correctly");
        }

        [Test]
        [TestCase(InventoryPlace.Hotbar, 1, InventoryPlace.Items, 1)]
        public static void SwitchesDifferentItemsProperly(InventoryPlace origin, int originIndex, InventoryPlace destination, int destinationIndex) {
            ItemController.SelectItem(destination, destinationIndex);
            var destinationItem = Inventory.GetPlayerItemFromItemSelection();

            ItemController.SelectItem(origin, originIndex);
            var originItem = Inventory.GetPlayerItemFromItemSelection();

            ItemController.SwitchItems(destination, destinationIndex);

            ItemController.SelectItem(origin, originIndex);
            if (Inventory.GetPlayerItemFromItemSelection() != null) {
                Assert.AreEqual(destinationItem.stock_id, Inventory.GetPlayerItemFromItemSelection().stock_id);
            }
            else {
                Assert.Pass();
            }

            ItemController.SelectItem(destination, destinationIndex);
            if (Inventory.GetPlayerItemFromItemSelection() != null) {
                Assert.AreEqual(originItem.stock_id, Inventory.GetPlayerItemFromItemSelection());
            }
            else {
                Assert.Pass();
            }
        }
    }
}
