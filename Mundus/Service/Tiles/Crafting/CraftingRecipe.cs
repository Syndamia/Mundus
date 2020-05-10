using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Mundus.Service.Tiles.Items;

namespace Mundus.Service.Tiles.Crafting {
    [Table("Recipes", Schema = "Mundus")]
    public class CraftingRecipe {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Item that will be added to the inventory after crafting
        /// </summary>
        /// <value>The result item.</value>
        public string ResultItem { get; private set; }

        /// <summary>
        /// Required amount of the first item
        /// </summary>
        public int Count1 { get; private set; }
        /// <summary>
        /// Required first item
        /// </summary>
        public string ReqItem1 { get; private set; }

        /// <summary>
        /// Required amount of the second item
        /// </summary>
        public int Count2 { get; private set; }
        /// <summary>
        /// Required second item
        /// </summary>
        public string ReqItem2 { get; private set; }

        /// <summary>
        /// Required amount of the third item
        /// </summary>
        public int Count3 { get; private set; }
        /// <summary>
        /// Required third item
        /// </summary>
        public string ReqItem3 { get; private set; }

        /// <summary>
        /// Required amount of the fourth item
        /// </summary>
        public int Count4 { get; private set; }
        /// <summary>
        /// Required fourth item
        /// </summary>
        public string ReqItem4 { get; private set; }

        /// <summary>
        /// Required amount of the fifth item
        /// </summary>
        public int Count5 { get; private set; }
        /// <summary>
        /// Required fifth item
        /// </summary>
        public string ReqItem5 { get; private set; }

        public CraftingRecipe(string resultItem, int count1, string reqItem1) :this(resultItem, count1, reqItem1, 0, null, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2) : this(resultItem, count1, reqItem1, count2, reqItem2, 0, null, 0, null, 0, null) 
        { }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, 0, null, 0, null) 
        { }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3, int count4, string reqItem4) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, count4, reqItem4, 0, null) 
        { }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3, int count4, string reqItem4, int count5, string reqItem5) {
            this.ResultItem = resultItem;

            this.Count1 = count1;
            this.ReqItem1 = reqItem1;

            this.Count2 = count2;
            this.ReqItem2 = reqItem2;  //reqItem2.stock_id;

            this.Count3 = count3;
            this.ReqItem3 = reqItem3;  //reqItem3.stock_id;

            this.Count4 = count4;
            this.ReqItem4 = reqItem4;  //reqItem4.stock_id;

            this.Count5 = count5;
            this.ReqItem5 = reqItem5; //reqItem5.stock_id;
        }

        //ugly af, but will rewrite when I imntegrade data bases
        /// <summary>
        /// Checks if the parameter has enough of every requried item
        /// </summary>
        /// <returns><c>true</c>If has enough<c>false</c>otherwise</returns>
        /// <param name="items">Player items inventory (Inventory.Items)</param>
        public bool HasEnoughItems(ItemTile[] items) {
            bool hasEnough = false;

            if (items.Any(r => r != null)) {
                var allItems = items.Where(x => x != null).Select(x => x.stock_id).ToArray();

                hasEnough = allItems.Contains(ReqItem1) &&
                            allItems.Count(i => i == ReqItem1) >= Count1;

                if (ReqItem2 != null && hasEnough) {
                    hasEnough = allItems.Contains(ReqItem2) &&
                            allItems.Count(i => i == ReqItem2) >= Count2;
                }
                if (ReqItem3 != null && hasEnough) {
                    hasEnough = allItems.Contains(ReqItem3) &&
                            allItems.Count(i => i == ReqItem3) >= Count3;
                }
                if (ReqItem4 != null && hasEnough) {
                    hasEnough = allItems.Contains(ReqItem4) &&
                            allItems.Count(i => i == ReqItem4) >= Count4;
                }
                if (ReqItem5 != null && hasEnough) {
                    hasEnough = allItems.Contains(ReqItem5) &&
                            allItems.Count(i => i == ReqItem5) >= Count5;
                }
            }

            return hasEnough;
        }

        public string[] GetAllRequiredItems() {
            return new string[] { ReqItem1, ReqItem2, ReqItem3, ReqItem4, ReqItem5};
        }

        public int[] GetAllCounts() {
            return new int[] { Count1, Count2, Count3, Count4, Count5};
        }
    }
}
