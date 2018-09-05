using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Alphakip
{
	[AutoloadEquip(EquipType.Legs)]
	public class FishDiverBoots : ModItem
	{
		public override void SetStaticDefaults()
       
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Alphakip's Flippers");
            Tooltip.SetDefault(@"Not actually flippers
'Great for impersonating Ancients Awakened Devs!'");
		}

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 9;
            item.vanity = true;
        }
    }
}