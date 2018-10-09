using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class EnderSickle : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DeathSickle);
            projectile.penetrate = -1;  
            projectile.width = 50;
            projectile.height = 54;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 900;
        }

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Ender Sickle");
		}


    }
}
