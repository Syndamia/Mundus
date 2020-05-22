namespace Mundus.Views.Windows.GameWindows.Large 
{
    using Gtk;
    using Mundus.Data.Dialogues;
    using Mundus.Service.Tiles.Items;
    using static Mundus.Service.Tiles.Mobs.Inventory;

    public partial class LargeGameWindow : Gtk.Window, IGameWindow  
        {

        public LargeGameWindow() : base(Gtk.WindowType.Toplevel)  
        {
            this.Build();
        }

        /// <summary>
        /// Gets value for the height and width of the game screen, map screens and inventory screen 
        /// and the width of stats, hotbar, accessories, gear and items on the ground menus
        /// </summary>
        public int Size { get; private set; }

        public void OnDeleteEvent(object o, DeleteEventArgs args)  
        {
            ResponseType rt = (ResponseType)DI.DExit.Run();
            DI.DExit.Hide();

            if (rt == ResponseType.Close) {
                Application.Quit();
            }
            else {
                args.RetVal = true;
            }
        }

        public void SetDefaults()  
        {
            this.Size = 9;
            this.SetMapMenuVisibility(false);
            this.SetInvMenuVisibility(false);
        }

        private void SelectItem(InventoryPlace place, int index) {
            if (ItemController.HasSelectedItem()) {
                ItemController.SwitchItems(place, index);
            }
            else {
                ItemController.SelectItem(place, index);
            }

            this.PrintMainMenu();
            this.PrintInventory();
        }

        public void PrintMapOrInv() {
            if (this.MapMenuIsVisible()) {
                this.PrintMap();
            }
            else if (this.InvMenuIsVisible()) {
                this.PrintInventory();
            }
        }

        private bool InvMenuIsVisible()  
        {
            return btnI1.Visible;
        }

        private bool MapMenuIsVisible()  
        {
            return imgG1.Visible;
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
            imgG26.Visible = isVisible;
            imgG27.Visible = isVisible;
            imgG28.Visible = isVisible;
            imgG29.Visible = isVisible;
            imgG30.Visible = isVisible;
            imgG31.Visible = isVisible;
            imgG32.Visible = isVisible;
            imgG33.Visible = isVisible;
            imgG34.Visible = isVisible;
            imgG35.Visible = isVisible;
            imgG36.Visible = isVisible;
            imgG37.Visible = isVisible;
            imgG38.Visible = isVisible;
            imgG39.Visible = isVisible;
            imgG40.Visible = isVisible;
            imgG41.Visible = isVisible;
            imgG42.Visible = isVisible;
            imgG43.Visible = isVisible;
            imgG44.Visible = isVisible;
            imgG45.Visible = isVisible;
            imgG46.Visible = isVisible;
            imgG47.Visible = isVisible;
            imgG48.Visible = isVisible;
            imgG49.Visible = isVisible;
            imgG50.Visible = isVisible;
            imgG51.Visible = isVisible;
            imgG52.Visible = isVisible;
            imgG53.Visible = isVisible;
            imgG54.Visible = isVisible;
            imgG55.Visible = isVisible;
            imgG56.Visible = isVisible;
            imgG57.Visible = isVisible;
            imgG58.Visible = isVisible;
            imgG59.Visible = isVisible;
            imgG60.Visible = isVisible;
            imgG61.Visible = isVisible;
            imgG62.Visible = isVisible;
            imgG63.Visible = isVisible;
            imgG64.Visible = isVisible;
            imgG65.Visible = isVisible;
            imgG66.Visible = isVisible;
            imgG67.Visible = isVisible;
            imgG68.Visible = isVisible;
            imgG69.Visible = isVisible;
            imgG70.Visible = isVisible;
            imgG71.Visible = isVisible;
            imgG72.Visible = isVisible;
            imgG73.Visible = isVisible;
            imgG74.Visible = isVisible;
            imgG75.Visible = isVisible;
            imgG76.Visible = isVisible;
            imgG77.Visible = isVisible;
            imgG78.Visible = isVisible;
            imgG79.Visible = isVisible;
            imgG80.Visible = isVisible;
            imgG81.Visible = isVisible;

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
            imgI26.Visible = isVisible;
            imgI27.Visible = isVisible;
            imgI28.Visible = isVisible;
            imgI29.Visible = isVisible;
            imgI30.Visible = isVisible;
            imgI31.Visible = isVisible;
            imgI32.Visible = isVisible;
            imgI33.Visible = isVisible;
            imgI34.Visible = isVisible;
            imgI35.Visible = isVisible;
            imgI36.Visible = isVisible;
            imgI37.Visible = isVisible;
            imgI38.Visible = isVisible;
            imgI39.Visible = isVisible;
            imgI40.Visible = isVisible;
            imgI41.Visible = isVisible;
            imgI42.Visible = isVisible;
            imgI43.Visible = isVisible;
            imgI44.Visible = isVisible;
            imgI45.Visible = isVisible;
            imgI46.Visible = isVisible;
            imgI47.Visible = isVisible;
            imgI48.Visible = isVisible;
            imgI49.Visible = isVisible;
            imgI50.Visible = isVisible;
            imgI51.Visible = isVisible;
            imgI52.Visible = isVisible;
            imgI53.Visible = isVisible;
            imgI54.Visible = isVisible;
            imgI55.Visible = isVisible;
            imgI56.Visible = isVisible;
            imgI57.Visible = isVisible;
            imgI58.Visible = isVisible;
            imgI59.Visible = isVisible;
            imgI60.Visible = isVisible;
            imgI61.Visible = isVisible;
            imgI62.Visible = isVisible;
            imgI63.Visible = isVisible;
            imgI64.Visible = isVisible;
            imgI65.Visible = isVisible;
            imgI66.Visible = isVisible;
            imgI67.Visible = isVisible;
            imgI68.Visible = isVisible;
            imgI69.Visible = isVisible;
            imgI70.Visible = isVisible;
            imgI71.Visible = isVisible;
            imgI72.Visible = isVisible;
            imgI73.Visible = isVisible;
            imgI74.Visible = isVisible;
            imgI75.Visible = isVisible;
            imgI76.Visible = isVisible;
            imgI77.Visible = isVisible;
            imgI78.Visible = isVisible;
            imgI79.Visible = isVisible;
            imgI80.Visible = isVisible;
            imgI81.Visible = isVisible;

            lblHoleMsg.Visible = isVisible;
            lblHoleOnTop.Visible = isVisible;

            lblBlank6.Visible = isVisible;
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
            btnI26.Visible = isVisible;
            btnI27.Visible = isVisible;
            btnI28.Visible = isVisible;
            btnI29.Visible = isVisible;
            btnI30.Visible = isVisible;
            btnI31.Visible = isVisible;
            btnI32.Visible = isVisible;
            btnI33.Visible = isVisible;
            btnI34.Visible = isVisible;
            btnI35.Visible = isVisible;
            btnI36.Visible = isVisible;
            btnI37.Visible = isVisible;
            btnI38.Visible = isVisible;
            btnI39.Visible = isVisible;
            btnI40.Visible = isVisible;
            btnI41.Visible = isVisible;
            btnI42.Visible = isVisible;
            btnI43.Visible = isVisible;
            btnI44.Visible = isVisible;
            btnI45.Visible = isVisible;
            btnI46.Visible = isVisible;
            btnI47.Visible = isVisible;
            btnI48.Visible = isVisible;
            btnI49.Visible = isVisible;
            btnI50.Visible = isVisible;
            btnI51.Visible = isVisible;
            btnI52.Visible = isVisible;
            btnI53.Visible = isVisible;
            btnI54.Visible = isVisible;
            btnI55.Visible = isVisible;
            btnI56.Visible = isVisible;
            btnI57.Visible = isVisible;
            btnI58.Visible = isVisible;
            btnI59.Visible = isVisible;
            btnI60.Visible = isVisible;
            btnI61.Visible = isVisible;
            btnI62.Visible = isVisible;
            btnI63.Visible = isVisible;
            btnI64.Visible = isVisible;
            btnI65.Visible = isVisible;
            btnI66.Visible = isVisible;
            btnI67.Visible = isVisible;
            btnI68.Visible = isVisible;
            btnI69.Visible = isVisible;
            btnI70.Visible = isVisible;
            btnI71.Visible = isVisible;
            btnI72.Visible = isVisible;
            btnI73.Visible = isVisible;
            btnI74.Visible = isVisible;
            btnI75.Visible = isVisible;
            btnI76.Visible = isVisible;
            btnI77.Visible = isVisible;
            btnI78.Visible = isVisible;
            btnI79.Visible = isVisible;
            btnI80.Visible = isVisible;
            btnI81.Visible = isVisible;
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
            btnA11.Visible = isVisible;
            btnA12.Visible = isVisible;
            btnA13.Visible = isVisible;
            btnA14.Visible = isVisible;
            btnA15.Visible = isVisible;
            btnA16.Visible = isVisible;
            btnA17.Visible = isVisible;
            btnA18.Visible = isVisible;

            lblGear.Visible = isVisible;
            btnG1.Visible = isVisible;
            btnG2.Visible = isVisible;
            btnG3.Visible = isVisible;
            btnG4.Visible = isVisible;
            btnG5.Visible = isVisible;
            btnG6.Visible = isVisible;
            btnG7.Visible = isVisible;
            btnG8.Visible = isVisible;
            btnG9.Visible = isVisible;

            imgInfo.Visible = isVisible;
            lblInfo.Visible = isVisible;

            lblBlank6.Visible = isVisible;
        }
    }
}
