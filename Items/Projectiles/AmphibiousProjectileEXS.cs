using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class AmphibiousProjectileEXS : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mudkip");
            Main.projFrames[projectile.type] = 5;
        }
    	
        public override void SetDefaults()
        {
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
            aiType = 321;
        }

        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 186, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Wet, 600);
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}