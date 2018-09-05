using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Materials
{
    public class FulguriteBar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
            item.rare = 4;
			
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fulgurite Bar");
            Tooltip.SetDefault("It's static-y");
        }

		public override void AddRecipes()
        {                                                   //How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FulguriteShard", 3);              //example of how to craft with a modded item
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
