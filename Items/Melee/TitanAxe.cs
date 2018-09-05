using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Melee
{
	public class TitanAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Titan Axe");
            Tooltip.SetDefault("Left clicking throws the axe for throwing damage \n" + "Right clicking swings the axe for melee damage \n" + "'Oof this isn't google' \n'" + "-Welox");
		}

		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.expert = true;
		}

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumAxe, 1);
                recipe.AddIngredient(ItemID.LightDisc, 5);
                recipe.AddIngredient(ItemID.LunarBar, 20);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldAxe, 1);
                recipe.AddIngredient(ItemID.LightDisc, 5);
                recipe.AddIngredient(ItemID.LunarBar, 20);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{

            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
                item.useTime = 26;
                item.useAnimation = 26;
                item.thrown = true;
                item.damage = 200;
                item.shoot = mod.ProjectileType("TitanAxe");
                item.shootSpeed = 12f;
                item.noMelee = true;
                item.noUseGraphic = true;
            }
            else
            {
                item.useStyle = 1;
                item.useTime = 26;
                item.useAnimation = 26;
                item.melee = true;
                item.shoot = 0;
                item.damage = 200;
                item.noMelee = false;
                item.noUseGraphic = false;
            }
            return base.CanUseItem(player);
		}
	}
}