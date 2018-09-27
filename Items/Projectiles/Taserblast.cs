using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class Taserblast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Taserblast");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 3;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
            projectile.ranged = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 900;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 130f) //projectile time left before disappears
            {
                projectile.Kill();
            }
            if (++projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 1;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, oldVelocity, projectile.width, projectile.height);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            return true;
        }
    }
}