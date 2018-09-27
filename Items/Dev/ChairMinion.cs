using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace AAMod.Items.Dev
{
    public class ChairMinion : Summoning.Minions.Minion2
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(ProjectileID.BabySlime);
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
            DisplayName.SetDefault("Chair Minion");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = true;
			return true;
		}

        public override void AI()
        {
            if (projectile.wet || projectile.lavaWet || projectile.honeyWet || projectile.frame > 1)
            {
                projectile.frame++;
            }
            if (projectile.frame == 7)
            {
                projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (NPC.immuneTime > 0)
            {
                NPC.immuneTime = 0;
            }
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.position += projectile.velocity;
            projectile.velocity = Vector2.Zero;
            projectile.timeLeft = 180;
            if (target.whoAmI == NPCID.Crab)
            {
                NPC.NewNPC((int)(target.Center.X), (int)(target.Center.Y), NPCID.DungeonGuardian);
            }
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
                modPlayer.ChairMinion = false;
            }
            if (modPlayer.ChairMinion)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}