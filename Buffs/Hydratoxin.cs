using Terraria;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
	public class HydraToxin : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hydra Toxin");
			Description.SetDefault("Slower movement per Tile");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            foreach (Tile tile in Main.tile)
            {
                if (tile.collisionType == player.whoAmI)
                {
                    player.moveSpeed = (player.moveSpeed / 16) * 15;
                }
            }
        }

		public override void Update(NPC npc, ref int buffIndex)
		{
            foreach (Tile tile in Main.tile)
            {
                if (tile.collisionType == npc.whoAmI)
                {
                    npc.velocity.X = (npc.velocity.X / 16) * 15;
                    npc.velocity.Y = (npc.velocity.Y / 16) * 15;
                }
            }
		}
	}
}
