using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class TrueFleshClaymoreShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.penetrate = 1;  
            projectile.width = 42;
            projectile.height = 48;
			projectile.friendly = true;
			projectile.hostile = false;
            projectile.timeLeft = 900;
        }
		
		public override void AI()
		{
			{
				projectile.rotation += projectile.direction * 0.25f;
				projectile.spriteDirection = projectile.direction;
			}	
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = projectile.position;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 57, 0f, 0f, 0, new Color(255,255,255), 2.105263f)];
				dust.noGravity = true;
				dust.fadeIn = 1.342105f;
			}
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = projectile.position;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 57, 0f, 0f, 0, new Color(255,255,255), 2.105263f)];
				dust.noGravity = true;
				dust.fadeIn = 1.342105f;
			}
			{
				Dust dust;
				Vector2 position = projectile.position;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 57, 0f, 0f, 0, new Color(255,255,255), 2.105263f)];
				dust.noGravity = true;
				dust.fadeIn = 1.342105f;
			}
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flesh Beam");
        }
        
	    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           target.AddBuff(BuffID.Ichor, 300);
        }

        public override bool? CanCutTiles()
        {
            return true;
        }
    }
}
