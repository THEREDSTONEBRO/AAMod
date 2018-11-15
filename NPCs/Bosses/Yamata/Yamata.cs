using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ReLogic.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Audio;
using Terraria.ModLoader;
using BaseMod;

namespace AAMod.NPCs.Bosses.Yamata
{
	[AutoloadBossHead]
	public class Yamata : YamataBoss
	{

        public override void SendExtraAI(BinaryWriter writer)
		{
			base.SendExtraAI(writer);
			if((Main.netMode == 2 || Main.dedServ))
			{
				writer.Write((float)internalAI[0]);
				writer.Write((float)internalAI[1]);
				writer.Write((float)internalAI[2]);
				writer.Write((float)internalAI[3]);
			}
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.ReceiveExtraAI(reader);
			if(Main.netMode == 1)
			{
				internalAI[0] = reader.ReadFloat();
				internalAI[1] = reader.ReadFloat();
				internalAI[2] = reader.ReadFloat();
				internalAI[3] = reader.ReadFloat();
			}	
		}
		
		public override void SetStaticDefaults()
		{
            displayName = "Yamata";
            Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.npcSlots = 100;
            npc.width = 80;
            npc.height = 90;
            npc.value = BaseUtility.CalcValue(0, 0, 0, 0);
            npc.aiStyle = -1;
            npc.lifeMax = 180000;
            npc.defense = 160;
            npc.damage = 0;
            npc.knockBackResist = 0f;
			npc.boss = true;
            npc.HitSound = new LegacySoundStyle(3, 6, Terraria.Audio.SoundType.Sound);
            npc.DeathSound = new LegacySoundStyle(4, 8, Terraria.Audio.SoundType.Sound);
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Yamata");
            npc.noGravity = true;
            npc.noTileCollide = true;
			npc.netAlways = true;
			for(int m = 0; m < npc.buffImmune.Length; m++) npc.buffImmune[m] = true;
			bossBag = mod.ItemType("YamataBag");

			frameWidth = 98;
			frameHeight = 94;
			npc.frame = BaseDrawing.GetFrame(frameCount, frameWidth, frameHeight, 0, 2);
			frameBottom = BaseDrawing.GetFrame(frameCount, frameWidth, 70, 0, 2);
			frameHead = BaseDrawing.GetFrame(frameCount, frameWidth, 118, 0, 2);
			
			if(Main.expertMode)
			{
				int playerCount = 0;
				float bossHPScalar = 1f, scalarIncrement = 0.35f;
				if (Main.netMode != 0)
				{
					for (int i = 0; i < 255; i++)
					{
						if (Main.player[i].active)
						{
							playerCount++;
						}
					}
					for (int j = 1; j < playerCount; j++)
					{
						bossHPScalar += scalarIncrement;
						scalarIncrement += (1f - scalarIncrement) / 3f;
					}
				}
				ScaleExpertStats(playerCount, bossHPScalar);
			}
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}

		public override bool G_CanSpawn(int x, int y, int type, Player player)
		{
			return false;
		}

		public override void NPCLoot()
		{
            //BaseAI.DropItem(npc, mod.ItemType("YamataTrophy"), 1, 1, 15, true);
			if(Main.expertMode)
			{
				npc.DropBossBags();
			}else
			{
                npc.DropLoot(mod.ItemType("DreadScales"), 20, 30);
                //string[] lootTable = { "AkumaTerratool", "DayStorm", "LungStaff", "MorningGlory", "RadiantDawn", "Solar", "SunSpear", "ReignOfFire", "DaybreakArrow", "Daycrusher", "Dawnstrike", "SunStorm", "SunStaff", "DragonSlasher" };
                //int loot = Main.rand.Next(lootTable.Length);
                //npc.DropLoot(mod.ItemType(lootTable[loot]));
                //npc.DropLoot(Items.Vanity.Mask.YamataMask.type, 1f / 7);
                //npc.DropLoot(Items.Boss.Akuma.YamataTrophy.type, 1f / 10);
                Main.NewText("HEHEHEHEHEHEH...You're pretty good, but eh, not quite there. Come back when you're not a normal-mode playing scrub.", new Color(20, 20, 76));

            }
        }

		public override void G_HitEffect(int hitDirection, double damage, bool isDead)
		{
			if (Main.netMode == 2) { return; }	
			if(isDead)
			{
				
			}
		}

		public float[] internalAI = new float[4];
		public Rectangle frameBottom = new Rectangle(0, 0, 1, 1), frameHead = new Rectangle(0, 0, 1, 1);
		public bool prevHalfHPLeft = false, halfHPLeft = false, prevFourthHPLeft = false, fourthHPLeft = false;
		public Player playerTarget = null;
		public static int flyingTileCount = 12, totalMinionCount = 0;
		
		//damage counts
		public int swipeDamage = 100, scytheDamage = 120, eggDamage = 90;
		public int normalDefense = 200, healingDefense = 500;

		//clientside stuff
	
		public Vector2 bottomVisualOffset = default(Vector2);
		public Vector2 topVisualOffset = default(Vector2);
		public LegInfo[] legs = null;	
		
		public static bool NOTRELEASED = false;
		public static NPC dustMantid = null;
		

		public override void AI()
		{
			dustMantid = npc;
			prevHalfHPLeft = halfHPLeft;
			prevFourthHPLeft = fourthHPLeft;
			halfHPLeft = (halfHPLeft || npc.life <= npc.lifeMax / 2);
			fourthHPLeft = (fourthHPLeft || npc.life <= npc.lifeMax / 4);
			for (int m = npc.oldPos.Length - 1; m > 0; m--)
			{
				npc.oldPos[m] = npc.oldPos[m - 1];
			}
			npc.oldPos[0] = npc.position;

			bool foundTarget = TargetClosest();		
			if(foundTarget)
			{
				int tileY = BaseWorldGen.GetFirstTileFloor((int)(npc.Center.X / 16f), (int)(npc.Center.Y / 16f));
				npc.timeLeft = 300;
				
				float playerDistance = Vector2.Distance(playerTarget.Center, npc.Center);
				internalAI[0]--; if(internalAI[0] <= 0){ internalAI[0] = 0; }	
				
			}else
			{		
				AIMovementRunAway();
			}
			//topVisualOffset = new Vector2(Math.Min(8f, Math.Abs(npc.velocity.X) * 2f), 0f) * (npc.velocity.X < 0 ? 1 : -1);
			bottomVisualOffset = new Vector2(Math.Min(3f, Math.Abs(npc.velocity.X)), 0f) * (npc.velocity.X < 0 ? 1 : -1);
			UpdateLimbs();			
		}
		public void AIMovementIdle()
		{
			npc.velocity *= 0.9f;
			if(Math.Abs(npc.velocity.X) < 0.01f) npc.velocity.X = 0f;
			if(Math.Abs(npc.velocity.Y) < 0.01f) npc.velocity.Y = 0f;
			npc.rotation = 0f;
		}

		public void AIMovementRunAway()
		{
			npc.velocity.X *= 0.9f;
			if(Math.Abs(npc.velocity.X) < 0.01f) npc.velocity.X = 0f;
			npc.velocity.Y -= 0.25f;
			npc.rotation = 0f;
			if(npc.position.Y + npc.velocity.Y <= 0f && Main.netMode != 1){ BaseAI.KillNPC(npc); npc.netUpdate2 = true; } //if out of map, kill mantid
		}	

		
		
				
		public const int stateIdle = 0, stateMovementOnly = 1, stateArmScythes = 2, stateArmSpawns = 3, stateArmCombo = 4, stateFireEggs = 5, stateArmAndEggs = 6;
		public static int[] timers = new int[]{ 100, 60, 80, 170, 170, 160, 170 };
		public static int[] statesToChangeTo = new int[]{ stateMovementOnly, stateArmSpawns, stateArmCombo, stateFireEggs };
		public static int[] statesToChangeToExpert = new int[]{ stateMovementOnly, stateArmCombo, stateArmSpawns };		
		

		public bool TargetClosest()
		{
			int[] players = BaseAI.GetPlayers(npc.Center, 4200f);
			float dist = 999999999f;
			int foundPlayer = -1;
			for (int m = 0; m < players.Length; m++)
			{
				Player p = Main.player[players[m]];
				if (p.ZoneJungle && Vector2.Distance(p.Center, npc.Center) < dist) //prioritize players in the jungle
				{
					dist = Vector2.Distance(p.Center, npc.Center);
					foundPlayer = p.whoAmI;
				}
			}
			if (foundPlayer != -1)
			{
                BaseAI.SetTarget(npc, foundPlayer);
				playerTarget = Main.player[foundPlayer];
				return true;
			}else //found no jungle targets, you must be outside of it, time to make them pay :)
			{
				for (int m = 0; m < players.Length; m++)
				{
					Player p = Main.player[players[m]];
					if (Vector2.Distance(p.Center, npc.Center) < dist)
					{
						dist = Vector2.Distance(p.Center, npc.Center);
						foundPlayer = p.whoAmI;
					}
				}				
			}
			if (foundPlayer != -1)
			{
                BaseAI.SetTarget(npc, foundPlayer);
				playerTarget = Main.player[foundPlayer];
				return true;
			}			
			return false;
		}	
		
		public void UpdateLimbs()
		{
            ;
			if(legs == null || legs.Length < 4)
			{
				legs = new LegInfo[4];
				legs[0] = new LegInfo(0, npc.Bottom + new Vector2(60, 0), this);
				legs[1] = new LegInfo(1, npc.Bottom + new Vector2(-82, 0), this);
				legs[2] = new LegInfo(2, npc.Bottom + new Vector2(80, 0), this);
				legs[3] = new LegInfo(3, npc.Bottom + new Vector2(-102, 0), this);
			}
			for(int m = 0; m < 4; m++)
			{
				legs[m].UpdateLeg(npc);				
			}
		}

		public override bool PreDraw(SpriteBatch sb, Color dColor)
		{
			if(legs != null)
			{
				for(int m = 0; m < 4; m++)
				{
					legs[m].DrawLeg(sb, npc, dColor);				
				}
			}		
			return false;			
		}	
	}

	public class AnimationInfo
	{
		public int animType = 0;
		Vector2[] leftPos = null, left2Pos = null;
		Vector2[] rightPos = null, right2Pos = null;
		float[] leftRotations = null, left2Rotations = null;
		float[] rightRotations = null, right2Rotations = null;
		public float movementRatio = 0f, movementRate = 0.01f, animMult = 1f;
		public static float halfPI = (float)Math.PI / 2f;
		public bool[] fired = new bool[4];
		public float[] hitRatios = null;
		public bool flatJoint = false;
	}

	public class LimbInfo
	{
		public int limbType = 0;
		public Vector2 position, oldPosition;
		public Vector2 Center 
		{ 
			get { return new Vector2(position.X + ((float)Hitbox.Width * 0.5f), position.Y + ((float)Hitbox.Height * 0.5f)); } 
			set { position = new Vector2(value.X - ((float)Hitbox.Width * 0.5f), value.Y - ((float)Hitbox.Height * 0.5f)); }
		}
		public Rectangle Hitbox;
		public float rotation = 0f, movementRatio = 0f;
		public AnimationInfo overrideAnimation = null;
		public Yamata yamata = null;
	}
	
	public class LegInfo : LimbInfo
	{
		Vector2 velocity, oldVelocity, legOrigin;
		float velOffsetY = 0f, distanceToMove = 120f, distanceToMoveX = 50f;
		bool flying = false, leftLeg = false;
	
		Vector2 pointToStandOn = default(Vector2);
		Vector2 legJoint = default(Vector2);
		public static Texture2D[] textures = null;		

		public LegInfo(int lType, Vector2 initialPos, Yamata m)
		{
			yamata = m;
			position = initialPos;
			pointToStandOn = position;
			limbType = lType;
			Hitbox = new Rectangle(0, 0, 42, 110);
			legOrigin = new Vector2(limbType == 1 || limbType == 3 ? Hitbox.Width - 12 : 12, 12);
		}

		public void UpdateVelOffsetY()
		{
			movementRatio += 0.075f;
			movementRatio = Math.Max(0f, Math.Min(1f, movementRatio));
			velOffsetY = BaseUtility.MultiLerp(movementRatio, 0f, 40f, 0f);
		}

		public void MoveLegWalking(NPC npc, bool leftLeg, Vector2 standOnPoint)
		{
			UpdateVelOffsetY();
			if(pointToStandOn != default(Vector2))
			{
				Vector2 velAddon = (pointToStandOn - position); velAddon.Normalize(); velAddon *= (1.6f + (npc.velocity.Length() * 0.5f));
				velocity += velAddon;
				float velMax = 6f + npc.velocity.Length();
				if(velocity.Length() > velMax){ velocity.Normalize(); velocity *= velMax; }
				if(Vector2.Distance(pointToStandOn, position) <= 20){ position = pointToStandOn; velocity = default(Vector2); }
				position += velocity;
				if((position == pointToStandOn || Vector2.Distance(standOnPoint, position + new Vector2((float)Hitbox.Width * 0.5f, 0f)) > distanceToMove || Math.Abs(position.X - standOnPoint.X) > distanceToMoveX))
				{
					pointToStandOn = default(Vector2);
				}
			}
			if(pointToStandOn == default(Vector2))
			{
				if(Vector2.Distance(standOnPoint, position + new Vector2((float)Hitbox.Width * 0.5f, 0f)) > distanceToMove || Math.Abs(position.X - standOnPoint.X) > distanceToMoveX)
				{
					movementRatio = 0f;
					pointToStandOn = standOnPoint;
				}
			}				
		}

		public void UpdateLeg(NPC npc)
		{
			leftLeg = limbType == 1 || limbType == 3;
			if(Vector2.Distance(Center, npc.Center) > 1000f) position = npc.Center; //prevent issues when the legs are WAY off.
			rotation = 0f;
		    Vector2 standOnPoint = GetStandOnPoint(npc);
			MoveLegWalking(npc, leftLeg, standOnPoint);
			Vector2 yamataConnector = GetYamataConnector(npc);
			legJoint = Vector2.Lerp(position, yamataConnector, 0.5f) + new Vector2(leftLeg ? 32 : 0f, 60);
			oldPosition = position;
			oldVelocity = velocity;
		}

		public Vector2 GetStandOnPoint(NPC npc)
		{
			float scalar = npc.velocity.Length();
			float outerLegDefault = 100f + (0.5f * scalar);
			float innerLegDefault = 70f + (0.5f * scalar);
			float rightLegScalar = 1f + (npc.velocity.X > 2f ? (scalar * 0.2f) : 0f); //fixes an offset problem when the matriarch walks right
			float standOnX = npc.Center.X + yamata.topVisualOffset.X + (limbType == 3 ? (-outerLegDefault - Hitbox.Width) : limbType == 2 ? (outerLegDefault + Hitbox.Width) : limbType == 1 ? (-innerLegDefault - Hitbox.Width) : (innerLegDefault + Hitbox.Width));
			int defaultTileY = (int)(npc.Bottom.Y / 16f);
			int tileY = BaseWorldGen.GetFirstTileFloor((int)(standOnX / 16f), (int)(npc.Bottom.Y / 16f));
			tileY = (int)((int)((float)tileY * 16f) / 16);
			float tilePosY = ((float)tileY * 16f);
			if(Main.tile[(int)(standOnX / 16f), tileY] == null || !Main.tile[(int)(standOnX / 16f), tileY].nactive() || !Main.tileSolid[Main.tile[(int)(standOnX / 16f), tileY].type]) tilePosY += 16f;
			return new Vector2(standOnX - (Hitbox.Width * 0.5f), tilePosY - Hitbox.Height);
		}

		public Vector2 GetYamataConnector(NPC npc)
		{
			return npc.Center + yamata.topVisualOffset + new Vector2((limbType == 3 || limbType == 1 ? -30f : 30f), 60f);
		}

        public void DrawLeg(SpriteBatch sb, NPC npc, Color dColor)
		{
			if (textures == null)
			{
				textures = new Texture2D[4];
				textures[3] = AAMod.GetTexture("YamataLegLeft");
			}
			Vector2 drawPos = position - new Vector2(0f, velOffsetY);
			Color lightColor = npc.GetAlpha(BaseDrawing.GetLightColor(Center));
            BaseDrawing.DrawTexture(sb, textures[3], 0, drawPos, Hitbox.Width, Hitbox.Height, npc.scale, rotation, limbType == 1 || limbType == 3 ? 1 : -1, 1, Hitbox, lightColor, false, legOrigin);
		}
	}
}