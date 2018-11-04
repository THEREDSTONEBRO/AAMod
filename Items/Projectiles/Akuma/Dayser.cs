using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
    public class Dayser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 5;
            projectile.height = 5;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.extraUpdates = 2;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0.25f, 0.4f, 0.7f);
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
                Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0f, 0.4f, 0.7f);
            
            float num55 = 100f;
            float num56 = 3f;
            if (projectile.ai[1] == 0f)
            {
                projectile.localAI[0] += num56;
                if (projectile.localAI[0] == num56 * 1f && projectile.type == 606)
                {
                    for (int num57 = 0; num57 < 4; num57++)
                    {
                        int num58 = Dust.NewDust(projectile.Center - projectile.velocity / 2f, 0, 0, mod.DustType("AkumaADust"), 0f, 0f, 100, default(Color), 1.4f);
                        Main.dust[num58].velocity *= 0.2f;
                        Main.dust[num58].velocity += projectile.velocity / 10f;
                        Main.dust[num58].noGravity = true;
                    }
                }
                if (projectile.localAI[0] > num55)
                {
                    projectile.localAI[0] = num55;
                }
            }
            else
            {
                projectile.localAI[0] -= num56;
                if (projectile.localAI[0] <= 0f)
                {
                    projectile.Kill();
                    return;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            int num294 = Main.rand.Next(3, 7);
            for (int num295 = 0; num295 < num294; num295++)
            {
                int num296 = Dust.NewDust(projectile.Center - projectile.velocity / 2f, 0, 0, mod.DustType("AkumaADust"), 0f, 0f, 100, default(Color), 2.1f);
                Main.dust[num296].velocity *= 2f;
                Main.dust[num296].noGravity = true;
            }
        }

        public override Color? GetAlpha(Color newColor)
        {

            float num12 = (float)(255 - projectile.alpha) / 255f;
            int num;
            int num2;
            int num3;
            num = 255 - projectile.alpha;
            num2 = 255 - projectile.alpha;
            num3 = 255 - projectile.alpha;
            num = (int)((float)newColor.R * num12);
            num2 = (int)((float)newColor.G * num12);
            num3 = (int)((float)newColor.B * num12);
            int num13 = (int)newColor.A - projectile.alpha;
            if (num13 < 0)
            {
                num13 = 0;
            }
            if (num13 > 255)
            {
                num13 = 255;
            }
            return new Color(num, num2, num3, num13);
        }

        public override void SetStaticDefaults()
		{
		    DisplayName.SetDefault("Dayser");
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}
