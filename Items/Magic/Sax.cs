using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Magic
{
	public class Sax : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Number One Saxaphone");
            Tooltip.SetDefault(@"'Dream Big'
-Stefan Karl Stefansson");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 230;
			item.magic = true;
			item.mana = 8;
			item.width = 54;
			item.height = 80;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000000;
			item.rare = 11;
            item.expert = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Number1");
			item.shootSpeed = 7f;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "YairsGildedKazoo", 1);
            recipe.AddIngredient(ItemID.MagicalHarp, 1);
            recipe.AddIngredient(null, "RadiumBar", 5);
            recipe.AddRecipeGroup("AAMod:Gold", 32);
            recipe.AddTile(null, "QuantumFusionAccelerator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}