using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    class Ryugen : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 28;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Arkhalis);
            aiType = ProjectileID.Arkhalis;
            projectile.width = 132;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 60;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            //return Color.White;
            return new Color(0, 200, 0, 0) * (1f - projectile.alpha / 255f);
        }
    }
}
