﻿using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Void
{
    public class VoidSkyData : ScreenShaderData
    {
        private int DataIndex;

        public VoidSkyData(string passName) : base(passName)
        {
        }

        private void UpdateVoidSky()
        {
            AAPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<AAPlayer>();
            if (AAWorld.voidTiles < 100)
            {
                return;
            }
            DataIndex = -1;
        }

        public override void Apply()
        {
            UpdateVoidSky();
            base.Apply();
        }
    }
}