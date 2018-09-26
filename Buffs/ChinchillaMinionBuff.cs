using Terraria;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
	public class ChinchillaMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Chinchilla Friend");
			Description.SetDefault("Extra Fluffy!!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AAPlayer modPlayer = player.GetModPlayer<AAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("ChinchillaMinion")] > 0)
			{
				modPlayer.ChinchillaMinion = true;
			}
			if (!modPlayer.ChinchillaMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}