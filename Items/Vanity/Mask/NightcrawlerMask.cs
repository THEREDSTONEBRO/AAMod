using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Mask
{
	[AutoloadEquip(EquipType.Head)]
	public class NightcrawlerMask : ModItem
	{
		public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Nightcrawler Mask");
		}

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.rare = 2;
            item.vanity = true;
        }
    }
}