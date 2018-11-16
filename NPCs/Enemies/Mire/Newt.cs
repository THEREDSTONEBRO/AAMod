using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AAMod.NPCs.Enemies.Mire
{
    public class Newt : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Newt");
            Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
        {
            npc.width = 112;
            npc.height = 30;
            npc.damage = 10;
			npc.defense = 10;
			npc.lifeMax = 200;
            npc.damage = 45;
            npc.defense = 14;
            npc.lifeMax = 210;
            npc.knockBackResist = 0.55f;
            npc.value = 100f;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return spawnInfo.player.GetModPlayer<AAPlayer>(mod).ZoneInferno && !Main.dayTime ? .1f : 0f;
        }

        public override void AI()
        {
            bool flag19 = true;
            if (npc.confused)
            {
                npc.ai[2] = 0f;
            }
            else
            {
                if (npc.ai[1] > 0f)
                {
                    npc.ai[1] -= 1f;
                }
                if (npc.justHit)
                {
                    npc.ai[1] = 30f;
                    npc.ai[2] = 0f;
                }
                int num144 = 70;
                int num145 = num144 / 2;
                if (npc.type == 424)
                {
                    num145 = num144 - 1;
                }
                if (npc.type == 426)
                {
                    num145 = num144 - 1;
                }
                if (npc.ai[2] > 0f)
                {
                    if (flag19)
                    {
                        npc.TargetClosest(true);
                    }
                    if (npc.ai[1] == (float)num145)
                    {
                        float num146 = 11f;
                        Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num147 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - value9.X;
                        float num148 = Math.Abs(num147) * 0.1f;
                        float num149 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - value9.Y - num148;
                        float num150 = (float)Math.Sqrt((double)(num147 * num147 + num149 * num149));
                        npc.netUpdate = true;
                        num150 = num146 / num150;
                        num147 *= num150;
                        num149 *= num150;
                        int num151 = 35;
                        int num152 = mod.ProjectileType("AcidProj");
                        value9.X += num147;
                        value9.Y += num149;
                        if (Main.netMode != 1)
                        {
                            Projectile.NewProjectile(value9.X, value9.Y, num147, num149, num152, num151, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (Math.Abs(num149) > Math.Abs(num147) * 2f)
                        {
                            if (num149 > 0f)
                            {
                                npc.ai[2] = 1f;
                            }
                            else
                            {
                                npc.ai[2] = 5f;
                            }
                        }
                        else if (Math.Abs(num147) > Math.Abs(num149) * 2f)
                        {
                            npc.ai[2] = 3f;
                        }
                        else if (num149 > 0f)
                        {
                            npc.ai[2] = 2f;
                        }
                        else
                        {
                            npc.ai[2] = 4f;
                        }
                    }
                }
                
                else if ((npc.ai[2] <= 0f) && (npc.velocity.Y == 0f) && npc.ai[1] <= 0f && !Main.player[npc.target].dead)
                {
                    bool flag21 = Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height);
                    if (Main.player[npc.target].stealth == 0f && Main.player[npc.target].itemAnimation == 0)
                    {
                        flag21 = false;
                    }
                    if (flag21)
                    {
                        float num156 = 10f;
                        Vector2 vector20 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num157 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector20.X;
                        float num158 = Math.Abs(num157) * 0.1f;
                        float num159 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector20.Y - num158;
                        num157 += (float)Main.rand.Next(-40, 41);
                        num159 += (float)Main.rand.Next(-40, 41);
                        float num160 = (float)Math.Sqrt((double)(num157 * num157 + num159 * num159));
                        float num161 = 700f;
                        if (num160 < num161)
                        {
                            npc.netUpdate = true;
                            npc.velocity.X = npc.velocity.X * 0.5f;
                            num160 = num156 / num160;
                            num157 *= num160;
                            num159 *= num160;
                            npc.ai[2] = 3f;
                            npc.ai[1] = (float)num144;
                            if (Math.Abs(num159) > Math.Abs(num157) * 2f)
                            {
                                if (num159 > 0f)
                                {
                                    npc.ai[2] = 1f;
                                }
                                else
                                {
                                    npc.ai[2] = 5f;
                                }
                            }
                            else if (Math.Abs(num157) > Math.Abs(num159) * 2f)
                            {
                                npc.ai[2] = 3f;
                            }
                            else if (num159 > 0f)
                            {
                                npc.ai[2] = 2f;
                            }
                            else
                            {
                                npc.ai[2] = 4f;
                            }
                        }
                    }
                }
                if (npc.ai[2] <= 0f)
                {
                    float num162 = 1f;
                    float num163 = 0.07f;
                    float scaleFactor6 = 0.8f;
                    bool flag22 = false;
                    if (npc.velocity.X < -num162 || npc.velocity.X > num162 || flag22)
                    {
                        if (npc.velocity.Y == 0f)
                        {
                            npc.velocity *= scaleFactor6;
                        }
                    }
                    else if (npc.velocity.X < num162 && npc.direction == 1)
                    {
                        npc.velocity.X = npc.velocity.X + num163;
                        if (npc.velocity.X > num162)
                        {
                            npc.velocity.X = num162;
                        }
                    }
                    else if (npc.velocity.X > -num162 && npc.direction == -1)
                    {
                        npc.velocity.X = npc.velocity.X - num163;
                        if (npc.velocity.X < -num162)
                        {
                            npc.velocity.X = -num162;
                        }
                    }
                }
            }
        }
	}
}