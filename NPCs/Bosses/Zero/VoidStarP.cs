using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace AAMod.NPCs.Bosses.Zero
{
    // to investigate: Projectile.Damage, (8843)
    class VoidStarP : ModProjectile
    {
        public override void SetDefaults()
        {
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            projectile.CloneDefaults(ProjectileID.VortexVortexLightning);
            projectile.width = 60;
            projectile.height = 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.aiStyle = 108;
            projectile.alpha = 100;
            projectile.ignoreWater = true;
            projectile.Name = "Void Storm";
        }

        public override void AI()
        {
            Vector2 vector111 = projectile.ai[1].ToRotationVector2();
            Vector2 value60 = vector111.RotatedBy(1.5707963705062866, default(Vector2)) * (float)(Main.rand.Next(2) == 0).ToDirectionInt() * (float)Main.rand.Next(10, 21);
            vector111 *= (float)Main.rand.Next(-80, 81);
            Vector2 vector112 = vector111 - value60;
            vector112 /= 10f;
            int num949 = Utils.SelectRandom<int>(Main.rand, new int[]
            {
                                                                                                        229,
                                                                                                        229
            });
            Dust dust18 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, num949, 0f, 0f, 0, Color.Black, 1f)];
            dust18.noGravity = true;
            dust18.position = projectile.Center + value60;
            dust18.velocity = vector112;
            dust18.scale = 0.5f + Main.rand.NextFloat();
            dust18.fadeIn = 0.5f;
            if (projectile.ai[0] == 90f && Main.netMode != 1)
            {
                Vector2 vector113 = projectile.ai[1].ToRotationVector2() * 8f;
                float ai2 = (float)Main.rand.Next(80);
                Projectile.NewProjectile(projectile.Center.X - vector113.X, projectile.Center.Y - vector113.Y, vector113.X, vector113.Y, mod.ProjectileType<DarkShock>(), 15, 1f, Main.myPlayer, projectile.ai[1], ai2);
                return;
            }
        }
    }

    class DarkShock : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.VortexLightning);
            projectile.Name = "Dark Shock";
        }

        public override void AI()
        {
            if (projectile.localAI[1] == 0f && projectile.ai[0] >= 900f)
            {
                projectile.ai[0] -= 1000f;
                projectile.localAI[1] = -1f;
            }
            projectile.frameCounter++;
            Lighting.AddLight(projectile.Center, 0.5f, 0f, 0f);
            if (projectile.velocity == Vector2.Zero)
            {
                if (projectile.frameCounter >= projectile.extraUpdates * 2)
                {
                    projectile.frameCounter = 0;
                    bool flag37 = true;
                    for (int num858 = 1; num858 < projectile.oldPos.Length; num858++)
                    {
                        if (projectile.oldPos[num858] != projectile.oldPos[0])
                        {
                            flag37 = false;
                        }
                    }
                    if (flag37)
                    {
                        projectile.Kill();
                        return;
                    }
                }
                if (Main.rand.Next(projectile.extraUpdates) == 0 && (projectile.velocity != Vector2.Zero || Main.rand.Next((projectile.localAI[1] == 2f) ? 2 : 6) == 0))
                {
                    for (int num859 = 0; num859 < 2; num859++)
                    {
                        float num860 = projectile.rotation + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
                        float num861 = (float)Main.rand.NextDouble() * 0.8f + 1f;
                        Vector2 vector86 = new Vector2((float)Math.Cos((double)num860) * num861, (float)Math.Sin((double)num860) * num861);
                        int num862 = Dust.NewDust(projectile.Center, 0, 0, 226, vector86.X, vector86.Y, 0, Color.Black, 1f);
                        Main.dust[num862].noGravity = true;
                        Main.dust[num862].scale = 1.2f;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        Vector2 value50 = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
                        int num863 = Dust.NewDust(projectile.Center + value50 - Vector2.One * 4f, 8, 8, 31, 0f, 0f, 100, Color.Black, 1.5f);
                        Main.dust[num863].velocity *= 0.5f;
                        Main.dust[num863].velocity.Y = -Math.Abs(Main.dust[num863].velocity.Y);
                        return;
                    }
                }
            }
            else if (projectile.frameCounter >= projectile.extraUpdates * 2)
            {
                projectile.frameCounter = 0;
                float num864 = projectile.velocity.Length();
                UnifiedRandom unifiedRandom2 = new UnifiedRandom((int)projectile.ai[1]);
                int num865 = 0;
                Vector2 spinningpoint3 = -Vector2.UnitY;
                Vector2 vector87;
                do
                {
                    int num866 = unifiedRandom2.Next();
                    projectile.ai[1] = (float)num866;
                    num866 %= 100;
                    float f2 = (float)num866 / 100f * 6.28318548f;
                    vector87 = f2.ToRotationVector2();
                    if (vector87.Y > 0f)
                    {
                        vector87.Y *= -1f;
                    }
                    bool flag38 = false;
                    if (vector87.Y > -0.02f)
                    {
                        flag38 = true;
                    }
                    if (vector87.X * (float)(projectile.extraUpdates + 1) * 2f * num864 + projectile.localAI[0] > 40f)
                    {
                        flag38 = true;
                    }
                    if (vector87.X * (float)(projectile.extraUpdates + 1) * 2f * num864 + projectile.localAI[0] < -40f)
                    {
                        flag38 = true;
                    }
                    if (!flag38)
                    {
                        goto IL_2361B;
                    }
                }
                while (num865++ < 100);
                projectile.velocity = Vector2.Zero;
                if (projectile.localAI[1] < 1f)
                {
                    projectile.localAI[1] += 2f;
                    goto IL_23623;
                }
                goto IL_23623;
                IL_2361B:
                spinningpoint3 = vector87;
                IL_23623:
                if (projectile.velocity != Vector2.Zero)
                {
                    projectile.localAI[0] += spinningpoint3.X * (float)(projectile.extraUpdates + 1) * 2f * num864;
                    projectile.velocity = spinningpoint3.RotatedBy((double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num864;
                    projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
                    if (Main.rand.Next(4) == 0 && Main.netMode != 1 && projectile.localAI[1] == 0f)
                    {
                        float num867 = (float)Main.rand.Next(-3, 4) * 1.04719758f / 3f;
                        Vector2 vector88 = projectile.ai[0].ToRotationVector2().RotatedBy((double)num867, default(Vector2)) * projectile.velocity.Length();
                        if (!Collision.CanHitLine(projectile.Center, 0, 0, projectile.Center + vector88 * 50f, 0, 0))
                        {
                            Projectile.NewProjectile(projectile.Center.X - vector88.X, projectile.Center.Y - vector88.Y, vector88.X, vector88.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, vector88.ToRotation() + 1000f, projectile.ai[1]);
                            return;
                        }
                    }
                }
            }
        }
    }
}
