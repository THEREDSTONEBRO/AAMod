using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Blocks
{
    public class DoomsdayPlating : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("DoomsdayPlating"); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doomsday Circuit Plating");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ApocalyptitePlate", 2);
            recipe.AddTile(null, "BinaryReassembler");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
