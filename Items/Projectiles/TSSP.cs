using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class TSSP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DemonScythe);
            projectile.penetrate = 14;  
            projectile.width = 48;
            projectile.height = 18;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("CGP");
    }


    }
}
