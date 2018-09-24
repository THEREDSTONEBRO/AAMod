using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace AAMod.NPCs.Bosses.Zero
{
	// to investigate: Projectile.Damage, (8843)
	class VoidStarP : ModProjectile
	{
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/VoidStarP"; } }

        public override void SetDefaults()
		{
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            projectile.CloneDefaults(ProjectileID.NebulaArcanum);
            projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 6;
		}
	}
}
