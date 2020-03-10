using Mundus.Service.Tiles.Items;

namespace Mundus.Service {
    public class Inventory {
        public Tool Hand { get; set; }
        public Material[] Hotbar { get; set; }
        public Material[] Items { get; set; }
        public Gear[] Accessories { get; set; }
        public Gear[] Gear { get; set; }

        public Inventory(int screenInvSize) {
            this.SetNewSizes(screenInvSize);
        }

        public void SetNewSizes(int screenInvSize) {
            this.Hotbar = new Material[screenInvSize - 1];
            this.Items = new Material[screenInvSize * screenInvSize];
            this.Accessories = new Gear[screenInvSize * 2];
            this.Gear = new Gear[screenInvSize];
        }

        public void AddItem(string place, ItemTile newItem) {
            ItemTile[] tmp = null;
            switch (place.ToLower()) {
                case "hand": tmp[0] = this.Hand; break;
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
