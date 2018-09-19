using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
	public class ZeroStar : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Zero Star");
            Tooltip.SetDefault("Throws a spinning blade of doom");
		}

		public override void SetDefaults()
		{
			item.damage = 170;
			item.width = 90;
			item.height = 90;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.thrown = true;
            item.shoot = mod.ProjectileType("ZeroStarP");
            item.shootSpeed = 16f;
            item.noMelee = true;
            item.noUseGraphic = true;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(120, 0, 30);
                }
            }
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "ApocalyptitePlate", 5);
                recipe.AddIngredient(null, "UnstableSingularity", 5);
                recipe.AddIngredient(ItemID.LightDisc, 5);
                recipe.AddTile(null, "BinaryReassembler");
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
	}
}