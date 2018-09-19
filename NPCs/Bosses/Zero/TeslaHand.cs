using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Bosses.Zero
{
    public class TeslaHand : Zero
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/TeslaHand"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Weapon");
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 42;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeVice;
            npc.noGravity = true;
        }
        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            Vector2 vector51 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num462 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector51.X;
            float num463 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector51.Y;
            float num464 = (float)Math.Sqrt((double)(num462 * num462 + num463 * num463));
            if (npc.ai[2] != 99f)
            {
                if (num464 > 800f)
                {
                    npc.ai[2] = 99f;
                }
            }
            else if (num464 < 400f)
            {
                npc.ai[2] = 0f;
            }
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
            if (npc.ai[2] == 99f)
            {
                if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y > 8f)
                    {
                        npc.velocity.Y = 8f;
                    }
                }
                else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < -8f)
                    {
                        npc.velocity.Y = -8f;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2))
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.5f;
                    if (npc.velocity.X > 12f)
                    {
                        npc.velocity.X = 12f;
                    }
                }
                if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2))
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    if (npc.velocity.X < -12f)
                    {
                        npc.velocity.X = -12f;
                        return;
                    }
                }
            }
            else
            {
                if (npc.ai[2] == 0f || npc.ai[2] == 3f)
                {
                    if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
                    {
                        npc.TargetClosest(true);
                        npc.TargetClosest(true);
                        if (Main.player[npc.target].dead)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.1f;
                            if (npc.velocity.Y > 16f)
                            {
                                npc.velocity.Y = 16f;
                            }
                        }
                        else
                        {
                            Vector2 vector52 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num465 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector52.X;
                            float num466 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector52.Y;
                            float num467 = (float)Math.Sqrt((double)(num465 * num465 + num466 * num466));
                            num467 = 12f / num467;
                            num465 *= num467;
                            num466 *= num467;
                            npc.rotation = (float)Math.Atan2((double)num466, (double)num465) - 1.57f;
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 2f)
                            {
                                npc.rotation = (float)Math.Atan2((double)num466, (double)num465) - 1.57f;
                                npc.velocity.X = num465;
                                npc.velocity.Y = num466;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.velocity *= 0.97f;
                            }
                            npc.ai[3] += 1f;
                            if (npc.ai[3] >= 600f)
                            {
                                npc.ai[2] = 0f;
                                npc.ai[3] = 0f;
                                npc.netUpdate = true;
                            }
                        }
                    }
                    else
                    {
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] += 1f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y + 300f)
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
                        else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y + 230f)
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
                        if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) + 250f)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.94f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.3f;
                            if (npc.velocity.X > 9f)
                            {
                                npc.velocity.X = 9f;
                            }
                        }
                        if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2))
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.94f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.2f;
                            if (npc.velocity.X < -8f)
                            {
                                npc.velocity.X = -8f;
                            }
                        }
                    }
                    Vector2 vector53 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num468 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector53.X;
                    float num469 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector53.Y;
                    Math.Sqrt((double)(num468 * num468 + num469 * num469));
                    npc.rotation = (float)Math.Atan2((double)num469, (double)num468) + 1.57f;
                    return;
                }
                if (npc.ai[2] == 1f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    Vector2 vector54 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num470 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 280f * npc.ai[0] - vector54.X;
                    float num471 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector54.Y;
                    float num472 = (float)Math.Sqrt((double)(num470 * num470 + num471 * num471));
                    npc.rotation = (float)Math.Atan2((double)num471, (double)num470) + 1.57f;
                    npc.velocity.X = (npc.velocity.X * 5f + Main.npc[(int)npc.ai[1]].velocity.X) / 6f;
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    npc.velocity.Y = npc.velocity.Y - 0.5f;
                    if (npc.velocity.Y < -9f)
                    {
                        npc.velocity.Y = -9f;
                    }
                    if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 280f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 2f;
                        vector54 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        num470 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector54.X;
                        num471 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector54.Y;
                        num472 = (float)Math.Sqrt((double)(num470 * num470 + num471 * num471));
                        num472 = 20f / num472;
                        npc.velocity.X = num470 * num472;
                        npc.velocity.Y = num471 * num472;
                        npc.netUpdate = true;
                        return;
                    }
                }
                else if (npc.ai[2] == 2f)
                {
                    if (npc.position.Y > Main.player[npc.target].position.Y || npc.velocity.Y < 0f)
                    {
                        if (npc.ai[3] >= 4f)
                        {
                            npc.ai[2] = 3f;
                            npc.ai[3] = 0f;
                            return;
                        }
                        npc.ai[2] = 1f;
                        npc.ai[3] += 1f;
                        return;
                    }
                }
                else if (npc.ai[2] == 4f)
                {
                    Vector2 vector55 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num473 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector55.X;
                    float num474 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector55.Y;
                    float num475 = (float)Math.Sqrt((double)(num473 * num473 + num474 * num474));
                    npc.rotation = (float)Math.Atan2((double)num474, (double)num473) + 1.57f;
                    npc.velocity.Y = (npc.velocity.Y * 5f + Main.npc[(int)npc.ai[1]].velocity.Y) / 6f;
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    if (npc.velocity.X > 12f)
                    {
                        npc.velocity.X = 12f;
                    }
                    if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 500f || npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) + 500f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 5f;
                        vector55 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        num473 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector55.X;
                        num474 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector55.Y;
                        num475 = (float)Math.Sqrt((double)(num473 * num473 + num474 * num474));
                        num475 = 17f / num475;
                        npc.velocity.X = num473 * num475;
                        npc.velocity.Y = num474 * num475;
                        npc.netUpdate = true;
                        return;
                    }
                }
                else if (npc.ai[2] == 5f && npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - 100f)
                {
                    if (npc.ai[3] >= 4f)
                    {
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        return;
                    }
                    npc.ai[2] = 4f;
                    npc.ai[3] += 1f;
                    return;
                }
            }
        }
    }
}