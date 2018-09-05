using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class DragonP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.HornetStinger);
            projectile.penetrate = 3;  
            projectile.width = 16;
            projectile.height = 16;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("DragonP");
    }

    }
}
