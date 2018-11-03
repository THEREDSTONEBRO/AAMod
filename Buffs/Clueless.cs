using Terraria;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
	public class Clueless : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fog");
			Description.SetDefault("Can't see a thing");
			Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            if (player.GetModPlayer<AAPlayer>(mod).ZoneMire && Main.dayTime)
            {
                player.buffTime[buffIndex] = 5;
            }
		}
	}
}