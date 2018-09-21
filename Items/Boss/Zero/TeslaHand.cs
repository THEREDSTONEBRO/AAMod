using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
	public class TeslaHand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Zero Weapon");
            Tooltip.SetDefault("Just swing it around and it'll shock whatever's in front of you");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 42;
            item.damage = 240;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.channel = true;
            item.autoReuse = true;
            item.thrown = true;
            item.useAnimation = 13;
            item.useTime = 13;
            item.useStyle = 1;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item116;
            item.value = 1000000;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("Teslashock");
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocalyptitePlate", 5);
			recipe.AddIngredient(null, "UnstableSingularity", 5);
	        recipe.AddTile(null, "BinaryReassembler");
	        recipe.SetResult(this);
	        recipe.AddRecipe();
		}
	}
}
