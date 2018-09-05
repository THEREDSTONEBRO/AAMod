using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Blocks
{
    public class QuantumFusionAccelerator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Fusion Accelerator");
            Tooltip.SetDefault(
@"Launching particles at the speed of sound
Allows you to work with DarkMatter and Radium");
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
            item.rare = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("QuantumFusionAccelerator");
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LunarCraftingStation, 1);
                recipe.AddIngredient(null, "DarkmatterOre", 30);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
