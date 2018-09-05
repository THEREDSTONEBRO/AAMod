using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Materials
{
    public class Kazoo : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 42;
            item.height = 16;
			item.maxStack = 99;
			
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kazoo");
            Tooltip.SetDefault("Doot");
        }

        public override void AddRecipes()
        {
            {                                                   //How to craft this item
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 5);              //example of how to craft with a modded item
                recipe.AddTile(TileID.Furnaces);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            {                                                   //How to craft this item
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 5);              //example of how to craft with a modded item
                recipe.AddTile(TileID.Furnaces);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
