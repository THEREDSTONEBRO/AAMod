using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Dev
{
    internal class LemonJuice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lemon Juice");
            Tooltip.SetDefault("Made with 100% pure lemon juice!");
        }

        public override void SetDefaults()
        {
            item.rare = 7;
            item.buffTime = 3000;
            item.buffType = 69;
            item.consumable = true;
            item.height = 64;
            item.width = 64;
            item.value = 300000;
            item.maxStack = 9999;
            item.ammo = item.type;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(255, 212, 58);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.AddIngredient(ItemID.Ichor, 10);
            recipe.AddIngredient(mod.ItemType<SauceContainer>(), 1);
            recipe.AddTile(TileID.MythrilAnvil); // (null, "ModTileID");
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
        //faster bullet, enemy armor down
    }
}