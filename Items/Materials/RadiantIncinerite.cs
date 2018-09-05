using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Materials
{
    public class RadiantIncinerite : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
			item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.rare = 2;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("RadiantIncinerite");
			
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Incinerite Bar");
            Tooltip.SetDefault("You can barely look at it, it's so bright");
        }

		public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 2);
            recipe.AddIngredient(null, "Incinerite", 1);              //example of how to craft with a modded item
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
