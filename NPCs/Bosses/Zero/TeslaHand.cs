using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    public class TeslaHand : ModNPC
    {
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
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeVice;
            npc.noGravity = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/TeslaHand_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
            for (int l = 0; l < 2; l++)
            {
                float num21 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector7.X;
                float num22 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector7.Y;
                float num23;
                if (l == 0)
                {
                    num21 -= 200f * npc.ai[0];
                    num22 += 130f;
                    num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
                    num23 = 92f / num23;
                    vector7.X += num21 * num23;
                    vector7.Y += num22 * num23;
                }
                else
                {
                    num21 -= 50f * npc.ai[0];
                    num22 += 80f;
                    num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
                    num23 = 60f / num23;
                    vector7.X += num21 * num23;
                    vector7.Y += num22 * num23;
                }
                float rotation7 = (float)Math.Atan2((double)num22, (double)num21) - 1.57f;
                Color color7 = Lighting.GetColor((int)vector7.X / 16, (int)(vector7.Y / 16f));
                Main.spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/ZeroArm"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                if (l == 0)
                {
                    vector7.X += num21 * num23 / 2f;
                    vector7.Y += num22 * num23 / 2f;
                }
                else if (Main.rand.Next(2) == 0)
                {

                    vector7.X += num21 * num23 - 16f;
                    vector7.Y += num22 * num23 - 6f;
                    int num24 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num21 * 0.02f, num22 * 0.02f, 0, default(Microsoft.Xna.Framework.Color), 2.5f);
                    Main.dust[num24].noGravity = true;
                }
            }
            return base.PreDraw(spriteBatch, drawColor);
        }

        public override void AI()
        {
            bool flag = (npc.lifeMax / 2) >= npc.life;
            if (flag && Main.netMode != 1)
            {
                int ind = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("TeslaHand"), npc.whoAmI, npc.ai[0], npc.ai[1], 0f, 0f, byte.MaxValue);
                Main.npc[ind].life = npc.life;
                Main.npc[ind].rotation = npc.rotation;
                Main.npc[ind].velocity = npc.velocity;
                Main.npc[ind].netUpdate = true;
                Main.npc[(int)npc.ai[1]].ai[3]++;
                Main.npc[(int)npc.ai[1]].netUpdate = true;
            }
            npc.spriteDirection = -(int)npc.ai[0];
            Vector2 vector51 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num462 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector51.X;
            float num463 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector51.Y;
            float num464 = (float)Math.Sqrt(num462 * num462 + num463 * num463);
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
                if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
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
                if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
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
                            Vector2 vector52 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            float num465 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector52.X;
                            float num466 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector52.Y;
                            float num467 = (float)Math.Sqrt(num465 * num465 + num466 * num466);
                            num467 = 12f / num467;
                            num465 *= num467;
                            num466 *= num467;
                            npc.rotation = (float)Math.Atan2(num466, num465) - 1.57f;
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 2f)
                            {
                                npc.rotation = (float)Math.Atan2(num466, num465) - 1.57f;
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
                        if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 250f)
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
                        if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
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
                    Vector2 vector53 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num468 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector53.X;
                    float num469 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector53.Y;
                    Math.Sqrt(num468 * num468 + num469 * num469);
                    npc.rotation = (float)Math.Atan2(num469, num468) + 1.57f;
                    return;
                }
                if (npc.ai[2] == 1f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    Vector2 vector54 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num470 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 280f * npc.ai[0] - vector54.X;
                    float num471 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector54.Y;
                    float num472 = (float)Math.Sqrt(num470 * num470 + num471 * num471);
                    npc.rotation = (float)Math.Atan2(num471, num470) + 1.57f;
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
                        vector54 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num470 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector54.X;
                        num471 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector54.Y;
                        num472 = (float)Math.Sqrt(num470 * num470 + num471 * num471);
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
                    Vector2 vector55 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num473 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector55.X;
                    float num474 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector55.Y;
                    float num475 = (float)Math.Sqrt(num473 * num473 + num474 * num474);
                    npc.rotation = (float)Math.Atan2(num474, num473) + 1.57f;
                    npc.velocity.Y = (npc.velocity.Y * 5f + Main.npc[(int)npc.ai[1]].velocity.Y) / 6f;
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    if (npc.velocity.X > 12f)
                    {
                        npc.velocity.X = 12f;
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 500f || npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 500f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 5f;
                        vector55 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num473 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector55.X;
                        num474 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector55.Y;
                        num475 = (float)Math.Sqrt(num473 * num473 + num474 * num474);
                        num475 = 17f / num475;
                        npc.velocity.X = num473 * num475;
                        npc.velocity.Y = num474 * num475;
                        npc.netUpdate = true;
                        return;
                    }
                }
                else if (npc.ai[2] == 5f && npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 100f)
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