using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace AAMod.Items.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	class VoidStarPF : ModProjectile
	{
		public override void SetDefaults()
		{
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 300;
            projectile.CloneDefaults(ProjectileID.NebulaArcanum);
		
		}
	}
}
