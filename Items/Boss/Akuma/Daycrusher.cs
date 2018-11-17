using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
    public class Daycrusher : ModItem
    {
        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
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
            item.glowMask = customGlowMask;
            DisplayName.SetDefault("Daycrusher");
            Tooltip.SetDefault(@"Slams into foes with the force of a solar mass
Inflicts Daybroken");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(180, 41, 32);
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 44;
            item.value = Item.buyPrice(1, 0, 0, 0); ;
            item.rare = 1;

            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5F;
            item.damage = 240;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("Daycrusher");
            item.shootSpeed = 20F;
            item.UseSound = SoundID.Item20;
            item.melee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DaybreakIncinerite", 5);
            recipe.AddIngredient(null, "CrucibleScale", 5);
            recipe.AddIngredient(ItemID.Flairon, 1);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}