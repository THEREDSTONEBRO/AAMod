using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class Apocalypse : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apocalypse");
            Main.projFrames[projectile.type] = 3;
        }
    	
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 55;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 0)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > 2)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
                projectile.rotation = (float)Math.Atan2((double)(-(double)projectile.velocity.Y), (double)(-(double)projectile.velocity.X));
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            }
            if (projectile.ai[0] >= 0f && projectile.ai[0] < 200f)
            {
                int num547 = (int)projectile.ai[0];
                if (Main.npc[num547].active && !Main.npc[num547].friendly)
                {
                    float num548 = 8f;
                    Vector2 vector40 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num549 = Main.npc[num547].position.X - vector40.X;
                    float num550 = Main.npc[num547].position.Y - vector40.Y;
                    float num551 = (float)Math.Sqrt((double)(num549 * num549 + num550 * num550));
                    num551 = num548 / num551;
                    num549 *= num551;
                    num550 *= num551;
                    projectile.velocity.X = (projectile.velocity.X * 14f + num549) / 15f;
                    projectile.velocity.Y = (projectile.velocity.Y * 14f + num550) / 15f;
                }
                else
                {
                    float num552 = 1000f;
                    for (int num553 = 0; num553 < 200; num553++)
                    {
                        if (Main.npc[num553].CanBeChasedBy(this, false) && !Main.npc[num553].friendly)
                        {
                            float num554 = Main.npc[num553].position.X + (float)(Main.npc[num553].width / 2);
                            float num555 = Main.npc[num553].position.Y + (float)(Main.npc[num553].height / 2);
                            float num556 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num554) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num555);
                            if (num556 < num552 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num553].position, Main.npc[num553].width, Main.npc[num553].height))
                            {
                                num552 = num556;
                                projectile.ai[0] = (float)num553;
                            }
                        }
                    }
                }
                int num557 = 8;
                int num558 = Dust.NewDust(new Vector2(projectile.position.X + (float)num557, projectile.position.Y + (float)num557), projectile.width - num557 * 2, projectile.height - num557 * 2, 6, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num558].velocity *= 0.5f;
                Main.dust[num558].velocity += projectile.velocity * 0.5f;
                Main.dust[num558].noGravity = true;
                Main.dust[num558].noLight = true;
                Main.dust[num558].scale = 1.4f;
                return;
            }
            projectile.Kill();
            return;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int num579 = 0; num579 < 20; num579++)
            {
                int num580 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num580].noGravity = true;
                Main.dust[num580].velocity *= 2f;
                num580 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                Main.dust[num580].velocity *= 2f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Wet, 600);
        }
    }
}