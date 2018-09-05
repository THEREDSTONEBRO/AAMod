using Terraria.ModLoader;

namespace AAMod.Items.Blocks
{
    public class FulguriteShard : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fulgurite Shard");
            Tooltip.SetDefault("The fury of a thousand bolts of lightning run through this shard");
        }
    }
}
