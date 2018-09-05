using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    public class AmphibiousProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Meowmere);
            projectile.penetrate = 1;  
            projectile.width = 28;
            projectile.height = 26;
			projectile.friendly = true;
			projectile.hostile = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mudkipz");
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0) // this is how many duspt particles will spawn
            {// DustID.Fire is a vanilla terrraria dust, change it to what you like. To add a modded dust the change DustID.Fire with mod.DustType("DustName")
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 186, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }


    }
}
