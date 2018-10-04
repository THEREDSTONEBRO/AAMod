using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System.Collections.Generic;

namespace AAMod.Items.Boss.Zero
{
    public class AMR : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti-matter Rifle");
            Tooltip.SetDefault(@"Fires an infinitely piercing laser that ignores tiles
Doesn't require ammo");
            if (Main.netMode != 2)
            {
                Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Boss/Zero/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }

        public override void SetDefaults()
        {
            item.glowMask = customGlowMask;
            item.damage = 300;
            item.noMelee = true;
            item.ranged = true;
            item.width = 74;
            item.height = 24;
            item.useTime = 26;
            item.useAnimation = 26; 
            item.useStyle = 5; 
            item.shoot = mod.ProjectileType("Antimatter");
            item.knockBack = 12;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = 9;
            item.UseSound = new LegacySoundStyle(2, 75, Terraria.Audio.SoundType.Sound);
            item.autoReuse = true; 
            item.shootSpeed = 40f; 
            item.crit = 5; 
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
    }
}