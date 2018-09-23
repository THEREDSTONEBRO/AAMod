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
    [AutoloadBossHead]
    public class Zero : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero");
            Main.npcFrameCount[npc.type] = 3; 
        }

        public override void SetDefaults()
        {
            npc.width = 206;
            npc.height = 208;
            npc.aiStyle = -1;
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

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write((short)npc.localAI[0]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            npc.localAI[0] = reader.ReadInt16();
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

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.7f);
        }

        public override void AI()
        {
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            bool expert = Main.expertMode;


            if (npc.ai[3] != 6)
            {
                if (npc.ai[3] != npc.localAI[0])
                {
                    npc.localAI[0] = npc.ai[3];
                    for (int i = 0; i < 200; i++)
                    {
                        NPC npc2 = Main.npc[i];
                        if (npc2.type == mod.NPCType("TeslaHand") && npc2.active)
                        {
                            npc2.ai[2] = 0f;
                            npc2.ai[3] = 0f;
                        }
                    }
                }
                if (expert)
                    npc.dontTakeDamage = true;
            }
            else
            {
                if (expert)
                    npc.dontTakeDamage = false;
            }
            if (npc.ai[0] < 300f) npc.ai[0]++;
            if (npc.ai[0] == 300.0 && Main.netMode != 1)
            {
                npc.TargetClosest(true);
                npc.ai[0]++;
                int index1 = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("VoidStar"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                Main.npc[index1].ai[0] = -1f;
                Main.npc[index1].ai[1] = npc.whoAmI;
                Main.npc[index1].target = npc.target;
                Main.npc[index1].netUpdate = true;
                int index2 = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RiftShredder"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                Main.npc[index2].ai[0] = 1f;
                Main.npc[index2].ai[1] = npc.whoAmI;
                Main.npc[index2].target = npc.target;
                Main.npc[index2].netUpdate = true;
                int index3 = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("Taser"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                Main.npc[index3].ai[0] = -1f;
                Main.npc[index3].ai[1] = npc.whoAmI;
                Main.npc[index3].target = npc.target;
                Main.npc[index3].ai[3] = 150f;
                Main.npc[index3].netUpdate = true;
                int index4 = NPC.NewNPC((int)(npc.position.X + (double)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RealityCannon"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                Main.npc[index4].ai[0] = 1f;
                Main.npc[index4].ai[1] = npc.whoAmI;
                Main.npc[index4].target = npc.target;
                Main.npc[index4].netUpdate = true;
                Main.npc[index4].ai[3] = 150f;
                
            }
            if (Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000.0 || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000.0)
                    npc.ai[1] = 3f;
            }
            if (((int)(Main.player[npc.target].position.Y / 16) <= Main.maxTilesY - 190 - (int)(Main.maxTilesY / 5)) && npc.ai[1] != 3.0 && npc.ai[1] != 2.0)
            {
                npc.ai[1] = 2f;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }
            if (npc.ai[1] == 0.0)
            {
                ++npc.ai[2];
                if (npc.ai[2] >= 600.0)
                {
                    npc.ai[2] = 0.0f;
                    npc.ai[1] = 1f;
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                }
                npc.rotation = npc.velocity.X / 15f;
                if (npc.position.Y > Main.player[npc.target].position.Y - 200.0)
                {
                    if (npc.velocity.Y > 0.0)
                        npc.velocity.Y *= 0.98f;
                    npc.velocity.Y -= 0.1f;
                    if (npc.velocity.Y > 2.0)
                        npc.velocity.Y = 2f;
                }
                else if (npc.position.Y < Main.player[npc.target].position.Y - 500.0)
                {
                    if (npc.velocity.Y < 0.0)
                        npc.velocity.Y *= 0.98f;
                    npc.velocity.Y += 0.1f;
                    if (npc.velocity.Y < -2.0)
                        npc.velocity.Y = -2f;
                }
                if (npc.position.X + (double)(npc.width / 2) > Main.player[npc.target].position.X + (double)(Main.player[npc.target].width / 2) + 100.0)
                {
                    if (npc.velocity.X > 0.0)
                        npc.velocity.X *= 0.98f;
                    npc.velocity.X -= 0.1f;
                    if (npc.velocity.X > 8.0)
                        npc.velocity.X = 8f;
                }


                if (npc.position.X + (double)(npc.width / 2) >= Main.player[npc.target].position.X + (double)(Main.player[npc.target].width / 2) - 100.0)
                    return;
                if (npc.velocity.X < 0.0)
                    npc.velocity.X *= 0.98f;
                npc.velocity.X += 0.1f;
                if (npc.velocity.X >= -8.0)
                    return;
                npc.velocity.X = -8f;



                if (Main.netMode == 1 || !expert || npc.ai[3] != 6)
                    return;
                ++npc.localAI[0];
                if (npc.localAI[0] <= 150.0)
                    return;
                npc.localAI[0] = 0.0f;
                Vector2 vector2_6 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num41 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector2_6.X;
                float num42 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector2_6.Y;
                float num43 = (float)Math.Sqrt(num41 * (double)num41 + num42 * (double)num42);
                float num4 = 8f;
                int Damage = 15;
                int Type = 258;
                float num5 = num4 / num43;
                float num6 = num41 * num5;
                float num7 = num42 * num5;
                float SpeedX = num6 + Main.rand.Next(-5, 6) * 0.05f;
                float SpeedY = num7 + Main.rand.Next(-5, 6) * 0.05f;
                vector2_6.X += SpeedX * 6f;
                vector2_6.Y += SpeedY * 6f;
                Projectile.NewProjectile(vector2_6.X, vector2_6.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
            }
            else if (npc.ai[1] == 1.0)
            {
                npc.defense *= 2;
                npc.damage *= 2;
                ++npc.ai[2];
                if (npc.ai[2] == 2.0)
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                if (npc.ai[2] >= 400.0)
                {
                    npc.ai[2] = 0.0f;
                    npc.ai[1] = 0.0f;
                }
                npc.rotation += npc.direction * 0.3f;
                Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num1 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector2.X;
                float num2 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector2.Y;
                float num3 = 2f / (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
                npc.velocity.X = num1 * num3;
                npc.velocity.Y = num2 * num3;

            }
            else if (npc.ai[1] == 2.0)
            {
                npc.damage = 1000;
                npc.defense = 9999;
                npc.rotation += npc.direction * 0.3f;
                Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num1 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector2.X;
                float num2 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector2.Y;
                float num3 = (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
                float num4 = 10f + num3 / 100f;
                if (num4 < 8.0)
                    num4 = 8f;
                if (num4 > 32.0)
                    num4 = 32f;
                float num5 = num4 / num3;
                npc.velocity.X = num1 * num5;
                npc.velocity.Y = num2 * num5;
            }
            else
            {
                if (npc.ai[1] != 3.0)
                    return;
                npc.velocity.Y += 0.1f;
                if (npc.velocity.Y < 0.0)
                    npc.velocity.Y *= 0.95f;
                npc.velocity.X *= 0.95f;
                if (npc.timeLeft <= 500)
                    return;
                npc.timeLeft = 500;
            }

        }
    }
}







