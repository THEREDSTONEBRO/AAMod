using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class MireProj : ModProjectile
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            projectile.glowMask = customGlowMask;
            DisplayName.SetDefault("MireProj (Incomplete)");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override string Texture
        {
            get
            {
                return "AAmod/Items/Usable/MireInsignia";
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Shatter, (int)position.X, (int)position.Y);

            int radius = 100;
            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X + projectile.direction * 36, projectile.Center.Y + 12, 0, 0, mod.ProjectileType("IndigoSolution"), 0, 0f); //, Main.myPlayer, 0f, 0f
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        int type = Main.tile[x, y].type;
                        int wall = Main.tile[x, y].wall;
                        if (wall != 0)
                            if (wall == 15)
                        {
                            Main.tile[x, y].wall = (ushort)mod.WallType("DepthstoneWall");
                            WorldGen.SquareWallFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        if (wall == 63)
                        {
                            Main.tile[x, y].wall = (ushort)mod.WallType("MireGrassWall");
                            WorldGen.SquareWallFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (wall == 64)
                        {
                            Main.tile[x, y].wall = (ushort)mod.WallType("MireJungleWall");
                            WorldGen.SquareWallFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        if (type == 2 && Main.tile[x, y].active())
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("DepthstoneTile");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        else if (type == 60)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("MireGrass");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 61)
                        {
                            Main.tile[x, y].type = 0;
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 62)
                        {
                            Main.tile[x, y].type = 0;
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 74)
                        {
                            Main.tile[x, y].type = 0;
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 383)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("LivingBogwood");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        else if (type == 384)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("LivingBogwoodLeaves");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                }
            }
        }
    }
}