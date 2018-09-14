using System;
using AAMod;
using Microsoft.Xna.Framework;
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
            DisplayName.SetDefault("Zero Awakened");
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 

        }
        public override void SetDefaults()
        {
            npc.width = 80;
            npc.height = 102;
            npc.aiStyle = 32;
            npc.damage = 130;  //boss damage
            npc.defense = 70;    //boss defense
            npc.lifeMax = 28000;
            npc.HitSound = new LegacySoundStyle(4, 36, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 39, Terraria.Audio.SoundType.Sound);
            npc.noGravity = true;
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Zero2");
            npc.noTileCollide = true;
            npc.value = 120000f;
            npc.knockBackResist = -1f;
            npc.boss = true;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.buffImmune[189] = (npc.buffImmune[169] = (npc.buffImmune[183] = true));
            npc.friendly = false;
            animationType = NPCID.SkeletronPrime;
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.netAlways = true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {

        }

        public override void NPCLoot()
        {
            
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
                int num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, 128, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = -1f;
                Main.npc[num440].ai[1] = (float)npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, 129, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = 1f;
                Main.npc[num440].ai[1] = (float)npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, 130, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                Main.npc[num440].ai[0] = -1f;
                Main.npc[num440].ai[1] = (float)npc.whoAmI;
                Main.npc[num440].target = npc.target;
                Main.npc[num440].ai[3] = 150f;
                Main.npc[num440].netUpdate = true;
                num440 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)npc.position.Y + npc.height / 2, 131, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
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
            if (Main.dayTime && npc.ai[1] != 3f && npc.ai[1] != 2f)
            {
                npc.ai[1] = 2f;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
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