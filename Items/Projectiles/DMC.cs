using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
	public class DMC : ModProjectile
	{

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5;
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Projectiles/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }

            projectile.glowMask = customGlowMask;
            DisplayName.SetDefault("DMC");
        }


        public override void SetDefaults()
		{
            projectile.CloneDefaults(ItemID.PossessedHatchet);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
		}
    }
}
