using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AAMod.Items.Projectiles
{
    public class TFGWP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;                       //this is the projectile penetration           //this is projectile frames
            projectile.hostile = false;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("TFGWP");
    }

 
        public override void AI()
        {
                                                          //this make that the projectile faces the right way
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            projectile.alpha = (int)projectile.localAI[0] * 2;
           
            if (projectile.localAI[0] > 60f) //projectile time left before disappears
            {
                projectile.Kill();
            }
           
        }
    }
}
