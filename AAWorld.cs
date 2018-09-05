using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using System.Reflection;
using Terraria.Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using AAMod.Tiles;


namespace AAMod
{
    public class AAWorld : ModWorld
    {
        public static int mireTiles = 0;
        public static int infernoTiles = 0;
        public static int voidTiles = 0;
        //Worldgen
        public static bool Luminite;
        public static bool DarkMatter;
        public static bool FulguriteOre;
        public static bool HallowedOre;
        public static bool Dynaskull;
        public static bool ChaosOres;
        public static bool RadiumOre;
        //Messages
        public static bool Evil;
        //Boss Bools
        public static bool downedGripRed;
        public static bool downedGripBlue;
        public static bool downedGrips;
        public static bool downedRetriever;
        public static bool zeroUS;
        public static bool downedZero;
        List<Point> posIslands;

        public override void Initialize()
        {
            downedGrips = false;
            downedGripRed = false;
            downedGripBlue = false;
            zeroUS = false;
            downedZero = false;
            downedRetriever = false;
            if (NPC.downedMechBoss3 == true || NPC.downedMechBoss2 == true || NPC.downedMechBoss1 == true)
            {
                HallowedOre = true;
            }
            else
            {
                HallowedOre = false;
            }
            if (NPC.downedMoonlord == true)
            {
                Luminite = true;
            }
            else
            {
                Luminite = false;
            }
            if (NPC.downedMoonlord == true)
            {
                DarkMatter = true;
                RadiumOre = true;
            }
            else
            {
                DarkMatter = false;
                RadiumOre = false;
            }
            if (NPC.downedPlantBoss == true)
            {
                Evil = true;
            }
            else
            {
                Evil = false;
            }
            if (downedGripRed == true || downedGripBlue == true)
            {
                downedGrips = true;
            }
            else
            {
                downedGrips = false;
            }
            if (downedGrips == true)
            {
                ChaosOres = true;
            }
            else
            {
                ChaosOres = false;
            }
            if (NPC.downedBoss3 == true)
            {
                Dynaskull = true;
            }
            else
            {
                Dynaskull = false;
            }
            if (downedRetriever == true)
            {
                FulguriteOre = true;
            }
            else
            {
                FulguriteOre = false;
            }
        }

        public static int Raycast(int x, int y)
        {
            while (!TileValid(x, y))
                y++;
            return y;
        }

        public static bool TileValid(int i, int j)
        {
            bool valid = false;
            try
            {
                valid = Main.tile[i, j].active() && Main.tileSolid[Main.tile[i, j].type];
            }
            catch (Exception e)
            {
                ErrorLogger.Log(e.ToString() + "\n" + i + " " + j);
            }
            return valid;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedGripRed) downed.Add("GripRed");
            if (downedGripBlue) downed.Add("GripBlue");
            if (NPC.downedMoonlord) downed.Add("MoonLord");
            if (NPC.downedMechBossAny) downed.Add("MechBoss");
            if (NPC.downedPlantBoss) downed.Add("Evil");
            if (NPC.downedBoss3) downed.Add("Dynaskull");
            if (downedGrips) downed.Add("Grips");
            if (downedRetriever) downed.Add("Storm1");
            if (zeroUS) downed.Add("0U");
            if (downedZero) downed.Add("0");

            return new TagCompound {
                {"downed", downed}
            };
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedGripRed;
            flags[1] = downedGripBlue;
            flags[2] = NPC.downedMoonlord;
            flags[3] = NPC.downedMechBossAny;
            flags[4] = NPC.downedPlantBoss;
            flags[5] = NPC.downedBoss3;
            flags[6] = downedGrips;
            flags[7] = downedRetriever;
            writer.Write(flags);

            BitsByte flags2 = new BitsByte();
            flags2[0] = zeroUS;
            flags2[1] = downedZero;
            writer.Write(flags2);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedGripRed = flags[0];
            downedGripBlue = flags[1];
            NPC.downedMoonlord = flags[2];
            NPC.downedMechBossAny = flags[3];
            NPC.downedPlantBoss = flags[4];
            NPC.downedBoss3 = flags[5];
            downedGrips = flags[6];
            downedRetriever = flags[7];

            BitsByte flags2 = reader.ReadByte();
            zeroUS = flags2[0];
            downedZero = flags2[1];
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedGripRed = downed.Contains("GripRed");
            downedGripBlue = downed.Contains("GripBlue");
            NPC.downedMoonlord = downed.Contains("MoonLord");
            NPC.downedMechBossAny = downed.Contains("MechBoss");
            NPC.downedPlantBoss = downed.Contains("Evil");
            NPC.downedBoss3 = downed.Contains("Dynaskull");
            downedGrips = downed.Contains("Grips");
            downedRetriever = downed.Contains("Storm1");
            zeroUS = downed.Contains("0U");
            downedZero = downed.Contains("0");
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Stalac"));
            if (shiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(shiniesIndex + 8, new PassLegacy("000000000", VoidIslands));
        }

        public void VoidIslands(GenerationProgress progress) //method line
        {
            int VoidHeight = 0;
            if (Main.maxTilesY < 2700)
            {
                VoidHeight = 120;
            }
            if (Main.maxTilesY < 3600)
            {
                VoidHeight = 120;
            }
            if (Main.maxTilesY > 3600)
            {
                VoidHeight = 120;
            }
            Point center = new Point((Main.maxTilesX / 15 * 14) + (Main.maxTilesX / 15 / 2), center.Y = VoidHeight);
            Point oldposition = new Point(1, 1);
            List<Point> posIslands = new List<Point>();
            for (int i = 0; i < Main.maxTilesX / 1400; ++i)
            {
                Point position = new Point(
                    center.X + (WorldGen.genRand.Next(35, 55) * (WorldGen.genRand.NextBool() ? -1 : 1)),
                    center.Y + (WorldGen.genRand.Next(35, 55) * (WorldGen.genRand.NextBool() ? -1 : 1)));

                while (posIslands.Any(x => Vector2.Distance(x.ToVector2(), position.ToVector2()) < 20))
                {
                    for (int k = 0; k < posIslands.Count; ++k)
                    {
                        while ((int)Vector2.Distance(posIslands[k].ToVector2(), position.ToVector2()) < 20)
                        {
                            position = new Point(center.X + (WorldGen.genRand.Next(45, 55) * (WorldGen.genRand.NextBool() ? -1 : 1)),
                              center.Y + (WorldGen.genRand.Next(45, 55) * (WorldGen.genRand.NextBool() ? -1 : 1)));
                        }
                    }
                }
                MiniIsland(position, 60);
                posIslands.Add(position);
                oldposition = position;
                for (int k = 0; k < posIslands.Count; ++k)
                {
                    for (int FuckWorldGen = 0; FuckWorldGen < 6; ++FuckWorldGen)
                    {
                        Point randompoint = new Point(
                            posIslands[k].X + WorldGen.genRand.Next(-30, 31),
                            posIslands[k].Y + WorldGen.genRand.Next(7, 42));
                        WorldGen.TileRunner(randompoint.X, randompoint.Y, (double)WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(6, 13), mod.TileType("Apocalyptite"), false, 0f, 0f, false, true);
                    }
                }
            }
            
            for (int j = 0; j < posIslands.Count; ++j)
            {
                Point position = posIslands[j];
                position.X -= 4;
                position.Y -= 11;
                VoidHouses(position.X, position.Y, (ushort)mod.TileType("DoomstoneBrick"), 10, 7);
            }
        }
        public int BlockLining(double x, double y, int repeats, int tileType, bool random, int max, int min = 3)
        {
            for (double i = x; i < x + repeats; i++)
            {
                if (random)
                {
                    for (double k = y; k < y + Main.rand.Next(min, max); k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
                else
                {
                    for (double k = y; k < y + max; k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
            }
            return repeats;
        }
        private void MiniIsland(Point position, int size)
        {
            for (int i = -size / 2; i < size / 2; ++i)
            {
                int repY = (size / 2) - (Math.Abs(i));
                int offset = repY / 5;
                repY += WorldGen.genRand.Next(4);
                for (int j = -offset; j < repY; ++j)
                {
                    WorldGen.PlaceTile(position.X + i, position.Y + j, mod.TileType<Doomstone>());
                }
                int y = Raycast((int)position.X + i, (int)position.Y - 5);
                WorldGen.PlaceObject((int)position.X + i, y, mod.TileType("OroborosTree"));
                WorldGen.GrowTree((int)position.X + i, y);
            }
        }
        
        public void VoidHouses(int X, int Y, int type = 30, int sizeX = 10, int sizeY = 7)
        {
            int wallID = (ushort)mod.WallType("DoomstoneBrickWall");
            //Clear area
            for (int i = X; i < X + sizeX - 1; ++i)
            {
                for (int j = Y - 1; j < Y + sizeY; ++j)
                {
                    WorldGen.KillTile(i, j);
                }
            }
            //Wall Placement
            for (int i = X + 1; i < X + sizeX - 2; ++i)
            {
                for (int j = Y + 1; j < Y + sizeY - 1; ++j)
                {
                    if (WorldGen.genRand.Next(5) >= 1)
                    {
                        WorldGen.KillWall(i, j);
                        WorldGen.PlaceWall(i, j, wallID);
                    }
                }
            }
            int chestType = 1;
            //Side placements
            for (int i = Y; i < Y + sizeY - 1; ++i)
            {
                WorldGen.PlaceTile(X, i, type);
                WorldGen.PlaceTile(X + (sizeX - 2), i, (ushort)mod.TileType("DoomstoneBrick"));
            }
            //Roof-floor placements
            for (int i = X; i < X + sizeX - 2; ++i)
            {
                WorldGen.PlaceTile(i, Y, type);
                WorldGen.PlaceTile(i, Y + (sizeY - 1), (ushort)mod.TileType("Doomstone"));
            }
            WorldGen.PlaceTile(X + sizeX - 2, Y + (sizeY) - 1, (ushort)mod.TileType("Doomstone"));
            //WorldGen.KillTile(X + sizeX - 1, Y + (sizeY));
            //WorldGen.PlaceTile(X + sizeX - 1, Y + (sizeY), TileID.MeteoriteBrick);
            if (chestType == 1)
            {
                WorldGen.PlaceChest(X + ((sizeX - 1) / 2), Y + sizeY - 2, (ushort)mod.TileType("OroborosChest"), true);
            }
            //Side holes
            for (int i = Y + sizeY - 4; i > Y + sizeY; --i)
                WorldGen.KillTile(X, i);
        }

        

        /*Point position = new Point(center.X + WorldGen.genRand.Next(-50, 50), center.Y + WorldGen.genRand.Next(-50, 50));
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Custom Mod Ores", delegate (GenerationProgress progress)
            {
                progress.Message = "00000000000000";
                                                                                                                                                                                                                                         
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)                                                                                                                                      
                {                                                                                                                                                                                                                      
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(5, 10), mod.TileType("AbyssiumOreTile"), false, 0f, 0f, false, true);
                }*/

        public override void PostUpdate()

        {

            if (downedGrips == true)
            {
                if (ChaosOres == false)
                {
                    ChaosOres = true;
                    Main.NewText("Chaos reigns in your world", Color.Indigo.R, Color.Indigo.G, Color.Indigo.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(7, 9), WorldGen.genRand.Next(10, 11), (ushort)mod.TileType("IncineriteOreTile"));
                    }
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(7, 9), WorldGen.genRand.Next(10, 11), (ushort)mod.TileType("AbyssiumOreTile"));
                    }
                }
            }

            if (NPC.downedMoonlord == true)
            {
                if (Luminite == false)
                {
                    Luminite = true;
                    Main.NewText("The Essence of the Moon Lord sparkles in the caves below", Color.DarkSeaGreen.R, Color.DarkSeaGreen.G, Color.DarkSeaGreen.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(6, 10), (ushort)mod.TileType("LuminiteOre"));
                    }
                }
                if (DarkMatter == false)
                {
                    DarkMatter = true;
                    Main.NewText("Darkness grows in the depths of the world", Color.DarkBlue.R, Color.DarkBlue.G, Color.DarkBlue.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(11, 12), (ushort)mod.TileType("DarkmatterOre"));
                    }
                }
                /*
                 public void OreComet()
        {
            int x = Main.rand.Next(0, Main.maxTilesX);
            int y = Main.worldSurface - 200;
            int[] tileIDs = { 6, 7, 8, 9 , 166, 167, 168, 169};
            if (Main.tile[x, y].type <= -1)
            {
                y--;
            }
            else
            {
                WorldGen.TileRunner(x, y, 2, 4, tileIDs[Main.rand.Next(tileIDs.Length)], false, 0f, 0f, true, true);
                return;
            }
        }
                 */
                 
                if (RadiumOre == false)
                {
                    RadiumOre = true;
                    Main.NewText("Stars twinkle in the atmosphere", Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B);
                    for (int i = 0; i < Main.maxTilesX / 28; ++i) //Repeats 700 times for small world, 1050 times for medium world, and 1400 times for large world.
                    {
                        int X = WorldGen.genRand.Next(50, (Main.maxTilesX / 10) * 9); //X position, centre.
                        int Y = WorldGen.genRand.Next(80); //Y position, centre.
                        int radius = WorldGen.genRand.Next(2, 5); //Radius.
                        for (int x = X - radius; x <= X + radius; x++)
                            for (int y = Y - radius; y <= Y + radius; y++)
                                if (Vector2.Distance(new Vector2(X, Y), new Vector2(x, y)) <= radius) //Checks if coords are within a circle position
                                    WorldGen.PlaceTile(x, y, mod.TileType<RadiumOre>(), true); //Places tile of type InsertTypeHere at the specified coords
                    }
                }
            }
            if (NPC.downedMechBossAny == true)
            {
                if (HallowedOre == false)
                {
                    HallowedOre = true;
                    Main.NewText("The Caverns shine with the light of the radiant sun for a brief moment", Color.Yellow.R, Color.Yellow.G, Color.Yellow.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(10, 11), (ushort)mod.TileType("HallowedOreTile"));
                    }
                }
            }
            if (NPC.downedBoss3 == true)
            {
                if (Dynaskull == false)
                {
                    Dynaskull = true;
                    Main.NewText("The bones of the ancient past burst with energy", Color.DarkOrange.R, Color.DarkOrange.G, Color.DarkOrange.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(7, 9), WorldGen.genRand.Next(10, 11), (ushort)mod.TileType("DynaskullOre"));
                    }
                }
            }
            if (NPC.downedPlantBoss == true)
            {
                if (Evil == false)
                {
                    Evil = true;
                    Main.NewText("Devils in the underworld begin to plot", Color.Purple.R, Color.Purple.G, Color.Purple.B);
                }
            }
            if (downedRetriever == true)
            {
                if (FulguriteOre == false)
                {
                    FulguriteOre = true;
                    Main.NewText("The sound of a thunderbolt roars in the caverns", Color.MediumPurple.R, Color.MediumPurple.G, Color.MediumPurple.B);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(10, 11), (ushort)mod.TileType("FulguriteOre"));
                    }
                }
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            mireTiles = tileCounts[mod.TileType("MireGrassTile")]+ tileCounts[mod.TileType("DepthstoneTile")];
            infernoTiles = tileCounts[mod.TileType("InfernoGrassTile")]+ tileCounts[mod.TileType("TorchstoneTile")];
            voidTiles = tileCounts[mod.TileType("Doomstone")] + tileCounts[mod.TileType("Apocalyptite")];
        }
    }
}