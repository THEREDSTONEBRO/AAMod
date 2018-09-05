using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class TrueCopperShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LightBeam);
            projectile.penetrate = 10;  
            projectile.width = 60;
            projectile.height = 60;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
            if (Main.rand.NextFloat() < 0.5010526f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 0, new Color(255, 0, 0), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 0, new Color(255, 176, 0), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 26, new Color(255, 251, 0), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 26, new Color(59, 255, 0), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 0, new Color(0, 167, 255), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 0, new Color(0, 17, 255), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 177, 0f, 0f, 0, new Color(134, 0, 255), 1.381579f)];
                dust.noGravity = true;
                dust.fadeIn = 1.421053f;
            }

        }

        public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Doom");
		}
	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 500);
        }
    }
}