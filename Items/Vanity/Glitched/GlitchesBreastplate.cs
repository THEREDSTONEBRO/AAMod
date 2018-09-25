using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace AAMod.Items.Vanity.Glitched
{
	[AutoloadEquip(EquipType.Body)]
	public class GlitchesBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Gl17cH's Breastplate");
			Tooltip.SetDefault("'Great for impersonating AA devs!'");
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(247, 0, 42);
                }
            }
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