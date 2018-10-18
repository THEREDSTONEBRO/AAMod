using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class PurpleIceYoyoP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Terrarian);
            projectile.penetrate = 20;  
            projectile.width = 16;
            projectile.height = 16;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("PurpleIceYoyoP");
    }


    }
}
