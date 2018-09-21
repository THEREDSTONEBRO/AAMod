using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Vanity.Glitched
{
	[AutoloadEquip(EquipType.Head)]
	public class GlitchesHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gl17cH's Helmet");
			Tooltip.SetDefault("Great for impersonating AA devs!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.rare = 10;
			item.vanity = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlitchesBreastplate") && legs.type == mod.ItemType("GlitchesGreaves");
		}
		
		public override void UpdateVanitySet(Player player)
		{
			int dust = Dust.NewDust(new Vector2(player.position.X - 14 + (player.direction == -1f ? 40 : 0), player.position.Y - 0), 6, 6, 6, Main.rand.Next(-10,10)/5, Main.rand.Next(-10,10)/5, 200, default(Color), 2.0f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].noLight = true;
        }
	}
}