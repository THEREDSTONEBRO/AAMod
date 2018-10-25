using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
    public class FireProj : ModProjectile
    {
        public int noTileHitCounter = 120;

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 62;
            projectile.height = 92;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            if (projectile.position.Y > Main.player[projectile.owner].position.Y - 300f)
            {
                projectile.tileCollide = true;
            }
            if ((double)projectile.position.Y < Main.worldSurface * 16.0)
            {
                projectile.tileCollide = true;
            }
            projectile.scale = projectile.ai[1];
            projectile.rotation += projectile.velocity.X;
            Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
            /*Dust dust20 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 0f, 0f, 0, default(Color), 1f)];
            dust20.position = position;
            dust20.velocity = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * 0.33f + projectile.velocity / 4f;
            dust20.position += projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2));
            dust20.fadeIn = 0.5f;
            dust20.noGravity = true;
            dust20 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 0f, 0f, 0, default(Color), 1f)];
            dust20.position = position;
            dust20.velocity = projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2)) * 0.33f + projectile.velocity / 4f;
            dust20.position += projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2));
            dust20.fadeIn = 0.5f;
            dust20.noGravity = true;*/
            for (int num189 = 0; num189 < 1; num189++)
            {
                int num190 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<Dusts.AkumaADust>(), 0f, 0f, 0, default(Color), 1f);
                Main.dust[num190].velocity *= 0.5f;
                Main.dust[num190].scale *= 1.3f;
                Main.dust[num190].fadeIn = 1f;
                Main.dust[num190].noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(new LegacySoundStyle(2, 124, Terraria.Audio.SoundType.Sound));
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int i;
            if (projectile.whoAmI == mod.ProjectileType("FireProj"))
            {
                for (i = 0; i < 4; i++)
                {
                    offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                    int Flame1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), mod.ProjectileType("AkumaFlare"), 230, 1.25f, projectile.whoAmI, 0f, 0f);
                    int Flame2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), mod.ProjectileType("AkumaFlare"), 230, 1.25f, projectile.whoAmI, 0f, 0f);
                    Main.projectile[Flame1].timeLeft = 120;
                    Main.projectile[Flame2].timeLeft = 120;
                }
            }
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.ProjectileType("AkumaFlare"), -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, default(Color), 1f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.ProjectileType("AkumaFlare"), -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, default(Color), 1f);
                Main.dust[num469].velocity *= 2f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 600);
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 5) //once the frameCounter has reached 10 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 1; //go back to the first frame
            }
            return true;
        }
    }
}