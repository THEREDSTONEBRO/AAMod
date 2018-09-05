using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class TheSquirter : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 84;
            item.noMelee = true;

            item.ranged = true;
            item.width = 38;
            item.height = 26;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType ("Squirt");
            item.knockBack = 0;
            item.value = 1000;
            item.rare = 6;
            item.UseSound = SoundID.Item34;
            item.autoReuse = false;
            item.shootSpeed = 14f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Squirter");
      Tooltip.SetDefault("Doesnt use ammo");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlimeGun, 1);
            recipe.AddIngredient(ItemID.Gel, 200);
            recipe.AddIngredient(null, "DeepAbyssium", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
