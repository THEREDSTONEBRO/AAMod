using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
	public class EventHorizon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Event Horizon");
            Tooltip.SetDefault("Throws out 4 razor sharp flails");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 54;
            item.damage = 170;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            item.melee = true;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 5;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item116;
            item.value = 1000000;
            item.shoot = mod.ProjectileType("EventHorizon");
            item.shootSpeed = 22f;
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
			recipe.AddIngredient(ItemID.SolarEruption);
	        recipe.AddTile(null, "BinaryReassembler");
	        recipe.SetResult(this);
	        recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            float ai3 = (Main.rand.NextFloat() - 0.75f) * 0.7853982f; //0.5
	    	float ai3X = (Main.rand.NextFloat() - 0.50f) * 0.7853982f; //0.5
            float ai3Y = (Main.rand.NextFloat() - 0.25f) * 0.7853982f; //0.5
            float ai3Z = (Main.rand.NextFloat() - 0.12f) * 0.7853982f; //0.5
            for (int i = 0; i < 4; i++)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EventHorizon"), damage, knockBack, player.whoAmI, 0.0f, ai3);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EventHorizon"), damage, knockBack, player.whoAmI, 0.0f, ai3X);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EventHorizon"), damage, knockBack, player.whoAmI, 0.0f, ai3Y);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EventHorizon"), damage, knockBack, player.whoAmI, 0.0f, ai3Z);
            }

            return false;
        }
	}
}
