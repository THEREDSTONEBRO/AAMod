using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionMod.Items.Armor.DEV
{
	[AutoloadEquip(EquipType.Body)]
	public class GlitchesBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Gl17cH's Breastplate");
			Tooltip.SetDefault("Great for impersonating AA devs!");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 20;
			item.rare = 10;
			item.vanity = true;
		}
	}
}