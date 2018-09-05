using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Alphakip

{
    [AutoloadEquip(EquipType.Body)]
    public class FishDiverJacket : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Alphakip's Diving Jacket");
            Tooltip.SetDefault(@"This jacket is so insulated, you could sit in the ocean and still come out dry
'Great for impersonating Ancients Awakened Devs!'");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 20;
            item.rare = 9;
            item.vanity = true;
        }
    }
}