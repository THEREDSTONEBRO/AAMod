using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Tiles
{
    public class Darkmud : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("Darkmud");
            AddMapEntry(new Color(0, 0, 33));
        }
    }
}