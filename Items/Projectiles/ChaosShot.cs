using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class ChaosShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TerraBeam);
            projectile.penetrate = 3;  
            projectile.width = 40;
            projectile.height = 40;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 600;
        }
		
		public override void AI()
		{
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Dust.NewDust(position, 0, 0, mod.DustType<Dusts.UmbreonSPDust>(), 4.736842f, 0f, 46, new Color(Main.DiscoR, 0, Main.DiscoB), 1f)];
                dust.noGravity = false;
            }
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Dust.NewDust(position, 0, 0, mod.DustType<Dusts.UmbreonSPDust>(), 4.736842f, 0f, 46, new Color(Main.DiscoR, 0, Main.DiscoB), 1f)];
                dust.noGravity = false;
            }
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Dust.NewDust(position, 0, 0, mod.DustType<Dusts.UmbreonSPDust>(), 4.736842f, 0f, 46, new Color(Main.DiscoR, 0, Main.DiscoB), 1f)];
                dust.noGravity = false;
            }
        }

        public override void Kill(int timeleft)
        {
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 107, -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, new Color(Main.DiscoR, 0, Main.DiscoB), 1.184211f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 107, -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, new Color(Main.DiscoR, 0, Main.DiscoB), 1.184211f);
                Main.dust[num469].velocity *= 2f;
            }
        }

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            projectile.glowMask = customGlowMask;
            DisplayName.SetDefault("Chaos Beam");
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 500);
			target.AddBuff(BuffID.Venom, 500);
        }
    }
}