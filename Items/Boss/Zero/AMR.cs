using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Zero
{
    class AMR : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 74;
            item.height = 24;
            DisplayName.SetDefault("Antimatter Rifle");
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.damage = 260;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = mod.ProjectileType<AMRProj>();
            Tooltip.SetDefault("Shoots a piercing laser that goes through tiles");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(120, 0, 30);
                }
            }
        }
    }

    class AMRProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            // NO! projectile.aiStyle = 48;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.extraUpdates = 100;
            projectile.timeLeft = 600; // lowered from 300
            projectile.penetrate = -1;
        }

        // Note, this Texture is actually just a blank texture, FYI.
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly; } }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false; // return false because we are handling collision
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.damage = (int)(projectile.damage * 1.5);
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    // Important, changed 173 to 178!
                    int dust = Dust.NewDust(projectilePosition, 1, 1, 178, 0f, 0f, 0, new Color(200, 0, 30), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
        }
    }
}
