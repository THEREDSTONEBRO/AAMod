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
	public class AkumaA : ModNPC
	{
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaA"; } }

        public bool Panic;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akuma Awakened");
			NPCID.Sets.TechnicallyABoss[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.width = 144;
			npc.height = 70;
			npc.aiStyle = -1;
			npc.netAlways = true;
            npc.damage = 90;
            npc.defense = 130;
            npc.lifeMax = 300000;
            if (Main.expertMode)
            {
                npc.value = Item.buyPrice(20, 0, 0, 0);
            }
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.DeathSound = new LegacySoundStyle(2, 124, Terraria.Audio.SoundType.Sound);
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Akuma2");
            musicPriority = MusicPriority.BossHigh;
            bossBag = mod.ItemType("AkumaBag");
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

				int proj2 = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-20, 20), npc.Center.Y  + Main.rand.Next(-20, 20), npc.velocity.X* Main.rand.Next(1, 2), npc.velocity.Y * Main.rand.Next(1, 2), mod.ProjectileType("AFireProjHostile"), 20, 0, Main.myPlayer);
				Main.projectile[proj2].timeLeft = 60;
			}
			if (Main.netMode != 1)
			{
				if (npc.ai[0] == 0)
				{
					npc.realLife = npc.whoAmI;
					int latestNPC = npc.whoAmI;
                    int segment = 0;
                    int AkumaALength = 9;
					for (int i = 0; i < AkumaALength; ++i)
					{

                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaBody"), npc.whoAmI, 0, latestNPC);
                        Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                        Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;


                        /*if (segment == 0 || segment == 2 || segment == 3 || segment == 5 || segment == 6 || segment == 8)
                        {
                            latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaABody"), npc.whoAmI, 0, latestNPC);
                            Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                            Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                            segment += 1;
                        }
                        if (segment == 1 || segment == 4 || segment == 7)
                        {
                            latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaAArm"), npc.whoAmI, 0, latestNPC);
                            Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                            Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                            segment += 1;
                        }*/
                    }

                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AkumaATail"), npc.whoAmI, 0, latestNPC);
					Main.npc[(int)latestNPC].realLife = npc.whoAmI;
					Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

					npc.ai[0] = 1;
					npc.netUpdate = true;
				}
			}
            if (npc.life <= npc.lifeMax / 5)
            {
                music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/RayOfHope");
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
			float speed = 12f;
			float acceleration = 0.20f;

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

        public override void HitEffect(int hitDirection, double damage)
        {
            int dust1 = mod.DustType<Dusts.AkumaADust>();
            int dust2 = mod.DustType<Dusts.AkumaADust>();
            if (npc.life <= 0)
            {
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust1].velocity *= 0.5f;
                Main.dust[dust1].scale *= 1.3f;
                Main.dust[dust1].fadeIn = 1f;
                Main.dust[dust1].noGravity = false;
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust2, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust2].velocity *= 0.5f;
                Main.dust[dust2].scale *= 1.3f;
                Main.dust[dust2].fadeIn = 1f;
                Main.dust[dust2].noGravity = true;

            }
            if (npc.life > npc.lifeMax / 5)
            {
                Panic = false;
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && !AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
        }

        public override void NPCLoot()
		{
			AAWorld.downedAkumaA = true;

            if (Main.expertMode)
            {
                //npc.DropLoot(Items.Vanity.Mask.AkumaMask.type, 1f / 7);
                npc.DropLoot(Items.Boss.Akuma.AkumaTrophy.type, 1f / 10);
                if (Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EXSoul"));
                }
                npc.DropBossBags();
                return;
            }
            if (!AAWorld.downedAkumaA && Main.expertMode)
            {
                Main.NewText("Gah..! How could this happen?! Even in my full form?! Fine, take your reward. You earned it.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);

                Panic = false;
            }
            if (AAWorld.downedAkumaA && Main.expertMode)
            {
                Main.NewText("Snuffed out again. You have my respect, kid. Here.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
                Panic = false;
            }
            if (!Main.expertMode)
            {
                Main.NewText("Nice hacks, kid. Now come back and fight me like a real man in expert mode. Then I’ll give you your prize.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
                Panic = false;
            }


        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (damage > npc.lifeMax / 2)
            {
                Main.NewText("Wuss.", Color.Red.R, Color.Red.G, Color.Red.B);
            }
            return false;
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
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Akuma/AkumaA_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }

            if (npc.type == mod.NPCType("AkumaAArms"))
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Akuma/AkumaAArms_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }

            if (npc.type == mod.NPCType("AkumaABody"))
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Akuma/AkumaABody_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }

            if (npc.type == mod.NPCType("AkumaATail"))
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Akuma/AkumaATail_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
                npc.frame, Color.White, npc.rotation,
                new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
            }
        }
    }

    public class AkumaAArms : AkumaA
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaAArms"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma Awakened");
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
            if (npc.life <= npc.lifeMax / 5)
            {
                music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/RayOfHope");
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
                
                if (npc.velocity.X < 0f)
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

        public override void HitEffect(int hitDirection, double damage)
        {
            int dust1 = mod.DustType<Dusts.AkumaADust>();
            int dust2 = mod.DustType<Dusts.AkumaADust>();
            if (npc.life <= 0)
            {
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust1].velocity *= 0.5f;
                Main.dust[dust1].scale *= 1.3f;
                Main.dust[dust1].fadeIn = 1f;
                Main.dust[dust1].noGravity = false;
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust2, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust2].velocity *= 0.5f;
                Main.dust[dust2].scale *= 1.3f;
                Main.dust[dust2].fadeIn = 1f;
                Main.dust[dust2].noGravity = true;

            }
            if (npc.life > npc.lifeMax / 5)
            {
                Panic = false;
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && !AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
        }
    }

    public class AkumaABody : AkumaA
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaABody"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma Awakened");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 52;
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
            if (npc.life <= npc.lifeMax / 5)
            {
                music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/RayOfHope");
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
                if (npc.velocity.X < 0f)
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

        public override void HitEffect(int hitDirection, double damage)
        {
            int dust1 = mod.DustType<Dusts.AkumaADust>();
            int dust2 = mod.DustType<Dusts.AkumaADust>();
            if (npc.life <= 0)
            {
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust1].velocity *= 0.5f;
                Main.dust[dust1].scale *= 1.3f;
                Main.dust[dust1].fadeIn = 1f;
                Main.dust[dust1].noGravity = false;
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust2, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust2].velocity *= 0.5f;
                Main.dust[dust2].scale *= 1.3f;
                Main.dust[dust2].fadeIn = 1f;
                Main.dust[dust2].noGravity = true;

            }
            if (npc.life > npc.lifeMax / 5)
            {
                Panic = false;
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && !AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
        }
    }

    public class AkumaATail : AkumaA
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaATail"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma Awakened");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            npc.width = 44;
            npc.height = 78;
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
            if (npc.life <= npc.lifeMax / 5)
            {
                music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/RayOfHope");
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
                if (npc.velocity.X < 0f)
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

        public override void HitEffect(int hitDirection, double damage)
        {
            int dust1 = mod.DustType<Dusts.AkumaADust>();
            int dust2 = mod.DustType<Dusts.AkumaADust>();
            if (npc.life <= 0)
            {
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust1].scale *= 1.3f;
                Main.dust[dust1].fadeIn = 1f;
                Main.dust[dust1].noGravity = false;
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust2, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust2].scale *= 1.3f;
                Main.dust[dust2].fadeIn = 1f;
                Main.dust[dust2].noGravity = true;

            }
            if (npc.life > npc.lifeMax / 5)
            {
                Panic = false;
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && !AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && Panic == false && AAWorld.downedAkumaA == false && Main.expertMode && npc.type == mod.NPCType<AkumaA>())
            {
                Panic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
        }
        
    }
}
