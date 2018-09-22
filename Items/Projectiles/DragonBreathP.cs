using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AAMod.Items.Projectiles   
{
    public class DragonBreathP : ModProjectile   
    {

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 14;
            projectile.height = 14; 
            projectile.aiStyle = 99; 
            projectile.friendly = true;  
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 360f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 15f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Breath");
        }
       
    }
}
