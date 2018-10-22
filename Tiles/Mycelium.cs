using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Tiles
{
    public class Mycelium : ModTile
	{
		public static int _type;

		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			SetModTree(new BogwoodTree());
            Main.tileMergeDirt[Type] = true;
			Main.tileBlendAll[this.Type] = true;
            drop = mod.ItemType("Mycelium");
			AddMapEntry(new Color(120, 60, 0));
		}

		public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
		{
            TileObject toBePlaced;
            if (!TileObject.CanPlace(x, y, type, style, direction, out toBePlaced, false))
            {
                return false;
            }
            toBePlaced.random = random;
			if (TileObject.Place(toBePlaced) && !mute)
			{
				WorldGen.SquareTileFrame(x, y, true);
				//   Main.PlaySound(0, x * 16, y * 16, 1, 1f, 0f);
			}
			return false;
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("MushroomTree");
		}
	}
}