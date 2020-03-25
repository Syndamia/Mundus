﻿namespace Mundus.Service.Tiles.Items {
    public class Gear : ItemTile {
        public Gear(string stock_id) : base(stock_id) 
        { }

        public override string ToString() {
            return $"Gear | Stock ID: {stock_id}";
        }
    }
}
