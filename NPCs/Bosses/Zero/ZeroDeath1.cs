using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace AAMod.NPCs.Bosses.Zero
{
    public class ZeroDeath1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 200;
            projectile.height = 178;
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 12;
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 3;
                }
            }
            projectile.velocity.X *= 0.00f;
            projectile.velocity.Y += 0.00f;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile((new Vector2(projectile.position.X + 100f, projectile.position.Y + 89f)), (new Vector2(0f, 0f)), mod.ProjectileType("ZeroDeath2"), 0, 0);
        }
    }
}