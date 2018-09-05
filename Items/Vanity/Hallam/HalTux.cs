using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Hallam
{
    [AutoloadEquip(EquipType.Body)]
    public class HalTux : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallam's Fancy Tux");
            Tooltip.SetDefault(
@"This tux was woven with pure class
'Great for impersonating Ancients Awakened Devs!'");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.rare = 9;
            item.vanity = true;
        }
    }
}