using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Pets
{
	public class PortaProbe : ModItem
	{
        public override void SetStaticDefaults()
		{
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Porta-Probe");

			Tooltip.SetDefault("Take a little life-seeking robot with you!");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.TikiTotem);
			item.shoot = mod.ProjectileType("MiniProbe");
            item.buffType = mod.BuffType("MiniProbe");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
                player.AddBuff(BuffID.Hunter, 2);
                player.AddBuff(BuffID.Spelunker, 2);
            }
		}
	}
}