using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class AmphibiousProjectileEX : ModProjectile
    {
        public static short customGlowMask = 0;
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mudkip");
            Main.projFrames[projectile.type] = 5;
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }
    	
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.RocketSnowmanIV);
            aiType = ProjectileID.RocketSnowmanIII;
            projectile.width = 26;
            projectile.height = 28;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.alpha = 0;
            projectile.tileCollide = false;
            projectile.glowMask = customGlowMask;
        }

        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 186, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Wet, 600);
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}