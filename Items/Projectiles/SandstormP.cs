using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class SandstormP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodYoyo);
            projectile.penetrate = 5;  
            projectile.width = 13;
            projectile.height = 13;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("SandstormP");
    }


    }
}
