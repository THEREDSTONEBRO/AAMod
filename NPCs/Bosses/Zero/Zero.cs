using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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

        public override void HitEffect(int hitDirection, double damage)

        {

            if (npc.life <= 0)

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



        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (npc.type == mod.NPCType("VoidStar") || npc.type == mod.NPCType("RealityCannon") || npc.type == mod.NPCType("RiftShredder") || npc.type == mod.NPCType("TeslaHand"))
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
                    spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/ZeroArm"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color7, rotation7, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
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
            return false;
        }



        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)

        {

            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);  //boss life scale in expertmode

            npc.damage = (int)(npc.damage * 0.7f);  //boss damage increase in expermode

        }



        public override void AI()

        {

            npc.damage = npc.defDamage;

            npc.defense = npc.defDefense;

            if (npc.ai[0] == 0f && Main.netMode != 1)

            {

                npc.TargetClosest(true);

                npc.ai[0] = 1f;

                int num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RealitySlasher"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);

                Main.npc[num440].ai[0] = -1f;

                Main.npc[num440].ai[1] = (float)npc.whoAmI;

                Main.npc[num440].target = npc.target;

                Main.npc[num440].netUpdate = true;

                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("TeslaHand"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);

                Main.npc[num440].ai[0] = 1f;

                Main.npc[num440].ai[1] = (float)npc.whoAmI;

                Main.npc[num440].target = npc.target;

                Main.npc[num440].netUpdate = true;

                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("VoidStar"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);

                Main.npc[num440].ai[0] = -1f;

                Main.npc[num440].ai[1] = (float)npc.whoAmI;

                Main.npc[num440].target = npc.target;

                Main.npc[num440].ai[3] = 150f;

                Main.npc[num440].netUpdate = true;

                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, mod.NPCType("RealityCannon"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);

                Main.npc[num440].ai[0] = 1f;

                Main.npc[num440].ai[1] = (float)npc.whoAmI;

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

                    npc.damage = 1000;

                    npc.defense = 9999;

                    npc.rotation += (float)npc.direction * 0.3f;

                    Vector2 vector45 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);

                    float num444 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector45.X;

                    float num445 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector45.Y;

                    float num446 = (float)Math.Sqrt((double)(num444 * num444 + num445 * num445));

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

}







