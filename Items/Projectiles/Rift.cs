using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace AAMod.Items.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	class Rift : ModProjectile
	{
		public override void SetDefaults()
		{
            
            projectile.width = 64;
            projectile.height = 64;
            projectile.alpha = 100;
            projectile.light = 0.2f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 0.9f;
            projectile.melee = true;
            projectile.timeLeft = 300;

        }
        public override void AI()
        {
            if (projectile.ai[1] == 0f && projectile.type == 44)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item8, projectile.position);
            }
            if (projectile.type != 263 && projectile.type != 274)
            {
                projectile.rotation += projectile.direction * 0.8f;
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    if (projectile.ai[0] < 100f)
                    {
                        projectile.velocity *= 1.06f;
                    }
                    else
                    {
                        projectile.ai[0] = 200f;
                    }
                }
                for (int num257 = 0; num257 < 2; num257++)
                {
                    int num258 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, 0f, 0f, 100, new Color(120, 0, 30), 1f);
                    Main.dust[num258].noGravity = true;
                }
                return;
            }
            if (projectile.type == 274 && projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
            }
            projectile.rotation += projectile.direction * 0.05f;
            projectile.rotation += projectile.direction * 0.5f * (projectile.timeLeft / 180f);
            if (projectile.type == 274)
            {
                projectile.velocity *= 0.96f;
                return;
            }
            projectile.velocity *= 0.95f;
            return;
        }
    }
}
