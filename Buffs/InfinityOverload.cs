using Terraria;
using Terraria.ModLoader;
using AAMod.Items.Accessories;
using AAMod.NPCs;

namespace AAMod.Buffs
{
	public class InfinityOverload : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Infinity Overload");
			Description.SetDefault("The infinity stone in your hand is too powerful for you");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AAPlayer>(mod).infinityOverload = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<AAModGlobalNPC>(mod).infinityOverload = true;
		}
	}
}
