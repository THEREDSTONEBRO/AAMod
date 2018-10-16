using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Dev
{
    internal class SauceContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sauce Packet");
            Tooltip.SetDefault("It's Empty?");
        }

        public override void SetDefaults()
        {
            item.rare = 2;
            item.width = 32;
            item.height = 32;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 212, 58);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom); // (null, "ModTileID");
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}