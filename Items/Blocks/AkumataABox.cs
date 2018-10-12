using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace AAMod.Items.Blocks
{
	public class AkumataABox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumata Awakened Music Box");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("AkumataABox");
            item.width = 72;
			item.height = 36;
			item.rare = 4;
			item.value = 10000;
			item.accessory = true;
        }
        public override void AddRecipes()
        {
            if (Main.expertMode == true)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.MusicBox);
                recipe.AddIngredient(null, "AkumataBox");
                recipe.AddIngredient(null, "EXSoul");
                recipe.AddTile(ItemID.Sawmill);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
