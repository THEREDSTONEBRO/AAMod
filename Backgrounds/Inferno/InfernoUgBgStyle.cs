using Terraria;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Inferno
{
    class InfernoUgBgStyle : ModUgBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return Main.LocalPlayer.GetModPlayer<AAPlayer>(mod).ZoneInferno;
        }

        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/Inferno/InfernoUnderground");
        }
    }
}
