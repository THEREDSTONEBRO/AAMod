using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Walls
{
	public class TorchstoneWall : ModWall
	{
		public override void SetDefaults()
		{
            dustType = mod.DustType("IncineriteDust");
			AddMapEntry(new Color(50, 150, 0));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}