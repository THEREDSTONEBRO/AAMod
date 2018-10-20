using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.MushroomMonarch
{
    public class MushroomMonarch : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Monarch");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;  //5 is the flying AI
            npc.lifeMax = 1500;   //boss life
            npc.damage = 24;  //boss damage
            npc.defense = 12;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 74;
            npc.height = 106;  //boss frame/animation 
            npc.value = Item.buyPrice(0, 0, 75, 45);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            music = MusicID.Boss5;
            npc.netAlways = true;
            bossBag = mod.ItemType("MonarchBag");
        }

        public int timer;
        private bool switchMove = false;
        private bool jumpUp;
        private int jumpFrame;
        private int jumpCounter;

        public override void AI()
        {
            if (jumpUp == true)
            {
                jumpCounter++;
                if (jumpCounter > 20)
                {
                    jumpFrame++;
                    jumpCounter = 0;
                }
                if (jumpFrame >= 3)
                {
                    jumpFrame = 0;
                }
            }
            timer++;                //Makes the int start
            if (timer == 600)          //if the timer has gotten to 7.5 seconds, this happens (60 = 1 second)
            {
                switchMove = true;     //Makes the switch turn on, making the AI change to nothing
                npc.aiStyle = 3;      //So the AI doesnt mix with the flying AI Style
                jumpUp = true;
            }
            if (timer >= 780)          //After 15 seconds this happens
            {
                switchMove = false;     //Turns the switch off so the void Move stuff is disabled
                npc.ai[2] = 0f;
                npc.ai[0] = 0f;
                npc.ai[1] = 5f;
                if (Main.netMode != 1)
                {
                    npc.TargetClosest(false);
                    Point point3 = npc.Center.ToTileCoordinates();
                    Point point4 = Main.player[npc.target].Center.ToTileCoordinates();
                    Vector2 vector26 = Main.player[npc.target].Center - npc.Center;
                    int num231 = 10;
                    int num232 = 0;
                    int num233 = 7;
                    int num234 = 0;
                    bool flag10 = false;
                    if (vector26.Length() > 2000f)
                    {
                        flag10 = true;
                        num234 = 100;
                    }
                    while (!flag10 && num234 < 100)
                    {
                        num234++;
                        int num235 = Main.rand.Next(point4.X - num231, point4.X + num231 + 1);
                        int num236 = Main.rand.Next(point4.Y - num231, point4.Y + 1);
                        if ((num236 < point4.Y - num233 || num236 > point4.Y + num233 || num235 < point4.X - num233 || num235 > point4.X + num233) && (num236 < point3.Y - num232 || num236 > point3.Y + num232 || num235 < point3.X - num232 || num235 > point3.X + num232) && !Main.tile[num235, num236].nactive())
                        {
                            int num237 = num236;
                            int num238 = 0;
                            bool flag11 = Main.tile[num235, num237].nactive() && Main.tileSolid[(int)Main.tile[num235, num237].type] && !Main.tileSolidTop[(int)Main.tile[num235, num237].type];
                            if (flag11)
                            {
                                num238 = 1;
                            }
                            else
                            {
                                while (num238 < 150 && num237 + num238 < Main.maxTilesY)
                                {
                                    int num239 = num237 + num238;
                                    bool flag12 = Main.tile[num235, num239].nactive() && Main.tileSolid[(int)Main.tile[num235, num239].type] && !Main.tileSolidTop[(int)Main.tile[num235, num239].type];
                                    if (flag12)
                                    {
                                        num238--;
                                        break;
                                    }
                                    num238++;
                                }
                            }
                            num236 += num238;
                            bool flag13 = true;
                            if (flag13 && Main.tile[num235, num236].lava())
                            {
                                flag13 = false;
                            }
                            if (flag13 && !Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
                            {
                                flag13 = false;
                            }
                            if (flag13)
                            {
                                npc.localAI[1] = (float)(num235 * 16 + 8);
                                npc.localAI[2] = (float)(num236 * 16 + 16);
                                break;
                            }
                        }
                    }
                    if (num234 >= 100)
                    {
                        Vector2 bottom = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].Bottom;
                        npc.localAI[1] = bottom.X;
                        npc.localAI[2] = bottom.Y;
                    }
                }        //Reverts back to the original Flying AI Style
                timer = 0;              //Sets the timer back to 0 to repeat
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.Mushroom;   //boss drops
            AAWorld.downedMonarch = true;
            Projectile.NewProjectile((new Vector2(npc.position.X, npc.position.Y)), (new Vector2(0f, 0f)), mod.ProjectileType("MonarchRUNAWAY"), 0, 0);
            if (Main.expertMode == true)
            {
                npc.DropBossBags();
            }
            else
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mushium"), Main.rand.Next(20, 30));
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.1f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.1f);  //boss damage increase in expermode
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Texture2D jumpAni = mod.GetTexture("NPCs/Bosses/MushroomMonarchJump");
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (jumpUp == false)
            {
                spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            if (jumpUp == true)
            {
                Vector2 drawCenter = new Vector2(npc.Center.X, npc.Center.Y);
                int num214 = jumpAni.Height / 3;
                int y6 = num214 * jumpFrame;
                Main.spriteBatch.Draw(jumpAni, drawCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, jumpAni.Width, num214)), drawColor, npc.rotation, new Vector2((float)jumpAni.Width / 2f, (float)num214 / 2f), npc.scale, npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            }
            return false;
        }
    }
}

    