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
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 31, 30, 27, 0f, 0f, 124, new Color(84,0,255), 2.105263f)];
                dust.noGravity = true;
            }
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 31, 30, 27, 0f, 0f, 0, new Color(255,50,0), 2.105263f)];
                dust.noGravity = true;
            }
        }

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Chaos Beam");
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 500);
			target.AddBuff(BuffID.Venom, 500);
        }
    }
}