using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AAMod.Tiles
{
    public class HaphestusForge : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            dustType = mod.DustType("RazeleafDust");
            name.SetDefault("Hephaestus Forge");
            AddMapEntry(new Color(200, 150, 0), name);
            disableSmartCursor = true;
            adjTiles = new int[]
            { TileID.WorkBenches,
              TileID.Hellforge,
              TileID.Furnaces,
              TileID.TinkerersWorkbench,
              TileID.AlchemyTable,
              TileID.Bottles,
              TileID.MythrilAnvil,
              TileID.Tables,
              TileID.DemonAltar,
              TileID.Chairs,
              TileID.Anvils,
              mod.TileType("HellstoneAnvilTile")
              };
            animationFrameHeight = 38;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.50f;
            g = 0.40f;
            b = 0.0f;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.Hellforge];
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("HaphestusForge"));
        }
    }
}