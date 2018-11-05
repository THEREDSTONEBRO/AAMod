using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Pets
{
	public class Sharkron : ModProjectile
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharkron"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 2;
			Main.projPet[projectile.type] = true;
        }

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
            projectile.width = 66;
            projectile.height = 56;
            projectile.glowMask = customGlowMask;
        }

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			AAPlayer modPlayer = player.GetModPlayer<AAPlayer>(mod);
			if (player.dead)
			{
				modPlayer.Sharkron = false;
			}
			if (modPlayer.Broodmini)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}