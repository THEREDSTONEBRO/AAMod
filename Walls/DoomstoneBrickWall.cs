using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Walls
{
	public class DoomstoneBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			dustType = mod.DustType("DoomDust");
			AddMapEntry(new Color(10, 10, 10));
            soundType = 21;
            drop = mod.ItemType("DoomstoneBrickWall");
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}