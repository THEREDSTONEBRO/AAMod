using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class Bubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FUCKING BUBBLES");
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
            aiType = ProjectileID.BulletHighVelocity;
        }
        public override void AI()
        {
            Dust dust1;
            Vector2 position = projectile.position;
            dust1 = Main.dust[Dust.NewDust(position, 0, 0, mod.DustType<Dusts.MireBubbleDust>(), 4.736842f, 0f, 46, default(Color), 1f)];
            dust1.noGravity = true;
        }
    }
}