using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class Throwshroom : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);
            projectile.penetrate = -1;  
            projectile.width = 20;
            projectile.height = 22;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 150;
            
        }
    }
}
