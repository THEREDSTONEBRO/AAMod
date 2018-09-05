using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;
using Terraria.Audio;

namespace AAMod.NPCs.Enemies.AncientLung
{
    class AncientLungHead : AncientLung
    {
		
		public override void SetDefaults()
		{
            //aiType = 87;
            npc.CloneDefaults(NPCID.WyvernHead);
            npc.aiStyle = -1;
            npc.lifeMax = 6000;
            npc.damage = 60;
            npc.height = 156; //sprite height
            npc.defense = 50;
            npc.value = Item.buyPrice(2, 0, 0, 0);
		}
		public override void Init()
		{
			base.Init();
			head = true;
		}
	}
	class AncientLungBody1 : AncientLung
    {

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.WyvernLegs);
            npc.aiStyle = -1;
            npc.defense = 999999;
            npc.lifeMax = 70000;
            npc.height = 156; //sprite height
		}
	}
	class AncientLungBody2 : AncientLung
    {

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.WyvernBody);
            npc.aiStyle = -1;
            npc.defense = 999999;
            npc.lifeMax = 70000;
            npc.height = 156; //sprite height
		}
	}
	class AncientLungBody3 : AncientLung
    {

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.WyvernBody);
            npc.aiStyle = -1;
            npc.defense = 999999;
            npc.lifeMax = 70000;
            npc.height = 156; //sprite height
		}
	}
	class AncientLungBody4 : AncientLung
    {

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.WyvernBody);
            npc.aiStyle = -1;
            npc.defense = 999999;
            npc.lifeMax = 70000;
            npc.height = 156; //sprite height
		}
	}
	class AncientLungTail : AncientLung
    {

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.WyvernBody);
            npc.aiStyle = -1;
            npc.defense = 999999;
            npc.lifeMax = 70000;
            npc.height = 156; //sprite height
		}
        public override void Init()
        {
            base.Init();
            tail = true;
        }
    }
	public abstract class AncientLung : Ancient_Lung
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Wyvern");
            Main.npcFrameCount[npc.type] = 12;   // How many animation frames the NPC has
		}
		//private bool despawn = false;

		public override void Init()
		{
			minLength = 13;
            maxLength = 13;
            length = 13;
            headType = mod.NPCType("AncientLungHead;");
            bodyType = mod.NPCType("AncientLungBody2");
            armType = mod.NPCType("AncientLungBody1");
            tailBaseType = mod.NPCType("AncientLungBody3");
            tailMidType = mod.NPCType("AncientLungBody4");
            tailEndType = mod.NPCType("AncientLungTail");
            speed = 13f;
			turnSpeed = 0.08f;
		}
	}

	public abstract class Ancient_Lung : ModNPC
	{
		/* ai[0] = follower
		 * ai[1] = following
		 * ai[2] = distanceFromTail
		 * ai[3] = head
		 */
        public int FollowerIndex { get { return (int)npc.ai[0]; } private set { npc.ai[0] = value; } }  //this is the npc that is following us. For most segments this is another body segment.
        public int FollowingIndex { get { return (int)npc.ai[1]; } private set { npc.ai[1] = value; } }  //this is the npc that we are following.

        protected int DistanceFromTail { get { return (int)npc.ai[2]; } private set { npc.ai[2] = value; } }  //the distance, in npc segments, from the tail.
        protected int HeadIndex { get { return (int)npc.ai[3]; } private set { npc.ai[3] = value; } }

        /// <summary>
        /// Determines if the worm turns towards its target or not. Defaults to true.
        /// Note that this has no effect if <see cref="flies"/> is false and the worm is in the air. (It will still turn to fall to the ground.)
        /// </summary>
        protected bool turnsToTarget = true;
        protected bool targetsPlayer;
        protected Player Target { get { return Main.player[npc.target]; } }

        protected Vector2 TargetPos { get { return new Vector2(targetPosX, targetPosY); } set { targetPosX = value.X; targetPosY = value.Y; } }
        private float targetPosX;
        private float targetPosY;
		public bool head;
		public bool tail;
		public int length;
        public int minLength;
        public int maxLength;// tail   y=arms  head
        public int headType; //    xxxxyxxxxxxyO
		public int bodyType; //    xxxxyOOOOOOyx
		public int armType; //     xxxxOxxxxxxOx
		public int tailBaseType; //xxxOyxxxxxxyx
		public int tailMidType; // xxOxyxxxxxxyx
		public int tailEndType; // xOxxyxxxxxxyx
		public bool flies = true;
		public bool directional = true;
		public float speed;
		public float turnSpeed;
		
        public override void SendExtraAI(BinaryWriter writer)
        {   //more efficent to write a single byte with several boolean values then several bytes with one boolean value each (which is what writer.Write(boolean) does)
            BitsByte flags = new BitsByte(turnsToTarget, targetsPlayer);
            writer.Write(flags);

            writer.Write(targetPosX);
            writer.Write(targetPosY);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            turnsToTarget = flags[0];
            targetsPlayer = flags[1];

            targetPosX = reader.ReadSingle();
            targetPosY = reader.ReadSingle();
        }
		public override void AI()
		{
			if (npc.localAI[1] == 0f)
			{
				npc.localAI[1] = 1f;
				Init();
			}
            if (npc.ai[3] > 0f)
            {   //realLife is a npc index at which we copy health from?
                //npc.realLife = HeadIndex;
                npc.realLife = (int)npc.ai[3];
            }

			if (!head && npc.timeLeft < 300)
			{
				npc.timeLeft = 300;
			}
            /*if (head && npc.timeLeft < 300)
            {
                npc.timeLeft = 300;
            }*/
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


                    if (head)
                    {
                        npc.ai[3] = (float)npc.whoAmI;
                        npc.realLife = npc.whoAmI;
                        //npc.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
                        npc.ai[2] = 13f;
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
                    }
                    else if (npc.ai[2] == 4f || npc.ai[2] == 10f)
                    {
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), armType, npc.whoAmI);
                    }
                    else if (npc.ai[2] == 1f)
                    {
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), tailMidType, npc.whoAmI);
                    }
                    else if (npc.ai[2] == 2f)
                    {
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), tailBaseType, npc.whoAmI);
                    }
                    else if (npc.ai[2] > 0f)
                    {
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
                    }
                    else
                    {
                        npc.ai[0] = (float)Terraria.NPC.NewNPC((int)(npc.position.X + (float)(npc.width)), (int)(npc.position.Y + (float)npc.height), tailEndType, npc.whoAmI);
                    }
                    //else { }
                    Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
                    Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                    Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
                    Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
                    npc.netUpdate = true;
                    //follower = Main.npc[FollowerIndex];

                    //follower.realLife = npc.realLife;
                    //follower.ai[3] = HeadIndex;
                    //follower.ai[1] = npc.whoAmI;
                    //follower.ai[2] = DistanceFromTail - 1f;
                    //npc.netUpdate = true;
                }
               /* if (!head && (!Main.npc[(int)npc.ai[1]].active || (Main.npc[(int)npc.ai[1]].type != headType && Main.npc[(int)npc.ai[1]].type != bodyType)))
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!tail && (!Main.npc[(int)npc.ai[0]].active || (Main.npc[(int)npc.ai[0]].type != bodyType && Main.npc[(int)npc.ai[0]].type != tailType)))
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }*/
                
                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
			}
            int tileLeft = (int)(npc.position.X / 16f) - 1;
            int tileRight = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
            int TileTop = (int)(npc.position.Y / 16f) - 1;
            int TileBottom = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
		
            #region clamp
            if (tileLeft < 0)
            {
                tileLeft = 0;
            }
            if (tileRight > Main.maxTilesX)
            {
                tileRight = Main.maxTilesX;
            }
            if (TileTop < 0)
            {
                TileTop = 0;
            }
            if (TileBottom > Main.maxTilesY)
            {
                TileBottom = Main.maxTilesY;
            }
            #endregion

            bool flying = this.flies;

            if (!flying)
            {   //if we don't fly, then we need to check to see if we're in tiles. We'll set our 'temporary' fly boolean to true if we are - so we dig through tiles, but not air.
                for (int tileX = tileLeft; tileX < tileRight; tileX++)
                {
                    for (int tileY = TileTop; tileY < TileBottom; tileY++)
                    {
                        if (Main.tile[tileX, tileY] != null && ((Main.tile[tileX, tileY].nactive() && (Main.tileSolid[Main.tile[tileX, tileY].type] || 
                            (Main.tileSolidTop[Main.tile[tileX, tileY].type] && Main.tile[tileX, tileY].frameY == 0))) || Main.tile[tileX, tileY].liquid > 64))
                        {
                            Vector2 tileWorldPos;
                            tileWorldPos.X = (float)(tileX * 16);
                            tileWorldPos.Y = (float)(tileY * 16);
                            if (npc.position.X + (float)npc.width > tileWorldPos.X && npc.position.X < tileWorldPos.X + 16f && npc.position.Y + (float)npc.height > tileWorldPos.Y && 
                                npc.position.Y < tileWorldPos.Y + 16f)
                            {
                                flying = true;

                                if (Main.rand.Next(100) == 0 && npc.behindTiles && Main.tile[tileX, tileY].nactive())
                                {
                                    WorldGen.KillTile(tileX, tileY, true, true, false);
                                }
                            }
                        }
                    }
                }
            }

            if (!flying && head)
            {   //check to see if the player is in a certain range. if they're not, set flying to true, so we path to them regardless of whether or not there are tiles to dig through.
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int rangeCheck = 1000;
                bool playerOutOfRange = true;

                playerOutOfRange = CheckInRange(rectangle, rangeCheck);
                
                if (playerOutOfRange)
                {
                    flying = true;
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

            float fSpeed = speed;
            float fTurnSpeed = turnSpeed;
            Vector2 center = npc.Center;

            Vector2 targetPosition = Vector2.Zero;
            if (targetsPlayer)
                targetPosition = Target.Center;
            else targetPosition = TargetPos; 

            targetPosition.X = (int)(targetPosition.X / 16f) * 16f;
            targetPosition.Y = (int)(targetPosition.Y / 16f) * 16f;
            center.X = (int)(center.X / 16f) * 16f;
            center.Y = (int)(center.Y / 16f) * 16f;

            targetPosition.X -= center.X;
            targetPosition.Y -= center.Y;

            float playerDistance = (float)Math.Sqrt((double)(targetPosition.X * targetPosition.X + targetPosition.Y * targetPosition.Y));

            if (!head)
            {
                try
                {
                    center = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    targetPosition.X = Main.npc[(int)FollowingIndex].position.X + (float)(Main.npc[(int)FollowingIndex].width / 2) - center.X;
                    targetPosition.Y = Main.npc[(int)FollowingIndex].position.Y + (float)(Main.npc[(int)FollowingIndex].height / 2) - center.Y;
                }
                catch
                {
                }

                npc.rotation = (float)Math.Atan2(targetPosition.Y, targetPosition.X) + 1.57f;

                playerDistance = (float)Math.Sqrt((double)(targetPosition.X * targetPosition.X + targetPosition.Y * targetPosition.Y));

                playerDistance = (playerDistance - npc.width) / playerDistance;

                targetPosition.X *= playerDistance;
                targetPosition.Y *= playerDistance;

                npc.velocity = Vector2.Zero;

                npc.position.X = npc.position.X + targetPosition.X;
                npc.position.Y = npc.position.Y + targetPosition.Y;

                if (directional)
                {
                    if (targetPosition.X < 0f)
                    {
                        npc.spriteDirection = 1;
                    }
                    if (targetPosition.X > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {   //we are the head. Perform changing direction and stuff here.
                if (!flying)
                {   //if we don't fly (i.e. we don't have flies set to true and we're not in tiles) we want to fall back down into tiles.   
                    npc.TargetClosest(true);

                    npc.velocity.Y = npc.velocity.Y + 0.11f;

                    if (npc.velocity.Y > fSpeed)
                    {
                        npc.velocity.Y = fSpeed;
                    }
                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < fSpeed * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - fTurnSpeed * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + fTurnSpeed * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == fSpeed)
                    {
                        if (npc.velocity.X < targetPosition.X)
                        {
                            npc.velocity.X = npc.velocity.X + fTurnSpeed;
                        }
                        else if (npc.velocity.X > targetPosition.X)
                        {
                            npc.velocity.X = npc.velocity.X - fTurnSpeed;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + fTurnSpeed * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - fTurnSpeed * 0.9f;
                        }
                    }
                }
                else
                {
                    if (!flies && npc.behindTiles && npc.soundDelay == 0)
                    {
                        float distanceDelay = playerDistance / 40f;
                        if (distanceDelay < 10f)
                        {
                            distanceDelay = 10f;
                        }
                        if (distanceDelay > 20f)
                        {
                            distanceDelay = 20f;
                        }
                        npc.soundDelay = (int)distanceDelay;
                        Main.PlaySound(SoundID.Roar, npc.position, 1);
                    }

                    playerDistance = (float)Math.Sqrt((double)(targetPosition.X * targetPosition.X + targetPosition.Y * targetPosition.Y));
                    float absPlayerCenterX = Math.Abs(targetPosition.X);
                    float absPlayerCenterY = Math.Abs(targetPosition.Y);
                    float num198 = fSpeed / playerDistance;

                    targetPosition.X *= num198;
                    targetPosition.Y *= num198;
                    if (ShouldRun())
                    {
                        if (Main.netMode != 1)
                        {
                            KillAllFollowers();
                        }
                        targetPosition.X = 0f;
                        targetPosition.Y = fSpeed;
                    }

                    if ((npc.velocity.X > 0f && targetPosition.X > 0f) || (npc.velocity.X < 0f && targetPosition.X < 0f) || (npc.velocity.Y > 0f && targetPosition.Y > 0f) || (npc.velocity.Y < 0f && targetPosition.Y < 0f))
                    {
                        if (turnsToTarget)
                        {
                            if (npc.velocity.X < targetPosition.X)
                            {
                                npc.velocity.X = npc.velocity.X + fTurnSpeed;
                            }
                            else
                            {
                                if (npc.velocity.X > targetPosition.X)
                                {
                                    npc.velocity.X = npc.velocity.X - fTurnSpeed;
                                }
                            }
                            if (npc.velocity.Y < targetPosition.Y)
                            {
                                npc.velocity.Y = npc.velocity.Y + fTurnSpeed;
                            }
                            else
                            {
                                if (npc.velocity.Y > targetPosition.Y)
                                {
                                    npc.velocity.Y = npc.velocity.Y - fTurnSpeed;
                                }
                            }
                            if ((double)System.Math.Abs(targetPosition.Y) < (double)fSpeed * 0.2 && ((npc.velocity.X > 0f && targetPosition.X < 0f) || (npc.velocity.X < 0f && targetPosition.X > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + fTurnSpeed * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - fTurnSpeed * 2f;
                                }
                            }
                            if ((double)System.Math.Abs(targetPosition.X) < (double)fSpeed * 0.2 && ((npc.velocity.Y > 0f && targetPosition.Y < 0f) || (npc.velocity.Y < 0f && targetPosition.Y > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + fTurnSpeed * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - fTurnSpeed * 2f;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (turnsToTarget)
                        {
                            if (absPlayerCenterX > absPlayerCenterY)
                            {
                                if (npc.velocity.X < targetPosition.X)
                                {
                                    npc.velocity.X = npc.velocity.X + fTurnSpeed * 1.1f;
                                }
                                else if (npc.velocity.X > targetPosition.X)
                                {
                                    npc.velocity.X = npc.velocity.X - fTurnSpeed * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)fSpeed * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y = npc.velocity.Y + fTurnSpeed;
                                    }
                                    else
                                    {
                                        npc.velocity.Y = npc.velocity.Y - fTurnSpeed;
                                    }
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < targetPosition.Y)
                                {
                                    npc.velocity.Y = npc.velocity.Y + fTurnSpeed * 1.1f;
                                }
                                else if (npc.velocity.Y > targetPosition.Y)
                                {
                                    npc.velocity.Y = npc.velocity.Y - fTurnSpeed * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)fSpeed * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X = npc.velocity.X + fTurnSpeed;
                                    }
                                    else
                                    {
                                        npc.velocity.X = npc.velocity.X - fTurnSpeed;
                                    }
                                }
                            }
                        }
                    }
                }

                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;

                if (head)
                {
                    if (flying)
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
            CustomAI();
        }

        /// <summary>
        /// Loops through all the players and checks to see if they're within a rectangle.
        /// </summary>
        /// <returns>Returns true if there are no players nearby.</returns>
        protected virtual bool CheckInRange(Rectangle npcRect, int rangeCheck)
        {
            for (int playerIndex = 0; playerIndex < 255; playerIndex++)
            {
                if (Main.player[playerIndex].active)
                {
                    Rectangle rectangle2 = new Rectangle((int)Main.player[playerIndex].position.X - rangeCheck, (int)Main.player[playerIndex].position.Y - rangeCheck, rangeCheck * 2, rangeCheck * 2);
                    if (npcRect.Intersects(rectangle2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected virtual void KillAllFollowers()
        {
            npc.active = false;
            int follower = (int)FollowerIndex;
            while (follower > 0 && follower < 200 && Main.npc[follower].active && Main.npc[follower].aiStyle == npc.aiStyle)
            {
                int num201 = (int)Main.npc[follower].ai[0];
                Main.npc[follower].active = false;
                npc.life = 0;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(23, -1, -1, null, follower, 0f, 0f, 0f, 0, 0, 0);
                }
                follower = num201;
            }
            if (Main.netMode == 2)
            {
                NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
            }
        }
        

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DragonSpirit"));
        }

        public virtual void Init()
		{

		}

		public virtual bool ShouldRun()
		{
			return false;
		}

		public virtual void CustomBehavior()
		{
		}

        public virtual void CustomAI()
        {
        }

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return head ? (bool?)null : false;
		}
	}
}