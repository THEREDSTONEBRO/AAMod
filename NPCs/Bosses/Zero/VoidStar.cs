using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    public class VoidStar : Zero
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/VoidStar"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Star");
        }
        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 48;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeCannon;
            npc.noGravity = true;
        }
        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != 32)
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50f || Main.netMode != 2)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (npc.ai[2] == 0f || npc.ai[2] == 3f)
            {
                if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
                {
                    npc.localAI[0] += 3f;
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                    if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 120f * npc.ai[0])
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
                    if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 120f * npc.ai[0])
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
                    npc.ai[3] += 1f;
                    if (npc.ai[3] >= 800f)
                    {
                        npc.ai[2] += 1f;
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                    if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 180f * npc.ai[0])
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
                    if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 180f * npc.ai[0])
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
                        int num493 = mod.ProjectileType<VoidStarP>();
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
            else if (npc.ai[2] == 1f)
            {
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 200f)
                {
                    npc.localAI[0] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
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
                        int num499 = mod.ProjectileType<VoidStarP>();
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
        /*npc.spriteDirection = -(int)npc.ai[0];
        if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != 32)
        {
            npc.ai[2] += 10f;
            if (npc.ai[2] > 50f || Main.netMode != 2)
            {
                npc.life = -1;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
        }
        if (npc.ai[2] == 0f)
        {
            if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
            {
                npc.timeLeft = 10;
            }
            if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
            {
                npc.localAI[0] += 2f;
                if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
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
                if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 120f * npc.ai[0])
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
                if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 120f * npc.ai[0])
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
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 1100f)
                {
                    npc.localAI[0] = 0f;
                    npc.ai[2] = 1f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                }
                if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 150f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.04f;
                    if (npc.velocity.Y > 3f)
                    {
                        npc.velocity.Y = 3f;
                    }
                }
                else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 150f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.04f;
                    if (npc.velocity.Y < -3f)
                    {
                        npc.velocity.Y = -3f;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) + 200f)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.2f;
                    if (npc.velocity.X > 8f)
                    {
                        npc.velocity.X = 8f;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) + 160f)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.2f;
                    if (npc.velocity.X < -8f)
                    {
                        npc.velocity.X = -8f;
                    }
                }
            }
            Vector2 vector56 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num476 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector56.X;
            float num477 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector56.Y;
            float num478 = (float)Math.Sqrt((double)(num476 * num476 + num477 * num477));
            npc.rotation = (float)Math.Atan2((double)num477, (double)num476) + 1.57f;
            if (Main.netMode != 1)
            {
                npc.localAI[0] += 1f;
                if (npc.localAI[0] > 140f)
                {
                    npc.localAI[0] = 0f;
                    float num479 = 12f;
                    int num480 = 0;
                    int num481 = 102;
                    num478 = num479 / num478;
                    num476 = -num476 * num478;
                    num477 = -num477 * num478;
                    num476 += (float)Main.rand.Next(-40, 41) * 0.01f;
                    num477 += (float)Main.rand.Next(-40, 41) * 0.01f;
                    vector56.X += num476 * 4f;
                    vector56.Y += num477 * 4f;
                    Projectile.NewProjectile(vector56.X, vector56.Y, num476, num477, num481, num480, 0f, Main.myPlayer, 0f, 0f);
                    return;
                }
            }
        }
        else if (npc.ai[2] == 1f)
        {
            npc.ai[3] += 1f;
            if (npc.ai[3] >= 300f)
            {
                npc.localAI[0] = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                npc.netUpdate = true;
            }
            Vector2 vector57 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num482 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector57.X;
            float num483 = Main.npc[(int)npc.ai[1]].position.Y - vector57.Y;
            num483 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 80f - vector57.Y;
            float num484 = (float)Math.Sqrt((double)(num482 * num482 + num483 * num483));
            num484 = 6f / num484;
            num482 *= num484;
            num483 *= num484;
            if (npc.velocity.X > num482)
            {
                if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.9f;
                }
                npc.velocity.X = npc.velocity.X - 0.04f;
            }
            if (npc.velocity.X < num482)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.9f;
                }
                npc.velocity.X = npc.velocity.X + 0.04f;
            }
            if (npc.velocity.Y > num483)
            {
                if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.9f;
                }
                npc.velocity.Y = npc.velocity.Y - 0.08f;
            }
            if (npc.velocity.Y < num483)
            {
                if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.9f;
                }
                npc.velocity.Y = npc.velocity.Y + 0.08f;
            }
            npc.TargetClosest(true);
            vector57 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            num482 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector57.X;
            num483 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector57.Y;
            num484 = (float)Math.Sqrt((double)(num482 * num482 + num483 * num483));
            npc.rotation = (float)Math.Atan2((double)num483, (double)num482) - 1.57f;
            if (Main.netMode != 1)
            {
                npc.localAI[0] += 1f;
                if (npc.localAI[0] > 40f)
                {
                    npc.localAI[0] = 0f;
                    float num485 = 10f;
                    int num486 = 0;
                    int num487 = 102;
                    num484 = num485 / num484;
                    num482 *= num484;
                    num483 *= num484;
                    num482 += (float)Main.rand.Next(-40, 41) * 0.01f;
                    num483 += (float)Main.rand.Next(-40, 41) * 0.01f;
                    vector57.X += num482 * 4f;
                    vector57.Y += num483 * 4f;
                    Projectile.NewProjectile(vector57.X, vector57.Y, num482, num483, num487, num486, 0f, Main.myPlayer, 0f, 0f);
                    return;
                }
            }
        }*/

    }
}