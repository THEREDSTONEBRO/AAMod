using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class ElementalBow : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 45;
            item.noMelee = true;
            item.ranged = true;
            item.width = 18;
            item.height = 42;

            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.value = 100;
            item.rare = 5;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 15f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bonechill Arc");
      Tooltip.SetDefault("Transforms Wooden arrows into Frostburn Arrows");
    }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FrostburnArrow, damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false; //Makes sure to not fire the original projectile
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddIngredient(ItemID.CobaltBar, 5);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
