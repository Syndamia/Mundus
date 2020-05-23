namespace Mundus.Service.Tiles.Items 
{
    public abstract class ItemTile : ITile 
    {
        public string stock_id { get; private set; }

        protected ItemTile(ItemTile item) : this(item.stock_id)
        { 
        }

        public ItemTile(string stock_id) 
        {
            this.stock_id = stock_id;
        }
    }
}
