using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Tiles
{
    class RazewoodTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("Razewood");   //put your CustomBlock name
            AddMapEntry(new Color(20f, 20f, 20f));
            minPick = 65;
            dustType = mod.DustType("RazewoodDust");
        }
    }
}
