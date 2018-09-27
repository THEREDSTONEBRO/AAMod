using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Enemies.Void
{
	public class Searcher : ModNPC
	{
		public int timer = 0;
		public bool start = true;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Searcher");
            Main.npcFrameCount[npc.type] = 5;
        }
		
		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.Probe);
			npc.width = 30;
			npc.height = 30;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.chaseable = false;
			npc.damage = 50;
			npc.defense = 20;
			npc.lifeMax = 6000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {
                int[] TileArray2 = { mod.TileType("Voidstone") };
                return SpawnCondition.Sky.Chance * 0.12f;
            }
            return 0f;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UnstableSingularity"), Main.rand.Next(1) + 2);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Apocalyptite"), Main.rand.Next(1) + 6);
        }
    }
}