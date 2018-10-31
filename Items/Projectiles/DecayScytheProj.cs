using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Projectiles
{
    class DecayScytheProj : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DeathSickle);
            projectile.tileCollide = false;
            projectile.alpha = 40;
        }

        public void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Melee/DecayScytheProj");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    projectile.position.X - Main.screenPosition.X + (projectile.width * 0.5f),
                    projectile.position.Y - Main.screenPosition.Y + projectile.height - (texture.Height * 0.5f) + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                new Color(Main.DiscoR, 255, 0),
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 1000);
            target.AddBuff(BuffID.CursedInferno, 1000);
        }

    }
}