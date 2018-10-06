using Terraria;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Mire
{
	public class MireUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return !Main.gameMenu && Main.player[Main.myPlayer].GetModPlayer<AAPlayer>(mod).ZoneMire;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/Mire/MireUnderground1");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/Mire/MireUnderground");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/Mire/MireCavern1");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/Mire/MireCavern");
		}
	}
}