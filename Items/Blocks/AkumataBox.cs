using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AAMod.Items.Blocks
{
	public class AkumataBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumata Music Box");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("AkumataBox");
			item.width = 28;
			item.height = 28;
			item.rare = 4;
			item.value = 10000;
			item.accessory = true;
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoB, Main.DiscoB);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusicBox);
            recipe.AddIngredient(null, "AkumaBox", 5);
            recipe.AddIngredient(null, "YamataBox", 5);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
