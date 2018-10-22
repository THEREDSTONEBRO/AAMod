using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Ranged
{
    public class TheVulcano : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetDefaults()
        {

            item.damage = 44;
            item.noMelee = true;

            item.ranged = true;
            item.width = 58;
            item.height = 24;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 85;
            item.knockBack = 0;
            item.value = 10;
            item.rare = 5;
            item.UseSound = SoundID.Item34;
            item.autoReuse = false;
            item.shootSpeed = 14f;
            item.glowMask = customGlowMask;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Vulcan");
            Tooltip.SetDefault("Doesnt use ammo");
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Ranged/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 40);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
