using Terraria;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Mire
{
    class MireUgBgStyle : ModUgBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return Main.LocalPlayer.GetModPlayer<AAPlayer>(mod).ZoneMire;
        }

        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/Mire/MireUnderground");
        }
    }
}
