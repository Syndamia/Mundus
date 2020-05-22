namespace MundusTests.ServiceTests.Tiles.Mobs 
{
    using Mundus.Service.Tiles.Items.Types;
    using Mundus.Service.Tiles.Mobs;
    using NUnit.Framework;

    [TestFixture]
    public static class InventoryTests 
    {
        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AddsToHotbar(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToHotbar(new Material(stock_id1), 2);
            inv.AddToHotbar(new Material(stock_id2), 4);

            Assert.AreEqual(stock_id1, inv.Hotbar[2].stock_id, "Add to hotbar doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Hotbar[4].stock_id, "Add to hotbar doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AddsToItems(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToItems(new Material(stock_id1), 2);
            inv.AddToItems(new Material(stock_id2), 4);

            Assert.AreEqual(stock_id1, inv.Items[2].stock_id, "Add to items doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Items[4].stock_id, "Add to items doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AddsToAccessories(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToAccessories(new Gear(stock_id1), 2);
            inv.AddToAccessories(new Gear(stock_id2), 4);

            Assert.AreEqual(stock_id1, inv.Accessories[2].stock_id, "Add to accessories doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Accessories[4].stock_id, "Add to accessories doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AddsToGear(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToGear(new Gear(stock_id1), 2);
            inv.AddToGear(new Gear(stock_id2), 4);

            Assert.AreEqual(stock_id1, inv.Gear[2].stock_id, "Add to gear doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Gear[4].stock_id, "Add to gear doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AppendsToHotbar(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AppendToHotbar(new Material(stock_id1));
            inv.AppendToHotbar(new Material(stock_id2));

            Assert.AreEqual(stock_id1, inv.Hotbar[0].stock_id, "Append to hotbar doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Hotbar[1].stock_id, "Append to hotbar doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AppendsToItems(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AppendToItems(new Material(stock_id1));
            inv.AppendToItems(new Material(stock_id2));

            Assert.AreEqual(stock_id1, inv.Items[0].stock_id, "Append to items doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Items[1].stock_id, "Append to items doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AppendsToAccessories(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AppendToAccessories(new Gear(stock_id1));
            inv.AppendToAccessories(new Gear(stock_id2));

            Assert.AreEqual(stock_id1, inv.Accessories[0].stock_id, "Append to accessories doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Accessories[1].stock_id, "Append to accessories doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void AppendsToGear(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AppendToGear(new Gear(stock_id1));
            inv.AppendToGear(new Gear(stock_id2));

            Assert.AreEqual(stock_id1, inv.Gear[0].stock_id, "Append to gear doesn't work as expected");
            Assert.AreEqual(stock_id2, inv.Gear[1].stock_id, "Append to gear doesn't work as expected");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void DeletesFromHotbar(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToHotbar(new Gear(stock_id1), 2);
            inv.AddToHotbar(new Gear(stock_id2), 4);

            inv.DeleteFromHotbar(2);
            inv.DeleteFromHotbar(4);

            Assert.IsNull(inv.Hotbar[2], "Doesn't delete item properly from hotbar");
            Assert.IsNull(inv.Hotbar[4], "Doesn't delete item properly from hotbar");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void DeletesFromItems(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToItems(new Gear(stock_id1), 2);
            inv.AddToItems(new Gear(stock_id2), 4);

            inv.DeleteFromItems(2);
            inv.DeleteFromItems(4);

            Assert.IsNull(inv.Items[2], "Doesn't delete item properly from items");
            Assert.IsNull(inv.Items[4], "Doesn't delete item properly from items");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void DeletesFromAccessories(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToAccessories(new Gear(stock_id1), 2);
            inv.AddToAccessories(new Gear(stock_id2), 4);

            inv.DeleteFromAccessories(2);
            inv.DeleteFromAccessories(4);

            Assert.IsNull(inv.Accessories[2], "Doesn't delete item properly from accessories");
            Assert.IsNull(inv.Accessories[4], "Doesn't delete item properly from accessories");
        }

        [Test]
        [TestCase("one", "two")]
        [TestCase(null, "two")]
        [TestCase("", "two")]
        public static void DeletesFromGear(string stock_id1, string stock_id2) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToGear(new Gear(stock_id1), 2);
            inv.AddToGear(new Gear(stock_id2), 4);

            inv.DeleteFromGear(2);
            inv.DeleteFromGear(4);

            Assert.IsNull(inv.Gear[2], "Doesn't delete item properly from gear");
            Assert.IsNull(inv.Gear[4], "Doesn't delete item properly from gear");
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public static void InstantiatesProperly(int size) 
        {
            Inventory inv = new Inventory(size);

            Assert.AreEqual(size, inv.Hotbar.Length, "Hotbar has incorrect size");
            Assert.AreEqual(size * size, inv.Items.Length, "Items has incorrect size");
            Assert.AreEqual(size * 2, inv.Accessories.Length, "Accessories has incorrect size");
            Assert.AreEqual(size, inv.Gear.Length, "Gear has incorrect size");
        }

        [Test]
        [TestCase("one", 3)]
        [TestCase(null, 1)]
        [TestCase("", 4)]
        public static void GetsProperHotbarItemTile(string stock_id, int index) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToHotbar(new Material(stock_id), index);

            Assert.AreEqual(stock_id, inv.GetItemTile(Inventory.InventoryPlace.Hotbar, index).stock_id);
        }

        [Test]
        [TestCase("one", 3)]
        [TestCase(null, 1)]
        [TestCase("", 4)]
        public static void GetsProperItemsItemTile(string stock_id, int index) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToItems(new Material(stock_id), index);

            Assert.AreEqual(stock_id, inv.GetItemTile(Inventory.InventoryPlace.Items, index).stock_id);
        }

        [Test]
        [TestCase("one", 3)]
        [TestCase(null, 1)]
        [TestCase("", 4)]
        public static void GetsProperAccessoriesItemTile(string stock_id, int index) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToAccessories(new Gear(stock_id), index);

            Assert.AreEqual(stock_id, inv.GetItemTile(Inventory.InventoryPlace.Accessories, index).stock_id);
        }

        [Test]
        [TestCase("one", 3)]
        [TestCase(null, 1)]
        [TestCase("", 4)]
        public static void GetsProperGearItemTile(string stock_id, int index) 
        {
            Inventory inv = new Inventory(5);

            inv.AddToGear(new Gear(stock_id), index);

            Assert.AreEqual(stock_id, inv.GetItemTile(Inventory.InventoryPlace.Gear, index).stock_id);
        }
    }
}
