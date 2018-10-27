using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
    public class Dawnstrike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.extraUpdates = 2;
            projectile.ranged = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dawnstrike");
        }

        public override void AI()
        {
            if (projectile.timeLeft > 100)
            {
                projectile.timeLeft = 100;
            }
            if (projectile.ai[0] > 7f)
            {
                float num296 = 1f;
                if (projectile.ai[0] == 8f)
                {
                    num296 = 0.25f;
                }
                else if (projectile.ai[0] == 9f)
                {
                    num296 = 0.5f;
                }
                else if (projectile.ai[0] == 10f)
                {
                    num296 = 0.75f;
                }
                projectile.ai[0] += 1f;
                int num297 = mod.DustType<Dusts.AkumaDust>();
                if (num297 == mod.DustType<Dusts.AkumaDust>() || Main.rand.Next(2) == 0)
                {
                    for (int num298 = 0; num298 < 1; num298++)
                    {
                        int num299 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num297, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (Main.rand.Next(3) != 0 || (num297 == mod.DustType<Dusts.AkumaADust>() && Main.rand.Next(3) == 0))
                        {
                            Main.dust[num299].noGravity = true;
                            Dust expr_DD5D_cp_0 = Main.dust[num299];
                            expr_DD5D_cp_0.velocity.X = expr_DD5D_cp_0.velocity.X * 2f;
                            Dust expr_DD7D_cp_0 = Main.dust[num299];
                            expr_DD7D_cp_0.velocity.Y = expr_DD7D_cp_0.velocity.Y * 2f;
                        }
                        if (projectile.type == mod.ProjectileType("Dawnstrike"))
                        {
                        }
                        Dust expr_DDE2_cp_0 = Main.dust[num299];
                        expr_DDE2_cp_0.velocity.X = expr_DDE2_cp_0.velocity.X * 1.2f;
                        Dust expr_DE02_cp_0 = Main.dust[num299];
                        expr_DE02_cp_0.velocity.Y = expr_DE02_cp_0.velocity.Y * 1.2f;
                        Main.dust[num299].scale *= num296;
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            return;
        }

    }
}
