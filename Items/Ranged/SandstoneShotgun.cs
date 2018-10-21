using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class SandstoneShotgun : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 12;
            item.noMelee = true;
            item.ranged = true;
            item.width = 68;
            item.height = 22;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.shoot = 14;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 2;
            item.value = 10;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 35f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sandstone Shotgun");
      Tooltip.SetDefault("");
    }

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            float spread = 45f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - .1d;
            double deltaAngle = spread / 6f;
            double offsetAngle;
            for (int i = 0; i < 3; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sandstone, 50);
			recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
