using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class PurpleIceYoyo : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Terrarian);

            item.damage = 17;                            
            item.value = 3;
            item.rare = 0;
            item.knockBack = 2;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 15;
            item.shoot = mod.ProjectileType("PurpleIceYoyoP");  
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Purple Ice Yoyo");
      Tooltip.SetDefault("");
    }

		

        public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleIceBlock, 30);              //exeample of how to craft with a modded item
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
