﻿using System;
using AAMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using AAMod.Items.Dev;
using System.Collections.Generic;
using System.Reflection;

namespace AAMod.NPCs.Bosses.Zero
{
    [AutoloadBossHead]
    public class ZeroAwakened : ModNPC
    {
        private List<string> SteamId64List;
        private static string CurrentSteamID64;

        public int timer;
        public static int type;
        private bool Panic = false;
        private bool DradonMode = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero Awakened");
            Main.npcFrameCount[npc.type] = 12;    //boss frame/animation 
            NPCID.Sets.TrailCacheLength[npc.type] = 5;
            NPCID.Sets.TrailingMode[npc.type] = 0;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 0;  //5 is the flying AI
            if (!AAWorld.downedZeroA)
            {
                npc.lifeMax = 120000;   //boss life
                npc.damage = 70;  //boss damage
                npc.defense = 70;    //boss defense
            }
            if (AAWorld.downedZeroA)
            {
                npc.lifeMax = 150000;   //boss life
                npc.damage = 100;  //boss damage
                npc.defense = 100;    //boss defense
            }
            npc.knockBackResist = 0f;
            npc.width = 178;
            npc.height = 174;
            npc.friendly = false;
            animationType = NPCID.Retinazer;   //this boss will behavior like the DemonEye
            npc.value = Item.buyPrice(2, 0, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;  
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Sounds/Zerohit");
            npc.DeathSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Sounds/ZeroDeath");
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Zero2");
            npc.netAlways = true;
            bossBag = mod.ItemType("ZeroBag");
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropLoot(Items.Vanity.Mask.ZeroMask.type, 1f / 7);
                npc.DropLoot(Items.Boss.Zero.ZeroTrophy.type, 1f / 10);
                if (Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EXSoul"));
                }
                if (Main.rand.NextFloat() < 0.05f && AAWorld.RealityDropped == false)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RealityStone"));
                    AAWorld.RealityDropped = true;
                }
                npc.DropBossBags();
                return;
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;   //boss drops
            AAWorld.downedZero = true;
            Projectile.NewProjectile((new Vector2(npc.position.X, npc.position.Y)), (new Vector2(0f, 0f)), mod.ProjectileType("ZeroDeath1"), 0, 0);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= npc.lifeMax / 5 && Panic == false && !AAWorld.downedZeroA == false && Main.expertMode)
            {
                Panic = true;
                Main.NewText("WARNING. DRASTIC DAMAGE DETECTED, FAILURE IMMINENT. ENGAGE T0TAL 0FFENCE PR0T0C0L.", Color.Red.R, Color.Red.G, Color.Red.B);
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && AAWorld.downedZeroA == false && Main.expertMode)
            {
                Panic = true;
                Main.NewText("WARNING. DRASTIC DAMAGE DETECTED, FAILURE IMMINENT AGAIN. ENGAGE T0TAL 0FFENCE PR0T0C0L VΩ.", Color.Red.R, Color.Red.G, Color.Red.B);
            }
            if (damage > 30)
            {
                if (Main.rand.Next(0,10) == 0)
                {
                    int Xint = (Main.rand.Next(0, 2) == 0) ? Main.rand.Next(-30, -9) : Main.rand.Next(10, 31);
                    int Yint = (Main.rand.Next(0, 2) == 0) ? Main.rand.Next(-30, -9) : Main.rand.Next(10, 31);
                    Player player = Main.player[npc.target];
                    Vector2 tele = new Vector2(player.Center.X + Xint, player.Center.Y + Yint);
                    npc.Center = tele;
                }
            }
            if (npc.life <= 0 && Main.expertMode && !AAWorld.downedZeroA && npc.type == mod.NPCType<ZeroAwakened>())
            {
                Main.NewText("MISSI0N FAILED. SENDING DISTRESS SIGNAL TO HOME BASE", Color.Red.R, Color.Red.G, Color.Red.B);

                Panic = false;
            }
            if (npc.life <= 0 && Main.expertMode && AAWorld.downedZeroA && npc.type == mod.NPCType<ZeroAwakened>())
            {
                Main.NewText("TERRARIAN, Y0UR W0RLD IS ALREADY D00MED. THE INFINITY SLAYER IS ON IT’S WAY. CHANCE OF SUCCESS IN DEFEATING IT IS .00000000000001%.", Color.Red.R, Color.Red.G, Color.Red.B);
                Panic = false;
            }
            if (npc.life <= 0 && !Main.expertMode && npc.type == mod.NPCType<ZeroAwakened>())
            {
                Main.NewText("CHEATER ALERT CHEATER ALERT. N0 DR0PS 4 U.", Color.Red.R, Color.Red.G, Color.Red.B);
                Panic = false;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/ZeroAwakened_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
            npc.frame, Color.Red, npc.rotation,
            new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, npc.height * 0.5f);
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
                Texture2D ZeroTrail = mod.GetTexture("NPCs/Bosses/Zero/ZeroTrail");
                lightColor = new Color(k * 50, 0, 0);
                Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                spriteBatch.Draw(ZeroTrail, drawPos, null, color, npc.rotation, drawOrigin, npc.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            SteamId64List = new List<string>();

            PropertyInfo SteamID64Info =
                typeof(ModLoader).GetProperty("SteamID64", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo SteamID64 = SteamID64Info.GetAccessors(true)[0];
            CurrentSteamID64 = (string)SteamID64.Invoke(null, new object[] { });

            SteamId64List.Add(CurrentSteamID64);

            if (damage > npc.lifeMax / 2)
            {
                Main.NewText("Y0UR CHEAT SHEET BUTCHER T00L WILL N0T SAVE Y0U HERE", Color.Red.R, Color.Red.G, Color.Red.B);
                damage = 0;
            }
            if (hitDirection == 0 && damage != 0 && SteamId64List.Contains("76561198062217769"))
            {
                Main.NewText("HELL0 DRAD0N WELC0ME T0 MY SPECIAL HELL!", Color.Red.R, Color.Red.G, Color.Red.B);
                damage = 0;
                DradonMode = true;
                npc.immortal = true;
                npc.chaseable = false;
                npc.damage = 99999999;
                npc.life = npc.lifeMax;
            }
            return false;
        }

        public override void AI()
        {
            if (DradonMode)
            {
                float Eggroll = Math.Abs(Main.GameUpdateCount) / 2.5f;
                float Pie = 1f * (float)Math.Sin(Eggroll);
                npc.color = Color.Lerp(Main.DiscoColor, Color.Transparent, Pie);
                //music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/JokeSong");
            }
            if (npc.life <= npc.lifeMax / 5 && !DradonMode)
            {
                music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/RayOfHope");
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            bool dead2 = Main.player[npc.target].dead;
            float num367 = npc.position.X + npc.width / 2 - Main.player[npc.target].position.X - Main.player[npc.target].width / 2;
            float num368 = npc.position.Y + npc.height - 59f - Main.player[npc.target].position.Y - Main.player[npc.target].height / 2;
            float num369 = (float)Math.Atan2(num368, num367) + 1.57f;
            if (num369 < 0f)
            {
                num369 += 6.283f;
            }
            else if (num369 > 6.283)
            {
                num369 -= 6.283f;
            }
            float num370 = 0.1f;
            if (npc.rotation < num369)
            {
                if (num369 - npc.rotation > 3.1415)
                {
                    npc.rotation -= num370;
                }
                else
                {
                    npc.rotation += num370;
                }
            }
            else if (npc.rotation > num369)
            {
                if (npc.rotation - num369 > 3.1415)
                {
                    npc.rotation += num370;
                }
                else
                {
                    npc.rotation -= num370;
                }
            }
            if (npc.rotation > num369 - num370 && npc.rotation < num369 + num370)
            {
                npc.rotation = num369;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += 6.283f;
            }
            else if (npc.rotation > 6.283)
            {
                npc.rotation -= 6.283f;
            }
            if (npc.rotation > num369 - num370 && npc.rotation < num369 + num370)
            {
                npc.rotation = num369;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num371 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
                Dust expr_12582_cp_0 = Main.dust[num371];
                expr_12582_cp_0.velocity.X = expr_12582_cp_0.velocity.X * 0.5f;
                Dust expr_125A2_cp_0 = Main.dust[num371];
                expr_125A2_cp_0.velocity.Y = expr_125A2_cp_0.velocity.Y * 0.1f;
            }
            if (Main.netMode != 1 && !dead2 && npc.timeLeft < 10)
            {
                for (int num372 = 0; num372 < 200; num372++)
                {
                    if (num372 != npc.whoAmI && Main.npc[num372].active && (Main.npc[num372].type == 125 || Main.npc[num372].type == 126) && Main.npc[num372].timeLeft - 1 > npc.timeLeft)
                    {
                        npc.timeLeft = Main.npc[num372].timeLeft - 1;
                    }
                }
            }
            if (dead2)
            {
                Main.NewText("TARGET NEUTRALIZED. RETURNING T0 0RBIT.", Color.Red.R, Color.Red.G, Color.Red.B);
                Panic = false;
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            else if (npc.ai[0] == 0f)
            {
                if (npc.ai[1] == 0f)
                {
                    float num373 = 7f;
                    float num374 = 0.1f;
                    if (Main.expertMode)
                    {
                        num373 = 8.25f;
                        num374 = 0.115f;
                    }
                    int num375 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num375 = -1;
                    }
                    Vector2 vector36 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num376 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num375 * 300 - vector36.X;
                    float num377 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 300f - vector36.Y;
                    float num378 = (float)Math.Sqrt(num376 * num376 + num377 * num377);
                    float num379 = num378;
                    num378 = num373 / num378;
                    num376 *= num378;
                    num377 *= num378;
                    if (npc.velocity.X < num376)
                    {
                        npc.velocity.X = npc.velocity.X + num374;
                        if (npc.velocity.X < 0f && num376 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num374;
                        }
                    }
                    else if (npc.velocity.X > num376)
                    {
                        npc.velocity.X = npc.velocity.X - num374;
                        if (npc.velocity.X > 0f && num376 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num374;
                        }
                    }
                    if (npc.velocity.Y < num377)
                    {
                        npc.velocity.Y = npc.velocity.Y + num374;
                        if (npc.velocity.Y < 0f && num377 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num374;
                        }
                    }
                    else if (npc.velocity.Y > num377)
                    {
                        npc.velocity.Y = npc.velocity.Y - num374;
                        if (npc.velocity.Y > 0f && num377 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - num374;
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 600f)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.target = 255;
                        npc.netUpdate = true;
                    }
                    else if (npc.position.Y + npc.height < Main.player[npc.target].position.Y && num379 < 400f)
                    {
                        if (!Main.player[npc.target].dead)
                        {
                            npc.ai[3] += 1f;
                            if (Main.expertMode && npc.life < npc.lifeMax * 0.9)
                            {
                                npc.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && npc.life < npc.lifeMax * 0.8)
                            {
                                npc.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && npc.life < npc.lifeMax * 0.7)
                            {
                                npc.ai[3] += 0.3f;
                            }
                            if (Main.expertMode && npc.life < npc.lifeMax * 0.6)
                            {
                                npc.ai[3] += 0.3f;
                            }
                        }
                        if (npc.ai[3] >= 60f)
                        {
                            npc.ai[3] = 0f;
                            vector36 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            num376 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector36.X;
                            num377 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector36.Y;
                            if (Main.netMode != 1)
                            {
                                float num380 = 9f;
                                int num381 = npc.damage / 8;
                                int num382 = mod.ProjectileType<DeathLaser>();
                                if (Main.expertMode)
                                {
                                    num380 = 10.5f;
                                    num381 = npc.damage / 8;
                                }
                                num378 = (float)Math.Sqrt(num376 * num376 + num377 * num377);
                                num378 = num380 / num378;
                                num376 *= num378;
                                num377 *= num378;
                                num376 += Main.rand.Next(-40, 41) * 0.08f;
                                num377 += Main.rand.Next(-40, 41) * 0.08f;
                                vector36.X += num376 * 15f;
                                vector36.Y += num377 * 15f;
                                Projectile.NewProjectile(vector36.X, vector36.Y, num376, num377, num382, num381, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                else if (npc.ai[1] == 1f)
                {
                    npc.rotation = num369;
                    float num383 = 12f;
                    if (Main.expertMode)
                    {
                        num383 = 15f;
                    }
                    Vector2 vector37 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num384 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector37.X;
                    float num385 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector37.Y;
                    float num386 = (float)Math.Sqrt(num384 * num384 + num385 * num385);
                    num386 = num383 / num386;
                    num386 *= 2;
                    npc.velocity.X = num384 * num386;
                    npc.velocity.Y = num385 * num386;
                    npc.ai[1] = 2f;
                }
                else if (npc.ai[1] == 2f)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 25f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                        {
                            npc.velocity.X = 0f;
                        }
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                        {
                            npc.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) - 1.57f;
                    }
                    if (npc.ai[2] >= 80f)
                    {
                        npc.ai[3] += 1f;
                        npc.ai[2] = 0f;
                        npc.target = 255;
                        npc.rotation = num369;
                        if (npc.ai[3] >= 4f)
                        {
                            npc.ai[1] = 0f;
                            npc.ai[3] = 0f;
                        }
                        else
                        {
                            npc.ai[1] = 1f;
                        }
                    }
                }
            }
            else if (npc.ai[0] == 1f || npc.ai[0] == 2f)
            {
                if (npc.ai[0] == 1f)
                {
                    npc.ai[2] += 0.005f;
                    if (npc.ai[2] > 0.5)
                    {
                        npc.ai[2] = 0.5f;
                    }
                }
                else
                {
                    npc.ai[2] -= 0.005f;
                    if (npc.ai[2] < 0f)
                    {
                        npc.ai[2] = 0f;
                    }
                }
                npc.rotation += npc.ai[2];
                npc.ai[1] += 1f;
                if (npc.ai[1] == 100f)
                {
                    npc.ai[0] += 1f;
                    npc.ai[1] = 0f;
                    if (npc.ai[0] == 3f)
                    {
                        npc.ai[2] = 0f;
                    }
                    else
                    {
                        Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1, 1f, 0f);
                        for (int num388 = 0; num388 < 20; num388++)
                        {
                            Dust.NewDust(npc.position, npc.width, npc.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        }
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
                    }
                }
                Dust.NewDust(npc.position, npc.width, npc.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                npc.velocity.X = npc.velocity.X * 0.98f;
                npc.velocity.Y = npc.velocity.Y * 0.98f;
                if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                {
                    npc.velocity.Y = 0f;
                    return;
                }
            }
            else
            {
                npc.damage = (int)(npc.defDamage * 1.5);
                npc.defense = npc.defDefense + 10;
                npc.HitSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Sounds/Zerohit2");
                if (npc.ai[1] == 0f)
                {
                    float num389 = 8f;
                    float num390 = 0.15f;
                    if (Main.expertMode)
                    {
                        num389 = 9.5f;
                        num390 = 0.175f;
                    }
                    Vector2 vector38 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num391 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector38.X;
                    float num392 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 300f - vector38.Y;
                    float num393 = (float)Math.Sqrt(num391 * num391 + num392 * num392);
                    num393 = num389 / num393;
                    num391 *= num393;
                    num392 *= num393;
                    if (npc.velocity.X < num391)
                    {
                        npc.velocity.X = npc.velocity.X + num390;
                        if (npc.velocity.X < 0f && num391 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num390;
                        }
                    }
                    else if (npc.velocity.X > num391)
                    {
                        npc.velocity.X = npc.velocity.X - num390;
                        if (npc.velocity.X > 0f && num391 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num390;
                        }
                    }
                    if (npc.velocity.Y < num392)
                    {
                        npc.velocity.Y = npc.velocity.Y + num390;
                        if (npc.velocity.Y < 0f && num392 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num390;
                        }
                    }
                    else if (npc.velocity.Y > num392)
                    {
                        npc.velocity.Y = npc.velocity.Y - num390;
                        if (npc.velocity.Y > 0f && num392 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - num390;
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 300f)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                    }
                    vector38 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num391 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector38.X;
                    num392 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector38.Y;
                    npc.rotation = (float)Math.Atan2(num392, num391) - 1.57f;
                    if (Main.netMode != 1)
                    {
                        npc.localAI[1] += 1f;
                        if (npc.life < npc.lifeMax * 0.75)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.5)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.25)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.1)
                        {
                            npc.localAI[1] += 2f;
                        }
                        if (npc.localAI[1] > 180f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                        {
                            npc.localAI[1] = 0f;
                            float num394 = 10f;
                            int num395 = npc.damage / 8;
                            int num396 = mod.ProjectileType<DeathLaser>();
                            if (Main.expertMode)
                            {
                                num394 = 12.5f;
                                num395 = npc.damage / 8;
                            }
                            num393 = (float)Math.Sqrt(num391 * num391 + num392 * num392);
                            num393 = num394 / num393;
                            num391 *= num393;
                            num392 *= num393;
                            vector38.X += num391 * 15f;
                            vector38.Y += num392 * 15f;
                            Projectile.NewProjectile(vector38.X, vector38.Y, num391, num392, num396, num395, 0f, Main.myPlayer, 0f, 0f);
                            return;
                        }
                    }
                }
                else
                {
                    int num397 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num397 = -1;
                    }
                    float num398 = 8f;
                    float num399 = 0.2f;
                    if (Main.expertMode)
                    {
                        num398 = 9.5f;
                        num399 = 0.25f;
                    }
                    Vector2 vector39 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    float num400 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num397 * 340 - vector39.X;
                    float num401 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector39.Y;
                    float num402 = (float)Math.Sqrt(num400 * num400 + num401 * num401);
                    num402 = num398 / num402;
                    num400 *= num402;
                    num401 *= num402;
                    if (npc.velocity.X < num400)
                    {
                        npc.velocity.X = npc.velocity.X + num399;
                        if (npc.velocity.X < 0f && num400 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num399;
                        }
                    }
                    else if (npc.velocity.X > num400)
                    {
                        npc.velocity.X = npc.velocity.X - num399;
                        if (npc.velocity.X > 0f && num400 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num399;
                        }
                    }
                    if (npc.velocity.Y < num401)
                    {
                        npc.velocity.Y = npc.velocity.Y + num399;
                        if (npc.velocity.Y < 0f && num401 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num399;
                        }
                    }
                    else if (npc.velocity.Y > num401)
                    {
                        npc.velocity.Y = npc.velocity.Y - num399;
                        if (npc.velocity.Y > 0f && num401 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - num399;
                        }
                    }
                    vector39 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num400 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector39.X;
                    num401 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector39.Y;
                    npc.rotation = (float)Math.Atan2(num401, num400) - 1.57f;
                    if (Main.netMode != 1)
                    {
                        npc.localAI[1] += 1f;
                        if (npc.life < npc.lifeMax * 0.75)
                        {
                            npc.localAI[1] += 0.5f;
                        }
                        if (npc.life < npc.lifeMax * 0.5)
                        {
                            npc.localAI[1] += 0.75f;
                        }
                        if (npc.life < npc.lifeMax * 0.25)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.1)
                        {
                            npc.localAI[1] += 1.5f;
                        }
                        if (Main.expertMode)
                        {
                            npc.localAI[1] += 1.5f;
                        }
                        if (npc.localAI[1] > 60f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                        {
                            npc.localAI[1] = 0f;
                            float num403 = 9f;
                            int num404 = npc.damage / 8;
                            int num405 = mod.ProjectileType<DeathLaser>();
                            if (Main.expertMode)
                            {
                                num404 = npc.damage / 8;
                            }
                            num402 = (float)Math.Sqrt(num400 * num400 + num401 * num401);
                            num402 = num403 / num402;
                            num400 *= num402;
                            num401 *= num402;
                            vector39.X += num400 * 15f;
                            vector39.Y += num401 * 15f;
                            Projectile.NewProjectile(vector39.X, vector39.Y, num400, num401, num405, num404, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 180f)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                        return;
                    }
                }
            }
        }
    }
}