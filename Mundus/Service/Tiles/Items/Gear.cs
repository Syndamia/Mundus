﻿namespace Mundus.Service.Tiles.Items {
    public class Gear : ItemTile {
        public Gear(Gear gear) : base(gear.stock_id) 
        { }

        public Gear(string stock_id) : base(stock_id) 
        { }

        public override string ToString() {
            return $"Gear | ID: {stock_id}";
        }
    }
}
