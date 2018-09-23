using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Hallam
{
	[AutoloadEquip(EquipType.Head)]
	public class HalHat : ModItem
	{
		public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallam's Dapper Top Hat");
            Tooltip.SetDefault(
@"You can't help but feel fancy just wearing this
'Great for impersonating Ancients Awakened Devs!'");
		}

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 14;
            item.rare = 9;
            item.vanity = true;
        }
	}
}