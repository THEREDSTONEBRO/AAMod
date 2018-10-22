using System.Collections.Generic;
using AAMod.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

/*namespace AAMod.Items.Projectiles
{
    public class Fog : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hide = false;
            projectile.timeLeft = 600;
            projectile.alpha = 0;
            projectile.width = 2048;
            projectile.height = 2048;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (projectile.Center != player.Center)
            {
                projectile.Center = player.Center;
            }
            if (Main.myPlayer != projectile.owner)
            {
                projectile.hide = true;
            }
            if (!player.GetModPlayer<AAPlayer>().ZoneMire)
            {
                player.ClearBuff(mod.BuffType<Clueless>());
                projectile.Kill();
            }
            if (player.GetModPlayer<AAPlayer>().ZoneMire)
            {
                player.AddBuff(mod.BuffType<Clueless>(), 600);
                player.GetModPlayer<AAPlayer>().Blackend = true;
            }
            if (projectile.timeLeft == 10)
            {
                projectile.timeLeft = 600;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(mod.GetTexture("Items/Projectiles/Fog"), projectile.getRect(), null, Color.White, 0f, projectile.Center, SpriteEffects.None, 10);
        }
    }
}*/
