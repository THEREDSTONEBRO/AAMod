﻿using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace AAMod.Backgrounds.Mire
{
    public class MireSkyData : ScreenShaderData
    {
        private int DataIndex;

        public MireSkyData(string passName) : base(passName)
        {
        }

        private void UpdateMireSky()
        {
            AAPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<AAPlayer>();
            if (AAWorld.mireTiles < 100)
            {
                return;
            }
            DataIndex = -1;
        }

        public override void Apply()
        {
            UpdateMireSky();
            base.Apply();
        }
    }
}