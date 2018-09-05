using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Hallam
{
	[AutoloadEquip(EquipType.Legs)]
	public class HalTrousers : ModItem
	{
		public override void SetStaticDefaults()
       
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallam's Fashionable Trousers");
            Tooltip.SetDefault(
@"These pants cost way more than you do
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