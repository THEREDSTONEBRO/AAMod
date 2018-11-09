using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class YtriumBoomerangP : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 40;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.magic = false;
			projectile.penetrate = 6;
			projectile.timeLeft = 550;
			projectile.light = 0.9f;
			projectile.extraUpdates = 2;
			
			
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("yBoomerangP");
    }

       

    }
}
