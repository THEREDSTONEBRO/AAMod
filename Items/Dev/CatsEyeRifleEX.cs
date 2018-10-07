using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System.Collections.Generic;

namespace AAMod.Items.Dev
{
    public class CatsEyeRifleEX : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Silencer");
            Tooltip.SetDefault(@"Fires Shadow bolts
Doesn't require ammo
Cat's Eye Rifle EX");
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Dev/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }

        public override void SetDefaults()
        {
            item.glowMask = customGlowMask;
            item.damage = 730; 
            item.noMelee = true;
            item.ranged = true;
            item.width = 86; 
            item.height = 22; 
            item.useTime = 20; 
            item.useAnimation = 20;  
            item.useStyle = 5; 
            item.shoot = ProjectileID.BlackBolt;
            item.knockBack = 12; 
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.autoReuse = true; 
            item.shootSpeed = 50f; 
            item.crit = 5;
            item.expert = true;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Dev/CatsEyeRifle_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.Purple,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "CatsEyeRifle");
                recipe.AddIngredient(null, "EXSoul");
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
    }
}