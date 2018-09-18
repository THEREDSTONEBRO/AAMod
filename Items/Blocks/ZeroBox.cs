using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AAMod.Items.Blocks
{
	public class ZeroBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zero Music Box");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("ZeroBox");
			item.width = 24;
			item.height = 24;
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
<<<<<<< HEAD
                    line2.overrideColor = new Color(100, 0, 10);
=======
                    line2.overrideColor = new Color(120, 0, 30);
>>>>>>> 448baa85bafb67ad7f37961deb2c4dbd11c32465
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusicBox);
            recipe.AddIngredient(null, "UnstableSingularity", 5);
            recipe.AddIngredient(null, "ApocalyptitePlate", 5);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
