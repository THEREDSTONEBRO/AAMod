using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class RealityLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RealityLaser");
        }
        public override void SetDefaults()
        {
<<<<<<< HEAD
            projectile.width = 32;
=======
            projectile.width = 20;
>>>>>>> 448baa85bafb67ad7f37961deb2c4dbd11c32465
            projectile.height = 1;
            projectile.friendly = true;
            projectile.penetrate = -1;           //this is projectile frames
            projectile.hostile = false;
            projectile.friendly = true;
<<<<<<< HEAD
            projectile.ranged = true;                        //this make the projectile do magic damage
=======
            projectile.magic = true;                        //this make the projectile do magic damage
>>>>>>> 448baa85bafb67ad7f37961deb2c4dbd11c32465
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = true;
            projectile.timeLeft = 900;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, oldVelocity, projectile.width, projectile.height);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            return true;
        }
    }
}