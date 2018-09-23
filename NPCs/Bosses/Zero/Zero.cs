using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    [AutoloadBossHead]
    public class Zero : ModNPC
    {
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero");
            Main.npcFrameCount[npc.type] = 3; 
        }

        public override void SetDefaults()
        {
            npc.width = 206;
            npc.height = 208;
            npc.aiStyle = 0;
            npc.damage = 130;
            npc.defense = 70;
            npc.lifeMax = 200000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.noGravity = true;
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Zero");
            npc.noTileCollide = true;
            if (Main.expertMode)
            {
                npc.value = 0;
            }
            else
            {
                npc.value = 120000f;
            }
            npc.knockBackResist = -1f;
            npc.boss = true;
            npc.friendly = false;
            animationType = NPCID.SkeletronPrime;
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.netAlways = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && npc.type == mod.NPCType<Zero>())
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/ZeroGore3"), 1f);
                npc.position.X = npc.position.X + npc.width / 2;
                npc.position.Y = npc.position.Y + npc.height / 2;
                npc.width = 100;
                npc.height = 100;
                npc.position.X = npc.position.X - npc.width / 2;
                npc.position.Y = npc.position.Y - npc.height / 2;
                Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
                if (Main.expertMode)
                {
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("ZeroAwakened"));
                }
            }
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropLoot(mod.ItemType("ApocalyptitePlate"), 2, 4);
            }
            else
            {
                npc.DropLoot(mod.ItemType("ApocalyptitePlate"), 20, 30);
                npc.DropLoot(mod.ItemType("UnstableSingularity"), 25, 35);
                string[] lootTable = { "RiftShredder", "EventHorizon", "VoidStar", "RealityCannon", "TeslaHand", "ZeroStar" };
                int loot = Main.rand.Next(lootTable.Length);
                npc.DropLoot(mod.ItemType(lootTable[loot]));
                npc.DropLoot(Items.Vanity.Mask.ZeroMask.type, 1f / 7);
                npc.DropLoot(Items.Blocks.ZeroTrophy.type, 1f / 10);
            }
        }
        
        public override void BossLoot(ref string name, ref int potionType)
        {
            if (!Main.expertMode)
            {
                potionType = ItemID.GreaterHealingPotion;   //boss drops
                AAWorld.downedZero = true;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/Zero_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
            npc.frame, Color.White, npc.rotation,
            new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D ZeroArmTex = mod.GetTexture("NPCs/Bosses/Zero/ZeroArm");
            if (npc.type == mod.NPCType("VoidStar") || npc.type == mod.NPCType("RealityCannon") || npc.type == mod.NPCType("RiftShredder") || npc.type == mod.NPCType("TeslaHand"))
            {
                Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                for (int k = 0; k < 2; k++)
                {
                    float num22 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector7.X;
                    float num23 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector7.Y;
                    float num24;
                    if (k == 0)
                    {
                        num22 -= 200f * npc.ai[0];
                        num23 += 130f;
                        num24 = (float)Math.Sqrt(num22 * num22 + num23 * num23);
                        num24 = 92f / num24;
                        vector7.X += num22 * num24;
                        vector7.Y += num23 * num24;
                    }
                    else
                    {
                        num22 -= 50f * npc.ai[0];
                        num23 += 80f;
                        num24 = (float)Math.Sqrt(num22 * num22 + num23 * num23);
                        num24 = 60f / num24;
                        vector7.X += num22 * num24;
                        vector7.Y += num23 * num24;
                    }
                    float rotation7 = (float)Math.Atan2(num23, num22) - 1.57f;
                    Color color7 = Lighting.GetColor((int)vector7.X / 16, (int)(vector7.Y / 16f));
                    Main.spriteBatch.Draw(ZeroArmTex, new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, ZeroArmTex.Width, ZeroArmTex.Height)), color7, rotation7, new Vector2(ZeroArmTex.Width * 0.5f, (float)ZeroArmTex.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    if (k == 0)
                    {
                        vector7.X += num22 * num24 / 2f;
                        vector7.Y += num23 * num24 / 2f;
                    }
                    else if (npc.active)
                    {
                        vector7.X += num22 * num24 - 16f;
                        vector7.Y += num23 * num24 - 6f;
                        int num25 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num22 * 0.02f, num23 * 0.02f, 0, default(Microsoft.Xna.Framework.Color), 2.5f);
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
            return true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.7f);
        }



        public override void AI()
        {
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            if (npc.ai[0] == 0f && Main.netMode != 1)
            {
                npc.TargetClosest(true);
                npc.ai[0] = 1f;
                int num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RiftShredder"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = -1f;
                Main.npc[num440].ai[1] = npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, mod.NPCType("TeslaHand"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = 1f;
                Main.npc[num440].ai[1] = npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, mod.NPCType("VoidStar"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = -1f;
                Main.npc[num440].ai[1] = npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].ai[3] = 150f;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, mod.NPCType("RealityCannon"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = 1f;
                Main.npc[num440].ai[1] = npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].netUpdate = true;
                Main.npc[num440].ai[3] = 150f;
            }

            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    npc.ai[1] = 3f;
                }
            }

            if (npc.ai[1] == 0f)
            {
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 600f)
                {
                    npc.ai[2] = 0f;
                    npc.ai[1] = 1f;
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                }

                npc.rotation = npc.velocity.X / 15f;
                if (npc.position.Y > Main.player[npc.target].position.Y - 200f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y > 2f)
                    {
                        npc.velocity.Y = 2f;
                    }
                }

                else if (npc.position.Y < Main.player[npc.target].position.Y - 500f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < -2f)
                    {
                        npc.velocity.Y = -2f;
                    }
                }

                if (npc.position.X + npc.width / 2 > Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + 100f)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.1f;
                    if (npc.velocity.X > 8f)
                    {
                        npc.velocity.X = 8f;
                    }
                }

                if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 100f)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.1f;
                    if (npc.velocity.X < -8f)
                    {
                        npc.velocity.X = -8f;
                        return;
                    }
                }
            }

            else
            {
                if (npc.ai[1] == 1f)
                {
                    npc.defense *= 2;
                    npc.damage *= 2;
                    npc.ai[2] += 1f;
                    if (npc.ai[2] == 2f)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
                    }

                    if (npc.ai[2] >= 400f)
                    {
                        npc.ai[2] = 0f;
                        npc.ai[1] = 0f;
                    }
                    npc.rotation += npc.direction * 0.3f;
                    Vector2 vector44 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num441 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector44.X;
                    float num442 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector44.Y;
                    float num443 = (float)Math.Sqrt(num441 * num441 + num442 * num442);
                    num443 = 2f / num443;
                    npc.velocity.X = num441 * num443;
                    npc.velocity.Y = num442 * num443;
                    return;
                }

                if (npc.ai[1] == 2f)
                {
                    npc.damage = 1000;
                    npc.defense = 9999;
                    npc.rotation += npc.direction * 0.3f;
                    Vector2 vector45 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num444 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector45.X;
                    float num445 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector45.Y;
                    float num446 = (float)Math.Sqrt(num444 * num444 + num445 * num445);
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
                    return;
                }

                if (npc.ai[1] == 3f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.95f;
                    }
                    npc.velocity.X = npc.velocity.X * 0.95f;
                    if (npc.timeLeft > 500)
                    {
                        npc.timeLeft = 500;
                        return;
                    }
                }
            }
        }
    }

    public class RealityCannon : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/RealityCannon"; } }

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
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
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
                spriteBatch.Draw(mod.GetTexture("AAMod/NPCs/Bosses/Zero/RealityCannon_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
            return true;
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

    public class RiftShredder : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/RiftShredder"; } }

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
            npc.HitSound = new LegacySoundStyle(3, 4, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 14, Terraria.Audio.SoundType.Sound);
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
                spriteBatch.Draw(mod.GetTexture("AAMod/NPCs/Bosses/Zero/RiftShredder_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
            return true;
        }

        public override void AI()
        {
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

    public class TeslaHand : ModNPC
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

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("AAMod/NPCs/Bosses/Zero/TeslaHand_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
            return true;
        }

        public override void AI()
        {
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

    public class VoidStar : ModNPC
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

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("AAMod/NPCs/Bosses/Zero/VoidStar_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
            return true;
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
                        int num493 = mod.ProjectileType<VoidStarP>();
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
                        int num499 = mod.ProjectileType<VoidStarP>();
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
    class ZeroArm1 : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm1"; } }
    }
    class ZeroArm2 : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm1"; } }
    }
    class ZeroArm3 : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm1"; } }
    }
    class ZeroArm4 : ModNPC
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm1"; } }
    }
}







