using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
    public class SunSpearShot : ModProjectile
    {

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
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/Akuma/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            projectile.glowMask = customGlowMask;
            DisplayName.SetDefault("Sun Ray");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LightBeam);
            projectile.penetrate = 4;  
            projectile.width = 40;
            projectile.height = 40;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust2;
                Vector2 position = projectile.position;
                dust2 = Main.dust[Dust.NewDust(position, 0, 0, mod.DustType<Dusts.AkumaADust>(), 4.736842f, 0f, 46, default(Color), 1f)];
                dust2.noGravity = true;
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}