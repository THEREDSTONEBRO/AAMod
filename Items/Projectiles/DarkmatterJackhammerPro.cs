using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{

    public class DarkmatterJackhammerPro : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 52;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darkmatter Jackhammer");
        }
    }
}