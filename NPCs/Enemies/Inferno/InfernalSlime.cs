using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs.Enemies.Inferno
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class InfernalSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("InfernalSlime");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
		}

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.BlueSlime);
			npc.width = 32;
			npc.height = 26;
			npc.damage = 14;
			npc.defense = 2;
			npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.BlueSlime;
			animationType = NPCID.BlueSlime;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {
                int[] TileArray2 = { mod.TileType("InfernoGrassTile"), mod.TileType("TorchstoneTile") };
                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) ? 6.09f : 0f;
            }
            return 0f;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zero/InfernalSlime_Glow"), new Vector2(npc.Center.X - Main.screenPosition.X, npc.Center.Y - Main.screenPosition.Y),
            npc.frame, Color.White, npc.rotation,
            new Vector2(npc.width * 0.5f, npc.height * 0.5f), 1f, spriteEffects, 0f);
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.IncineriteDust>(), 0f, 0f, 200, default(Color), 0.8f);
                Main.dust[dustIndex].velocity *= 0.3f;
			}
		}
	}
}
