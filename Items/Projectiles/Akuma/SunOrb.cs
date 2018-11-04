using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
	public class SunOrb : ModProjectile
	{
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/Akuma/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
            projectile.glowMask = customGlowMask;
            DisplayName.SetDefault("Sun Portal");    //The recording mode
		}

		public override void SetDefaults()
		{
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 0;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.sentry = true;
        }

        

        public override void AI()
        {
            float num1058 = 1000f;
            projectile.velocity = Vector2.Zero;
            
                projectile.alpha -= 5;
            if (projectile.alpha < 0)
            {
                    projectile.alpha = 0;
            }
            if (projectile.direction == 0)
            {
                    projectile.direction = Main.player[projectile.owner].direction;
            }
            projectile.rotation -= (float)projectile.direction * 6.28318548f / 120f;
            projectile.scale = projectile.Opacity;
            Lighting.AddLight(projectile.Center, new Vector3(0.3f, 0.9f, 0.7f) * projectile.Opacity);
            if (Main.rand.Next(2) == 0)
            {
                Vector2 vector135 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                Dust dust31 = Main.dust[Dust.NewDust(projectile.Center - vector135 * 30f, 0, 0, 229, 0f, 0f, 0, default(Color), 1f)];
                dust31.noGravity = true;
                dust31.position = projectile.Center - vector135 * (float)Main.rand.Next(10, 21);
                dust31.velocity = vector135.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                dust31.scale = 0.5f + Main.rand.NextFloat();
                dust31.fadeIn = 0.5f;
                dust31.customData = projectile.Center;
            }
            if (Main.rand.Next(2) == 0)
            {
                Vector2 vector136 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                Dust dust32 = Main.dust[Dust.NewDust(projectile.Center - vector136 * 30f, 0, 0, 240, 0f, 0f, 0, default(Color), 1f)];
                dust32.noGravity = true;
                dust32.position = projectile.Center - vector136 * 30f;
                dust32.velocity = vector136.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
                dust32.scale = 0.5f + Main.rand.NextFloat();
                dust32.fadeIn = 0.5f;
                dust32.customData = projectile.Center;
            }
            if (projectile.ai[0] < 0f)
            {
                Vector2 center15 = projectile.Center;
                int num1059 = Dust.NewDust(center15 - Vector2.One * 8f, 16, 16, 229, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 1f);
                Main.dust[num1059].velocity *= 2f;
                Main.dust[num1059].noGravity = true;
                Main.dust[num1059].scale = Utils.SelectRandom<float>(Main.rand, new float[]
                {
                    0.8f,
                    1.65f
                });
                Main.dust[num1059].customData = this;
            }
            if (projectile.ai[0] < 0f)
            {
                projectile.ai[0] += 1f;
                
                    projectile.ai[1] -= (float)projectile.direction * 0.3926991f / 50f;
                
            }
            if (projectile.ai[0] == 0f)
            {
                int num1060 = -1;
                float num1061 = num1058;
                NPC ownerMinionAttackTargetNPC6 = projectile.OwnerMinionAttackTargetNPC;
                if (ownerMinionAttackTargetNPC6 != null && ownerMinionAttackTargetNPC6.CanBeChasedBy(this, false))
                {
                    float num1062 = projectile.Distance(ownerMinionAttackTargetNPC6.Center);
                    if (num1062 < num1061 && Collision.CanHitLine(projectile.Center, 0, 0, ownerMinionAttackTargetNPC6.Center, 0, 0))
                    {
                        num1061 = num1062;
                        num1060 = ownerMinionAttackTargetNPC6.whoAmI;
                    }
                }
                if (num1060 < 0)
                {
                    for (int num1063 = 0; num1063 < 200; num1063++)
                    {
                        NPC nPC15 = Main.npc[num1063];
                        if (nPC15.CanBeChasedBy(this, false))
                        {
                            float num1064 = projectile.Distance(nPC15.Center);
                            if (num1064 < num1061 && Collision.CanHitLine(projectile.Center, 0, 0, nPC15.Center, 0, 0))
                            {
                                num1061 = num1064;
                                num1060 = num1063;
                            }
                        }
                    }
                }
                if (num1060 != -1)
                {
                    projectile.ai[0] = 1f;
                    projectile.ai[1] = (float)num1060;
                    projectile.netUpdate = true;
                    return;
                }
            }
            if (projectile.ai[0] > 0f)
            {
                int num1065 = (int)projectile.ai[1];
                if (!Main.npc[num1065].CanBeChasedBy(this, false))
                {
                    projectile.ai[0] = 0f;
                    projectile.ai[1] = 0f;
                    projectile.netUpdate = true;
                    return;
                }
                projectile.ai[0] += 1f;
                float num1066 = 30f;
                if (projectile.ai[0] >= num1066)
                {
                    Vector2 vector137 = projectile.DirectionTo(Main.npc[num1065].Center);
                    if (vector137.HasNaNs())
                    {
                        vector137 = Vector2.UnitY;
                    }
                    float num1067 = vector137.ToRotation();
                    int num1068 = (vector137.X > 0f) ? 1 : -1;
                    projectile.direction = num1068;
                    projectile.ai[0] = -60f;
                    projectile.ai[1] = num1067 + (float)num1068 * 3.14159274f / 16f;
                    projectile.netUpdate = true;
                    if (projectile.owner == Main.myPlayer)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector137.X, vector137.Y, mod.ProjectileType("Sunray"), projectile.damage, projectile.knockBack, projectile.owner, 0f, (float)projectile.whoAmI);
                    }
                    
                }
            }
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Projectile projectile = Main.projectile[i];
            main.LoadProjectile(projectile.type);
            SpriteEffects spriteEffects = SpriteEffects.None;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
            if (projectile.hide && !ProjectileID.Sets.DontAttachHideToAlpha[projectile.type])
            {
                color25 = Lighting.GetColor((int)mountedCenter.X / 16, (int)(mountedCenter.Y / 16f));
            }
            Vector2 vector38 = projectile.position + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
            Texture2D texture2D30 = Main.projectileTexture[projectile.type];
            Color alpha4 = projectile.GetAlpha(color25);
            Vector2 origin8 = new Vector2((float)texture2D30.Width, (float)texture2D30.Height) / 2f;

            Color color55 = alpha4 * 0.8f;
            color55.A /= 2;
            Color color56 = Color.Lerp(alpha4, Color.Black, 0.5f);
            color56.A = alpha4.A;
            float num274 = 0.95f + (projectile.rotation * 0.75f).ToRotationVector2().Y * 0.1f;
            color56 *= num274;
            float scale12 = 0.6f + projectile.scale * 0.6f * num274;
            Main.spriteBatch.Draw(Main.extraTexture[50], vector38, null, color56, -projectile.rotation + 0.35f, origin8, scale12, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
            Main.spriteBatch.Draw(Main.extraTexture[50], vector38, null, alpha4, -projectile.rotation, origin8, projectile.scale, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
            Main.spriteBatch.Draw(texture2D30, vector38, null, color55, -projectile.rotation * 0.7f, origin8, projectile.scale, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
            Main.spriteBatch.Draw(Main.extraTexture[50], vector38, null, alpha4 * 0.8f, projectile.rotation * 0.5f, origin8, projectile.scale * 0.9f, spriteEffects, 0f);
            alpha4.A = 0;
            Main.spriteBatch.Draw(texture2D30, vector38, null, alpha4, projectile.rotation, origin8, projectile.scale, spriteEffects, 0f);
        }*/
    }
}
