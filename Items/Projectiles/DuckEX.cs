using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    class DuckEX : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 14;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.RocketSnowmanIV);
            aiType = ProjectileID.RocketSnowmanIII;
            projectile.width = 28;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 0;
            projectile.penetrate = 0;
            projectile.timeLeft = 900;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(80, Main.DiscoG, 80, 0) * (1f - projectile.alpha / 255f);
        }
    }
}
