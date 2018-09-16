using Terraria.ModLoader;

namespace AAMod.Items.Blocks
{
    public class FulguriteShard : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.rare = 4;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("FulguriteOre");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fulgurite Shard");
            Tooltip.SetDefault("The fury of a thousand bolts of lightning run through this shard");
        }
    }
}
