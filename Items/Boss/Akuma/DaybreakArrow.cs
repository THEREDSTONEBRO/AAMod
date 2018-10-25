using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Akuma
{
	public class DaybreakArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Daybreak Arrow");
			Tooltip.SetDefault(@"Scorches its target with the heat of the scorching sun
Inflicts Daybroken");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 14;
			item.height = 40;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 7f;
			item.value = 100;
			item.rare = 6;
			item.shoot = mod.ProjectileType("DaybreakArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 1.5f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 100);
            recipe.AddIngredient(null, "DaybreakIncinerite", 1);
			recipe.AddTile(null, "BinaryReassembler");
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
