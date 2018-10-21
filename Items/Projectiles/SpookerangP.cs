using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class SpookerangP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LightDisc);
            projectile.penetrate = 6;  
            projectile.width = 32;
            projectile.height = 32;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("SpookerangP");
    }


    }
}
