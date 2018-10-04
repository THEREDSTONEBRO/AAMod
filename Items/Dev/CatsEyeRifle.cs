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
    public class CatsEyeRifle : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cat's Eye Rifle");
            Tooltip.SetDefault(@"Fires Shadow bolts
Doesn't require ammo
'QUICK HIDE THE LOLI STASH'
-Liz");
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
            item.damage = 530; //This is the amount of damage the item does
            item.noMelee = true; //This makes sure the bow doesn't do melee damage
            item.ranged = true; //This causes your bow to do ranged damage
            item.width = 72; //Hitbox width
            item.height = 22; //Hitbox height
            item.useTime = 30; //How long it takes to use the weapon. If this is shorter than the useAnimation it will fire twice in one click.
            item.useAnimation = 30;  //The animations time length
            item.useStyle = 5; //The style in which the item gets used. 5 for bows.
            item.shoot = ProjectileID.BlackBolt;
            item.knockBack = 12; //The amount of knockback the item has
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = 9; //The item's name color
            item.UseSound = new LegacySoundStyle(2, 40, Terraria.Audio.SoundType.Sound);
            item.autoReuse = true; //if the Bow autoreuses or not
            item.shootSpeed = 40f; //The arrows speed when shot
            item.crit = 0; //Crit chance
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(121, 21, 214);
                }
            }
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
    }
}