namespace Mundus.Data.Tiles.Presets 
{
    using Mundus.Service.Tiles.Items.Types;
    using static Mundus.Data.Values;

    public static class ToolPresets 
    {
        public static Tool GetAWoodenPickaxe() 
        {
            return new Tool("wooden_pickaxe", ToolType.Pickaxe, 1);
        }

        public static Tool GetAWoodenAxe() 
        {
            return new Tool("wooden_axe", ToolType.Axe, 1);
        }

        public static Tool GetAWoodenShovel() 
        {
            return new Tool("wooden_shovel", ToolType.Shovel, 1);
        }

        public static Tool GetAWoodenLongsword() 
        {
            return new Tool("wooden_longsword", ToolType.Sword, 2);
        }

        public static Tool GetARockPickaxe() 
        {
            return new Tool("rock_pickaxe", ToolType.Pickaxe, 2);
        }

        public static Tool GetARockAxe() 
        {
            return new Tool("rock_axe", ToolType.Axe, 2);
        }
       
        public static Tool GetARockShovel() 
        {
            return new Tool("rock_shovel", ToolType.Shovel, 2);
        }

        public static Tool GetARockLongsword() 
        {
            return new Tool("rock_longsword", ToolType.Sword, 4);
        }

        public static Tool GetFromStock(string stock_id) 
        {
            switch (stock_id) 
            {
                case "wooden_pickaxe": return GetAWoodenPickaxe();
                case "wooden_axe": return GetAWoodenAxe();
                case "wooden_shovel": return GetAWoodenShovel();
                case "wooden_longsword": return GetAWoodenLongsword();
                case "rock_pickaxe": return GetARockPickaxe();
                case "rock_axe": return GetARockAxe();
                case "rock_shovel": return GetARockShovel();
                case "rock_longsword": return GetARockLongsword();
                default: return null;
            }
        }
    }
}
