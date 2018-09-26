using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace AAMod.Items.Summoning.Minions
{
    public class ChinchillaMinion : Minion2
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(ProjectileID.PirateCaptain);
            projectile.width = 48;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.restrikeDelay = 0;
            projectile.localNPCHitCooldown = 0;
            projectile.damage = 1;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chinchilla Minion");
            Main.projFrames[projectile.type] = 7;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = true;
			return true;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.tileCollide = false;
            projectile.position += projectile.velocity;
            projectile.velocity = Vector2.Zero;
            projectile.timeLeft = 180;
            return false;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            AAPlayer modPlayer = (AAPlayer)player.GetModPlayer(mod, "AAPlayer");
            if (player.dead)
            {
                modPlayer.ChinchillaMinion = false;
            }
            if (modPlayer.ChinchillaMinion)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}