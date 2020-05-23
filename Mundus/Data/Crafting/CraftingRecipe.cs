namespace Mundus.Data.Crafting 
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CraftingRecipes", Schema = "Mundus")]
    public class CraftingRecipe 
    {
        public CraftingRecipe(string resultItem, int count1, string reqItem1) : this(resultItem, count1, reqItem1, 0, null, 0, null, 0, null, 0, null) 
        { 
        }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2) : this(resultItem, count1, reqItem1, count2, reqItem2, 0, null, 0, null, 0, null) 
        { 
        }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, 0, null, 0, null) 
        { 
        }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3, int count4, string reqItem4) : this(resultItem, count1, reqItem1, count2, reqItem2, count3, reqItem3, count4, reqItem4, 0, null) 
        { 
        }

        public CraftingRecipe(string resultItem, int count1, string reqItem1, int count2, string reqItem2, int count3, string reqItem3, int count4, string reqItem4, int count5, string reqItem5) 
        {
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

        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets the item that will be added to the inventory after crafting
        /// </summary>
        /// <value>The result item.</value>
        public string ResultItem { get; private set; }

        /// <summary>
        /// Gets the required amount of the first item
        /// </summary>
        public int Count1 { get; private set; }

        /// <summary>
        /// Gets the required first item
        /// </summary>
        public string ReqItem1 { get; private set; }

        /// <summary>
        /// Gets the required amount of the second item
        /// </summary>
        public int Count2 { get; private set; }

        /// <summary>
        /// Gets the required second item
        /// </summary>
        public string ReqItem2 { get; private set; }

        /// <summary>
        /// Gets the required amount of the third item
        /// </summary>
        public int Count3 { get; private set; }

        /// <summary>
        /// Gets the required third item
        /// </summary>
        public string ReqItem3 { get; private set; }

        /// <summary>
        /// Gets the required amount of the fourth item
        /// </summary>
        public int Count4 { get; private set; }

        /// <summary>
        /// Gets the required fourth item
        /// </summary>
        public string ReqItem4 { get; private set; }

        /// <summary>
        /// Gets the required amount of the fifth item
        /// </summary>
        public int Count5 { get; private set; }

        /// <summary>
        /// Gets the required fifth item
        /// </summary>
        public string ReqItem5 { get; private set; }

        public string[] GetAllRequiredItems() 
        {
            return new string[] { this.ReqItem1, this.ReqItem2, this.ReqItem3, this.ReqItem4, this.ReqItem5 };
        }

        public int[] GetAllCounts() 
        {
            return new int[] { this.Count1, this.Count2, this.Count3, this.Count4, this.Count5 };
        }
    }
}
