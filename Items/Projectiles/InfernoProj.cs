using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class InfernoProj : ModProjectile
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
            DisplayName.SetDefault("InfernoProj (Incomplete)");
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
                return "AAmod/Items/Usable/InfernoInsignia";
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
                Projectile.NewProjectile(projectile.Center.X + projectile.direction * 36, projectile.Center.Y + 12, 0, 0, mod.ProjectileType("OrangeSolution"), 0, 0f); //, Main.myPlayer, 0f, 0f
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
                        if (wall == 1)
                        {
                            Main.tile[x, y].wall = (ushort)mod.WallType("TorchstonestoneWall");
                            WorldGen.SquareWallFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (type == 2)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("InfernoGrass");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 1)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("Torchstone");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 191)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("LivingRazewood");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else if (type == 192)
                        {
                            Main.tile[x, y].type = (ushort)mod.TileType("LivingRazeleaves");
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                }
            }
        }
    }
}