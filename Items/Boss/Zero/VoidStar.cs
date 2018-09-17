using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
	public class VoidStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Star");
            Tooltip.SetDefault("Fires a dark, spinning vortex that homes in on enemies");
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 15;
            item.useTime = 15;
            item.shootSpeed = 10f;
            item.knockBack = 0f;
            item.width = 30;
            item.height = 26;
            item.damage = 190;
            item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("VoidStarPF");
            item.mana = 18;
            item.rare = 10;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.noMelee = true;
            item.magic = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
        }
		
		public override void ModifyTooltips(List<TooltipLine> list)
	    {
	        foreach (TooltipLine line2 in list)
	        {
	            if (line2.mod == "Terraria" && line2.Name == "ItemName")
	            {
	                line2.overrideColor = new Color(80, 0, 10);
	            }
	        }
	    }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocalyptitePlate", 5);
			recipe.AddIngredient(null, "UnstableSingularity", 5);
			recipe.AddIngredient(ItemID.NebulaBlaze);
	        recipe.AddTile(null, "BinaryReassembler");
	        recipe.SetResult(this);
	        recipe.AddRecipe();
		}
	}
}
