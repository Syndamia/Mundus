namespace Mundus.Views.Windows.GameWindows.Small 
{
    using Gtk;
    using Mundus.Data.Dialogues;
    using Mundus.Service.Tiles.Items;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    public partial class SmallGameWindow : Gtk.Window, IGameWindow 
    {
        public SmallGameWindow() : base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
        }

        /// <summary>
        /// Gets value for the height and width of the game screen, map screens and inventory screen 
        /// and the width of stats, hotbar, accessories, gear and items on the ground menus
        /// </summary>
        public int Size { get; private set; }

        public void OnDeleteEvent(object o, Gtk.DeleteEventArgs args) 
        {
            ResponseType rt = (ResponseType)DI.DExit.Run();
            DI.DExit.Hide();

            if(rt == ResponseType.Close) 
            {
                Application.Quit();
            }
            else 
            {
                args.RetVal = true;
            }
        }

        public void SetDefaults() 
        {
            this.Size = 5;
            this.SetMapMenuVisibility(false);
            this.SetInvMenuVisibility(false);
        }

        private void SelectItem(InventoryPlace place, int index) 
        { 
            if (ItemController.HasSelectedItem()) {
                ItemController.SwitchItems(place, index);
            }
            else {
                ItemController.SelectItem(place, index);
            }

            this.PrintMainMenu();
            this.PrintInventory();
        }

        public void PrintMapOrInv() 
        {
            if (this.MapMenuIsVisible()) 
            {
                this.PrintMap();
            }
            else if (this.InvMenuIsVisible()) 
            {
                this.PrintInventory();
            }
        }

        private bool MapMenuIsVisible() 
        {
            return imgG1.Visible;
        }

        private bool InvMenuIsVisible() 
        {
            return btnI1.Visible;
        }

        /// <summary>
        /// The map menu is the left menu with the grond layer, structure layer, coordinates, superlayer and "ground above player" items
        /// </summary>
        private void SetMapMenuVisibility(bool isVisible) 
        {
            lblGroundLayer.Visible = isVisible;
            imgG1.Visible = isVisible;
            imgG2.Visible = isVisible;
            imgG3.Visible = isVisible;
            imgG4.Visible = isVisible;
            imgG5.Visible = isVisible;
            imgG6.Visible = isVisible;
            imgG7.Visible = isVisible;
            imgG8.Visible = isVisible;
            imgG9.Visible = isVisible;
            imgG10.Visible = isVisible;
            imgG11.Visible = isVisible;
            imgG12.Visible = isVisible;
            imgG13.Visible = isVisible;
            imgG14.Visible = isVisible;
            imgG15.Visible = isVisible;
            imgG16.Visible = isVisible;
            imgG17.Visible = isVisible;
            imgG18.Visible = isVisible;
            imgG19.Visible = isVisible;
            imgG20.Visible = isVisible;
            imgG21.Visible = isVisible;
            imgG22.Visible = isVisible;
            imgG23.Visible = isVisible;
            imgG24.Visible = isVisible;
            imgG25.Visible = isVisible;

            lblSuperLayer.Visible = isVisible;
            lblCoord1.Visible = isVisible;
            lblCoord2.Visible = isVisible;

            lblItemLayer.Visible = isVisible;
            imgI1.Visible = isVisible;
            imgI2.Visible = isVisible;
            imgI3.Visible = isVisible;
            imgI4.Visible = isVisible;
            imgI5.Visible = isVisible;
            imgI6.Visible = isVisible;
            imgI7.Visible = isVisible;
            imgI8.Visible = isVisible;
            imgI9.Visible = isVisible;
            imgI10.Visible = isVisible;
            imgI11.Visible = isVisible;
            imgI12.Visible = isVisible;
            imgI13.Visible = isVisible;
            imgI14.Visible = isVisible;
            imgI15.Visible = isVisible;
            imgI16.Visible = isVisible;
            imgI17.Visible = isVisible;
            imgI18.Visible = isVisible;
            imgI19.Visible = isVisible;
            imgI20.Visible = isVisible;
            imgI21.Visible = isVisible;
            imgI22.Visible = isVisible;
            imgI23.Visible = isVisible;
            imgI24.Visible = isVisible;
            imgI25.Visible = isVisible;

            lblHoleMsg.Visible = isVisible;
            lblHoleOnTop.Visible = isVisible;

            lblBlank5.Visible = isVisible;
        }

        /// <summary>
        /// The inventory menu is the right menu with the items, accessories, gear incentories, item info and crafting button
        /// </summary>
        private void SetInvMenuVisibility(bool isVisible) 
        {
            btnI1.Visible = isVisible;
            btnI2.Visible = isVisible;
            btnI3.Visible = isVisible;
            btnI4.Visible = isVisible;
            btnI5.Visible = isVisible;
            btnI6.Visible = isVisible;
            btnI7.Visible = isVisible;
            btnI8.Visible = isVisible;
            btnI9.Visible = isVisible;
            btnI10.Visible = isVisible;
            btnI11.Visible = isVisible;
            btnI12.Visible = isVisible;
            btnI13.Visible = isVisible;
            btnI14.Visible = isVisible;
            btnI15.Visible = isVisible;
            btnI16.Visible = isVisible;
            btnI17.Visible = isVisible;
            btnI18.Visible = isVisible;
            btnI19.Visible = isVisible;
            btnI20.Visible = isVisible;
            btnI21.Visible = isVisible;
            btnI22.Visible = isVisible;
            btnI23.Visible = isVisible;
            btnI24.Visible = isVisible;
            btnI25.Visible = isVisible;
            btnCrafting.Visible = isVisible;

            lblAccessories.Visible = isVisible;
            btnA1.Visible = isVisible;
            btnA2.Visible = isVisible;
            btnA3.Visible = isVisible;
            btnA4.Visible = isVisible;
            btnA5.Visible = isVisible;
            btnA6.Visible = isVisible;
            btnA7.Visible = isVisible;
            btnA8.Visible = isVisible;
            btnA9.Visible = isVisible;
            btnA10.Visible = isVisible;

            lblGear.Visible = isVisible;
            btnG1.Visible = isVisible;
            btnG2.Visible = isVisible;
            btnG3.Visible = isVisible;
            btnG4.Visible = isVisible;
            btnG5.Visible = isVisible;

            imgInfo.Visible = isVisible;
            lblInfo.Visible = isVisible;

            lblBlank4.Visible = isVisible;
        }
    }
}
