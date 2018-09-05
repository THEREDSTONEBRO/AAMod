using Terraria.ModLoader;

namespace AAMod.Items.Blocks
{
    public class DynaskullOre : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.rare = 1;
            item.consumable = true;
            item.createTile = mod.TileType("DynaskullOre"); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynaskull Ore");
            Tooltip.SetDefault("The energy of millions of years pulsates through this ancient fossil");
        }
    }
}
