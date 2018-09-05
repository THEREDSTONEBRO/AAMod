using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class IceChunk : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LightBeam);
            projectile.penetrate = 1;  
            projectile.width = 14;
            projectile.height = 18;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
			if (Main.rand.NextFloat() < 0.9210526f)
			{
				Dust dust;
				Vector2 position = projectile.position;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 230, 0f, 0f, 0, new Color(255,255,255), 2.105263f)];
				dust.noGravity = true;
				dust.fadeIn = 1.342105f;
			}
		}

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ice Chunk");
		}


    }
}
