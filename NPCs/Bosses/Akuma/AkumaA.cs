using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Akuma
{
    
    //[AutoloadBossHead]
    public class AkumaAHead : ModNPC
	{
        public bool AkumaAPanic = false;
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaAHead"; } }
        public bool flies = false;
		public const int minLength = 50;
		public const int maxLength = 51;
		public float speed = 0.15f;
		public float turnSpeed = 0.1f;
		bool TailSpawned = false;
		public bool secondStage = false;
		public bool thirdStage = false;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akuma Awakened");
		}

        public override void SetDefaults()
        {
            npc.lifeMax = 280000;
            npc.damage = 100;
            npc.defense = 120;
            npc.knockBackResist = 0f;
            npc.width = 112;
            npc.height = 144;
            npc.value = Item.buyPrice(0, 55, 0, 0);
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.DeathSound = null;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Akuma2");
            musicPriority = MusicPriority.BossHigh;
            npc.scale = 1.2f;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            //bossBag = mod.ItemType("NCBag");
        }

        public override void AI()
		{
			bool expertMode = Main.expertMode;
			int defenseDown = (int)(30f * (1f - npc.life / (float)npc.lifeMax));
			npc.defense = npc.defDefense - defenseDown;
			Lighting.AddLight((int)((npc.position.X + npc.width / 2) / 16f), (int)((npc.position.Y + npc.height / 2) / 16f), 0.2f, 0.05f, 0.2f);
			
			if (npc.ai[3] > 0f)
			{
				npc.realLife = (int)npc.ai[3];
			}
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}
			npc.velocity.Length();
			float speedMult = expertMode ? 1.7f : 1.6f;
			float life = npc.life;
			float totalLife = npc.lifeMax;
			float newSpeed = speed * (speedMult - (life / totalLife));
			float newTurnSpeed = turnSpeed * (speedMult - (life / totalLife));
			
			if (Main.netMode != 1)
			{
				if (!TailSpawned && npc.ai[0] == 0f)
	            {
	                int Previous = npc.whoAmI;
	                for (int num36 = 0; num36 < maxLength; num36++)
	                {
	                    int Segment = 0;
	                    if (num36 >= 0 && num36 < minLength)
	                    {
	                        Segment = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.NPCType("AkumaBody"), npc.whoAmI);
	                    }
	                    else
	                    {
	                        Segment = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.NPCType("AkumaTail"), npc.whoAmI);
	                    }
	                    if (num36 % 2 == 0)
	                    {
	                    	Main.npc[Segment].localAI[3] = 1f;
	                    }
	                    Main.npc[Segment].realLife = npc.whoAmI;
	                    Main.npc[Segment].ai[2] = npc.whoAmI;
	                    Main.npc[Segment].ai[1] = Previous;
	                    Main.npc[Previous].ai[0] = Segment;
	                    Previous = Segment;
	                }
	                TailSpawned = true;
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
			bool flag94 = flies;
			if (!flag94)
			{
				for (int num952 = num180; num952 < num181; num952++)
				{
					for (int num953 = num182; num953 < num183; num953++)
					{
						if (Main.tile[num952, num953] != null && ((Main.tile[num952, num953].nactive() && (Main.tileSolid[Main.tile[num952, num953].type] || (Main.tileSolidTop[Main.tile[num952, num953].type] && Main.tile[num952, num953].frameY == 0))) || Main.tile[num952, num953].liquid > 64))
						{
							Vector2 vector105;
							vector105.X = num952 * 16;
							vector105.Y = num953 * 16;
							if (npc.position.X + npc.width > vector105.X && npc.position.X < vector105.X + 16f && npc.position.Y + npc.height > vector105.Y && npc.position.Y < vector105.Y + 16f)
							{
								flag94 = true;
								break;
							}
						}
					}
				}
			}
			if (!flag94)
			{
				npc.localAI[1] = 1f;
				Rectangle rectangle12 = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
				int num954 = 1000;
				bool flag95 = true;
				if (npc.position.Y > Main.player[npc.target].position.Y)
				{
					for (int num955 = 0; num955 < 255; num955++)
					{
						if (Main.player[num955].active)
						{
							Rectangle rectangle13 = new Rectangle((int)Main.player[num955].position.X - num954, (int)Main.player[num955].position.Y - num954, num954 * 2, num954 * 2);
							if (rectangle12.Intersects(rectangle13))
							{
								flag95 = false;
								break;
							}
						}
					}
					if (flag95)
					{
						flag94 = true;
					}
				}
			}
			else
			{
				npc.localAI[1] = 0f;
			}
			float maxSpeed = 20f;
			if (!Main.dayTime || Main.player[npc.target].dead)
			{
				flag94 = false;
				npc.velocity.Y = npc.velocity.Y + 1f;
				if (npc.position.Y > Main.worldSurface * 16.0)
				{
					npc.velocity.Y = npc.velocity.Y + 1f;
					maxSpeed = 40f;
				}
				if (npc.position.Y > Main.rockLayer * 16.0)
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
			float num188 = newSpeed;
			float num189 = newTurnSpeed;
			Vector2 vector18 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float num191 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
			float num192 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
			num191 = (int)(num191 / 16f) * 16;
			num192 = (int)(num192 / 16f) * 16;
			vector18.X = (int)(vector18.X / 16f) * 16;
			vector18.Y = (int)(vector18.Y / 16f) * 16;
			num191 -= vector18.X;
			num192 -= vector18.Y;
			float num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
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
				npc.rotation = (float)Math.Atan2(num192, num191) + 1.57f;
				num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
				int num194 = npc.width;
				num193 = (num193 - num194) / num193;
				num191 *= num193;
				num192 *= num193;
				npc.velocity = Vector2.Zero;
				npc.position.X = npc.position.X + num191;
				npc.position.Y = npc.position.Y + num192;
			}
			else
			{
				if (!flag94)
				{
					npc.TargetClosest(true);
					npc.velocity.Y = npc.velocity.Y + 0.15f;
					if (npc.velocity.Y > maxSpeed)
					{
						npc.velocity.Y = maxSpeed;
					}
					if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < maxSpeed * 0.4)
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X - num188 * 1.1f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X + num188 * 1.1f;
						}
					}
					else if (npc.velocity.Y == maxSpeed)
					{
						if (npc.velocity.X < num191)
						{
							npc.velocity.X = npc.velocity.X + num188;
						}
						else if (npc.velocity.X > num191)
						{
							npc.velocity.X = npc.velocity.X - num188;
						}
					}
					else if (npc.velocity.Y > 4f)
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X + num188 * 0.9f;
						}
						else
						{
							npc.velocity.X = npc.velocity.X - num188 * 0.9f;
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
						Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
					}
					num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
					float num196 = Math.Abs(num191);
					float num197 = Math.Abs(num192);
					float num198 = maxSpeed / num193;
					num191 *= num198;
					num192 *= num198;
					if (((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f)) && ((npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f)))
					{
						if (npc.velocity.X < num191)
						{
							npc.velocity.X = npc.velocity.X + num189;
						}
						else if (npc.velocity.X > num191)
						{
							npc.velocity.X = npc.velocity.X - num189;
						}
						if (npc.velocity.Y < num192)
						{
							npc.velocity.Y = npc.velocity.Y + num189;
						}
						else if (npc.velocity.Y > num192)
						{
							npc.velocity.Y = npc.velocity.Y - num189;
						}
					}
					if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
					{
						if (npc.velocity.X < num191)
						{
							npc.velocity.X = npc.velocity.X + num188;
						}
						else
						{
							if (npc.velocity.X > num191)
							{
								npc.velocity.X = npc.velocity.X - num188;
							}
						}
						if (npc.velocity.Y < num192)
						{
							npc.velocity.Y = npc.velocity.Y + num188;
						}
						else
						{
							if (npc.velocity.Y > num192)
							{
								npc.velocity.Y = npc.velocity.Y - num188;
							}
						}
						if (Math.Abs(num192) < maxSpeed * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
						{
							if (npc.velocity.Y > 0f)
							{
								npc.velocity.Y = npc.velocity.Y + num188 * 2f;
							}
							else
							{
								npc.velocity.Y = npc.velocity.Y - num188 * 2f;
							}
						}
						if (Math.Abs(num191) < maxSpeed * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
						{
							if (npc.velocity.X > 0f)
							{
								npc.velocity.X = npc.velocity.X + num188 * 2f;
							}
							else
							{
								npc.velocity.X = npc.velocity.X - num188 * 2f;
							}
						}
					}
					else
					{
						if (num196 > num197)
						{
							if (npc.velocity.X < num191)
							{
								npc.velocity.X = npc.velocity.X + num188 * 1.1f;
							}
							else if (npc.velocity.X > num191)
							{
								npc.velocity.X = npc.velocity.X - num188 * 1.1f;
							}
							if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < maxSpeed * 0.5)
							{
								if (npc.velocity.Y > 0f)
								{
									npc.velocity.Y = npc.velocity.Y + num188;
								}
								else
								{
									npc.velocity.Y = npc.velocity.Y - num188;
								}
							}
						}
						else
						{
							if (npc.velocity.Y < num192)
							{
								npc.velocity.Y = npc.velocity.Y + num188 * 1.1f;
							}
							else if (npc.velocity.Y > num192)
							{
								npc.velocity.Y = npc.velocity.Y - num188 * 1.1f;
							}
							if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < maxSpeed * 0.5)
							{
								if (npc.velocity.X > 0f)
								{
									npc.velocity.X = npc.velocity.X + num188;
								}
								else
								{
									npc.velocity.X = npc.velocity.X - num188;
								}
							}
						}
					}
				}
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
				if (flag94)
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
		
		public override bool CheckActive()
		{
			return false;
		}
		
		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.penetrate == -1 && !projectile.minion)
			{
				damage /= 5;
			}
			else if (projectile.penetrate > 1)
			{
				damage /= projectile.penetrate;
			}
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && !AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
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
        }
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
		
		public override void NPCLoot()
		{
            if (Main.expertMode && !AAWorld.downedAkumaA)
            {
                Main.NewText("Gah..! How could this happen?! Even in my full form?! Fine, take your reward. You earned it.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
                
            }
            if (Main.expertMode && AAWorld.downedAkumaA)
            {
                Main.NewText("Snuffed out again. You have my respect, kid. Here.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
                
            }
            if (!Main.expertMode)
            {
                Main.NewText("Nice hacks, kid. Now come back and fight me like a real man in expert mode. Then I’ll give you your prize.", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
                
            }
            AAWorld.downedAkumaA = true;
        }
		
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
				player.AddBuff(mod.BuffType("Dragonfire"), 150, true);
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
			npc.damage = (int)(npc.damage * 1.5f);
		}
	}

    public class AkumaABody : AkumaAHead
    {
        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaABody"; } }

        public int spawn = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma Awakened");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 280000;
            npc.damage = 100;
            npc.defense = 120;
            npc.knockBackResist = 0f;
            npc.width = 112;
            npc.height = 96;
            npc.height = 112;
            npc.value = Item.buyPrice(0, 55, 0, 0);
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.DeathSound = null;
            npc.scale = 1.2f;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Akuma2");
            musicPriority = MusicPriority.BossHigh;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            //bossBag = mod.ItemType("NCBag");
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void AI()
        {
            bool expertMode = Main.expertMode;
            int defenseDown = (int)(30f * (1f - npc.life / (float)npc.lifeMax));
            npc.defense = npc.defDefense - defenseDown;
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            
            Texture2D texture = mod.GetTexture("NPCs/Bosses/Akuma/AkumaAArms");
            AAMod.DrawTexture(spriteBatch, npc.localAI[3] == 1f ? texture : Main.npcTexture[npc.type], 0, npc, drawColor);
            return false;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.penetrate == -1 && !projectile.minion)
            {
                damage /= 5;
            }
            else if (projectile.penetrate > 1)
            {
                damage /= projectile.penetrate;
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && !AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
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
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                player.AddBuff(mod.BuffType("Dragonfire"), 150, true);
            
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
    }

    public class AkumaATail : AkumaAHead
    {

        public override string Texture { get { return "AAMod/NPCs/Bosses/Akuma/AkumaATail"; } }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Akuma");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 280000;
            npc.damage = 100;
            npc.defense = 120;
            npc.knockBackResist = 0f;
            npc.width = 112;
            npc.height = 78;
            npc.value = Item.buyPrice(0, 55, 0, 0);
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.DeathSound = null;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Akuma2");
            musicPriority = MusicPriority.BossHigh;
            npc.scale = 1.2f;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            //bossBag = mod.ItemType("NCBag");
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void AI()
        {
            int defenseDown = (int)(30f * (1f - npc.life / (float)npc.lifeMax));
            npc.defense = npc.defDefense - defenseDown;
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.penetrate == -1 && !projectile.minion)
            {
                damage /= 5;
            }
            else if (projectile.penetrate > 1)
            {
                damage /= projectile.penetrate;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && !AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Wha—?! How have you lasted this long?! Grrrrrr…! I refuse to be bested by you! Have at it!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
            if (npc.life <= npc.lifeMax / 5 && AkumaAPanic == false && AAWorld.downedAkumaA == false && Main.expertMode)
            {
                AkumaAPanic = true;
                Main.NewText("Still got it, do ya? I like that about you, kid..!", Color.DeepSkyBlue.R, Color.DeepSkyBlue.G, Color.DeepSkyBlue.B);
            }
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
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                player.AddBuff(mod.BuffType("Dragonfire"), 150, true);
            
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
    }
}