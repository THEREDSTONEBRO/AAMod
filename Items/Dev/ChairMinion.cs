using System;
using System.Reflection;
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
        private int chairdeath = 0;

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(ProjectileID.DeadlySphere);
            projectile.width = 16;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = 1;
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
            if (chairdeath > 0)
            {
                chairdeath--;
            }
            if (projectile.timeLeft == 10)
            {
                projectile.timeLeft = 180;
            }
            if (projectile.frame == 9 && chairdeath == 0)
            {
                projectile.Kill();
            }
            if ((projectile.wet || projectile.lavaWet || projectile.honeyWet || projectile.frame > 1) && chairdeath == 0)
            {
                projectile.frame++;
                chairdeath = 10;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type == NPCID.Crab)
            {
                target.life = 1;
                target.StrikeNPC(99999, 0, 0);
                NPC.NewNPC((int)(target.Center.X), (int)(target.Center.Y), mod.NPCType<CrabGuardian>());
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
                projectile.timeLeft = 180;
            }
        }
    }
    internal class CrabGuardian : ModNPC
    {
        private int soundTimer = 0;

        public override string Texture { get { return "AAMod/Items/Dev/CrabGuardian"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crab Guardian");
            npc.CloneDefaults(NPCID.DungeonGuardian);
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 1;
            npc.immortal = true;
            npc.scale = 3f;
            npc.defense = 0;
            npc.damage = 999999;
        }

        public override void AI()
        {
            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    npc.timeLeft = 10;
                }
            }
            if (soundTimer > 0)
            {
                soundTimer--;
            }
            if (soundTimer == 0)
            {
                Main.PlaySound(SoundID.MoonLord, npc.position, 0);
                soundTimer = 600;
            }
            npc.TargetClosest(true);
            npc.rotation += (float)npc.direction * 0.5f;
            Vector2 vector45 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num444 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector45.X;
            float num445 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector45.Y;
            float num446 = (float)Math.Sqrt((double)(num444 * num444 + num445 * num445));
            float num447 = 10f;
            num447 += num446 / 100f;
            if (num447 < 8f)
            {
                num447 = 8f;
            }
            if (num447 > 32f)
            {
                num447 = 32f;
            }
            num446 = num447 / num446;
            npc.velocity.X = num444 * num446;
            npc.velocity.Y = num445 * num446;
            if (npc.timeLeft < 500 && npc.timeLeft > 10)
            {
                npc.timeLeft = 500;
            }
        }

        public override void NPCLoot()
        {
            MethodInfo methodInfo = typeof(Main).GetMethod("QuitGame", BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(Main.instance, null);
        }
    }
}