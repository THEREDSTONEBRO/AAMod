using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
    public class Sandstorm : ModItem
    {

        public override void SetDefaults()
        {

			item.useTime = 10;
            item.CloneDefaults(ItemID.WoodYoyo);

            item.damage = 15;                            
            item.value = 4;
            item.rare = 2;
            item.knockBack = 2;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 10;
            item.useTime = 10;
            item.shoot = mod.ProjectileType("SandstormP");           
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sandstorm");
      Tooltip.SetDefault("Darude-Sandstorm");
    }


        public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sandstone, 20);
            recipe.AddIngredient(ItemID.Cactus, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
