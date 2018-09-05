using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Buffs
{
    public class UnstableSoul : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Unstable Soul");
			Description.SetDefault("You are now etheral \n" + "You have more invincibility frames, but less defense");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.longInvince = true;
            player.statDefense -= 10;
            player.armorEffectDrawShadowLokis = true;
		}
	}
}
