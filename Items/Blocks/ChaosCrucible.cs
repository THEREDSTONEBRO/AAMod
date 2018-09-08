using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;

namespace AAMod.Items.Blocks
{
    public class ChaosCrucible : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Crucible");
            Tooltip.SetDefault("Even chaos requires a steady hand and a gigantic forge to work with");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.rare = 11;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 1000000;
            item.createTile = mod.TileType("ChaosCrucible");
        }
        public override void ModifyTooltips(List<TooltipLine> list)
    {
        foreach (TooltipLine line2 in list)
        {
            if (line2.mod == "Terraria" && line2.Name == "ItemName")
            {
                line2.overrideColor = new Color(Main.DiscoR, 0, Main.DiscoB);
            }
        }
    }

    public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "QuantumFusionAccelerator", 1);
                recipe.AddIngredient(null, "TruePaladinsSmeltery", 1);
                recipe.AddIngredient(null, "DeepAbyssium", 5);
                recipe.AddIngredient(null, "RadiantIncinerite", 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
