using Terraria;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Inferno
{
    public class InfernoUgBgStyle : ModUgBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return !Main.gameMenu && Main.player[Main.myPlayer].GetModPlayer<AAPlayer>(mod).ZoneInferno;
        }

        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/Mire/InfernoUnderground1");
            textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/Mire/InfernoUnderground");
            textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/Mire/InfernoCavern1");
            textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/Mire/InfernoCavern");
        }
    }
}
