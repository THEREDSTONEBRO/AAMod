using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Throwing
{
    public class Spookerang : ModItem
    {

        public override void SetDefaults()
        {
			item.useTime = 25;
            item.CloneDefaults(ItemID.LightDisc);

            item.damage = 70;                            
            item.value = 20;
            item.rare = 3;
            item.knockBack = 2;
            item.useStyle = 1;
            item.useAnimation = 19;
            item.useTime = 19;
            item.shoot = mod.ProjectileType("SpookerangP");
			item.width = 54;
            item.height = 54;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Spookerang");
      Tooltip.SetDefault("");
    }


        public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);              //exeample of how to craft with a modded item
			recipe.AddIngredient(ItemID.SpookyWood, 50);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
