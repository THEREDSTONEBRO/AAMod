using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
	public class RealityCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Cannon");
            Tooltip.SetDefault("Rapidly Fires a dark spread of piercing lasers");
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 5;
            item.useTime = 5;
            item.shootSpeed = 16f;
            item.knockBack = 0f;
            item.width = 30;
            item.height = 26;
            item.damage = 120;
            item.UseSound = SoundID.Item12;
            item.shoot = mod.ProjectileType("RealityLaser");
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
                    line2.overrideColor = new Color(100, 0, 10);
                }
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
			recipe.AddIngredient(null, "ApocalyptitePlate", 5);
			recipe.AddIngredient(null, "UnstableSingularity", 5);
			recipe.AddIngredient(ItemID.StarCannon);
	        recipe.AddTile(null, "BinaryReassembler");
	        recipe.SetResult(this);
	        recipe.AddRecipe();
		}
	}
}
