using System;
using System.IO;
using AAMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Zero
{
    [AutoloadBossHead]
    public class Zero : ZeroCode
    {
        private Player player;
        private float speed;
        public static Texture2D ZeroArmTex;
        //bools for each part of zero
        public bool ArmsAndWeapons;
        public bool RC;
        public bool RS;
        public bool VS;
        public bool TH;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero");
            Main.npcFrameCount[npc.type] = 3;    //boss frame/animation 

        }
        public override void SetDefaults()
        {
            npc.width = 206;
            npc.height = 206;
            npc.aiStyle = 0;
            npc.damage = 130;  //boss damage
            npc.defense = 70;    //boss defense
            npc.lifeMax = 200000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit4;
            npc.noGravity = true;
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Zero");
            npc.noTileCollide = true;
            npc.value = 120000f;
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
            return (ArmsAndWeapons && (!RC && !RS && !VS && !TH)) ? false : (bool?)null;
        }

        public override void Init()
        {
            base.Init();
        }
    }

    public abstract class ZeroCode : ModNPC
    {
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
                NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("ZeroAwakened"));
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.7f);  //boss damage increase in expermode
        }
        
        bool donotrepeat = false;

        public virtual void Init()
        {

        }

        public override void AI()
        {
            Init();
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            if (Main.netMode != 1 && (!NPC.AnyNPCs(mod.NPCType<TeslaHand>()) && !NPC.AnyNPCs(mod.NPCType<RiftShredder>()) && !NPC.AnyNPCs(mod.NPCType<RealityCannon>()) && !NPC.AnyNPCs(mod.NPCType<VoidStar>())) && !donotrepeat)
            {
                donotrepeat = true;
                npc.TargetClosest(true);
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<ZeroArm>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<RealityCannon>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<ZeroArm>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<RiftShredder>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<ZeroArm>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<VoidStar>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<ZeroArm>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<TeslaHand>(), npc.whoAmI);
                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                npc.netUpdate = true;
            }
            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    npc.ai[1] = 2f;
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
                if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + 100f)
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
                if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - 100f)
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
                    npc.rotation += (float)npc.direction * 0.3f;
                    Vector2 vector44 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num441 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector44.X;
                    float num442 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector44.Y;
                    float num443 = (float)Math.Sqrt((double)(num441 * num441 + num442 * num442));
                    num443 = 2f / num443;
                    npc.velocity.X = num441 * num443;
                    npc.velocity.Y = num442 * num443;
                    return;
                }
                if (npc.ai[1] == 2f)
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

    class ZeroArm : Zero
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm"; } }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 1;
            npc.knockBackResist = 0f;
            npc.dontTakeDamage = true;
            npc.width = 18;
            npc.height = 68;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void Init()
        {
            base.Init();
            ArmsAndWeapons = true;
        }

        public override void AI()
        {
            if (TH)
            {
                Vector2 vector46 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num448 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector46.X;
                float num449 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector46.Y;
                float num450 = (float)Math.Sqrt((double)(num448 * num448 + num449 * num449));
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
                                Vector2 vector47 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                float num451 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector47.X;
                                float num452 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector47.Y;
                                float num453 = (float)Math.Sqrt((double)(num451 * num451 + num452 * num452));
                                num453 = 7f / num453;
                                num451 *= num453;
                                num452 *= num453;
                                npc.rotation = (float)Math.Atan2((double)num452, (double)num451) - 1.57f;
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
                            if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2))
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
                            if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 250f)
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
                        Vector2 vector48 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num454 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector48.X;
                        float num455 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector48.Y;
                        Math.Sqrt((double)(num454 * num454 + num455 * num455));
                        npc.rotation = (float)Math.Atan2((double)num455, (double)num454) + 1.57f;
                        return;
                    }
                    if (npc.ai[2] == 1f)
                    {
                        Vector2 vector49 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num456 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector49.X;
                        float num457 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector49.Y;
                        float num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
                        npc.rotation = (float)Math.Atan2((double)num457, (double)num456) + 1.57f;
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
                            vector49 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            num456 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector49.X;
                            num457 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector49.Y;
                            num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
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
                            Vector2 vector50 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num459 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector50.X;
                            float num460 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector50.Y;
                            float num461 = (float)Math.Sqrt((double)(num459 * num459 + num460 * num460));
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
                            vector50 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            num459 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector50.X;
                            num460 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector50.Y;
                            num461 = (float)Math.Sqrt((double)(num459 * num459 + num460 * num460));
                            npc.rotation = (float)Math.Atan2((double)num460, (double)num459) + 1.57f;
                            return;
                        }
                        if (npc.ai[2] == 5f && ((npc.velocity.X > 0f && npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2)) || (npc.velocity.X < 0f && npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))))
                        {
                            npc.ai[2] = 0f;
                            return;
                        }
                    }
                }
            }
            if (RC)
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
                            int num493 = 100;
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
                            int num499 = 100;
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
            if (VS)
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
            if (RS)
            {
                Vector2 vector46 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num448 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector46.X;
                float num449 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector46.Y;
                float num450 = (float)Math.Sqrt((double)(num448 * num448 + num449 * num449));
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
                                Vector2 vector47 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                float num451 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector47.X;
                                float num452 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector47.Y;
                                float num453 = (float)Math.Sqrt((double)(num451 * num451 + num452 * num452));
                                num453 = 7f / num453;
                                num451 *= num453;
                                num452 *= num453;
                                npc.rotation = (float)Math.Atan2((double)num452, (double)num451) - 1.57f;
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
                            if (npc.position.X + (float)(npc.width / 2) > Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2))
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
                            if (npc.position.X + (float)(npc.width / 2) < Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 250f)
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
                        Vector2 vector48 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num454 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector48.X;
                        float num455 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector48.Y;
                        Math.Sqrt((double)(num454 * num454 + num455 * num455));
                        npc.rotation = (float)Math.Atan2((double)num455, (double)num454) + 1.57f;
                        return;
                    }
                    if (npc.ai[2] == 1f)
                    {
                        Vector2 vector49 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num456 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector49.X;
                        float num457 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector49.Y;
                        float num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
                        npc.rotation = (float)Math.Atan2((double)num457, (double)num456) + 1.57f;
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
                            vector49 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            num456 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector49.X;
                            num457 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector49.Y;
                            num458 = (float)Math.Sqrt((double)(num456 * num456 + num457 * num457));
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
                            Vector2 vector50 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float num459 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector50.X;
                            float num460 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector50.Y;
                            float num461 = (float)Math.Sqrt((double)(num459 * num459 + num460 * num460));
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
                            vector50 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            num459 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - 200f * npc.ai[0] - vector50.X;
                            num460 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector50.Y;
                            num461 = (float)Math.Sqrt((double)(num459 * num459 + num460 * num460));
                            npc.rotation = (float)Math.Atan2((double)num460, (double)num459) + 1.57f;
                            return;
                        }
                        if (npc.ai[2] == 5f && ((npc.velocity.X > 0f && npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2)) || (npc.velocity.X < 0f && npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))))
                        {
                            npc.ai[2] = 0f;
                            return;
                        }
                    }
                }
            }
        }
    }
}