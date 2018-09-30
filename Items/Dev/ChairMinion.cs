using System;
using System.Reflection;
using Microsoft.Xna.Framework;
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
            projectile.width = 16;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.restrikeDelay = 0;
            projectile.localNPCHitCooldown = 0;
            projectile.damage = 1;
            projectile.alpha = 0;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
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
            if ((projectile.wet || projectile.lavaWet || projectile.honeyWet || projectile.frame > 0) && chairdeath == 0)
            {
                projectile.frame++;
                chairdeath = 10;
            }
            Player player = Main.player[projectile.owner];
            Vector2 targetPos = projectile.position;
            float targetDist = 400f;
            bool target = false;
            projectile.tileCollide = true;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                {
                    targetDist = Vector2.Distance(projectile.Center, targetPos);
                    targetPos = npc.Center;
                    target = true;
                }
            }
            else for (int k = 0; k < 200; k++)
            {
                NPC npc = Main.npc[k];
                if (npc.CanBeChasedBy(this, false))
                {
                    float distance = Vector2.Distance(npc.Center, projectile.Center);
                    if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                    {
                        targetDist = distance;
                        targetPos = npc.Center;
                        target = true;
                    }
                }
            }
            if (Vector2.Distance(player.Center, projectile.Center) > (target ? 1000f : 500f))
            {
                projectile.ai[0] = 1f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[0] == 1f)
            {
                projectile.tileCollide = false;
            }
            if (target && projectile.ai[0] == 0f)
            {
                Vector2 direction = targetPos - projectile.Center;
                if (direction.Length() > 200f)
                {
                    direction.Normalize();
                    projectile.velocity = (projectile.velocity * 40f + direction * 6f) / (40f + 1);
                }
                else
                {
                    projectile.velocity *= (float)Math.Pow(0.97, 40.0 / 40f);
                }
            }
            else
            {
                if (!Collision.CanHitLine(projectile.Center, 1, 1, player.Center, 1, 1))
                {
                    projectile.ai[0] = 1f;
                }
                float speed = 6f;
                if (projectile.ai[0] == 1f)
                {
                    speed = 15f;
                }
                Vector2 center = projectile.Center;
                Vector2 direction = player.Center - center;
                projectile.ai[1] = 3600f;
                projectile.netUpdate = true;
                int num = 1;
                for (int k = 0; k < projectile.whoAmI; k++)
                {
                    if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
                    {
                        num++;
                    }
                }
                direction.X -= (float)((10 + num * 40) * player.direction);
                direction.Y -= 70f;
                float distanceTo = direction.Length();
                if (distanceTo > 200f && speed < 9f)
                {
                    speed = 9f;
                }
                if (distanceTo < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (distanceTo > 2000f)
                {
                    projectile.Center = player.Center;
                }
                if (distanceTo > 48f)
                {
                    direction.Normalize();
                    direction *= speed;
                    float temp = 40f / 2f;
                    projectile.velocity = (projectile.velocity * temp + direction) / (temp + 1);
                }
                else
                {
                    projectile.direction = Main.player[projectile.owner].direction;
                    projectile.velocity *= (float)Math.Pow(0.9, 40.0 / 40f);
                }
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