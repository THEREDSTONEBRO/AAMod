﻿using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.Audio;

namespace AAMod.NPCs.Bosses.Akuma
{
	public class Akuma : ModNPC
	{
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/Akuma"; } }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akuma");
			NPCID.Sets.TechnicallyABoss[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.height = 144;
			npc.width = 70;
			npc.aiStyle = -1;
			npc.netAlways = true;
			npc.knockBackResist = 0f; if (!Main.expertMode && !AAWorld.downedAkuma)
            {
                npc.damage = 80;
                npc.defense = 100;
                npc.lifeMax = 200000;
                npc.value = Item.buyPrice(0, 55, 0, 0);
            }
            if (!Main.expertMode && AAWorld.downedAkuma)
            {
                npc.damage = 90;
                npc.defense = 120;
                npc.lifeMax = 220000;
                npc.value = Item.buyPrice(0, 55, 0, 0);
            }
            if (Main.expertMode && !AAWorld.downedAkumaA)
            {
                npc.damage = 80;
                npc.defense = 100;
                npc.lifeMax = 200000;
                npc.value = Item.buyPrice(0, 0, 0, 0);
            }
            if (Main.expertMode && AAWorld.downedAkumaA)
            {
                npc.damage = 100;
                npc.defense = 130;
                npc.lifeMax = 240000;
                npc.value = Item.buyPrice(0, 0, 0, 0);
            }
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.DeathSound = new LegacySoundStyle(2, 124, Terraria.Audio.SoundType.Sound);
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Akuma");
            musicPriority = MusicPriority.BossHigh;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }

		public override bool PreAI()
		{

            Main.dayTime = true;
            Main.time = 24000;


            Player player = Main.player[npc.target];
			float dist = npc.Distance(player.Center);
			if (dist < 300 & Main.rand.Next(3) == 1)
			{
				if (Main.rand.Next(10) == 1)
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 9);

				int proj2 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-20, 20), npc.Center.Y  + Main.rand.Next(-20, 20), npc.velocity.X* Main.rand.Next(1, 2), npc.velocity.Y * Main.rand.Next(1, 2), mod.ProjectileType("Starshock"), 20, 0, Main.myPlayer);
				Main.projectile[proj2].timeLeft = 60;
			}
			if (Main.netMode != 1)
			{
                if (npc.ai[0] == 0)
                {
                    npc.realLife = npc.whoAmI;
                    int latestNPC = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaArms"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaArms"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaArms"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaTail"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                    npc.ai[0] = 1;
                    npc.netUpdate = true;
                }
            }

			int minTilePosX = (int)(npc.position.X / 16.0) - 1;
			int maxTilePosX = (int)((npc.position.X + npc.width) / 16.0) + 2;
			int minTilePosY = (int)(npc.position.Y / 16.0) - 1;
			int maxTilePosY = (int)((npc.position.Y + npc.height) / 16.0) + 2;
			if (minTilePosX < 0)
				minTilePosX = 0;
			if (maxTilePosX > Main.maxTilesX)
				maxTilePosX = Main.maxTilesX;
			if (minTilePosY < 0)
				minTilePosY = 0;
			if (maxTilePosY > Main.maxTilesY)
				maxTilePosY = Main.maxTilesY;

			bool collision = true;

			for (int i = minTilePosX; i < maxTilePosX; ++i)
			{
				for (int j = minTilePosY; j < maxTilePosY; ++j)
				{
					if (Main.tile[i, j] != null && (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type] && (int)Main.tile[i, j].frameY == 0) || (int)Main.tile[i, j].liquid > 64))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						if (npc.position.X + npc.width > vector2.X && npc.position.X < vector2.X + 16.0 && (npc.position.Y + npc.height > (double)vector2.Y && npc.position.Y < vector2.Y + 16.0))
						{
							collision = true;
							if (Main.rand.Next(100) == 0 && Main.tile[i, j].nactive())
								WorldGen.KillTile(i, j, true, true, false);
						}
					}
				}
			}
			float speed = 10f;
			float acceleration = 0.16f;

			Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float targetXPos = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2);
			float targetYPos = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2);

			float targetRoundedPosX = (float)((int)(targetXPos / 16.0) * 16);
			float targetRoundedPosY = (float)((int)(targetYPos / 16.0) * 16);
			npcCenter.X = (float)((int)(npcCenter.X / 16.0) * 16);
			npcCenter.Y = (float)((int)(npcCenter.Y / 16.0) * 16);
			float dirX = targetRoundedPosX - npcCenter.X;
			float dirY = targetRoundedPosY - npcCenter.Y;
			npc.TargetClosest(true);
			float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);

			float absDirX = Math.Abs(dirX);
			float absDirY = Math.Abs(dirY);
			float newSpeed = speed / length;
			dirX = dirX * (newSpeed * 2);
			dirY = dirY * (newSpeed * 2);
			if (npc.velocity.X > 0.0 && dirX > 0.0 || npc.velocity.X < 0.0 && dirX < 0.0 || (npc.velocity.Y > 0.0 && dirY > 0.0 || npc.velocity.Y < 0.0 && dirY < 0.0))
			{
				if (npc.velocity.X < dirX)
					npc.velocity.X = npc.velocity.X + acceleration;
				else if (npc.velocity.X > dirX)
					npc.velocity.X = npc.velocity.X - acceleration;
				if (npc.velocity.Y < dirY)
					npc.velocity.Y = npc.velocity.Y + acceleration;
				else if (npc.velocity.Y > dirY)
					npc.velocity.Y = npc.velocity.Y - acceleration;
				if (Math.Abs(dirY) < speed * 0.2 && (npc.velocity.X > 0.0 && dirX < 0.0 || npc.velocity.X < 0.0 && dirX > 0.0))
				{
					if (npc.velocity.Y > 0.0)
						npc.velocity.Y = npc.velocity.Y + acceleration * 2f;
					else
						npc.velocity.Y = npc.velocity.Y - acceleration * 2f;
				}
				if (Math.Abs(dirX) < speed * 0.2 && (npc.velocity.Y > 0.0 && dirY < 0.0 || npc.velocity.Y < 0.0 && dirY > 0.0))
				{
					if (npc.velocity.X > 0.0)
						npc.velocity.X = npc.velocity.X + acceleration * 2f;
					else
						npc.velocity.X = npc.velocity.X - acceleration * 2f;
				}
			}
			else if (absDirX > absDirY)
			{
				if (npc.velocity.X < dirX)
					npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
				else if (npc.velocity.X > dirX)
					npc.velocity.X = npc.velocity.X - acceleration * 1.1f;

				if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
				{
					if (npc.velocity.Y > 0.0)
						npc.velocity.Y = npc.velocity.Y + acceleration;
					else
						npc.velocity.Y = npc.velocity.Y - acceleration;
				}
			}
			else
			{
				if (npc.velocity.Y < dirY)
					npc.velocity.Y = npc.velocity.Y + acceleration * 1.1f;
				else if (npc.velocity.Y > dirY)
					npc.velocity.Y = npc.velocity.Y - acceleration * 1.1f;

				if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
				{
					if (npc.velocity.X > 0.0)
						npc.velocity.X = npc.velocity.X + acceleration;
					else
						npc.velocity.X = npc.velocity.X - acceleration;
				}
			}
            if (Main.player[npc.target].dead)
            {
                npc.velocity.Y = npc.velocity.Y + 1f;
                if ((double)npc.position.Y > Main.rockLayer * 16.0)
                {
                    npc.velocity.Y = npc.velocity.Y + 1f;
                    speed = 30f;
                }
                if ((double)npc.position.Y > Main.rockLayer * 16.0)
                {
                    for (int num957 = 0; num957 < 200; num957++)
                    {
                        if (Main.npc[num957].aiStyle == npc.aiStyle)
                        {
                            Main.npc[num957].active = false;
                        }
                    }
                }
            }

            npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = 1;

            }
            else
            {
                npc.spriteDirection = -1;
            }

            if (collision)
			{
				if (npc.localAI[0] != 1)
					npc.netUpdate = true;
				npc.localAI[0] = 1f;
			}
			if ((npc.velocity.X > 0.0 && npc.oldVelocity.X < 0.0 || npc.velocity.X < 0.0 && npc.oldVelocity.X > 0.0 || (npc.velocity.Y > 0.0 && npc.oldVelocity.Y < 0.0 || npc.velocity.Y < 0.0 && npc.oldVelocity.Y > 0.0)) && !npc.justHit)
				npc.netUpdate = true;

			return false;
		}

		public override void NPCLoot()
		{
			AAWorld.downedAkuma = true;
            
                if (!Main.expertMode)
                {
                    npc.DropLoot(mod.ItemType("CrucibleScale"), 25, 35);
                    string[] lootTable = { "Solar", "SunSpear", "ReignOfFire", "DaybreakArrow", "Daycrusher", "Dawnstrike", "SunStorm", "SunStaff"};
                    int loot = Main.rand.Next(lootTable.Length);
                    npc.DropLoot(mod.ItemType(lootTable[loot]));
                    //npc.DropLoot(Items.Vanity.Mask.AkumaMask.type, 1f / 7);
                    npc.DropLoot(Items.Boss.Akuma.AkumaTrophy.type, 1f / 10);
                    Main.NewText("Hmpf...you’re pretty good kid, but not good enough. Come back once you’ve gotten a bit better.", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
                }
                if (Main.expertMode)
                {
                    Projectile.NewProjectile((new Vector2(npc.position.X, npc.position.Y)), (new Vector2(0f, 0f)), mod.ProjectileType("AkumaTransition"), 0, 0);
                }
                npc.value = 0f;
                npc.boss = false;
		}
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (npc.type == mod.NPCType("AkumaA"))
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Akuma/Akuma_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }

            if (npc.type == mod.NPCType("AkumaArms"))
            {
                
            }

            if (npc.type == mod.NPCType("AkumaBody"))
            {
                
            }

            if (npc.type == mod.NPCType("AkumaTail"))
            {
                
            }
        }
    }

    public class AkumaArms : Akuma
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaArms"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 82;
            npc.height = 96;
            npc.dontCountMe = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;

            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    // NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                }
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                // We're getting the center of this NPC.
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                // Then using that center, we calculate the direction towards the 'parent NPC' of this NPC.
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                // We then use Atan2 to get a correct rotation towards that parent NPC.
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                // We also get the length of the direction vector.
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // We calculate a new, correct distance.
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                // Reset the velocity of this NPC, because we don't want it to move on its own
                if (dirX < 0f)
                {
                    npc.spriteDirection = 1;

                }
                else
                {
                    npc.spriteDirection = -1;
                }
                // And set this NPCs position accordingly to that of this NPCs parent NPC.
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            return false;
        }
        
    }

    public class AkumaBody : Akuma
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaBody"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 52;
            npc.height = 92;
            npc.dontCountMe = true;
        }

        public override void HitEffect(int hitDirection, double damage)
        {

            if (npc.life <= 0)
            {
                npc.position.X = npc.position.X + (float)(npc.width / 2);
                npc.position.Y = npc.position.Y + (float)(npc.height / 2);
                npc.width = 20;
                npc.height = 40;
                npc.position.X = npc.position.X - (float)(npc.width / 2);
                npc.position.Y = npc.position.Y - (float)(npc.height / 2);
                for (int num621 = 0; num621 < 200; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 400; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;
                    num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].velocity *= 2f;
                }
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;

            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    // NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                }
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                // We're getting the center of this NPC.
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                // Then using that center, we calculate the direction towards the 'parent NPC' of this NPC.
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                // We then use Atan2 to get a correct rotation towards that parent NPC.
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                // We also get the length of the direction vector.
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // We calculate a new, correct distance.
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                // Reset the velocity of this NPC, because we don't want it to move on its own
                if (dirX < 0f)
                {
                    npc.spriteDirection = 1;

                }
                else
                {
                    npc.spriteDirection = -1;
                }
                // And set this NPCs position accordingly to that of this NPCs parent NPC.
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("AAMod");
            Texture2D texture = mod.GetTexture("NPCs/Bosses/Akuma/AkumaArms");
            AAMod.DrawTexture(spriteBatch, (npc.localAI[3] == 1f ? texture : Main.npcTexture[npc.type]), 0, npc, drawColor);
            return false;
        }
    }

    public class AkumaTail : Akuma
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaTail"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            npc.width = 44;
            npc.height = 96;
            npc.dontCountMe = true;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {

                npc.position.X = npc.position.X + (float)(npc.width / 2);
                npc.position.Y = npc.position.Y + (float)(npc.height / 2);
                npc.width = 44;
                npc.height = 78;
                npc.position.X = npc.position.X - (float)(npc.width / 2);
                npc.position.Y = npc.position.Y - (float)(npc.height / 2);
                for (int num621 = 0; num621 < 100; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 400; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;
                    num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].velocity *= 2f;
                }
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;

            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    // NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                }
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                // We're getting the center of this NPC.
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                // Then using that center, we calculate the direction towards the 'parent NPC' of this NPC.
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                // We then use Atan2 to get a correct rotation towards that parent NPC.
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                // We also get the length of the direction vector.
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // We calculate a new, correct distance.
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                // Reset the velocity of this NPC, because we don't want it to move on its own
                if (dirX < 0f)
                {
                    npc.spriteDirection = 1;

                }
                else
                {
                    npc.spriteDirection = -1;
                }
                // And set this NPCs position accordingly to that of this NPCs parent NPC.
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            return false;
        }
    }
}
