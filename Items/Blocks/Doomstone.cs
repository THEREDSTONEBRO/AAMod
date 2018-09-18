using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AAMod.Items.Blocks
{
    public class Doomstone : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.rare = 10;
            item.consumable = true;
            item.createTile = mod.TileType("Doomstone"); //put your CustomBlock Tile name
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new ColorColor(100, 0, 10);
                }
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doomstone");
            Tooltip.SetDefault("");
        }
    }
}
