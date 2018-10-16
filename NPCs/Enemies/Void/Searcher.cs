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
            npc.aiStyle = 5;
			npc.width = 30;
			npc.height = 30;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.chaseable = false;
			npc.damage = 30;
			npc.defense = 20;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {

                if (player.GetModPlayer<AAPlayer>().ZoneVoid)
                {
                    int[] TileArray2 = { mod.TileType("Voidstone") };
                    return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && NPC.downedMoonlord ? 6.09f : 3.21f;
                }

                int[] TileArray2 = { mod.TileType("Doomstone"), mod.TileType("Apocalyptite"), mod.TileType("DoomstoneBrick") };
                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && NPC.downedMoonlord ? 6.09f : 0f;

            }
            return 0f;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Apocalyptite"), 1);
        }
    }
}