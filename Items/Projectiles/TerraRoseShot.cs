using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class TerraRoseShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MagicMissile);
            projectile.penetrate = 1;  
            projectile.width = 18;
            projectile.height = 18;
            projectile.tileCollide = false;
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
                dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 31, 4.736842f, 0f, 0, new Color(84, 255, 0), 1.184211f)];
                dust.fadeIn = 1.223684f;
                dust.noGravity = true;
			}
		}

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("TerraPetal");
		}
    }
}
