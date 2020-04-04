using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Crafting {
    public class CraftingRecipie {
        public ItemTile Result { get; private set; }

        public int Count1 { get; private set; }
        public ItemTile ReqItem1 { get; private set; }

        public int Count2 { get; private set; }
        public ItemTile ReqItem2 { get; private set; }

        public int Count3 { get; private set; }
        public ItemTile ReqItem3 { get; private set; }

        public int Count4 { get; private set; }
        public ItemTile ReqItem4 { get; private set; }

        public int Count5 { get; private set; }
        public ItemTile ReqItem5 { get; private set; }

        public CraftingRecipie(ItemTile result, int count1, ItemTile reqItem1) :this(result, count1, reqItem1, 0, null, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipie(ItemTile result, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2) : this(result, count1, reqItem1, count2, reqItem2, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipie(ItemTile result, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3) : this(result, count1, reqItem1, count2, reqItem2, count3, reqItem3, 0, null, 0, null) 
        { }

        public CraftingRecipie(ItemTile result, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3, int count4, ItemTile reqItem4) : this(result, count1, reqItem1, count2, reqItem2, count3, reqItem3, count4, reqItem4, 0, null) 
        { }

        public CraftingRecipie(ItemTile result, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3, int count4, ItemTile reqItem4, int count5, ItemTile reqItem5) {
            this.Result = result;

            this.Count1 = count1;
            this.ReqItem1 = reqItem1;

            this.Count2 = count2;
            this.ReqItem2 = reqItem2;

            this.Count3 = count3;
            this.ReqItem3 = reqItem3;

            this.Count4 = count4;
            this.ReqItem4 = reqItem4;

            this.Count5 = count5;
            this.ReqItem5 = reqItem5;
        }
    }
}
