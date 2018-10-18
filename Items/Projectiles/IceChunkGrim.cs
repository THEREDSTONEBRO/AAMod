using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class IceChunkGrim : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.IceSickle);
            projectile.penetrate = 1;  
            projectile.width = 14;
            projectile.height = 18;
			projectile.friendly = false;
			projectile.hostile = true;
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
			if (Main.rand.NextFloat() < 0.9210526f)
			{
				Dust dust;
				Vector2 position = projectile.position;
				dust = Main.dust[Dust.NewDust(position, 30, 30, 230, 0f, 0f, 0, new Color(255,255,255), 2.105263f)];
				dust.noGravity = true;
				dust.fadeIn = 1.342105f;
			}
		}

        /*public override void Kill(int timeleft)
        {
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 230, -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, new Color(255, 255, 255), 2.105263f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 230, -projectile.velocity.X * 0.2f,
                    -projectile.velocity.Y * 0.2f, 0, new Color(255, 255, 255), 2.105263f);
                Main.dust[num469].velocity *= 2f;
            }
        }*/

        public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ice Chunk");
		}


    }
}