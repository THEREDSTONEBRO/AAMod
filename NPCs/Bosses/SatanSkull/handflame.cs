using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.SatanSkull
{
    public class handflame : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Satan's Flamethrower");
        }
        public override void SetDefaults()
        {
            
            npc.width = 52;
            npc.height = 52;
            npc.damage = 40;
            npc.defense = 23;
            npc.lifeMax = 7000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.0f;
            npc.buffImmune[20] = true;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
            npc.netAlways = true;

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale * (1 + numPlayers / 10));
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write((short)npc.localAI[0]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            npc.localAI[0] = reader.ReadInt16();
        }
        public override bool PreNPCLoot()
        {
            GoreHand();
            return base.PreNPCLoot();
        }


        public override void AI()
        {
            if (Main.expertMode) npc.dontTakeDamage = true;
            int idx;
            npc.spriteDirection = -(int)npc.ai[0];
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50.0 || Main.netMode != 2)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (Main.npc[(int)npc.ai[1]].ai[1] == 3.0 && npc.timeLeft > 10)
                npc.timeLeft = 10;

            if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
            {
                if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 50 * npc.ai[0])
                {
                    if (npc.velocity.Y > 0.0)
                        npc.velocity.Y *= 0.96f;
                    npc.velocity.Y -=1.1f;
                    if (npc.velocity.Y > 3.0)
                        npc.velocity.Y =3f;
                }
                else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y + 50 * npc.ai[0])
                {
                    if (npc.velocity.Y < 0.0)
                        npc.velocity.Y *= 0.96f;
                    npc.velocity.Y += 1.1f;
                    if (npc.velocity.Y < -3.0)
                        npc.velocity.Y = -3f;
                }
                if (npc.position.X + (double)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) - 25.0 * npc.ai[0])
                {
                    if (npc.velocity.X > 0.0)
                        npc.velocity.X *= 0.96f;
                    npc.velocity.X -= 1.14f;
                    if (npc.velocity.X > 8.0)
                        npc.velocity.X = 8f;

                }

                if (npc.position.X + (double)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) -25.0 * npc.ai[0])
                {
                    if (npc.velocity.X < 0.0)
                        npc.velocity.X *= 0.96f;
                    npc.velocity.X += 1.14f;
                    if (npc.velocity.X < -8.0)
                        npc.velocity.X = -8f;
                }
                npc.TargetClosest(true);
                Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                npc.rotation += npc.direction * 0.3f;
                if (Main.netMode == 1)
                    return;
                ++npc.localAI[0];
                if (npc.localAI[0] <=5.0)
                    return;
                npc.localAI[0] = 0.0f;
                if (Main.rand.Next(2) == 0)
                {
                    int Damage = 10;
                    int Type = mod.ProjectileType("SpinFlame");//85;
                float SpeedX = (float)Math.Sin(npc.rotation) + Main.rand.Next(-2, 3) * 0.05f;
                float SpeedY = (float)Math.Cos(npc.rotation) + Main.rand.Next(-2, 3) * 0.05f;
                vector2.X += SpeedX * 3f;
                vector2.Y += SpeedY * 3f;

                    Projectile.NewProjectile(vector2.X, vector2.Y, 0f, 0f, Type, Damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);

                }
            
        }
            else
            {
                if (npc.ai[2] == 0f)
                {
                    ++npc.ai[3];
                    if (npc.ai[3] >= 400f)
                    {
                        ++npc.ai[2];
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y + 50.0 * npc.ai[0])
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y *= 0.96f;
                        npc.velocity.Y -= 0.1f;
                        if (npc.velocity.Y > 3.0)
                            npc.velocity.Y = 3f;
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 50.0 * npc.ai[0])
                    {
                        if (npc.velocity.Y < 0.0)
                            npc.velocity.Y *= 0.96f;
                        npc.velocity.Y += 0.1f;
                        if (npc.velocity.Y < -3.0)
                            npc.velocity.Y = -3f;
                    }
                    if (npc.position.X + (double)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) - 180.0 * npc.ai[0])
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X *= 0.96f;
                        npc.velocity.X -= 0.14f;
                        if (npc.velocity.X > 8.0)
                            npc.velocity.X = 8f;
                    }
                    if (npc.position.X + (double)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) - 180.0 * npc.ai[0])
                    {
                        if (npc.velocity.X < 0.0)
                            npc.velocity.X *= 0.96f;
                        npc.velocity.X += 0.14f;
                        if (npc.velocity.X < -8.0)
                            npc.velocity.X = -8f;
                    }

                    npc.TargetClosest(true);
                    Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num1 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector2.X;
                    float num2 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector2.Y;
                    float num3 = (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
                    npc.rotation = (float)Math.Atan2(num2, num1) - 1.57f;
                    if (Main.netMode == 1 )//|| npc.ai[3] >= 200f)
                        return;
                    ++npc.localAI[0];
                    if (npc.localAI[0] <= 100.0)
                        return;
                    npc.localAI[0] = 0.0f;
                    float num4 = 8f;
                    int Damage = 15;
                    int Type = 258;
                    float num5 = num4 / num3;
                    float num6 = num1 * num5;
                    float num7 = num2 * num5;
                    float SpeedX = num6 + Main.rand.Next(-5,6) * 0.05f;
                    float SpeedY = num7 + Main.rand.Next(-5, 6) * 0.05f;
                    vector2.X += SpeedX * 6f;
                    vector2.Y += SpeedY * 6f;
                    idx = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                }
                else if (npc.ai[2] == 1f)
                {
                    ++npc.ai[3];
                    if (npc.ai[3] >= 300f)
                    {
                        npc.ai[2]=0f;
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100)
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y *= 0.96f;
                        npc.velocity.Y -= 0.1f;
                        if (npc.velocity.Y > 3.0)
                            npc.velocity.Y = 3f;
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100)
                    {
                        if (npc.velocity.Y < 0.0)
                            npc.velocity.Y *= 0.96f;
                        npc.velocity.Y += 0.1f;
                        if (npc.velocity.Y < -3.0)
                            npc.velocity.Y = -3f;
                    }
                    if (npc.position.X + (double)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) - 180.0 * npc.ai[0])
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X *= 0.96f;
                        npc.velocity.X -= 0.14f;
                        if (npc.velocity.X > 8.0)
                            npc.velocity.X = 8f;
                    }
                    if (npc.position.X + (double)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (double)(Main.npc[(int)npc.ai[1]].width / 2) - 180.0 * npc.ai[0])
                    {
                        if (npc.velocity.X < 0.0)
                            npc.velocity.X *= 0.96f;
                        npc.velocity.X += 0.14f;
                        if (npc.velocity.X < -8.0)
                            npc.velocity.X = -8f;
                    }
                }
            }

        }
        public void GoreHand()
        {
            for (int num512 = 0; num512 < 40; num512++)
            {
                Color color5 = new Color();
                int num257 = Dust.NewDust(new Vector2((npc.position.X + 3f), (npc.position.Y + 3f)) - ((Vector2)(npc.velocity * 0.5f)), npc.width+8, npc.height+8, 6, 0f, 0f, 100, color5, 1f);
                Dust dust99 = Main.dust[num257];
                dust99.scale *= 2f + (Main.rand.Next(10) * 0.1f);
                Dust dust100 = Main.dust[num257];
                dust100.velocity = (Vector2)(dust100.velocity * 0.2f);
                Main.dust[num257].noGravity = true;
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
                Main.spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/SatanSkull/ArmSatan"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
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
    }
}