using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace AAMod.Items.Armor.MadTitan
{
    [AutoloadEquip(EquipType.Body)]
	public class MadTitanChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Mad Titan's Chestplate");
			Tooltip.SetDefault(@"40% increased damage
25% decreased ammo consumption");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.value = 3000000;
			item.rare = 11;
			item.defense = 38;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.40f;
            player.rangedDamage *= 1.40f;
            player.magicDamage *= 1.40f;
            player.minionDamage *= 1.40f;
            player.thrownDamage *= 1.40f;
            player.ammoCost75 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkmatterBreastplate", 1);
            recipe.AddIngredient(null, "RadiumPlatemail", 1);
            recipe.AddTile(null, "QuantumFusionAccelerator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}