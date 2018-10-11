using System;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    internal class DeathLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doom Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.hostile = true;
            projectile.scale = 2f;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.alpha = 60;
            projectile.timeLeft = 120;
        }

        public override void AI()
        {
            if (projectile.timeLeft > 0)
            {
                projectile.timeLeft--;
            }
            if (projectile.timeLeft == 0)
            {
                projectile.Kill();
            }
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f);
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            for (int i = 0; i < 255; i++)
            {
                Player target = Main.player[i];
                //Get the shoot trajectory from the projectile and target
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the live targeted npc and the projectile is less than 480 pixels
                if (distance < 480f && !target.dead && target.active)
                {
                    //Divide the factor, 3f, which is the desired velocity
                    distance = 3f / distance;

                    //Multiply the distance by a multiplier if you wish the projectile to have go faster
                    shootToX *= distance * 3;
                    shootToY *= distance * 3;

                    //Set the velocities to the shoot values
                    projectile.velocity.X = shootToX;
                    projectile.velocity.Y = shootToY;
                }
            }
        }
    }
}