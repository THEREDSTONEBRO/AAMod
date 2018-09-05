using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Tiles
{
    public class DynaskullOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            //true for block to emit light
            soundType = 21;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("DynaskullOre");
            AddMapEntry(new Color(100, 100, 0));
			minPick = 65;
        }

        

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = .250f;
            g = .125f;
            b = 0f;
        }
    }
}