namespace MundusTests.ServiceTests.SuperLayers 
{
    using Gtk;
    using Mundus.Data;
    using Mundus.Data.Tiles.Mobs;
    using Mundus.Data.Windows;
    using Mundus.Service.SuperLayers;
    using NUnit.Framework;
    using static Mundus.Service.SuperLayers.ImageController;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    [TestFixture]
    public static class ImageControllerTests 
    {

        [Test]
        [TestCase(1, 5)]
        [TestCase(2, 2)]
        [TestCase(8, 10)]
        public static void GetsCorrectGroundImage(int yPos, int xPos) 
        {
            Image img = null;

            if (DataBaseContexts.LContext.GetGroundLayerStock(yPos, xPos) != null) 
            {
                img = new Image(DataBaseContexts.LContext.GetGroundLayerStock(yPos, xPos), IconSize.Dnd);
            }

            if (img == null) 
            {
                Assert.AreEqual(img, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Ground), $"Ground image at Y:{yPos}, X:{xPos} should be null");
            }
            else 
            {
                Assert.AreEqual(img.Stock, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Ground).Stock, $"Ground image at Y:{yPos}, X:{xPos} should be {img.Stock}, but is {ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Ground).Stock}");
            }
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(2, 2)]
        [TestCase(8, 11)]
        public static void GetsCorrectMobImage(int yPos, int xPos) 
        {
            Image img = null;

            if (DataBaseContexts.LContext.GetMobLayerStock(yPos, xPos) != null) 
            {
                img = new Image(DataBaseContexts.LContext.GetMobLayerStock(yPos, xPos), IconSize.Dnd);
            }

            if (img == null) 
            {
                Assert.AreEqual(img, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Mob), $"Mob image at Y:{yPos}, X:{xPos} should be null");
            }
            else 
            {
                Assert.AreEqual(img.Stock, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Mob).Stock, $"Mob image at Y:{yPos}, X:{xPos} should be {img.Stock}, but is {ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Ground).Stock}");
            }
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(2, 2)]
        [TestCase(8, 11)]
        public static void GetsCorrectStructureImage(int yPos, int xPos) 
        {
            Image img = null;

            if (DataBaseContexts.LContext.GetStructureLayerStock(yPos, xPos) != null) {
                img = new Image(DataBaseContexts.LContext.GetStructureLayerStock(yPos, xPos), IconSize.Dnd);
            }

            if (img == null) {
                Assert.AreEqual(img, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Structure), $"Structure image at Y:{yPos}, X:{xPos} should be null");
            }
            else {
                Assert.AreEqual(img.Stock, ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Structure).Stock, $"Structure image at Y:{yPos}, X:{xPos} should be {img.Stock}, but is {ImageController.GetPlayerScreenImage(yPos, xPos, Layer.Ground).Stock}");
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public static void GetsCorrectPlayerHotbarImage(int index) 
        {
            Image img = new Image("blank", IconSize.Dnd);

            if (MI.Player.Inventory.Hotbar[index] != null) 
            {
                img = new Image(MI.Player.Inventory.Hotbar[index].stock_id, IconSize.Dnd);
            }

            Assert.AreEqual(img.Stock, ImageController.GetPlayerInventoryImage(InventoryPlace.Hotbar, index).Stock, $"Hotbar image at index {index} should be {img.Stock}, but was {ImageController.GetPlayerInventoryImage(InventoryPlace.Hotbar, index).Stock}");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public static void GetsCorrectPlayerItemsImage(int index) 
        {
            Image img = new Image("blank", IconSize.Dnd);

            if (MI.Player.Inventory.Items[index] != null) 
            {
                img = new Image(MI.Player.Inventory.Items[index].stock_id, IconSize.Dnd);
            }

            Assert.AreEqual(img.Stock, ImageController.GetPlayerInventoryImage(InventoryPlace.Items, index).Stock, $"Items image at index {index} should be {img.Stock}, but was {ImageController.GetPlayerInventoryImage(InventoryPlace.Items, index).Stock}");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public static void GetsCorrectPlayerAccessoriesImage(int index) {
            Image img = new Image("blank_gear", IconSize.Dnd);

            if (MI.Player.Inventory.Accessories[index] != null) 
            {
                img = new Image(MI.Player.Inventory.Accessories[index].stock_id, IconSize.Dnd);
            }

            Assert.AreEqual(img.Stock, ImageController.GetPlayerInventoryImage(InventoryPlace.Accessories, index).Stock, $"Accessories image at index {index} should be {img.Stock}, but was {ImageController.GetPlayerInventoryImage(InventoryPlace.Accessories, index).Stock}");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public static void GetsCorrectPlayerGearImage(int index) 
        {
            Image img = new Image("blank_gear", IconSize.Dnd);

            if (MI.Player.Inventory.Gear[index] != null) 
            {
                img = new Image(MI.Player.Inventory.Gear[index].stock_id, IconSize.Dnd);
            }

            Assert.AreEqual(img.Stock, ImageController.GetPlayerInventoryImage(InventoryPlace.Gear, index).Stock, $"Gear image at index {index} should be {img.Stock}, but was {ImageController.GetPlayerInventoryImage(InventoryPlace.Gear, index).Stock}");
        }
    }
}
