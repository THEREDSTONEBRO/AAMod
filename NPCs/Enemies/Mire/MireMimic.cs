using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;

namespace AAMod.NPCs.Enemies.Mire
{
	public class MireMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mire Mimic");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[475];
		}

		public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 42;
            npc.damage = 50;
			npc.defense = 8;
			npc.lifeMax = 3500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 240000f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 87;
            aiType = NPCID.Zombie;
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
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, Vector2.Zero, 13);
				Gore.NewGore(npc.position, Vector2.Zero, 12);
				Gore.NewGore(npc.position, Vector2.Zero, 11);
			}
		}

		public override void NPCLoot()
		{
			string[] lootTable = { "BotchedBand" };
			int loot = Main.rand.Next(lootTable.Length);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
		}
	}
}