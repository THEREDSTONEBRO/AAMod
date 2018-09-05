using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Tools
{
    public class DarkmatterPitchet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkmatter Pitchet");
		}


        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 54;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
		    item.pick = 235;
            item.axe = 200;

            item.damage = 60;
            item.knockBack = 4;

            item.useStyle = 1;
            item.useTime = 5;
            item.useAnimation = 19;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkMatter", 20);
            recipe.AddTile(null, "QuantumFusionAccelerator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}