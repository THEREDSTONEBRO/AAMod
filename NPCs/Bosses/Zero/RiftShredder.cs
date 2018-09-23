using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    public class RiftShredder : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Shredder");

            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 62;
            npc.friendly = false;
            npc.damage = 100;
            npc.defense = 90;
            npc.lifeMax = 28000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeSaw;
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
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/RiftShredder_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
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
                int ind = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RiftShredder"), npc.whoAmI, npc.ai[0], npc.ai[1], 0f, 0f, byte.MaxValue);
                Main.npc[ind].life = npc.life;
                Main.npc[ind].rotation = npc.rotation;
                Main.npc[ind].velocity = npc.velocity;
                Main.npc[ind].netUpdate = true;
                Main.npc[(int)npc.ai[1]].ai[3]++;
                Main.npc[(int)npc.ai[1]].netUpdate = true;
            }
            Vector2 vector46 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num448 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector46.X;
            float num449 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector46.Y;
            float num450 = (float)Math.Sqrt(num448 * num448 + num449 * num449);
            if (npc.ai[2] != 99f)
            {
                if (num450 > 800f)
                {
                    npc.ai[2] = 99f;
                }
            }
            else if (num450 < 400f)
            {
                npc.ai[2] = 0f;
            }
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
                            Vector2 vector47 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            float num451 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector47.X;
                            float num452 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector47.Y;
                            float num453 = (float)Math.Sqrt(num451 * num451 + num452 * num452);
                            num453 = 7f / num453;
                            num451 *= num453;
                            num452 *= num453;
                            npc.rotation = (float)Math.Atan2(num452, num451) - 1.57f;
                            if (npc.velocity.X > num451)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.97f;
                                }
                                npc.velocity.X = npc.velocity.X - 0.05f;
                            }
                            if (npc.velocity.X < num451)
                            {
                                if (npc.velocity.X < 0f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.97f;
                                }
                                npc.velocity.X = npc.velocity.X + 0.05f;
                            }
                            if (npc.velocity.Y > num452)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y * 0.97f;
                                }
                                npc.velocity.Y = npc.velocity.Y - 0.05f;
                            }
                            if (npc.velocity.Y < num452)
                            {
                                if (npc.velocity.Y < 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y * 0.97f;
                                }
                                npc.velocity.Y = npc.velocity.Y + 0.05f;
                            }
                        }
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                    }
                    else
                    {
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 300f)
                        {
                            npc.ai[2] += 1f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y + 320f)
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
                        else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y + 260f)
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
                        if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.96f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.3f;
                            if (npc.velocity.X > 12f)
                            {
                                npc.velocity.X = 12f;
                            }
                        }
                        if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 250f)
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.96f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.3f;
                            if (npc.velocity.X < -12f)
                            {
                                npc.velocity.X = -12f;
                            }
                        }
                    }
                    Vector2 vector48 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num454 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector48.X;
                    float num455 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector48.Y;
                    Math.Sqrt(num454 * num454 + num455 * num455);
                    npc.rotation = (float)Math.Atan2(num455, num454) + 1.57f;
                    return;
                }
                if (npc.ai[2] == 1f)
                {
                    Vector2 vector49 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num456 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector49.X;
                    float num457 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector49.Y;
                    float num458 = (float)Math.Sqrt(num456 * num456 + num457 * num457);
                    npc.rotation = (float)Math.Atan2(num457, num456) + 1.57f;
                    npc.velocity.X = npc.velocity.X * 0.95f;
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y < -8f)
                    {
                        npc.velocity.Y = -8f;
                    }
                    if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 200f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 2f;
                        vector49 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num456 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector49.X;
                        num457 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector49.Y;
                        num458 = (float)Math.Sqrt(num456 * num456 + num457 * num457);
                        num458 = 22f / num458;
                        npc.velocity.X = num456 * num458;
                        npc.velocity.Y = num457 * num458;
                        npc.netUpdate = true;
                        return;
                    }
                }
                else if (npc.ai[2] == 2f)
                {
                    if (npc.position.Y > Main.player[npc.target].position.Y || npc.velocity.Y < 0f)
                    {
                        npc.ai[2] = 3f;
                        return;
                    }
                }
                else
                {
                    if (npc.ai[2] == 4f)
                    {
                        npc.TargetClosest(true);
                        Vector2 vector50 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        float num459 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector50.X;
                        float num460 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector50.Y;
                        float num461 = (float)Math.Sqrt(num459 * num459 + num460 * num460);
                        num461 = 7f / num461;
                        num459 *= num461;
                        num460 *= num461;
                        if (npc.velocity.X > num459)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.97f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.05f;
                        }
                        if (npc.velocity.X < num459)
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.97f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.05f;
                        }
                        if (npc.velocity.Y > num460)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.97f;
                            }
                            npc.velocity.Y = npc.velocity.Y - 0.05f;
                        }
                        if (npc.velocity.Y < num460)
                        {
                            if (npc.velocity.Y < 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.97f;
                            }
                            npc.velocity.Y = npc.velocity.Y + 0.05f;
                        }
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        vector50 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num459 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector50.X;
                        num460 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector50.Y;
                        num461 = (float)Math.Sqrt(num459 * num459 + num460 * num460);
                        npc.rotation = (float)Math.Atan2(num460, num459) + 1.57f;
                        return;
                    }
                    if (npc.ai[2] == 5f && ((npc.velocity.X > 0f && npc.position.X + npc.width / 2 > Main.player[npc.target].position.X + Main.player[npc.target].width / 2) || (npc.velocity.X < 0f && npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width / 2)))
                    {
                        npc.ai[2] = 0f;
                        return;
                    }
                }
            }
        }
    }
}