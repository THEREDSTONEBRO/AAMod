using Terraria.ModLoader;

namespace AAMod.Items.Materials
{
    public class DragonFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragonfire");
            Tooltip.SetDefault("The Essance of Chaos found from the Inferno");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 16;
            item.maxStack = 99;
            item.rare = 3;
            item.alpha = 40;
        }
    }
}