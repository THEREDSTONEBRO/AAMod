using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    class RealityCannon : Army
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/RealityCannon"; } }

        public override void Init()
        {
            base.Init();
            RC = true;
        }

        float floatzero = 0f;
        float floatone = 0f;
        float floattwo = 0f;
        float floatthree = 0f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reality Cannon");
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 42;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.life = 28000;
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
            npc.value = 0f;
            npc.noGravity = true;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeLaser;
        }

        public override void AI()
        {
            npc.spriteDirection = -(int)floatzero;
            if (!Main.npc[(int)floatone].active || Main.npc[(int)floatone].aiStyle != 32)
            {
                floattwo += 10f;
                if (floattwo > 50f || Main.netMode != 2)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (floattwo == 0f || floattwo == 3f)
            {
                if (Main.npc[(int)floatone].ai[1] == 3f && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (Main.npc[(int)floatone].ai[1] != 0f)
                {
                    npc.localAI[0] += 3f;
                    if (npc.position.Y > Main.npc[(int)floatone].position.Y - 100f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.07f;
                        if (npc.velocity.Y > 6f)
                        {
                            npc.velocity.Y = 6f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)floatone].position.Y - 100f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.07f;
                        if (npc.velocity.Y < -6f)
                        {
                            npc.velocity.Y = -6f;
                        }
                    }
                    if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)floatone].position.X + (float)(Main.npc[(int)floatone].width / 2) - 120f * floatzero)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.1f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)floatone].position.X + (float)(Main.npc[(int)floatone].width / 2) - 120f * floatzero)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.1f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                else
                {
                    floatthree += 1f;
                    if (floatthree >= 800f)
                    {
                        floattwo += 1f;
                        floatthree = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)floatone].position.Y - 100f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.1f;
                        if (npc.velocity.Y > 3f)
                        {
                            npc.velocity.Y = 3f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)floatone].position.Y - 100f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.1f;
                        if (npc.velocity.Y < -3f)
                        {
                            npc.velocity.Y = -3f;
                        }
                    }
                    if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)floatone].position.X + (float)(Main.npc[(int)floatone].width / 2) - 180f * floatzero)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.14f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)floatone].position.X + (float)(Main.npc[(int)floatone].width / 2) - 180f * floatzero)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.14f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                npc.TargetClosest(true);
                Vector2 vector58 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num488 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector58.X;
                float num489 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector58.Y;
                float num490 = (float)Math.Sqrt((double)(num488 * num488 + num489 * num489));
                npc.rotation = (float)Math.Atan2((double)num489, (double)num488) - 1.57f;
                if (Main.netMode != 1)
                {
                    npc.localAI[0] += 1f;
                    if (npc.localAI[0] > 200f)
                    {
                        npc.localAI[0] = 0f;
                        float num491 = 8f;
                        int num492 = 25;
                        int num493 = 100;
                        num490 = num491 / num490;
                        num488 *= num490;
                        num489 *= num490;
                        num488 += (float)Main.rand.Next(-40, 41) * 0.05f;
                        num489 += (float)Main.rand.Next(-40, 41) * 0.05f;
                        vector58.X += num488 * 8f;
                        vector58.Y += num489 * 8f;
                        Projectile.NewProjectile(vector58.X, vector58.Y, num488, num489, num493, num492, 0f, Main.myPlayer, 0f, 0f);
                        return;
                    }
                }
            }
            else if (floattwo == 1f)
            {
                floatthree += 1f;
                if (floatthree >= 200f)
                {
                    npc.localAI[0] = 0f;
                    floattwo = 0f;
                    floatthree = 0f;
                    npc.netUpdate = true;
                }
                Vector2 vector59 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num494 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - 350f - vector59.X;
                float num495 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 20f - vector59.Y;
                float num496 = (float)Math.Sqrt((double)(num494 * num494 + num495 * num495));
                num496 = 7f / num496;
                num494 *= num496;
                num495 *= num496;
                if (npc.velocity.X > num494)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.1f;
                }
                if (npc.velocity.X < num494)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.1f;
                }
                if (npc.velocity.Y > num495)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.03f;
                }
                if (npc.velocity.Y < num495)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.03f;
                }
                npc.TargetClosest(true);
                vector59 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                num494 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector59.X;
                num495 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector59.Y;
                num496 = (float)Math.Sqrt((double)(num494 * num494 + num495 * num495));
                npc.rotation = (float)Math.Atan2((double)num495, (double)num494) - 1.57f;
                if (Main.netMode == 1)
                {
                    npc.localAI[0] += 1f;
                    if (npc.localAI[0] > 80f)
                    {
                        npc.localAI[0] = 0f;
                        float num497 = 10f;
                        int num498 = 25;
                        int num499 = 100;
                        num496 = num497 / num496;
                        num494 *= num496;
                        num495 *= num496;
                        num494 += (float)Main.rand.Next(-40, 41) * 0.05f;
                        num495 += (float)Main.rand.Next(-40, 41) * 0.05f;
                        vector59.X += num494 * 8f;
                        vector59.Y += num495 * 8f;
                        Projectile.NewProjectile(vector59.X, vector59.Y, num494, num495, num499, num498, 0f, Main.myPlayer, 0f, 0f);
                        return;
                    }
                }
            }
        }
    }
}