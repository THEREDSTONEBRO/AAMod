using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;

namespace AAMod.NPCs.Enemies.Mire
{
	public class ChaoticTwilight : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaotic Twilight");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[83];
		}

		public override void SetDefaults()
        {
            npc.width = 74;
            npc.height = 76;
            npc.damage = 90;
			npc.defense = 10;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 240000f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 23;
            animationType = 475;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
			{
                int[] TileArray2 = { mod.TileType("MireGrass"), mod.TileType("Depthstone") };

                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && spawnInfo.spawnTileY > (Main.rockLayer) ? 0.1f : 0f;
                
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{

            int dust1 = mod.DustType<Dusts.MireBubbleDust>();
            if (npc.life <= 0)
			{
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
                Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, dust1, 0f, 0f, 0, default(Color), 1f);
            }
		}

		public override void NPCLoot()
		{
		    //empty for desired loots
		}
	}
}