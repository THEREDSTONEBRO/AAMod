using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class CloudEdgeP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Starfury);
            projectile.penetrate = 14;  
            projectile.width = 14;
            projectile.height = 18;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("CGP");
    }


    }
}
