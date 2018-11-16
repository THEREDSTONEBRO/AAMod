using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AAMod.Items.Boss.Yamata
{
    public class YamataTrophy : ModItem
	{
        public static int type;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yamata Trophy");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(20, 20, 76);
                }
            }
        }

        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
            item.rare = 1;
            item.useStyle = 1;
			item.consumable = true;
			item.value = 2000;
			item.rare = 1;
			item.createTile = mod.TileType("YamataTrophy");
		}
	}
}