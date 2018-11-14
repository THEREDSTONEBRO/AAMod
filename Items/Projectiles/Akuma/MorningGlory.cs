using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles.Akuma
{
    public class MorningGlory : ModProjectile
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
            DisplayName.SetDefault("Morning Glory");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.hide = true;
            projectile.MaxUpdates = 2;
            projectile.glowMask = customGlowMask;
        }

        

 
        public override void AI()
        {
            if (projectile.ai[0] == 0f)
            {
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] >= 45f)
                    {
                        float num975 = 0.98f;
                        float num976 = 0.35f;
                        if (projectile.type == 636)
                        {
                            num975 = 0.995f;
                            num976 = 0.15f;
                        }
                        projectile.ai[1] = 45f;
                        projectile.velocity.X = projectile.velocity.X * num975;
                        projectile.velocity.Y = projectile.velocity.Y + num976;
                    }
                    projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            }
            if (projectile.ai[0] == 1f)
            {
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
                int num977 = 15;
                num977 = 5 * projectile.MaxUpdates;
                bool flag53 = false;
                bool flag54 = false;
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] % 30f == 0f)
                {
                    flag54 = true;
                }
                int num978 = (int)projectile.ai[1];
                if (projectile.localAI[0] >= (float)(60 * num977))
                {
                    flag53 = true;
                }
                else if (num978 < 0 || num978 >= 200)
                {
                    flag53 = true;
                }
                else if (Main.npc[num978].active && !Main.npc[num978].dontTakeDamage)
                {
                    projectile.Center = Main.npc[num978].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[num978].gfxOffY;
                    if (flag54)
                    {
                        Main.npc[num978].HitEffect(0, 1.0);
                    }
                }
                else
                {
                    flag53 = true;
                }
                if (flag53)
                {
                    projectile.Kill();
                }
                Lighting.AddLight(projectile.Center, 0, 191, 255);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 600);
        }
    }
}
