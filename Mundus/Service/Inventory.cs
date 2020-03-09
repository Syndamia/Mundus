using Mundus.Service.Tiles;

namespace Mundus.Service {
    public class Inventory {
        public ItemTile[] Hotbar { get; set; }
        public ItemTile[] Items { get; set; }
        public ItemTile[] Accessories { get; set; }
        public ItemTile[] Gear { get; set; }

        public Inventory(int screenInvSize) {
            this.SetNewSizes(screenInvSize);
        }

        public void SetNewSizes(int screenInvSize) {
            this.Hotbar = new ItemTile[screenInvSize];
            this.Items = new ItemTile[screenInvSize * screenInvSize];
            this.Accessories = new ItemTile[screenInvSize * 2];
            this.Gear = new ItemTile[screenInvSize];
        }

        public void AddItem(string place, ItemTile newItem) {
            ItemTile[] tmp = null;
            switch (place.ToLower()) {
                case "hotbar": tmp = this.Hotbar; break;
                case "items": tmp = this.Items; break;
                case "accessories": tmp = this.Accessories; break;
                case "gear": tmp = this.Gear; break; 
            }

            for (int i = 0; i < tmp.Length; i++) {
                if (tmp[i] == null) {
                    tmp[i] = newItem;
                    break;
                }
            }
        }

        public void RemoveItem(string place, int index) {
            switch (place.ToLower()) {
                case "hotbar": this.Hotbar[index] = null; break;
                case "items": this.Items[index] = null; break;
                case "accessories": this.Accessories[index] = null; break;
                case "gear": this.Gear[index] = null; break;
            }
        }
    }
}
