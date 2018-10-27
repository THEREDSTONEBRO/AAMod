using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
    public class Dawnstrike : ModItem
    {
        public static short customGlowMask = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dawnstrike");
            Tooltip.SetDefault("Shoots a piercing blaze of fire");
            if (Main.netMode != 2)
            {
                Microsoft.Xna.Framework.Graphics.Texture2D[] glowMasks = new Microsoft.Xna.Framework.Graphics.Texture2D[Main.glowMaskTexture.Length + 1];
                for (int i = 0; i < Main.glowMaskTexture.Length; i++)
                {
                    glowMasks[i] = Main.glowMaskTexture[i];
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Boss/Akuma/" + GetType().Name + "_Glow");
                customGlowMask = (short)(glowMasks.Length - 1);
                Main.glowMaskTexture = glowMasks;
            }
        }

        public override void SetDefaults()
        {

            item.damage = 230;
            item.noMelee = true;
            item.ranged = true;
            item.width = 64;
            item.height = 46;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("Dawnstrike");
            item.knockBack = 0;
            item.value = 10;
            item.rare = 0;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 14f;
            item.glowMask = customGlowMask;

        }

        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DaybreakIncinerite", 5);
            recipe.AddIngredient(null, "CrucibleScale", 5);
            recipe.AddIngredient(null, "TheVulcano");
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
