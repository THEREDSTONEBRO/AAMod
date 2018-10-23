﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace AAMod.Items.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	class Rift : ModProjectile
	{
		public override void SetDefaults()
		{
            
            projectile.width = 64;
            projectile.height = 64;
            projectile.alpha = 100;
            projectile.light = 0.2f;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.tileCollide = false;
            projectile.scale = 0.9f;
            projectile.melee = true;
            projectile.timeLeft = 300;

        }
        public override void AI()
        {
            float num472 = projectile.Center.X;
            float num473 = projectile.Center.Y;
            float num474 = 400f;
            bool flag17 = false;
            for (int num475 = 0; num475 < 200; num475++)
            {
                if (Main.npc[num475].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num475].Center, 1, 1))
                {
                    float num476 = Main.npc[num475].position.X + (float)(Main.npc[num475].width / 2);
                    float num477 = Main.npc[num475].position.Y + (float)(Main.npc[num475].height / 2);
                    float num478 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num476) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num477);
                    if (num478 < num474)
                    {
                        num474 = num478;
                        num472 = num476;
                        num473 = num477;
                        flag17 = true;
                    }
                }
            }
            if (flag17)
            {
                float num483 = 20f;
                Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num484 = num472 - vector35.X;
                float num485 = num473 - vector35.Y;
                float num486 = (float)Math.Sqrt((double)(num484 * num484 + num485 * num485));
                num486 = num483 / num486;
                num484 *= num486;
                num485 *= num486;
                projectile.velocity.X = (projectile.velocity.X * 20f + num484) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + num485) / 21f;
                if (projectile.ai[1] == 0f && projectile.type == 44)
                {
                    projectile.ai[1] = 1f;
                    Main.PlaySound(SoundID.Item8, projectile.position);
                }
                if (projectile.type != 263 && projectile.type != 274)
                {
                    projectile.rotation += projectile.direction * 0.8f;
                    projectile.ai[0] += 1f;
                    if (projectile.ai[0] >= 30f)
                    {
                        if (projectile.ai[0] < 100f)
                        {
                            projectile.velocity *= 1.06f;
                        }
                        else
                        {
                            projectile.ai[0] = 200f;
                        }
                    }
                    for (int num257 = 0; num257 < 2; num257++)
                    {
                        int num258 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<Dusts.VoidDust>(), 0f, 0f, 100, new Color(120, 0, 30), 1f);
                        Main.dust[num258].noGravity = true;
                    }
                    return;
                }
                if (projectile.type == 274 && projectile.velocity.X < 0f)
                {
                    projectile.spriteDirection = -1;
                }
                projectile.rotation += projectile.direction * 0.05f;
                projectile.rotation += projectile.direction * 0.5f * (projectile.timeLeft / 180f);
                if (projectile.type == 274)
                {
                    projectile.velocity *= 0.96f;
                    return;
                }
                projectile.velocity *= 0.95f;
                return;
            }
            if (projectile.ai[1] == 0f && projectile.type == 44)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item8, projectile.position);
            }
            if (projectile.type != 263 && projectile.type != 274)
            {
                projectile.rotation += projectile.direction * 0.8f;
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    if (projectile.ai[0] < 100f)
                    {
                        projectile.velocity *= 1.06f;
                    }
                    else
                    {
                        projectile.ai[0] = 200f;
                    }
                }
                for (int num257 = 0; num257 < 2; num257++)
                {
                    int num258 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType<Dusts.VoidDust>(), 0f, 0f, 100, new Color(120, 0, 30), 1f);
                    Main.dust[num258].noGravity = true;
                }
                return;
            }
            if (projectile.type == 274 && projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
            }
            projectile.rotation += projectile.direction * 0.05f;
            projectile.rotation += projectile.direction * 0.5f * (projectile.timeLeft / 180f);
            if (projectile.type == 274)
            {
                projectile.velocity *= 0.96f;
                return;
            }
            projectile.velocity *= 0.95f;
            Lighting.AddLight(projectile.Center, (255 - projectile.alpha) * 0.6f / 255f, (255 - projectile.alpha) * 0f / 255f, (255 - projectile.alpha) * 0.1f / 255f);
            return;
            
        }
    }
}
