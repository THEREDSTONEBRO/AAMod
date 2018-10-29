using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Throwing
{
	public class DarkmatterKunai : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 60;            
            item.thrown = true;
            item.width = 20;
            item.height = 20;
			item.useTime = 8;
			item.useAnimation = 8;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 0;
			item.value = 8;
			item.rare = 6;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType ("DMK");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abyssal Arc");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
		    recipe.AddIngredient(null, "DarkMatter");
		    recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
		}
    }
}
