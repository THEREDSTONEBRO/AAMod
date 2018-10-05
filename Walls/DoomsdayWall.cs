using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.Walls
{
	public class DoomsdayWall : ModWall
	{
		public override void SetDefaults()
		{
			dustType = mod.DustType("DoomDust");
			AddMapEntry(new Color(30, 30, 30));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}