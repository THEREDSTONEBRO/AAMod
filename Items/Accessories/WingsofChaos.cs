using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class WingsofChaos : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Wings of Chaos");
            Tooltip.SetDefault("The Wings of an ancient Dragon god, sealed away by the hero of legend");
		}

		public override void SetDefaults()
		{
			item.width = 56;
			item.height = 28;
			item.value = 50000000;
			item.rare = 9;
			item.accessory = true;
            item.expert = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 600;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 12f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AbyssiumBar", 30);
            recipe.AddIngredient(null, "IncineriteBar", 30);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}