using System.Collections.Generic;
using System.Linq;
using AAMod.Buffs;
using AAMod.NPCs.Enemies.Void;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.NPCs
{
	public class AAModGlobalNPC : GlobalNPC
	{
        public bool TimeFrozen;
        public bool infinityOverload;

		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override void ResetEffects(NPC npc)
		{
            infinityOverload = false;
		}

		public override void SetDefaults(NPC npc)
		{
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{

            int before = npc.lifeRegen;
            bool drain = false;
            bool noDamage = damage <= 1;
            int damageBefore = damage;

            if (infinityOverload)
            {
                drain = true;
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 60;
                if (damage < 40)
                {
                    damage = 40;
                }
            }
            if (noDamage)
                damage -= damageBefore;
            if (drain && before > 0)
                npc.lifeRegen -= before;
        }

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.FireImp)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilSilk"), Main.rand.Next(2, 3));
            }
            if (npc.type == NPCID.Demon)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilSilk"), Main.rand.Next(4, 5));
            }
            if (npc.type == NPCID.VoodooDemon)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DevilSilk"), Main.rand.Next(5, 6));
            }
            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlanteraPetal"), Main.rand.Next(30, 40));
            }
            if (npc.type == NPCID.GreekSkeleton)
            {
                if (Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GladiatorsGlory"));
                }
            }

            if (Main.rand.Next(4096) == 0)   //item rarity
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShinyCharm")); //Item spawn
            }

            if (NPC.downedMoonlord == true)
            {
                if (npc.type == NPCID.GoblinSummoner)   //this is where you choose the npc you want
                {
                    if (Main.rand.Next(4) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
                    {
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GoblinDoll"), 1);
                        }
                    }
                }
            }
            if (NPC.downedPlantBoss == true)
            {
                if (npc.type == NPCID.RedDevil)   //this is where you choose the npc you want
                {
                    if (Main.rand.Next(4) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
                    {
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PureEvil"), 1);
                        }
                    }
                }
            }
            if (npc.type == NPCID.EyeofCthulhu)   //this is where you choose the npc you want
            {
                if (Main.rand.Next(4) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CthulhusBlade"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
                    }
                }
            }
            if (npc.type == NPCID.GiantFlyingFox)   //this is where you choose the npc you want
            {
                if (Main.rand.Next(4) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
                {
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheFox"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
                    }
                }
            }
            if (npc.type == NPCID.Necromancer)
            {
                if (Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Exorcist"));
                }
            }
            if (npc.type == NPCID.AngryBones ||
                npc.type == NPCID.AngryBonesBig ||
                npc.type == NPCID.AngryBonesBigHelmet ||
                npc.type == NPCID.AngryBonesBigMuscle)
            {
                if (Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientPoker"));
                }
            }
        }

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
		}

        

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.GetModPlayer<AAPlayer>().ZoneVoid) //modded npc's need to be removed manually
            {
                if (pool.ContainsKey(NPCID.Harpy))
                {
                    pool.Remove(NPCID.Harpy);
                }
                if (pool.ContainsKey(NPCID.MartianProbe))
                {
                    pool.Remove(NPCID.MartianProbe);
                }
                if (pool.ContainsKey(NPCID.WyvernHead))
                {
                    pool.Remove(NPCID.WyvernHead);
                }
            }
            else if (spawnInfo.player.ZoneSkyHeight)
            {
                if (!pool.ContainsKey(NPCID.Harpy))
                {
                    pool.Add(NPCID.Harpy, 600); //please change 600 to spawnrate
                }
                if (!pool.ContainsKey(NPCID.MartianProbe) && NPC.downedGolemBoss)
                {
                    pool.Add(NPCID.MartianProbe, 600); //please change 600 to spawnrate
                }
                if (!pool.ContainsKey(NPCID.WyvernHead) && Main.hardMode)
                {
                    pool.Add(NPCID.WyvernHead, 600); //please change 600 to spawnrate
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
		}

        public override bool PreAI(NPC npc)
        {
            if (!npc.boss ||
                npc.type != NPCID.WallofFlesh ||
                npc.type != NPCID.SkeletronHand ||
                npc.type != NPCID.DungeonGuardian ||
                npc.type != NPCID.WallofFlesh ||
                npc.type != NPCID.WallofFleshEye ||
                npc.type != NPCID.PrimeCannon ||
                npc.type != NPCID.PrimeLaser ||
                npc.type != NPCID.PrimeSaw ||
                npc.type != NPCID.PrimeVice ||
                npc.type != NPCID.EaterofWorldsBody ||
                npc.type != NPCID.EaterofWorldsTail ||
                npc.type != NPCID.EaterofWorldsHead ||
                npc.type != NPCID.TheDestroyerBody ||
                npc.type != NPCID.TheDestroyerTail ||
                npc.type != NPCID.GolemFistLeft ||
                npc.type != NPCID.GolemFistRight ||
                npc.type != NPCID.GolemHead ||
                npc.type != NPCID.GolemHeadFree ||
                npc.type != NPCID.PlanterasHook ||
                npc.type != NPCID.PlanterasTentacle ||
                npc.type != NPCID.Creeper ||
                npc.type != NPCID.PumpkingBlade ||
                npc.type != NPCID.MartianSaucerCannon ||
                npc.type != NPCID.MartianSaucerCore ||
                npc.type != NPCID.MartianSaucerTurret ||
                npc.type != NPCID.MoonLordCore ||
                npc.type != NPCID.MoonLordFreeEye ||
                npc.type != NPCID.MoonLordHand ||
                npc.type != NPCID.MoonLordHead ||
                npc.type != NPCID.MoonLordLeechBlob ||
                npc.type != NPCID.AncientCultistSquidhead ||
                npc.type != NPCID.CultistBossClone ||
                npc.type != NPCID.CultistDragonBody1 ||
                npc.type != NPCID.CultistDragonBody2 ||
                npc.type != NPCID.CultistDragonBody3 ||
                npc.type != NPCID.CultistDragonBody4 ||
                npc.type != NPCID.CultistDragonHead ||
                npc.type != NPCID.CultistDragonTail ||
                npc.type != NPCID.CultistTablet ||
                npc.type != NPCID.MothronEgg ||
                npc.type != NPCID.MothronSpawn ||
                npc.type != NPCID.Mothron ||
                npc.type != NPCID.PirateShipCannon ||
                npc.type != NPCID.LunarTowerSolar ||
                npc.type != NPCID.LunarTowerNebula ||
                npc.type != NPCID.LunarTowerVortex ||
                npc.type != NPCID.LunarTowerStardust ||
                npc.type != NPCID.AncientLight ||
                npc.type != NPCID.AncientDoom ||
                npc.type != NPCID.SandElemental ||
                npc.type != NPCID.DD2EterniaCrystal ||
                npc.type != NPCID.DD2AttackerTest ||
                npc.type != NPCID.DD2Betsy ||
                npc.type != NPCID.DD2DarkMageT1 ||
                npc.type != NPCID.DD2DarkMageT3 ||
                npc.type != NPCID.DD2DrakinT2 ||
                npc.type != NPCID.DD2DrakinT3 ||
                npc.type != NPCID.DD2GoblinBomberT1 ||
                npc.type != NPCID.DD2GoblinBomberT2 ||
                npc.type != NPCID.DD2GoblinBomberT3 ||
                npc.type != NPCID.DD2GoblinT1 ||
                npc.type != NPCID.DD2GoblinT2 ||
                npc.type != NPCID.DD2GoblinT3 ||
                npc.type != NPCID.DD2JavelinstT1 ||
                npc.type != NPCID.DD2JavelinstT2 ||
                npc.type != NPCID.DD2JavelinstT3 ||
                npc.type != NPCID.DD2KoboldFlyerT2 ||
                npc.type != NPCID.DD2KoboldFlyerT3 ||
                npc.type != NPCID.DD2KoboldWalkerT2 ||
                npc.type != NPCID.DD2KoboldWalkerT3 ||
                npc.type != NPCID.DD2LanePortal ||
                npc.type != NPCID.DD2LightningBugT3 ||
                npc.type != NPCID.DD2OgreT2 ||
                npc.type != NPCID.DD2OgreT3 ||
                npc.type != NPCID.DD2SkeletonT1 ||
                npc.type != NPCID.DD2SkeletonT3 ||
                npc.type != NPCID.DD2WitherBeastT2 ||
                npc.type != NPCID.DD2WitherBeastT3 ||
                npc.type != NPCID.DD2WyvernT1 ||
                npc.type != NPCID.DD2WyvernT2 ||
                npc.type != NPCID.DD2WyvernT3 ||
                npc.type != NPCID.ShadowFlameApparition)
            {
                if (TimeFrozen)
                {
                    npc.position = npc.oldPosition;
                    npc.frameCounter--;
                    return false;
                }
            }
            return true;
        }
        
    }
    public class Harpy : GlobalNPC
    {

        public float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {
                int[] TileArray2 = { mod.TileType("Doomstone"), mod.TileType("Apocalyptite"), mod.TileType("DoomstoneBrick") };
                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) ? 0f : 0f;
            }
            return 0f;
        }
    }
    public class Wyvern : GlobalNPC
    {
        public float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {
                int[] TileArray2 = { mod.TileType("Doomstone"), mod.TileType("Apocalyptite"), mod.TileType("DoomstoneBrick") };
                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) ? 0f : 0f;
            }
            return 0f;
        }
    }
    public class MartianProbe : GlobalNPC
    {
        public float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime) && (SpawnCondition.GoblinArmy.Chance == 0))
            {
                int[] TileArray2 = { mod.TileType("Doomstone"), mod.TileType("Apocalyptite"), mod.TileType("DoomstoneBrick") };
                return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) ? 0f : 0f;
            }
            return 0f;
        }
    }
}
