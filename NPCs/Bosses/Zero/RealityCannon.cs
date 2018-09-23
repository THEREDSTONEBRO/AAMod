using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    public class RealityCannon : ModNPC
    {

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
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.value = 0f;
            npc.knockBackResist = -1f;
            npc.aiStyle = 0;
            animationType = NPCID.PrimeLaser;
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
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/RealityCannon_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
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
                int ind = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RealityCannon"), npc.whoAmI, npc.ai[0], npc.ai[1], 0f, 0f, byte.MaxValue);
                Main.npc[ind].life = npc.life;
                Main.npc[ind].rotation = npc.rotation;
                Main.npc[ind].velocity = npc.velocity;
                Main.npc[ind].netUpdate = true;
                Main.npc[(int)npc.ai[1]].ai[3]++;
                Main.npc[(int)npc.ai[1]].netUpdate = true;
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
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
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
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
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
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 180f * npc.ai[0])
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
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 180f * npc.ai[0])
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
                Vector2 vector58 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num488 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector58.X;
                float num489 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector58.Y;
                float num490 = (float)Math.Sqrt(num488 * num488 + num489 * num489);
                npc.rotation = (float)Math.Atan2(num489, num488) - 1.57f;
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
                        num488 += Main.rand.Next(-40, 41) * 0.05f;
                        num489 += Main.rand.Next(-40, 41) * 0.05f;
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
                Vector2 vector59 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num494 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 350f - vector59.X;
                float num495 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 20f - vector59.Y;
                float num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
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
                vector59 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                num494 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector59.X;
                num495 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector59.Y;
                num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                npc.rotation = (float)Math.Atan2(num495, num494) - 1.57f;
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
                        num494 += Main.rand.Next(-40, 41) * 0.05f;
                        num495 += Main.rand.Next(-40, 41) * 0.05f;
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