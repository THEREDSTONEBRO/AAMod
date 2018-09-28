using AAMod.Items.Dev;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
	public class Chairless : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("You are Chairless");
			Description.SetDefault("a Crab Stole it!!");
            Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AAPlayer modPlayer = player.GetModPlayer<AAPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("ChairMinion")] > 0)
            {
                player.ownedProjectileCounts[mod.ProjectileType("ChairMinion")] = 0;
            }
            if (NPC.AnyNPCs(NPCID.DungeonGuardian))
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
	}
}