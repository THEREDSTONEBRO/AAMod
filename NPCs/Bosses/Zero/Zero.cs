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
    public class Zero : ModNPC
    {
        private Player player;
        private float speed;
        public static Texture2D ZeroArmTex;

        public bool ArmsAndWeapons;
        public bool RC;
        public bool RS;
        public bool VS;
        public bool TH;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zero Awakened");
            Main.npcFrameCount[npc.type] = 3;    //boss frame/animation 

        }
        public override void SetDefaults()
        {
            npc.width = 206;
            npc.height = 208;
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
            return (!ArmsAndWeapons || (RC || RS || VS || TH)) ? (bool?)null : false;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && ((!RC && !RS && !VS && !TH) || npc.lifeMax != 0))
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

        /*protected void DrawNPC(int iNPCIndex, bool behindTiles)
        {
            if (NPC.AnyNPCs(mod.NPCType("RealityCannon")))
            {
                Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                for (int k = 0; k < 2; k++)
                {
                    float num22 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector7.X;
                    float num23 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector7.Y;
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
                    Main.spriteBatch.Draw(mod.GetTexture("RealityCannon"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    if (k == 0)
                    {
                        vector7.X += num22 * num24 / 2f;
                        vector7.Y += num23 * num24 / 2f;
                    }
                    else if (npc.active)
                    {
                        vector7.X += num22 * num24 - 16f;
                        vector7.Y += num23 * num24 - 6f;
                        int num25 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num22 * 0.02f, num23 * 0.02f, 0, default(Color), 2.5f);
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
            if (NPC.AnyNPCs(mod.NPCType("RiftShredder")))
            {
                Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                for (int k = 0; k < 2; k++)
                {
                    float num22 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector7.X;
                    float num23 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector7.Y;
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
                    Main.spriteBatch.Draw(mod.GetTexture("RiftShredder"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    if (k == 0)
                    {
                        vector7.X += num22 * num24 / 2f;
                        vector7.Y += num23 * num24 / 2f;
                    }
                    else if (npc.active)
                    {
                        vector7.X += num22 * num24 - 16f;
                        vector7.Y += num23 * num24 - 6f;
                        int num25 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num22 * 0.02f, num23 * 0.02f, 0, default(Color), 2.5f);
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
            if (NPC.AnyNPCs(mod.NPCType("TeslaHand")))
            {
                Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                for (int k = 0; k < 2; k++)
                {
                    float num22 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector7.X;
                    float num23 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector7.Y;
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
                    Main.spriteBatch.Draw(mod.GetTexture("TeslaHand"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    if (k == 0)
                    {
                        vector7.X += num22 * num24 / 2f;
                        vector7.Y += num23 * num24 / 2f;
                    }
                    else if (npc.active)
                    {
                        vector7.X += num22 * num24 - 16f;
                        vector7.Y += num23 * num24 - 6f;
                        int num25 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num22 * 0.02f, num23 * 0.02f, 0, default(Color), 2.5f);
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
            if (NPC.AnyNPCs(mod.NPCType("VoidStar")))
            {
                Vector2 vector7 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
                for (int k = 0; k < 2; k++)
                {
                    float num22 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector7.X;
                    float num23 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector7.Y;
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
                    Main.spriteBatch.Draw(mod.GetTexture("VoidStar"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                    if (k == 0)
                    {
                        vector7.X += num22 * num24 / 2f;
                        vector7.Y += num23 * num24 / 2f;
                    }
                    else if (npc.active)
                    {
                        vector7.X += num22 * num24 - 16f;
                        vector7.Y += num23 * num24 - 6f;
                        int num25 = Dust.NewDust(new Vector2(vector7.X, vector7.Y), 30, 10, 6, num22 * 0.02f, num23 * 0.02f, 0, default(Color), 2.5f);
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
        }*/
       
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.7f);  //boss damage increase in expermode
        }
        
        public override void AI()
        {
            float floatingnum = 0f;
            float anothernum = 0f;
            //Putting each hand at its own ai so you don't get confused
            //do not remove the floats above (I replaced them to fix anytime you used the ai's)
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            if (Main.netMode != 1 && (npc.ai[0] != 1f || npc.ai[1] != 1f || npc.ai[2] != 1f || npc.ai[3] != 1f))
            {
                npc.TargetClosest(true);
                npc.ai[0] = 1f;
                npc.ai[1] = 1f;
                npc.ai[2] = 1f;
                npc.ai[3] = 1f;
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<Army>(), npc.whoAmI);
                npc.ai[1] = (float)NPC.NewNPC((int)(npc.position.X - (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<Army>(), npc.whoAmI);
                npc.ai[2] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y - (float)(npc.height / 2)), mod.NPCType<Army>(), npc.whoAmI);
                npc.ai[3] = (float)NPC.NewNPC((int)(npc.position.X - (float)(npc.width / 2)), (int)(npc.position.Y - (float)(npc.height / 2)), mod.NPCType<Army>(), npc.whoAmI);
                npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<RealityCannon>(), npc.whoAmI);
                npc.ai[1] = (float)NPC.NewNPC((int)(npc.position.X - (float)(npc.width / 2)), (int)(npc.position.Y + (float)(npc.height / 2)), mod.NPCType<RiftShredder>(), npc.whoAmI);
                npc.ai[2] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y - (float)(npc.height / 2)), mod.NPCType<VoidStar>(), npc.whoAmI);
                npc.ai[3] = (float)NPC.NewNPC((int)(npc.position.X - (float)(npc.width / 2)), (int)(npc.position.Y - (float)(npc.height / 2)), mod.NPCType<TeslaHand>(), npc.whoAmI);
            }
            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    floatingnum = 2f;
                }
            }
            if (floatingnum == 0f)
            {
                anothernum += 1f;
                if (anothernum >= 600f)
                {
                    anothernum = 0f;
                    floatingnum = 1f;
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
                if (floatingnum == 1f)
                {
                    npc.defense *= 2;
                    npc.damage *= 2;
                    anothernum += 1f;
                    if (anothernum == 2f)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
                    }
                    if (anothernum >= 400f)
                    {
                        anothernum = 0f;
                        floatingnum = 0f;
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
                if (floatingnum == 2f)
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

    public abstract class ZeroArm : Zero
    {   
        public override void SetDefaults()
        {
            Init();
        }

        public virtual void Init()
        {
            ArmsAndWeapons = true;
        }
    }

    class Army : ZeroArm
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Zero/ZeroArm"; } }

        public override void Init()
        {
            base.Init();
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 1;
            npc.knockBackResist = 0.5f;
            npc.width = 18;
            npc.height = 68;
            npc.aiStyle = 0;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.dontTakeDamage = true;
        }
    }
}