﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.Akuma
{
    internal class AkumaBreath : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Fury");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.hostile = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.alpha = 60;
            projectile.timeLeft = 60;
        }

        public override void AI()
        {
            if (projectile.ai[0] < 8f)
            {
                projectile.ai[0] = 8f;
            }
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
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
                if (Main.rand.Next(2) == 0)
                {
                    for (int num298 = 0; num298 < 1; num298++)
                    {
                        int num299 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("AkumaDust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (Main.rand.Next(3) != 0)
                        {
                            Main.dust[num299].noGravity = true;
                            Main.dust[num299].scale *= 3f;
                            Dust expr_DD5D_cp_0 = Main.dust[num299];
                            expr_DD5D_cp_0.velocity.X = expr_DD5D_cp_0.velocity.X * 2f;
                            Dust expr_DD7D_cp_0 = Main.dust[num299];
                            expr_DD7D_cp_0.velocity.Y = expr_DD7D_cp_0.velocity.Y * 2f;
                        }
                        Main.dust[num299].scale *= 1.25f;
                        Dust expr_DDE2_cp_0 = Main.dust[num299];
                        expr_DDE2_cp_0.velocity.X = expr_DDE2_cp_0.velocity.X * 1.2f;
                        Dust expr_DE02_cp_0 = Main.dust[num299];
                        expr_DE02_cp_0.velocity.Y = expr_DE02_cp_0.velocity.Y * 1.2f;
                        Main.dust[num299].scale *= num296;
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("DragonFire"), 600);
        }
    }
}