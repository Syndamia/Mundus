﻿using static Mundus.Data.Values;

namespace Mundus.Service.Tiles.Items {
    public class Tool : ItemTile {
        public ToolType Type { get; private set; }
        public int Class { get; private set; }

        public Tool(Tool tool) : this(tool.stock_id, tool.Type, tool.Class) 
        { }

        public Tool(string stock_id, ToolType toolType, int toolClass) : base(stock_id) {
            this.Type = toolType;
            this.Class = toolClass;
        }

        public override string ToString() {
            return $"Tool | ID: {this.stock_id} Type: {this.Type} Class: {this.Class}";
        }
    }
}
