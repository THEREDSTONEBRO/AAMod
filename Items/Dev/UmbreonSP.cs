using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AAMod.Items.Dev
{
	public class UmbreonSP : ModItem
	{
		public static short customGlowMask = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade of Night");
			Tooltip.SetDefault("A dark sword from a dark creature.");
			if (Main.netMode != 2)
			{
				Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
				for (int i = 0; i < Main.glowMaskTexture.Length; i++)
				{
					glowMasks[i] = Main.glowMaskTexture[i];
				}
				glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Dev/UmbreonSP_Glow");
				customGlowMask = (short)(glowMasks.Length - 1);
				Main.glowMaskTexture = glowMasks;
			}
		}
		
		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true;
			item.width = 84;
			item.height = 84;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("UmbreonProjectile");
			item.shootSpeed = 20f;
			item.glowMask = customGlowMask;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		    float spread = 20f * 0.0174f;
		    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - .1d;
		    double deltaAngle = spread / 6f;
		    double offsetAngle;
		    for (int i = 0; i < 3; i++)
		    {
		    	offsetAngle = startAngle + deltaAngle * i;
		    	Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
		    }
		    return false;
		}
	}
}
