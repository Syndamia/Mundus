using System.Collections.Generic;
using System.Linq;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Crafting {
    public class CraftingRecipe {
        public ItemTile ResultItem { get; private set; }

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

        public CraftingRecipe(ItemTile resultItem, int count1, ItemTile reqItem1) :this(resultItem, count1, reqItem1, 0, null, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipe(ItemTile resultItem, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2) : this(resultItem, count1, reqItem1, count2, reqItem2, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipe(ItemTile resultItem, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, 0, null, 0, null) 
        { }

        public CraftingRecipe(ItemTile resultItem, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3, int count4, ItemTile reqItem4) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, count4, reqItem4, 0, null) 
        { }

        public CraftingRecipe(ItemTile resultItem, int count1, ItemTile reqItem1, int count2, ItemTile reqItem2, int count3, ItemTile reqItem3, int count4, ItemTile reqItem4, int count5, ItemTile reqItem5) {
            this.ResultItem = resultItem;

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

        //ugly af, but will rewrite when I imntegrade data bases
        public bool HasEnoughItems(Dictionary<ItemTile, int> itemsAndCounts) {
            bool hasEnough = true;

            if (ReqItem1 != null && hasEnough) {
                if (itemsAndCounts.Keys.Any(k => k.stock_id == ReqItem1.stock_id)) {
                    hasEnough = itemsAndCounts.First(x => x.Key.stock_id == ReqItem1.stock_id).Value >= Count1;
                }
                else hasEnough = false;
            }

            if (ReqItem2 != null && hasEnough) {
                if (itemsAndCounts.Keys.Any(k => k.stock_id == ReqItem2.stock_id)) {
                    hasEnough = itemsAndCounts.First(x => x.Key.stock_id == ReqItem2.stock_id).Value >= Count2;
                }
                else hasEnough = false;
            }

            if (ReqItem3 != null && hasEnough) {
                if (itemsAndCounts.Keys.Any(k => k.stock_id == ReqItem3.stock_id)) {
                    hasEnough = itemsAndCounts.First(x => x.Key.stock_id == ReqItem3.stock_id).Value >= Count3;
                }
                else hasEnough = false;
            }

            if (ReqItem4 != null && hasEnough) {
                if (itemsAndCounts.Keys.Any(k => k.stock_id == ReqItem4.stock_id)) {
                    hasEnough = itemsAndCounts.First(x => x.Key.stock_id == ReqItem4.stock_id).Value >= Count4;
                }
                else hasEnough = false;
            }

            if (ReqItem5 != null && hasEnough) {
                if (itemsAndCounts.Keys.Any(k => k.stock_id == ReqItem5.stock_id)) {
                    hasEnough = itemsAndCounts.First(x => x.Key.stock_id == ReqItem5.stock_id).Value >= Count5;
                }
                else hasEnough = false;
            }

            return hasEnough;
        }

        public bool HasEnoughOfItem(ItemTile item, int count) {
            if (ReqItem1.stock_id == item.stock_id) return count >= Count1;
            if (ReqItem2.stock_id == item.stock_id) return count >= Count2;
            if (ReqItem3.stock_id == item.stock_id) return count >= Count3;
            if (ReqItem4.stock_id == item.stock_id) return count >= Count4;
            if (ReqItem5.stock_id == item.stock_id) return count >= Count5;
            return false;
        }

        public Dictionary<ItemTile, int> GetRequiredItemsAndCounts() {
            Dictionary<ItemTile, int> req = new Dictionary<ItemTile, int>();

            req.Add(ReqItem1, Count1);
            if (ReqItem2 != null) req.Add(ReqItem2, Count2);
            if (ReqItem3 != null) req.Add(ReqItem3, Count3);
            if (ReqItem4 != null) req.Add(ReqItem4, Count4);
            if (ReqItem5 != null) req.Add(ReqItem5, Count5);

            return req;
        }
    }
}
