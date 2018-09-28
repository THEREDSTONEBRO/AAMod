using System;
using AAMod.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.restrikeDelay = 0;
            projectile.localNPCHitCooldown = 0;
            projectile.damage = 1;
            projectile.alpha = 0;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chair Minion");
            Main.projFrames[projectile.type] = 9;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = true;
			return true;
		}

        public override void AI()
        {
            if (projectile.timeLeft == 10)
            {
                projectile.timeLeft = 180;
            }
            Player player = Main.player[projectile.owner];
            if (player.HasBuff(mod.BuffType<Chairless>()))
            {
                projectile.frameCounter++;
            }
            if (projectile.wet || projectile.lavaWet || projectile.honeyWet || projectile.frameCounter > 1)
            {
                projectile.frameCounter++;
            }
            if (projectile.frameCounter == 8)
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
            projectile.position += projectile.velocity;
            projectile.velocity = Vector2.Zero;
            projectile.timeLeft = 180;
            if (target.type == NPCID.Crab)
            {
                target.life = 1;
                target.StrikeNPC(99999, 0, 0);
                NPC.NewNPC((int)(target.Center.X), (int)(target.Center.Y), NPCID.DungeonGuardian);
                Player player = Main.player[projectile.owner];
                player.AddBuff(mod.BuffType<Chairless>(), 1800);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
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