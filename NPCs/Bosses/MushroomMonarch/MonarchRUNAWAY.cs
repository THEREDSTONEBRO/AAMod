using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace AAMod.NPCs.Bosses.MushroomMonarch
{
    public class MonarchRUNAWAY: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Monarch");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.damage = 24;
            projectile.width = 74;
            projectile.height = 80;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 900;
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 2)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 1;
                }
            }
            projectile.velocity.X *= 0.00f;
            projectile.velocity.Y -= .1f;
        }
    }
}