using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class Crystal : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TerraBeam);
            projectile.penetrate = 2;  
            projectile.width = 20;
            projectile.height = 20;
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
                dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 27, 4.736842f, 0f, 46, new Color(30, 30, 30), 1.184211f)];
                dust.fadeIn = 0.9868421f;
                dust.noGravity = false;
            }
		}

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Crystal");
		}


    }
}
