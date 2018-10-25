﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AAMod.NPCs.Bosses.Akuma
{
    //[AutoloadBossHead]
    class AkumaHead : Akuma
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaHead"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightcrawler");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 280000;
            npc.damage = 100;
            npc.defense = 120;
            npc.knockBackResist = 0f;
            npc.width = 66;
            npc.height = 62;
            npc.value = Item.buyPrice(0, 55, 0, 0);
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = false;
            npc.DeathSound = null;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Equinox");
            //musicPriority = MusicPriority.BossHigh;
            //bossBag = mod.ItemType("NCBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / Main.expertLife * 1.4f * bossLifeScale);
            npc.defense = 140;
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Nightcrawler/Nightcrawler_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }*/

        public override void Init()
        {
            base.Init();
            head = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && npc.type == mod.NPCType<DaybringerHead>())
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NCGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NCGore2"), 1f);
            }
        }*/
    }

    class AkumaArm : AkumaHead
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaArms"; } }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 96;
            npc.height = 112;
            npc.DeathSound = null;
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Nightcrawler/NightcrawlerBody_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }*/

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }

        public override void Init()
        {
            base.Init();
            arm = true;
        }
    }
    class AkumaBody : AkumaHead
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaBody"; } }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 96;
            npc.height = 112;
            npc.DeathSound = null;
        }
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Nightcrawler/NightcrawlerBody_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }*/

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }

        public override void Init()
        {
            base.Init();
            body = true;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && npc.type == mod.NPCType<DaybringerHead>())
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NCGore3"), 1f);
            }
        }*/
    }

    class AkumaTail : AkumaHead
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaTail"; } }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 78;
            npc.height = 112;
            npc.DeathSound = null;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }

        public override void Init()
        {
            base.Init();
            tail = true;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && npc.type == mod.NPCType<DaybringerHead>())
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NCGore4"), 1f);
            }
        }*/
    }
    // I made this 2nd base class to limit code repetition.
    class Akuma : China
    {
        public override void Init()
        {
            tailType = mod.NPCType<AkumaTail>();
            armType = mod.NPCType<AkumaArm>();
            bodyType = mod.NPCType<AkumaBody>();
            headType = mod.NPCType<AkumaHead>();
            speed = 14f;
            turnSpeed = 7.25f;
        }
    }

    public abstract class China : ModNPC
    {
        /* ai[0] = follower
		 * ai[1] = following
		 * ai[2] = distanceFromTail
		 * ai[3] = head
         */
        public bool head;
        public bool body;
        public bool arm;
        public bool tail;
        public int minLength;
        public int maxLength;
        public int headType;
        public int bodyType;
        public int armType;
        public int tailType;
        public bool flies = true;
        public bool directional = true;
        public float speed;
        public float turnSpeed;
        public bool Initiated = false;

        public override void AI()
        {
            if (npc.localAI[1] == 0f)
            {
                npc.localAI[1] = 1f;
                Init();
            }
            if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }
            if (!head && npc.timeLeft < 300)
            {
                npc.timeLeft = 300;
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
            {
                npc.timeLeft = 300;
            }
            if (Main.netMode != 1)
            {
                if (!tail && npc.ai[0] == 0f)
                {
                    if (head && !tail)
                    {
                        npc.ai[3] = npc.whoAmI;
                        npc.realLife = npc.whoAmI;
                        if (!Initiated)
                        {
                            npc.ai[2] = 7;
                            Initiated = true;
                        }
                        if (npc.ai[2] == 7 || npc.ai[2] == 5 || npc.ai[2] == 3 || npc.ai[2] == 1)
                        {
                            npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), bodyType, npc.whoAmI);
                        }
                        else if (npc.ai[2] == 6 || npc.ai[2] == 4 || npc.ai[2] == 2)
                        {
                            npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), armType, npc.whoAmI);
                        }
                    }
                    else if (npc.ai[2] != 0)
                    {
                        npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), npc.type, npc.whoAmI);
                    }
                    if (npc.ai[2] == 0)
                    {
                        npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), tailType, npc.whoAmI);
                    }
                    Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
                    Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                    Main.npc[(int)npc.ai[0]].ai[1] = npc.whoAmI;
                    Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1;
                    npc.netUpdate = true;
                }
                if (!NPC.AnyNPCs(mod.NPCType<AkumaHead>()) && (body || tail || arm))
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            }
            int num180 = (int)(npc.position.X / 16f) - 1;
            int num181 = (int)((npc.position.X + npc.width) / 16f) + 2;
            int num182 = (int)(npc.position.Y / 16f) - 1;
            int num183 = (int)((npc.position.Y + npc.height) / 16f) + 2;
            if (num180 < 0)
            {
                num180 = 0;
            }
            if (num181 > Main.maxTilesX)
            {
                num181 = Main.maxTilesX;
            }
            if (num182 < 0)
            {
                num182 = 0;
            }
            if (num183 > Main.maxTilesY)
            {
                num183 = Main.maxTilesY;
            }
            bool flag18 = flies;
            if (!flag18)
            {
                for (int num184 = num180; num184 < num181; num184++)
                {
                    for (int num185 = num182; num185 < num183; num185++)
                    {
                        if (Main.tile[num184, num185] != null && ((Main.tile[num184, num185].nactive() && (Main.tileSolid[Main.tile[num184, num185].type] || (Main.tileSolidTop[Main.tile[num184, num185].type] && Main.tile[num184, num185].frameY == 0))) || Main.tile[num184, num185].liquid > 64))
                        {
                            Vector2 vector17;
                            vector17.X = num184 * 16;
                            vector17.Y = num185 * 16;
                            if (npc.position.X + npc.width > vector17.X && npc.position.X < vector17.X + 16f && npc.position.Y + npc.height > vector17.Y && npc.position.Y < vector17.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.Next(100) == 0 && npc.behindTiles && Main.tile[num184, num185].nactive())
                                {
                                    WorldGen.KillTile(num184, num185, true, true, false);
                                }
                                if (Main.netMode != 1 && Main.tile[num184, num185].type == 2)
                                {
                                    ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].type;
                                }
                            }
                        }
                    }
                }
            }
            if (!flag18 && head)
            {
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int num186 = 1000;
                bool flag19 = true;
                for (int num187 = 0; num187 < 255; num187++)
                {
                    if (Main.player[num187].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            flag19 = false;
                            break;
                        }
                    }
                }
                if (flag19)
                {
                    flag18 = true;
                }
            }
            if (directional)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.spriteDirection = -1;
                }
            }
            float num188 = speed;
            float num189 = turnSpeed;
            Vector2 vector18 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num191 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            float num192 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num191 = (int)(num191 / 16f) * 16;
            num192 = (int)(num192 / 16f) * 16;
            vector18.X = (int)(vector18.X / 16f) * 16;
            vector18.Y = (int)(vector18.Y / 16f) * 16;
            num191 -= vector18.X;
            num192 -= vector18.Y;
            float num193 = (float)System.Math.Sqrt(num191 * num191 + num192 * num192);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector18 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num191 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector18.X;
                    num192 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector18.Y;
                }
                catch
                {
                }
                npc.rotation = (float)System.Math.Atan2(num192, num191) + 1.57f;
                num193 = (float)System.Math.Sqrt(num191 * num191 + num192 * num192);
                int num194 = npc.width;
                num193 = (num193 - num194) / num193;
                num191 *= num193;
                num192 *= num193;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num191;
                npc.position.Y = npc.position.Y + num192;
                if (directional)
                {
                    if (num191 < 0f)
                    {
                        npc.spriteDirection = 1;
                    }
                    if (num191 > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (!flag18)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > num188)
                    {
                        npc.velocity.Y = num188;
                    }
                    if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < num188 * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num189 * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + num189 * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == num188)
                    {
                        if (npc.velocity.X < num191)
                        {
                            npc.velocity.X = npc.velocity.X + num189;
                        }
                        else if (npc.velocity.X > num191)
                        {
                            npc.velocity.X = npc.velocity.X - num189;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num189 * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num189 * 0.9f;
                        }
                    }
                }
                else
                {
                    if (!flies && npc.behindTiles && npc.soundDelay == 0)
                    {
                        float num195 = num193 / 40f;
                        if (num195 < 10f)
                        {
                            num195 = 10f;
                        }
                        if (num195 > 20f)
                        {
                            num195 = 20f;
                        }
                        npc.soundDelay = (int)num195;
                        Main.PlaySound(SoundID.Roar, npc.position, 1);
                    }
                    num193 = (float)System.Math.Sqrt(num191 * num191 + num192 * num192);
                    float num196 = System.Math.Abs(num191);
                    float num197 = System.Math.Abs(num192);
                    float num198 = num188 / num193;
                    num191 *= num198;
                    num192 *= num198;
                    if (ShouldRun())
                    {
                        bool flag20 = true;
                        for (int num199 = 0; num199 < 255; num199++)
                        {
                        }
                        if (flag20)
                        {
                            if (Main.netMode != 1 && npc.position.Y / 16f > (Main.rockLayer + Main.maxTilesY) / 2.0)
                            {
                                npc.active = false;
                                int num200 = (int)npc.ai[0];
                                while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == npc.aiStyle)
                                {
                                    int num201 = (int)Main.npc[num200].ai[0];
                                    Main.npc[num200].active = false;
                                    npc.life = 0;
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(23, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
                                    }
                                    num200 = num201;
                                }
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                                }
                            }
                            num191 = 0f;
                            num192 = num188;
                        }
                    }
                    bool flag21 = false;
                    
                    if (!flag21)
                    {
                        if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
                        {
                            if (npc.velocity.X < num191)
                            {
                                npc.velocity.X = npc.velocity.X + num189;
                            }
                            else
                            {
                                if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - num189;
                                }
                            }
                            if (npc.velocity.Y < num192)
                            {
                                npc.velocity.Y = npc.velocity.Y + num189;
                            }
                            else
                            {
                                if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189;
                                }
                            }
                            if (System.Math.Abs(num192) < num188 * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num189 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189 * 2f;
                                }
                            }
                            if (System.Math.Abs(num191) < num188 * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num189 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num189 * 2f;
                                }
                            }
                        }
                        else
                        {
                            if (num196 > num197)
                            {
                                if (npc.velocity.X < num191)
                                {
                                    npc.velocity.X = npc.velocity.X + num189 * 1.1f;
                                }
                                else if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - num189 * 1.1f;
                                }
                                if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < num188 * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y = npc.velocity.Y + num189;
                                    }
                                    else
                                    {
                                        npc.velocity.Y = npc.velocity.Y - num189;
                                    }
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
                                }
                                else if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
                                }
                                if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < num188 * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X = npc.velocity.X + num189;
                                    }
                                    else
                                    {
                                        npc.velocity.X = npc.velocity.X - num189;
                                    }
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)System.Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
                if (head)
                {
                    if (flag18)
                    {
                        if (npc.localAI[0] != 1f)
                        {
                            npc.netUpdate = true;
                        }
                        npc.localAI[0] = 1f;
                    }
                    else
                    {
                        if (npc.localAI[0] != 0f)
                        {
                            npc.netUpdate = true;
                        }
                        npc.localAI[0] = 0f;
                    }
                    if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
                    {
                        npc.netUpdate = true;
                        return;
                    }
                }
            }
            CustomBehavior();
        }

        public virtual void Init()
        {
        }

        public virtual bool ShouldRun()
        {
            return false;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;   //boss drops
        }

        public virtual void CustomBehavior()
        {

        }

        public override void NPCLoot()
        {
            int bossAlive = mod.NPCType("AkumaHead");
            AAWorld.downedAkuma = true;
            /*if (NPC.CountNPCS(bossAlive) < 1)
            {
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AkumaTrophy"));
                }
                if (Main.expertMode)
                {
                    npc.DropBossBags();
                }
                else
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NightcrawlerMask"));
                    }
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkmatterOre"), Main.rand.Next(30, 75));
                }
            }
            else
            {
                npc.value = 0f;
                npc.boss = false;
            }*/
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return (tail || body || arm) ? false : (bool?)null;
        }
    }
}