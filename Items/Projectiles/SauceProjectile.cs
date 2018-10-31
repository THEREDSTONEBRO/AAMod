using AAMod.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class ChiliSauceBurst : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceRed"; } }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chili Sauce Burst");
		}
    	
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType<DragonFire>(), 900);
        }
    }
    public class WasabiBowlBurst : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceGreen"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wasabi Bowl Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 900);
        }
    }
    public class BlueberryJamBurst : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceBlue"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blueberry Jam Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.ai[0] != 1f)
            {
                Projectile.NewProjectile(projectile.position, -projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType<HydraToxin>(), 900);
        }
    }
    public class LemonJuiceBurst : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceYellow"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lemon Juice Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 900);
        }
    }
    public class ChiliSauceSpew : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chili Sauce Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            int num576 = mod.BuffType<DragonFire>();
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(255, 75, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
    public class WasabiBowlSpew : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wasabi Bowl Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            int num576 = BuffID.CursedInferno;
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(75, 255, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
    public class BlueberryJamSpew : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blueberry Jam Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            int num576 = mod.BuffType<HydraToxin>();
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(75, 75, 255, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.ai[0] != 1f)
            {
                Projectile.NewProjectile(projectile.position, -projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f);
            }
        }
    }
    public class LemonJuiceSpew : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lemon Juice Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            int num576 = BuffID.Ichor;
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(255, 255, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
    public class ChiliSauceBurstEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceRed"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chili Sauce Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.scale = 1.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType<DragonFire>(), 900);
        }
    }
    public class WasabiBowlBurstEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceGreen"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wasabi Bowl Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.scale = 1.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 900);
        }
    }
    public class BlueberryJamBurstEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceBlue"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blueberry Jam Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.scale = 1.5f;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.ai[0] != 1f)
            {
                Projectile.NewProjectile(projectile.position, -projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType<HydraToxin>(), 900);
        }
    }
    public class LemonJuiceBurstEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceYellow"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lemon Juice Burst");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.scale = 1.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 900);
        }
    }
    public class ChiliSauceSpewEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chili Sauce Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.scale = 5f;
        }

        public override void AI()
        {
            int num576 = mod.BuffType<DragonFire>();
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(255, 75, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].scale = 5f;
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].scale = 5f;
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
    public class WasabiBowlSpewEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wasabi Bowl Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.scale = 5f;
        }

        public override void AI()
        {
            int num576 = BuffID.CursedInferno;
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(75, 255, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].scale = 5f;
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].scale = 5f;
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
    public class BlueberryJamSpewEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blueberry Jam Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.scale = 5f;
        }

        public override void AI()
        {
            int num576 = mod.BuffType<HydraToxin>();
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(75, 75, 255, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].scale = 5f;
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].scale = 5f;
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.ai[0] != 1f)
            {
                Projectile.NewProjectile(projectile.position, -projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f);
            }
        }
    }
    public class LemonJuiceSpewEX : ModProjectile
    {
        public override string Texture { get { return "AAMod/Items/Projectiles/SauceProjectile"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lemon Juice Spew");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.scale = 5f;
        }

        public override void AI()
        {
            int num576 = BuffID.Ichor;
            if (projectile.owner == Main.myPlayer)
            {
                Rectangle rectangle4 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                for (int num577 = 0; num577 < 200; num577++)
                {
                    if (Main.npc[num577].active && !Main.npc[num577].dontTakeDamage && Main.npc[num577].lifeMax > 1)
                    {
                        Rectangle value12 = new Rectangle((int)Main.npc[num577].position.X, (int)Main.npc[num577].position.Y, Main.npc[num577].width, Main.npc[num577].height);
                        if (rectangle4.Intersects(value12))
                        {
                            Main.npc[num577].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
                for (int num578 = 0; num578 < 255; num578++)
                {
                    if (num578 != projectile.owner && Main.player[num578].active && !Main.player[num578].dead)
                    {
                        Rectangle value13 = new Rectangle((int)Main.player[num578].position.X, (int)Main.player[num578].position.Y, Main.player[num578].width, Main.player[num578].height);
                        if (rectangle4.Intersects(value13))
                        {
                            Main.player[num578].AddBuff(num576, 900, false);
                            projectile.Kill();
                        }
                    }
                }
            }
            int num587 = 0;
            Color newColor = new Color(255, 255, 75, 0);
            for (int num588 = 0; num588 < 6; num588++)
            {
                Vector2 vector42 = projectile.velocity * (float)num588 / 6f;
                int num589 = 6;
                int num590 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num589 * 2), projectile.height - (num589 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num590].scale = 5f;
                Main.dust[num590].noGravity = true;
                Main.dust[num590].velocity *= 0.3f;
                Main.dust[num590].velocity += projectile.velocity * 0.5f;
                Main.dust[num590].position = projectile.Center;
                Dust expr_18042_cp_0 = Main.dust[num590];
                expr_18042_cp_0.position.X = expr_18042_cp_0.position.X - vector42.X;
                Dust expr_18066_cp_0 = Main.dust[num590];
                expr_18066_cp_0.position.Y = expr_18066_cp_0.position.Y - vector42.Y;
                Main.dust[num590].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int num591 = 6;
                int num592 = Dust.NewDust(projectile.position + (Vector2.One * 6f), projectile.width - (num591 * 2), projectile.height - (num591 * 2), 4, 0f, 0f, num587, newColor, 1.2f);
                Main.dust[num592].scale = 5f;
                Main.dust[num592].velocity *= 0.5f;
                Main.dust[num592].velocity += projectile.velocity * 0.5f;
                return;
            }
        }
    }
}