using AAMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
    public class BurningAsh : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burning Ash");
			Description.SetDefault("Ash is melting your skin");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
            if (player.GetModPlayer<AAPlayer>(mod).ZoneInferno)
            {
                player.buffTime[buffIndex] = 5;
            }
            player.lifeRegenTime = 1;
            player.lifeRegen -= 22;
		}
	}
}