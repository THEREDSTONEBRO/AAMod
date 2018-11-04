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

        public void DrawProj(int i, Main main)
        {
            Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
            int num147 = 0;
            int num148 = 0;
            float num149 = (float)(Main.projectileTexture[projectile.type].Width - projectile.width) * 0.5f + (float)projectile.width * 0.5f;
            Microsoft.Xna.Framework.Rectangle value8 = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
            if (projectile.getRect().Intersects(value8))
            {
                Vector2 value9 = new Vector2(projectile.position.X - Main.screenPosition.X + num149 + (float)num148, projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY);
                float num174 = 100f;
                float scaleFactor = 3f;
                if (projectile.type == 606)
                {
                    num174 = 150f;
                    scaleFactor = 3f;
                }
                if (projectile.ai[1] == 1f)
                {
                    num174 = (float)((int)projectile.localAI[0]);
                }
                for (int num175 = 1; num175 <= (int)projectile.localAI[0]; num175++)
                {
                    Vector2 value10 = Vector2.Normalize(projectile.velocity) * (float)num175 * scaleFactor;
                    Microsoft.Xna.Framework.Color color32 = projectile.GetAlpha(color25);
                    color32 *= (num174 - (float)num175) / num174;
                    color32.A = 0;
                    Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], value9 - value10, null, color32, projectile.rotation, new Vector2(num149, (float)(projectile.height / 2 + num147)), projectile.scale, spriteEffects, 0f);
                }
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
